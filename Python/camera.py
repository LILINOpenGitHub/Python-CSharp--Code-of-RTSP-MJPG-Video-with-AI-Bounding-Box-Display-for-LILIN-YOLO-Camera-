import cv2
import time
import keyboard
import socket
import json
import base64
from jsonschema import validate

#video settings
s_username = 'admin'
s_password = 'Pass1234'
s_count = s_username + ':' + s_password
s_count_base64 = str((base64.b64encode(s_count.encode())).decode())
s_URL = '192.168.50.113'
i_ai_port = 8592
i_http_port = 80
i_rtsp_port = 554
i_rtsp_stream = 'stream3'
i_width = 352
i_height = 240
i_scaling = 2 # 2x
open_rtsp = True
recv_buffer_size = 8192 * 10

schema = {
   "AiEngine":[
      {
        
      }
   ],
   "counter_count":[
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0
   ],
   "something_vanish_in_zone1":"No",
   "something_vanish_in_zone2":"No",
   "something_vanish_in_zone3":"No",
   "something_vanish_in_zone4":"No",
   "Count":0
}

def OnMouseAction(event,x,y,flags,param):
    print("move windows")

def work_with_captured_video(camera, client_socket):
    global open_rtsp, schema
    while True:
        ret, frame = camera.read()
        if not ret:
            print("Camera is disconnected!")
            camera.release()
            break
        else:
            recv = client_socket.recv(recv_buffer_size)  #Specify buffer
            try:
                recv = recv.decode().split('\n')[5] #bounding box
                Json_data = json.loads(recv) #Get the JSON data from /getalarmmotion CGI
            except:
                print('ERROR : recv data incomplete pass\n')
                # print(recv)
                continue
            
            if validate(instance=Json_data, schema=schema): #Check JSON data format
                print('ERROR : Json data format error!\n')
                print(Json_data)
                break
            
            print(Json_data)

            if len(Json_data["AiEngine"]) != 0: #Find AiEngine token
                for j in range(len(Json_data["AiEngine"])): #Loop for display bouding box and plate
                    #Render the bonding box
                    i_x1 = int(int(Json_data["AiEngine"][j]["x"])*i_width/1920)
                    i_y1 = int(int(Json_data["AiEngine"][j]["y"])*i_height/1080)
                    i_x2 = i_x1 + int(int(Json_data["AiEngine"][j]["w"])*i_width/1920)
                    i_y2 = i_y1 + int(int(Json_data["AiEngine"][j]["h"])*i_width/1920)
                    
                    #Protect the width and hight
                    if i_x2 > i_width:
                        i_x2 = i_width
                    if i_y2 > i_height:
                        i_y2 = i_height
                    if i_y1 < 5:
                        i_y1 = 5

                    if "L._Plate" in Json_data["AiEngine"][j]["label_name"]:
                        i_label = str(Json_data["AiEngine"][j]["properties"]["plate"])
                        cv2.putText(frame,str(Json_data["AiEngine"][j]["properties"]["country"]) , (i_x1,i_y2+25), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 1, cv2.LINE_AA) #test_label
                    else:
                        i_label = str(Json_data["AiEngine"][j]["label_name"])
                    
                    cv2.putText(frame,i_label , (i_x1,i_y1-5), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 1, cv2.LINE_AA) #test_label

                    #Render the bounding box and plate
                    #cv2.rectangle( The frame, top-left, bottom-right, RGB color, width )
                    cv2.rectangle(frame, (i_x1, i_y1), (i_x2, i_y2), (0, 0, 255), 2)
                    
            print('---------------------------------------------')

            cv2.imshow('Capturing', frame)

        if cv2.waitKey(1) & 0xFF == ord('q'):
            open_rtsp = False
            break

        if keyboard.is_pressed('esc'):  # if key 'ESC' is pressed 
            open_rtsp = False
            break  # finishing the loop

    return True

while open_rtsp:
    #video
    cap = cv2.VideoCapture('rtsp://' + str(s_count) + '@' + str(s_URL) + ':' + str(i_rtsp_port) + '/' + str(i_rtsp_stream))
    cap.set(cv2.CAP_PROP_FRAME_WIDTH,i_width)  #Set streaming width and height
    cap.set(cv2.CAP_PROP_FRAME_HEIGHT,i_height)
    cv2.namedWindow('Capturing',cv2.WINDOW_NORMAL | cv2.WINDOW_KEEPRATIO) #Keep ratio
    cv2.moveWindow('Capturing',0,0)#Init window position
    cv2.setMouseCallback('Capturing',OnMouseAction)
    cv2.resizeWindow("Capturing", int(i_width*4), int(i_height*4))  #Set display window size

    #bounding box
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_address = (s_URL, i_ai_port)
    client_socket.connect(server_address)
    request_header ='GET /getalarmmotion HTTP/1.1\r\nCookie: ipcam_lang=0\r\nHost: ' + str(s_URL) + ':' + str(i_ai_port) + '\r\nAuthorization: Basic ' + str(s_count_base64) + '\r\n\r\n'
    client_socket.send(request_header.encode())

    if cap.isOpened():
        print('Camera is connected')
        response = work_with_captured_video(cap, client_socket)
        if response == False:
            time.sleep(1)
            continue
    else:
        print('Camera not connected')
        cap.release()
        time.sleep(1)
        continue

cap.release()
cv2.destroyAllWindows()

