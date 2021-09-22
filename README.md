# Python Code of RTSP/MJPG Video with AI Bounding Box Display for LILIN YOLO Camera

LILIN 7 series cameras are using Ambarella CV series, CV22/CV25 VPU and running Yolo for AI recognition.  The purpose of the Python code is to use OpenCV, CV2 library, for showing RTSP/MJPG video from LILIN IP camera via RTSP port.  It also connects to LILIN AI port at 8592 for AI bounding boxes and license plate recognition. 
<BR>
## What is Self-trained AI Yolo Camera
For more information, visit [here](http://ai.meritlilin.com.tw:3380/) for Self-trained AI Yolo Camera.  For this sample code, you can learn:
<BR>
##Prerequisites
For this sample code, please prepare the following libraries
import cv2
import keyboard
import socket
import json

## What can you learn from the Python code
(1) Base64 encode <BR>
(2) CV22 for RTSP stream <BR>
(3) Bounding boxes display for LILIN AI Yolo Camera <BR>
<BR>
## The RTSP URL of LILIN 7 series camera
(1) 4K H.264/H.265: http://username:password@192.168.0.200:554/stream0 <BR>
(2) 480P H.264/H.265: http://username:password@192.168.0.200:554/stream1 <BR>
(3) Reserved: http://username:password@192.168.0.200:554/stream2 <BR>
(4) MJPG: http://username:password@192.168.0.200:554/stream2 <BR>

![image](https://github.com/LILINOpenGitHub/Python-Code-of-RTSP-MJPG-Video-with-AI-Bounding-Box-Display-for-LILIN-Yolo-Camera-/blob/main/image/image01.jpg)
