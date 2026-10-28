import cv2
import os
import time
import datetime
import mysql.connector
import shutil
import threading
from gpiozero import MotionSensor
from gpiozero import LED
from gpiozero import Button
import mysql.connector, sys
from mysql.connector import Error
from mysql.connector import errorcode
import smtplib 
from rclone_python import rclone
from rclone_python.remote_types import RemoteTypes
from luma.core.interface.serial import i2c
from luma.core.render import canvas
from luma.oled.device import sh1106

config = {
  'host':'localhost',
  'user':'loguser',
  'password':os.getenv("sqlpass"),
  'database':'camerasystem'
}
connection = mysql.connector.connect(**config)
def recordVideo(deviceText):

  stream = cv2.VideoCapture(0)
  stream2 = cv2.VideoCapture(2)
  print("Recording feed.")
  now = datetime.datetime.now()
  datefolder = now.strftime("%Y_%m_%d")
  timefile = now.strftime("%H_%M_%S")
  createfolder = "/media/usbdrive/camerasystem/"+datefolder
  createfolder2 = "/home/camerauser/gdrive/Recordings/"+datefolder
  checkfolder = os.path.isdir(createfolder)
  checkfolder2 = os.path.isdir(createfolder2)
  createVideo1 = True
  createVideo2 = True


  if not stream.isOpened():
    #raise RuntimeError("Could not open camera 1")
    addmysqlrecord("Camera 1 is not working." )
    oledinfo("CAMERA 1", "IS NOT WORKING.", "","")
    sendEmail("Camera 1 is not working.")
    setText = ""
    createVideo1 = False 
 

  if not stream2.isOpened():
    #raise RuntimeError("Could not open camera 1")
    addmysqlrecord("Camera 2 is not working." )
    oledinfo("CAMERA 2", "IS NOT WORKING.", "","")
    sendEmail("Camera 2 is not working.")
    setText2 = ""
    createVideo2 = False 


  if createVideo1 == False or createVideo2 == False:
    greenLed1.off()
    redLed1.on()
  else:
    greenLed1.on()
    redLed1.off()
   
  if createVideo1 == True:
    if not os.path.isdir("/media/usbdrive/camerasystem/"+datefolder+"/camera1"):
      os.makedirs(os.path.join("/media/usbdrive/camerasystem/"+datefolder+"/", "camera1"),mode=0o777)
      print ("Camera 1 created.")

  if createVideo2 == True:
    if not os.path.isdir("/media/usbdrive/camerasystem/"+datefolder+"/camera2"):
      os.makedirs(os.path.join("/media/usbdrive/camerasystem/"+datefolder+"/", "camera2"), mode=0o777)
      print ("Camera 2 created.")

  frame_width = int(stream.get(cv2.CAP_PROP_FRAME_WIDTH))
  frame_height = int(stream.get(cv2.CAP_PROP_FRAME_HEIGHT))
  fourcc = cv2.VideoWriter_fourcc(*'mp4v')
  if camera1 == 1:
    output = cv2.VideoWriter(createfolder + '/camera1/video_' + str(timefile) + '.mp4', fourcc, 15.0, (frame_width, frame_height))
  if camera2 == 1:
    output2 = cv2.VideoWriter(createfolder + '/camera2/video_' + str(timefile) + '.mp4', fourcc, 15.0, (frame_width, frame_height))
  startTime = time.time()

  print("Enabled: ")
  while(int(time.time() - startTime) < recordingTime):
    if createVideo1 == True:
      if camera1 ==1:
        try:
          if not stream.isOpened():
            raise RuntimeError("Could not open camera")
          ret, frame = stream.read()
          if not ret:
            raise RuntimeError("Could not read frame from camera")
          output.write(frame)
        except Exception as e:
          print(f"Camera 1 error: {e}")
    
    if createVideo2 == True:    
      if camera2 == 1:
        try:
          if not stream2.isOpened():
            raise RuntimeError("Could not open camera")
          ret2, frame2 = stream2.read()
          if not ret2:
            raise RuntimeError("Could not read frame from camera")
          output2.write(frame2)
        except Exception as e:
          print(f"Camera 2 error: {e}")
  
  if createVideo1 == True:
    if camera1 == 1:
      setText = "Camera 1 "
      output.release()
      cameraText1 = "'" + datefolder + "/camera1/video_" + str(timefile) + "'"
    else:
      setText = ""
  
  if createVideo2 == True:
    if camera2 == 1:
      setText2 = "Camera 2 "
      output2.release()
      cameraText2 = "'" + datefolder + "/camera2/video_" + str(timefile) + "'"
    else:
      setText = ""  
  
  if enableDrive == 'True':
    print("Uploading to GDrive.")
    if not os.path.isdir(createfolder2 + "/camera1"):
      os.makedirs(createfolder2+"/camera1", mode=0o777)
      print ("Cloud Camera 1 created.")

    if not os.path.isdir(createfolder2 + "/camera2"):
      os.makedirs(createfolder2+"/camera2", mode=0o777)
      print ("Cloud Camera 2 created.")
    
    if createVideo1 == True:
      if camera1 == 1:
        copyfrom = createfolder + "/camera1/video_" + str(timefile) +".mp4"
        rclone.copy(copyfrom, createfolder2 + "/camera1")
    if createVideo2 == True:
      if camera2 == 1:
        copyfrom2 = createfolder + "/camera2/video_" + str(timefile) +".mp4"
        rclone.copy(copyfrom2, createfolder2 + "/camera2")
    print("GDrive: " + createfolder2 + "/video_" + str(timefile) +".mp4")    
  setText3 = setText + setText2 + "were detected with " + deviceText + "."
  print(setText3)
  sendEmail(setText3) 
  stream.release()
  stream2.release()  
  print("Recording done.")

