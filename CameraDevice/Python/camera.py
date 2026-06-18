import cv2
import os
import time
import datetime
import mysql.connector
from gpiozero import MotionSensor
from gpiozero.tools import any_values
import smtplib 
from rclone_python import rclone
from rclone_python.remote_types import RemoteTypes

dbconfig = mysql.connector.connect(
   host = "localhost",
   user = "loguser",
   password = os.environ["sqlpass"],
   database = "camerasystem"
)

def streamVideo():
   global filecount
   global starttime
   global delaytime
   global stream
   global frame_width
   global frame_height
   frame_width = int(stream.get(cv2.CAP_PROP_FRAME_WIDTH))
   frame_height = int(stream.get(cv2.CAP_PROP_FRAME_HEIGHT))
   fourcc = cv2.VideoWriter_fourcc(*'mp4v')
   output = cv2.VideoWriter(createfolder + '/video' + str(filecount) + '.mp4', fourcc, 20.0, (frame_width, frame_height))
   test = 0
   startTime = time.time()
   while(int(time.time() - startTime) < recordingTime):
      ret, frame = stream.read()
      output.write(frame)
      test = 1
   output.release()

recordingTime = 10
stream = cv2.VideoCapture(0)

motionSensor1 = MotionSensor(12)
motionSensor2 = MotionSensor(16)
username = 'ken.ekholm76@gmail.com'
password = os.environ["googlepass"]


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
  setStreamtime = row[4]
  motionChoice = row[7]
  dbconfig.commit()


  print(motionChoice);
  delaytime = time.time() + setStreamtime

  while True:
    match motionChoice:
      case 1:
        print("Waiting for motion on sensor 1.")
        alertText = "Motion detected on sensor 1. "
        motionSensor1.wait_for_motion()
      case 2:
        print("Waiting for motion on sensor 2.")  
        alertText = "Motion detected on sensor 2. "
        motionSensor2.wait_for_motion()
      case 3:
        print("Waiting for motion on either sensor.")
        alertText = "Motion detected on both sensor. "
        while not motionSensor1.motion_detected and not motionSensor2.motion_detected:
          time.sleep(0.1)
          continue 
     

    print("Recording feed.")
    now = datetime.datetime.now()
    datefolder = now.strftime("%d_%m_%Y")
    timefile = now.strftime("%H:%M:%S")
    createfolder = "/media/usbdrive/camerasystem/"+datefolder
    createfolder2 = "/home/camerauser/gdrive/Recordings/"+datefolder
    checkfolder = os.path.isdir(createfolder)
    checkfolder2 = os.path.isdir(createfolder2)
  
    if not checkfolder:
      os.mkdir(createfolder, mode=0o777)
    else:
      filecount = next(os.walk(createfolder))[2]
      print(len(filecount))
      filecount = len(filecount)
      filecount = filecount + 1
      streamVideo()
      print("Local: " + createfolder + "/video" + str(filecount) +".mp4")

    alertText = alertText + " '" + datefolder + "/video" + str(filecount) + "'";
    query = "insert into cameralogs (logtext) values (%s)"
    dbinfo.execute(query, [alertText])
    dbconfig.commit()

    if enableDrive == 'True':
      if not checkfolder2:
        os.mkdir(createfolder2)
      else:
        print(checkfolder2)
        print(createfolder + "/video" + str(filecount) +".mp4")
        copyfrom = createfolder + "/video" + str(filecount) +".mp4"
        rclone.copy(copyfrom, createfolder2)
        print("GDrive: " + createfolder2 + "/video" + str(filecount) +".mp4")
          
    if enableEmail == 'True':
      try:
        server = smtplib.SMTP('smtp.gmail.com', 587)
        server.starttls()
        server.login(username, password)
        server.sendmail('Camera alert',sendEmail, alertText)
        print("Email sent")
      except Exception as e:
        print(f"Error: {e}")
#    pir.wait_for_no_motion()  
  stream.release()
except mysql.connector.Error as error:
    print("Failed to insert record into table {}".format(error))
except KeyboardInterrupt:
    print("Exit!")
#    GPIO.cleanup()  
