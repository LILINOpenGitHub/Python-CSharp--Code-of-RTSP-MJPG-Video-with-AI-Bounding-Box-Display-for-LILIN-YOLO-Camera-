import cv2
import keyboard
import socket
import json
import base64

#video

s_username = 'admin'
s_password = 'Pass1234'
s_count = s_username + ':' + s_password
s_count_base64 = str((base64.b64encode(s_count.encode())).decode())
s_URL = '192.168.1.200'
i_ai_port = 8592
i_http_port = 80
i_rtsp_port = 554
i_rtsp_stream = 'stream3'
i_width = 352
i_height = 240
i_scaling = 2 # 2x
cap = cv2.VideoCapture('rtsp://' + str(s_count) + '@' + str(s_URL) + ':' + str(i_rtsp_port) + '/' + str(i_rtsp_stream))
ret, frame = cap.read()


#bounding box
client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_address = (s_URL, i_ai_port)
client_socket.connect(server_address)
request_header ='GET /getalarmmotion HTTP/1.1\r\nCookie: ipcam_lang=0\r\nHost: ' + str(s_URL) + ':' + str(i_ai_port) + '\r\nAuthorization: Basic ' + str(s_count_base64) + '\r\n\r\n'
client_socket.send(request_header.encode())
def OnMouseAction(event,x,y,flags,param):
    print("move windows")

cv2.moveWindow('Capturing',250,0)#Init window position
#Loop for read video and bounding box
while True:
    cv2.setMouseCallback('Capturing',OnMouseAction)  
    cap.set(cv2.CAP_PROP_FRAME_WIDTH,i_width)  #Set streaming width and height
    cap.set(cv2.CAP_PROP_FRAME_HEIGHT,i_height)
    cv2.namedWindow('Capturing',cv2.WINDOW_NORMAL | cv2.WINDOW_KEEPRATIO) #Keep ratio
    ret, frame = cap.read()
    cv2.resizeWindow("Capturing", int(i_width*4), int(i_height*4))  #Set display window size
    
    recv = client_socket.recv(2048)  #Specify buffer
    recv = recv.decode().split('\n')[5] #bounding box 
    print(recv)
    Json_data = json.loads(recv) #Get the JSON data from /getalarmmotion CGI

    if len(Json_data["AiEngine"]) != 0: #Find AiEngine token
        for j in range(len(Json_data["AiEngine"])): #Loop for display bouding box and plate
            #Render the bonding box
            i_x1 = int(int(Json_data["AiEngine"][j]["x"])*i_width/1920)
            i_y1 = int(int(Json_data["AiEngine"][j]["y"])*i_height/1080)
            i_x2 = i_x1 + int(int(Json_data["AiEngine"][j]["w"])*i_width/1920)
            i_y2 = i_y1 + int(int(Json_data["AiEngine"][j]["h"])*i_width/1920)
            i_label = str(Json_data["AiEngine"][j]["label_name"])
            #i_plate = str(Json_data["AiEngine"][j]["properties"]["plate"])
            #Protect the width and hight
            if i_x2 > i_width:
                i_x2 = i_width
            if i_y2 > i_height:
                i_y2 = i_height
            if i_y1 < 5:
                i_y1 = 5
            #Render the bounding box and plate
            #cv2.rectangle(The frame, top-left, bottom-right, RGB color, width)
            cv2.rectangle(frame, (i_x1, i_y1), (i_x2, i_y2), (0, 0, 255), 2)
            #cv2.rectangle(frame, (10, 10), (50 ,50), (0, 0, 255), 2)
            cv2.putText(frame,i_label , (i_x1,i_y1-5), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 1, cv2.LINE_AA) #test_label
            #cv2.putText(frame,i_plate , (i_x1,i_y1-5), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 1, cv2.LINE_AA) #test_label
            
    print('---------------------------------------------')


    cv2.imshow("Capturing",frame)
    if keyboard.is_pressed('esc'):  # if key 'ESC' is pressed 
        break  # finishing the loop

    if cv2.waitKey(1) & 0xFF == ord('q'):
        break
    

cap.release()
cv2.destroyAllWindows()