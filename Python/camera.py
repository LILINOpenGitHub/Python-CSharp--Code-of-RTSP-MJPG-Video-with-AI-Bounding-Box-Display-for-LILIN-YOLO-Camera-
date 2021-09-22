import cv2
import keyboard
import socket
import json

#video

cap = cv2.VideoCapture('rtsp://admin:Pass1234@192.168.1.200:554/stream3')
i_width = 352
i_height = 240
ret, frame = cap.read()

#bounding box
client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_address = ('192.168.1.200', 8592)
client_socket.connect(server_address)
request_header = 'GET /getalarmmotion HTTP/1.1\r\nCookie: ipcam_lang=0\r\nHost: 192.168.1.200:8592\r\nAuthorization: Basic YWRtaW46UGFzczEyMzQ=\r\n\r\n'
client_socket.send(request_header.encode())
 


#迴圈讀取影像及bounding box
while True:
    cap.set(cv2.CAP_PROP_FRAME_WIDTH,i_width)  #Set streaming width and height
    cap.set(cv2.CAP_PROP_FRAME_HEIGHT,i_height)
    cv2.namedWindow('Capturing',cv2.WINDOW_NORMAL | cv2.WINDOW_KEEPRATIO) #Keep ratio
    ret, frame = cap.read()
    cv2.resizeWindow("Capturing", 352, 240)  #Set display window size

    recv = client_socket.recv(2048)  #Specify buffer
    recv = recv.decode().split('\n')[5] #bounding box 
    print(recv)
    Json_data = json.loads(recv) #Get the JSON data from /getalarmmotion CGI

    if len(Json_data["AiEngine"]) != 0: #Find AiEngine token
        for j in range(len(Json_data["AiEngine"])): #依序畫上bounding box及車牌
            #Render the bonding box
            i_x1 = int(int(Json_data["AiEngine"][j]["x"])*i_width/1920)
            i_y1 = int(int(Json_data["AiEngine"][j]["y"])*i_height/1080)
            i_x2 = i_x1 + int(int(Json_data["AiEngine"][j]["w"])*i_width/1920)
            i_y2 = i_y1 + int(int(Json_data["AiEngine"][j]["h"])*i_width/1920)
            i_plate = str(Json_data["AiEngine"][j]["properties"]["plate"])
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

            cv2.putText(frame,i_plate , (i_x1,i_y1-5), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 1, cv2.LINE_AA) #test_label
            
    print('---------------------------------------------')


    cv2.imshow("Capturing",frame)
    if keyboard.is_pressed('esc'):  # if key 'ESC' is pressed 
        break  # finishing the loop

    if cv2.waitKey(1) & 0xFF == ord('q'):
        break
    

cap.release()
cv2.destroyAllWindows()