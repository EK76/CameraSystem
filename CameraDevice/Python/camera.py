from picamzero import Camera
import os
from time import *
from datetime import *
import mysql.connector
from gpiozero import MotionSensor
import smtplib 
from rclone_python import rclone
from rclone_python.remote_types import RemoteTypes

dbconfig = mysql.connector.connect(
   host = "localhost",
   user = "loguser",
   password = os.environ["sqlpass"],
   database = "camerasystem"
)

pir = MotionSensor(12)
username = 'ken.ekholm76@gmail.com'
password = 'bagisvhqmjozmxbu'

try:
  showvideo = Camera()
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
  alertText = row[4]
  alertText2 = row[4]
  sendEmail = row[5]
  setStreamtime = row[6]
  dbconfig.commit()

  print(alertText);

  while True:
    pir.wait_for_motion()
    print("Recording feed.")
    now = datetime.now()
    datefolder = now.strftime("%d_%m_%Y")
    timefile = now.strftime("%H:%M:%S")
    createfolder = "/media/usbdrive/camerasystem/"+datefolder
    createfolder2 = "/home/camerauser/gdrive/"+datefolder
    checkfolder = os.path.isdir(createfolder)
    checkfolder2 = os.path.isdir(createfolder2)
  
    alertText = alertText2
    if not checkfolder:
      os.mkdir(createfolder, mode=0o777)
    else:
      filecount = next(os.walk(createfolder))[2]
      print(len(filecount))
      filecount = len(filecount)
      filecount = filecount + 1
      showvideo.record_video(createfolder + "/video" + str(filecount) +".mp4", duration=setStreamtime)
      print("Local: " + createfolder + "/video" + str(filecount) +".mp4")

    alertText = alertText + ". '" + datefolder + "/video" + str(filecount) + "'";
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
    pir.wait_for_no_motion()  
except mysql.connector.Error as error:
    print("Failed to insert record into table {}".format(error))
except KeyboardInterrupt:
    print("Exit!")
#    GPIO.cleanup()  
