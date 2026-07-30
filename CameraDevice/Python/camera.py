import cv2
import os
import time
import datetime
import mysql.connector
import shutil
from gpiozero import MotionSensor
from gpiozero import LED
from gpiozero import Button

import smtplib 
from rclone_python import rclone
from rclone_python.remote_types import RemoteTypes

dbconfig = mysql.connector.connect(
   host = "localhost",
   user = "loguser",
   password = os.environ["sqlpass"],
   database = "camerasystem"
)

def recordVideo():
  global alertText
  global createfolder
  global filecount
  global createfolder2
  global checkfolder
  global checkfolder2
  global checkspace
  global statusspace


  print("Recording feed.")
  now = datetime.datetime.now()
  datefolder = now.strftime("%d_%m_%Y")
  timefile = now.strftime("%H:%M:%S")
  createfolder = "/media/usbdrive/camerasystem/"+datefolder
  createfolder2 = "/home/camerauser/gdrive/Recordings/"+datefolder
  checkfolder = os.path.isdir(createfolder)
  checkfolder2 = os.path.isdir(createfolder2)
  
  if not checkfolder and checkspace > 99:
    os.mkdir(createfolder, mode=0o777)
 
  if checkspace > 99 and statusspace == 0:
    filecount = next(os.walk(createfolder))[2]
    print(len(filecount))
    filecount = len(filecount)
    filecount = filecount + 1
    print("Local: " + createfolder + "/video" + str(filecount) +".mp4")
    alertText = alertText + " '" + datefolder + "/video" + str(filecount) + "'";
    query = "insert into cameralogs (logtext) values (%s)"
    dbinfo.execute(query, [alertText])
    dbconfig.commit()
  else:
    print("Check space")

def streamVideo():
  global filecount
  global starttime
  global delaytime
  global stream
  global frame_width
  global frame_height
  global createfolder
  global alertText  
  global checkspace
  global statusspace
  global index

  index = index + 1

  print("Status: " + str(index))

  frame_width = int(stream.get(cv2.CAP_PROP_FRAME_WIDTH))
  frame_height = int(stream.get(cv2.CAP_PROP_FRAME_HEIGHT))
  fourcc = cv2.VideoWriter_fourcc(*'mp4v')
  output = cv2.VideoWriter(createfolder + '/video' + str(filecount) + '.mp4', fourcc, 20.0, (frame_width, frame_height))
  startTime = time.time()
  while(int(time.time() - startTime) < recordingTime):
    ret, frame = stream.read()
    output.write(frame)
    output.release()
   
def motionShow():
   global alertText  
   global detectStatus

   detectStatus = True
   statusspace = 0
   index = 0
   print("Check: "+ str(index))
   match motionChoice:
      case 1:
        print("Waiting for motion on sensor 1.")
        alertText = "Motion detected on sensor 1. "
        motionLed1.on()
        motionLed2.off()
        motionSensor1.wait_for_motion()
      case 2:
        print("Waiting for motion on sensor 2.")  
        alertText = "Motion detected on sensor 2. "
        motionLed1.off()
        motionLed2.on()
        motionSensor2.wait_for_motion()
      case 3:
        print("Waiting for motion on either sensor.")
        alertText = "Motion detected on both sensor. "
        motionLed1.on()
        motionLed2.on()
        while not motionSensor1.motion_detected and not motionSensor2.motion_detected:
          time.sleep(0.1)
          continue 
      case 4:    
        detectStatus = False

def enableChoice():
  if enableDrive == 'True' and checkspace > 99:
    if not checkfolder2:
      os.mkdir(createfolder2)   
    print(checkfolder2)
    print(createfolder + "/video" + str(filecount) +".mp4")
    copyfrom = createfolder + "/video" + str(filecount) +".mp4"
    rclone.copy(copyfrom, createfolder2)
    print("GDrive: " + createfolder2 + "/video" + str(filecount) +".mp4")    
  if enableEmail == 'True':
    server = smtplib.SMTP('smtp.gmail.com', 587)
    server.starttls()
    server.login(username, password)
    message = 'Subject: {}\n\n{}'.format("Camera alert", alertText)
    server.sendmail("Camera alert",sendEmail, message)
    print("Email sent")

def doorStatus():
    global alertText
    match detectChoice:
      case 1:
        print ("Door is opened!")
        alertText = "The door was opened with detection 1. "
        recordVideo()
        streamVideo()
        enableChoice()
      case 2:
        print ("None detection selected.")


stream = cv2.VideoCapture(0)
motionSensor1 = MotionSensor(12)
motionSensor2 = MotionSensor(16)
motionLed1 = LED(23)
motionLed2 = LED(24)
detectLed1 = LED(21)

statusOpen = Button(5,pull_up = True,bounce_time= 0.2)
username = 'ken.ekholm76@gmail.com'
password = os.environ["googlemessage"]

try:
  dbinfo = dbconfig.cursor()
  query = "insert into cameralogs(logtext) values ('Camera device started.')"
  dbinfo.execute(query)
  dbconfig.commit()

  dbinfo = dbconfig.cursor(buffered=True)
  query = "select * from settings where id = 1"
  dbinfo.execute(query)
  row = dbinfo.fetchone()
  enableEmail = row[1]
  enableDrive = row[2]
  sendEmail = row[3]
  recordingTime = row[4]
  motionChoice = row[7]
  detectChoice = row[8]
  dbconfig.commit()
  statusspace = 0
  index = 0
 
  if detectChoice == 1:
    detectLed1.on()
  else:
    detectLed1.off()  

  total, used, free = shutil.disk_usage("/media/usbdrive/camerasystem")
  checkspace = free / total * 100
  if checkspace > 99:
    while True:

      statusOpen.when_released = doorStatus
      motionShow()

      if detectStatus == True:
        recordVideo()
        streamVideo()
        enableChoice()
    stream.release()
  else:
    print("Not enough space on local drive. " + str(statusspace) + "% free space remaining.")
    dbinfo = dbconfig.cursor()
    query = "insert into cameralogs(logtext) values ('Not enough space on local drive.')"
    dbinfo.execute(query)
    dbconfig.commit()    


except mysql.connector.Error as error:
    print("Failed to insert record into table {}".format(error))
except KeyboardInterrupt:
    print("Exit!")
    GPIO.cleanup()  
