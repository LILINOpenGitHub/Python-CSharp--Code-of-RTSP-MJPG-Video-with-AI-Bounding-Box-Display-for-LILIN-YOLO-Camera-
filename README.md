# Python Code of RTSP/MJPG Video with AI Bounding Box Display for LILIN YOLO Camera

LILIN 7 series cameras are using Ambarella CV series, CV22/CV25 VPU and running Yolo for AI recognition.  The purpose of the Python code is to use OpenCV, CV2 library, for showing RTSP/MJPG video from LILIN IP camera via RTSP port.  It also connects to LILIN AI port at 8592 for AI bounding boxes and license plate recognition. 
<BR>
## What is Self-trained AI Yolo Camera
For more information, visit [here](http://ai.meritlilin.com.tw:3380/) for Self-trained AI Yolo Camera.  For this sample code, you can learn:
<BR>
## Prerequisites
For this Python sample code, please prepare the following libraries <BR>
import cv2 4.4.0 <BR> 
import keyboard <BR>
import socket <BR>
import json <BR>
Ubuntu-20.04.1 <BR>

For this C# sample code, please prepare the following libraries <BR>
[EnguCV](https://github.com/emgucv/emgucv)

## What can you learn from the Python code
(1) Base64 encode <BR>
(2) CV22 for RTSP stream <BR>
(3) Bounding boxes display for LILIN AI Yolo Camera <BR>
<BR>
## How to run the demo code
### Yolo V3 Tiny on AI Yolo Camera
Type python [camera.py](https://github.com/LILINOpenGitHub/Python-Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-Yolo-Camera-/blob/main/Python/camera.py) in command prompt.
<BR>
<BR>
![image](https://github.com/LILINOpenGitHub/Python-Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-Yolo-Camera-/blob/main/image/person_test.gif)
### USA license plate recognition on AI Yolo Camera
Type python [camera.py](https://github.com/LILINOpenGitHub/Python-Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-Yolo-Camera-/blob/main/Python/camera.py) in command prompt.
<BR>
<BR>
![image](https://github.com/LILINOpenGitHub/Python-Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-Yolo-Camera-/blob/main/image/plate_test_2.gif)

## C# Code of RTSP/MJPG Video with AI Bounding Box Display for LILIN YOLO Camera
Visit the C# code [here](https://github.com/LILINOpenGitHub/Python-CSharp--Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-Yolo-Camera-/blob/main/C%23/SDK_CSharp_test/Form1.cs).
 
![image](https://github.com/LILINOpenGitHub/Python-CSharp--Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-Yolo-Camera-/blob/main/image/nvrrtsp.gif)

## The RTSP URL of LILIN 7 series camera
(1) 4K H.264/H.265: http://username:password@192.168.0.200:554/stream0 <BR>
(2) 480P H.264/H.265: http://username:password@192.168.0.200:554/stream1 <BR>
(3) Reserved: http://username:password@192.168.0.200:554/stream2 <BR>
(4) MJPG: http://username:password@192.168.0.200:554/stream2 <BR>

![image](https://github.com/LILINOpenGitHub/Python-Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-Yolo-Camera-/blob/main/image/image01.jpg)
  

