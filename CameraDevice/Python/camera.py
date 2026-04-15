from picamzero import Camera
import os
from time import *
from datetime import *
import mysql.connector
from gpiozero import MotionSensor
import smtplib , shutil

dbconfig = mysql.connector.connect(
   host = "localhost",
   user = "loguser",
   password = "Test0880!",
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
  query = "select email from settings where id = 1"
  dbinfo.execute(query)
  enableEmail = dbinfo.fetchone()[0]
  dbconfig.commit()

  dbinfo = dbconfig.cursor(buffered=True)
  query = "select location from settings where id = 1"
  dbinfo.execute(query)
  choice = dbinfo.fetchone()[0]
  dbconfig.commit()

  dbinfo = dbconfig.cursor(buffered=True)
  query = "select sendemail from settings where id = 1"
  dbinfo.execute(query)
  sendEmail = dbinfo.fetchone()[0]
  dbconfig.commit()

  dbinfo = dbconfig.cursor(buffered=True)
  query = "select alerttext from settings where id = 1"
  dbinfo.execute(query)
  alertText = dbinfo.fetchone()[0]
  dbconfig.commit()

  print (enableEmail)
  print (choice)

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

    query = "insert into cameralogs(logtext) values ('Motion detected.')"
    dbinfo.execute(query)
    dbconfig.commit()
   
    if choice == 1:

      if not checkfolder:
        os.mkdir(createfolder)
      else:
        filecount = next(os.walk(createfolder))[2]
        print(len(filecount))
        filecount = len(filecount)
        filecount = filecount + 1
        showvideo.record_video(createfolder + "/video" + str(filecount) +".mp4", duration=5)
        print("Local: " + createfolder + "/video" + str(filecount) +".mp4")
     
    if choice == 2:
      if not checkfolder2:
        os.mkdir(createfolder2)
      else:
        print(createfolder2)
        filecount = next(os.walk(createfolder2))[2]
        print(len(filecount))
        filecount = len(filecount)
        filecount = filecount + 1
        showvideo.record_video(createfolder2 + "/video" + str(filecount) +".mp4", duration=5)
        print("GDrive: +" + createfolder2 + "/video" + str(filecount) +".mp4")
          
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