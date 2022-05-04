# Python & CSharp Code of RTSP/MJPG Video with AI Bounding Box Display for LILIN YOLO Camera

LILIN 7 series cameras are using Ambarella CV series, CV22/CV25 VPU and running YOLO for AI recognition.  The purpose of the Python & CSharp code is to use OpenCV, CV2 library, for showing RTSP/MJPG video from LILIN IP camera via RTSP port.  It also connects to LILIN AI port at 8592 for AI bounding boxes and license plate recognition. 
<BR>
## What is Self-trained AI YOLO Camera
For more information, visit [here](https://ai.meritlilin.com.tw/) for Self-trained AI YOLO Camera.  
<BR>
## Prerequisites
For this Python sample code, please prepare the following libraries <BR>
import cv2 4.4.0 <BR> 
import keyboard <BR>
import socket <BR>
import json <BR>
Ubuntu-20.04.1 <BR>

## What can you learn from the Python code
(1) Base64 encode <BR>
(2) RTSP stream display for IP camera <BR>
(3) Bounding boxes display for LILIN AI YOLO Camera <BR>
<BR>
## How to run the demo code
### YOLO V3 Tiny on AI YOLO camera
Type python [camera.py](https://github.com/LILINOpenGitHub/Python-Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-YOLO-Camera-/blob/main/Python/camera.py) in command prompt.
<BR>
<BR>
![image](https://github.com/LILINOpenGitHub/Python-Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-YOLO-Camera-/blob/main/image/person_test.gif)
### USA license plate recognition on AI YOLO Camera
Type python [camera.py](https://github.com/LILINOpenGitHub/Python-Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-YOLO-Camera-/blob/main/Python/camera.py) in command prompt.
<BR>
<BR>
![image](https://github.com/LILINOpenGitHub/Python-Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-YOLO-Camera-/blob/main/image/plate_test_2.gif)

## C# code of RTSP/MJPG video with AI bounding box display for LILIN YOLO camera
## Prerequisites
Microsoft Visual Studio 2019 <BR>
For this C# sample code, please prepare the following libraries [EnguCV](https://github.com/emgucv/emgucv)
<BR>
Visit the C# code [here](https://github.com/LILINOpenGitHub/Python-CSharp--Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-YOLO-Camera-/blob/main/C%23/SDK_CSharp_test/Form1.cs).
 
![image](https://github.com/LILINOpenGitHub/Python-CSharp--Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-YOLO-Camera-/blob/main/image/nvrrtsp.gif)

## The RTSP URL of LILIN 7 series camera
(1) 4K H.264/H.265: http://username:password@192.168.0.200:554/stream0 <BR>
(2) 480P H.264/H.265: http://username:password@192.168.0.200:554/stream1 <BR>
(3) Reserved: http://username:password@192.168.0.200:554/stream2 <BR>
(4) MJPG: http://username:password@192.168.0.200:554/stream2 <BR>

![image](https://github.com/LILINOpenGitHub/Python-Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-Yolo-Camera-/blob/main/image/image01.jpg)
 
 ## How to use CURL for bounding box
 [CURL](https://curl.se/download.html) is a HTTP client that is a good tool runing in Windows and Linux.
 
 curl -k -X GET  -u "admin:Pass1234" -v http://admin:Pass1234@192.168.0.200:8592/getalarmmotion
 
 curl [example in C language](https://github.com/LILINOpenGitHub/Python-CSharp--Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-YOLO-Camera-/blob/main/c/curl_example.c).
 
 ![image](https://github.com/LILINOpenGitHub/Python-CSharp--Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-YOLO-Camera-/blob/main/image/curl.jpg)
 

 
  