def sendEmail(infoText):
  if enableEmail == 'True':
    server = smtplib.SMTP('smtp.gmail.com', 587)
    server.starttls()
    server.login(username, password)
    message = 'Subject: {}\n\n{}'.format("Camera alert", infoText)
    server.sendmail("Camera alert",sendAdress,message)

def motionShow1():
  if motionChoice1 == 1:
    if not recordingLock.acquire(blocking=False):
      return
    try:
      print("Motion on sensor 1.")
      addmysqlrecord("Motion detected on sensor 1." )
      oledinfo("THE MOTION 1", "WAS TRIGGED.", "","")
      deviceText = "Motion 1"
      recordVideo(deviceText)
    finally:
      recordingLock.release()

def motionShow2():
  if motionChoice2 == 1:
    if not recordingLock.acquire(blocking=False):
      return
    try:  
      print("Motion on sensor 2.")
      addmysqlrecord("Motion detected on sensor 2." )
      oledinfo("THE MOTION 2","WAS TRIGGED", "","")
      deviceText = "Motion 2"
      recordVideo(deviceText)
    finally:
      recordingLock.release()

def doorStatus():
  if detectChoice == 1:
    if not recordingLock.acquire(blocking=False):
      return
    try:  
      print ("Door is opened!")
      addmysqlrecord("The door was opened with detection 1.")
      oledinfo("THE DOOR SWITCH ", "WITH DETECTION 1", "","")
      deviceText = "Detection 1"
      recordVideo(deviceText)
    finally:
      recordingLock.release()  

def oledinfo(row1, row2, row3, row4):
  now = datetime.datetime.now()
  row4 = now.strftime("%d-%m-%Y  %H:%M:%S")
  with canvas(device) as draw:
    draw.rectangle(device.bounding_box, outline="white", fill="black")
    draw.text((5, 10), row1, fill="white")
    draw.text((5, 22), row2, fill="white")
    draw.text((5, 34), row3, fill="white")
    draw.text((5, 46), row4, fill="white")

def addmysqlrecord(info):
   cursor = connection.cursor()
   query = "insert into cameralogs(logtext) values (%s)"
   cursor.execute(query, [info])
   connection.commit()
   print("Record inserted successfully into table cameralogs with info: ", (info))
   cursor.close()

try:
  serial = i2c(port=1, address=0x3C)
  device = sh1106(serial, width=128, height=64, rotate=0)
  recordingLock = threading.Lock()
  motionSensor1 = MotionSensor(12)
  motionSensor2 = MotionSensor(16)
  statusOpen = Button(5,pull_up = True,bounce_time= 0.2)
  motionLed1 = LED(23) 
  motionLed2 = LED(24)
  detectLed1 = LED(21)
  redLed1 = LED(17)
  greenLed1 = LED(27)
  redLed1.off()
  greenLed1.on()
  username = 'ken.ekholm76@gmail.com'
  password = os.environ["googlemessage"]
 
  cursor = connection.cursor()
  query = "select * from settings where id = 1"
  cursor.execute(query)
  row = cursor.fetchone()
  enableEmail = row[1]
  enableDrive = row[2]
  sendAdress = row[3]
  recordingTime = row[4]
  motionChoice2 = row[7]
  detectChoice = row[8]
  motionChoice1 = row[9]
  camera1 = row[10]
  camera2 = row[11]
  connection.commit()
  cursor.close()
 
  if detectChoice == 1:
    detectLed1.on()
  else:
    detectLed1.off()
  
  if motionChoice1 == 1:
    motionLed2.on()
    print("ON")
  else:
    motionLed2.off()
    print("OFF")

  if motionChoice2 == 1:
    motionLed1.on()
  else:
    motionLed1.off()

  oledinfo("Cameradevice", "version 1.3", "Ken Ekholm", "Copyright 2026")
  addmysqlrecord("Camera device started.")

  while True:
    statusOpen.when_released = doorStatus
    motionSensor1.when_motion = motionShow1
    motionSensor2.when_motion = motionShow2

except KeyboardInterrupt:
    print("Exit!")
  