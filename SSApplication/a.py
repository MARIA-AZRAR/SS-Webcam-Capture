import cv2
from datetime import datetime
import sys
import os

num = sys.argv[1]
videoCaptureObject = cv2.VideoCapture(0)
result = True
while(result):
    ret,frame = videoCaptureObject.read()
    now = datetime.now();

    path = 'E:\semester 6\FYP Trial\ScreenShotImages';

    cv2.imwrite(os.path.join(path, "webcam" + num +".jpg"),frame)
    result = False
videoCaptureObject.release()
cv2.destroyAllWindows()