import cv2
import os
import time
import datetime
import mysql.connector
import shutil
from gpiozero import MotionSensor
from gpiozero import LED
from gpiozero import Button
from RPLCD.i2c import CharLCD

import smtplib 
from rclone_python import rclone
from rclone_python.remote_types import RemoteTypes

dbconfig = mysql.connector.connect(
   host = "localhost",
   user = "loguser",
   password = os.environ["sqlpass"],
   database = "camerasystem"
)

def showDisplay(displayText):
  lcd.clear()
  lcd.write_string("%s" %time.strftime("%d.%m.%Y") + " %s" %time.strftime("%H:%M"))
  lcd.crlf()
  lcd.write_string("%s" %displayText)

def recordVideo():
  global alertText
  global createfolder
  global filecount
  global createfolder2
  global checkfolder
  global checkfolder2
  global checkspace

  print("Recording feed.")
  now = datetime.datetime.now()
  datefolder = now.strftime("%Y_%m_%d")
  timefile = now.strftime("%H:%M:%S")
  createfolder = "/media/usbdrive/camerasystem/"+datefolder
  createfolder2 = "/home/camerauser/gdrive/Recordings/"+datefolder
  checkfolder = os.path.isdir(createfolder)
  checkfolder2 = os.path.isdir(createfolder2)

  if not checkfolder and checkspace > 99:
    os.mkdir(createfolder, mode=0o777)

  filecount = next(os.walk(createfolder))[2]
  print(len(filecount))
  filecount = len(filecount)
  filecount = filecount + 1
  print("Local: " + createfolder + "/video" + str(filecount) +".mp4")
  alertText = alertText + " '" + datefolder + "/video" + str(filecount) + "'";
  query = "insert into cameralogs (logtext) values (%s)"
  dbinfo.execute(query, [alertText])
  dbconfig.commit()

def streamVideo():
  global filecount
  global starttime
  global delaytime
  global stream
  global frame_width
  global frame_height
  global createfolder
  global alertText
  global recording
 
  frame_width = int(stream.get(cv2.CAP_PROP_FRAME_WIDTH))
  frame_height = int(stream.get(cv2.CAP_PROP_FRAME_HEIGHT))
  fourcc = cv2.VideoWriter_fourcc(*'mp4v')
  output = cv2.VideoWriter(createfolder + '/video' + str(filecount) + '.mp4', fourcc, 20.0, (frame_width, frame_height))
  startTime = time.time()

  recording = 0
  print("Enbaled: " + str(recording))
  while(int(time.time() - startTime) < recordingTime):
    ret, frame = stream.read()
    output.write(frame)
  print("Video recored completed: ")
  output.release()
  recording = 1
  print("Recording done.")


def changeStatus(setText):
    print(setText + " detected. Please wait until recording is completed.")
    showDisplay("Camera busy")
    dbinfo = dbconfig.cursor()
    query = "insert into cameralogs(logtext) values (%s)"
    dbinfo.execute(query, [setText + " detected. Camera was busy."])
    dbconfig.commit()    

def motionShow1():
  global alertText  
  global detectStatus
  global recording

  detectStatus = True
  statusspace = 0
  print("Motion Enbaled: " + str(recording))
  if motionChoice1 == 1:
    if recording == 1:
      print("Waiting for motion on sensor 1.")
      alertText = "Motion detected on sensor 1. " 
      showDisplay("Motion1 detected")
      motionLed1.on()
      motionLed2.off()
      recordVideo()
      streamVideo()
      enableChoice()
    else:
      changeStatus("Motion1")
 
  
def motionShow2():
  global alertText  
  global detectStatus
  global recording

  detectStatus = True
  statusspace = 0
  print("Recording " + str(recording))
  if motionChoice2 == 1:
    if recording == 1:
      print("Waiting for motion on sensor 2.")
      alertText = "Motion detected on sensor 2. " 
      showDisplay("Motion2 detected")
      motionLed1.off()
      motionLed2.on()
      recordVideo()
      streamVideo()
      enableChoice()
    else:
      changeStatus("Motion2")

def enableChoice():
  if enableDrive == 'True':
    if not checkfolder2:
      os.mkdir(createfolder2)   
    print(checkfolder2)
    print(createfolder + "/video" + str(filecount) +".mp4")
    copyfrom = createfolder + "/video" + str(filecount) +".mp4"
    print ("Copying from  " + copyfrom + " to " + createfolder2)
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
    if detectChoice == 1:
      if recording == 1:
        print ("Door is opened!")
        alertText = "The door was opened with detection 1. "
        showDisplay("Door1 detected")
        recordVideo()
        streamVideo()
        enableChoice()
      else: 
        changeStatus("Door1")

motionSensor1 = MotionSensor(12)
motionSensor2 = MotionSensor(16)
motionLed1 = LED(23)
motionLed2 = LED(24)
detectLed1 = LED(21)
redLed1 = LED(17)
greenLed1 = LED(27)
redLed1.off()
greenLed1.on()

lcd = CharLCD('PCF8574', 0x27, cols=16, rows=2)
lcd.clear()
lcd.write_string("Camera device")
lcd.crlf()
lcd.write_string("  activated.")

statusOpen = Button(5,pull_up = True,bounce_time= 0.2)
username = 'ken.ekholm76@gmail.com'
password = os.environ["googlemessage"]
statusspace = 1
recording = 1


stream = cv2.VideoCapture(0)

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
  motionChoice2 = row[7]
  detectChoice = row[8]
  motionChoice1 = row[9]
  dbconfig.commit()
  recording = 1


  if motionChoice1 == 1:
    motionLed1.on()
  else:
    motionLed1.off()  

  if motionChoice2 == 1:
    motionLed2.on()
  else:
    motionLed2.off()  
 
  if detectChoice == 1:
    detectLed1.on()
  else:
    detectLed1.off()  

  while True:
    total, used, free = shutil.disk_usage("/media/usbdrive/camerasystem")
    checkspace = free / total * 100
    statusOpen.when_released = doorStatus
    motionSensor1.when_motion = motionShow1
    motionSensor2.when_motion = motionShow2


    if statusspace == 1 and checkspace < 98:
      print("Not enough space on local drive. " + str(statusspace) + "% free space remaining.")
      dbinfo = dbconfig.cursor()
      query = "insert into cameralogs(logtext) values ('Not enough space on local drive.')"
      showDisplay("Not enough space")
      dbinfo.execute(query)
      dbconfig.commit()    
      redLed1.on()
      greenLed1.off()
      statusspace = 0
      if enableEmail == 'True':
        server = smtplib.SMTP('smtp.gmail.com', 587)
        server.starttls()
        server.login(username, password)
        message = 'Subject: {}\n\n{}'.format("Camera alert", "Not enough space on local drive.")
        server.sendmail("Camera alert",sendEmail, message)
        print("Email sent")
  stream.release()
except mysql.connector.Error as error:
    print("Failed to insert record into table {}".format(error))
except KeyboardInterrupt:
    print("Exit!")
    GPIO.cleanup()  
