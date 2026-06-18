# CameraDevice

The goal with this IT project project was to record videos with a certain length when a motion sensor was triggered. This project contains of two motion sensors. 
The recordings are saved automatically to local hard drive and optionally to cloud share with help of a usb camera. For cloud share I have used Google drive. Search online with the phrase 
*"How to setup Google drive share in linux"* to learn more about to setup Google drive in linux. 

It is also possible to watch or delete these video recordings from local storage or 
from cloushare with the Visual Studio C# project or with a 3rd-party application. It is even possible to send notifications to a email adress of your choosing. Search online with the phrase 
*"How to setup email notifications in linux"* to learn more about to setup email notifications. In my case I used a Google account.
 
### Requirements for this Visual Studio C# project.
- .NET 9.0
-  C# language version 13.0

### List over the hardware for this project.
- Raspberry Pi 5
- Usb camera
- 2 PIR motion sensors

Both camera and sensor motions are connected to Raspberry PI 5, which have Debian GNU/Linux 13 (trixie) version installed. A python script makes it for example possible to create the video recordings, when a motion sensor is trigged. The python code can be found (located) at the folder Python within this project. I used python version 3.13.5 for this project.

### The installation of library for using usb camera.

In my case I used the opencv library for controlling the usb camera with python.
How to install the opencv library for python.

#### Raspberry Pi OS (Recommended).
```
sudo apt update
sudo apt install python3-opencv
```
#### Using pip (For other OS or virtual environments):
```
sudo pip3 install python3-opencv-python
```
### PIR motion sensor

<img width="143" height="123" alt="image" src="https://github.com/user-attachments/assets/d85f2d60-32a4-4a5e-932e-370d10e6ed53" />

I used the this PIR HC-SR501 as my sensor motion. At the core of many smart automation devices lies the powerful PIR Sensor. 
It stands for Passive Infrared Sensor and relies on infrared sensing technology to detect the motion of objects.

The following schema below this text shows how Raspberry Pi 5 and motion sensor are connected to each other.
<img width="362" height="257" alt="image" src="https://github.com/user-attachments/assets/b0f1249e-f78d-47fb-a6ee-357365dfe7b3" />

The connection between Raspberry PI5 and sensor motions.
- Both motion sensor's pin labelled VCC is connected to the 5V pin on the Raspberry Pi5. 
- both motion sensor's pin labelled GND is connected to a ground pin on the Raspberry Pi5. 
- In my case motion sensor1's pin labelled OUT is connected to GPIO 12 on the Raspberry Pi5.
- in my cate motion sensor2's pin labelled OUT is connected to GPIO 16 on the Raspberry Pi5.

### The installation of motion sensor library.

#### Raspberry Pi OS (Recommended).
```
sudo apt update
sudo apt install python3-gpiozero
```
#### Using pip (For other OS or virtual environments).
```
sudo pip3 install gpiozero
```
### This project contains of two mysql tables.

- cameralogs – where the alert text is saved to whenfor example a motion sensor is triggeded.
- settings – where the settings are stored.

To create the tables, follow the instructions below.
```
create database camerasystem;
use camerasystem;

create table cameralogs(
id int not null auto_increment,
logtext varchar(250),
datecreated datetime default (current_timestamp),
primary key(id)
);

create table settings(
id int not null auto_increment,
email varchar(20),
drive varchar(20),
sendemail varchar(250),
stream int,
datechanged timestamp not null default current_timestamp on update current_timestamp,
numberofrows int,
motionchoice int,
primary key(id)
);
```
The MySQL version 11.8.6-MariaDB-0+deb13u1 acts as my database server for this project.

#### The settings that can be changed how the python script is run.
- Enable email notification.
- Change email address.
- The recording length for video.
- Enable cloud share.
- Choose if only sensor motion 1 or sensor motion2 or both are enabled.

You can make these setting with the Visual Studio C# project.
The Visual Studio C# project works only with computers that run under Windows 11 operating system. 

I have created a service which I have named camerasystem.service that when one or more of these changes are changed, it restarts the python program.
```
[Unit]
Description=Control Cameradevice.
After=network.target

[Service]
Type=simple
EnvironmentFile=/etc/cameradevice/cameradevice.conf
WorkingDirectory=/home/camerauser/camerasystem/
User=camerauser
ExecStart=/usr/bin/python3 /home/camerauser/camerasystem/camera.py
Restart=on-aboirt

[Install]
WantedBy=multi-user.target
```
Both my mysql password and email token for the pyhton script are located at /etc/controldevice/controldevice.conf file.
You should always consider to hide sensative information, for example password. On way to achieve this is to use environment variables.
I also created another service, gdrive.service that controls the cloudshare, in my case Google drive.
```
[Unit]
Description=Google Drive
After=network.target
StartLimitIntervalSec=0

[Service]
Type=simple
User=camerauser
Restart=always
RestartSec=10
ExecStart=/usr/bin/rclone mount gDrive: /home/camerauser/gdrive \
--allow-other \
--vfs-cache-mode writes
ExecStop=fusermount -u /home/camerauser/gdrive

[Install]
WantedBy=multi-user.target
```
This project also cointain of php file (updatesql) that works like a cli application, which purpose is to delete all rows for the table cameralogs, except the newest rows according to the value $row[6]
In order for updatesql can run as cli application you must put #!/usr/bin/env php as the first row in updatesql and make the file runnable with chmod 777 updatesql.  You also must install php for example

```
sudo apt install php php-cli php-fpm
```
My php version is 8.4.21 .

Content of the updatesql file.
```
#!/usr/bin/env php
<?php
$hostname = "localhost";
$username = "loguser";
$password = getenv('sqlpass');
$db = "camerasystem";
$dbconnect=mysqli_connect($hostname,$username,$password,$db);

$query = mysqli_query($dbconnect, "select * from settings where id = 1")
or die (mysqli_error($dbconnect));
$row = mysqli_fetch_row($query);

mysqli_query($dbconnect, "delete from cameralogs where id not in (select id from(select id from cameralogs order by id desc limit ".$row[6]." )info)")
or die (mysqli_error($dbconnect));
?>
```
You can use crontab to run this updatesql for example every night at 2 o'clock. <br />
**0 2 * * *  /home/camerauser/camerasystem/updatetable**

I have also installed one external plugin trough Visual Studio NuGet Package Manager for this Visaul Studio C# project, which is MySql.Data from Oracle Corporation.
MySql.Data makes it easier to read from and make changes to MySQL database when using Visual Studio.

### Picture about this project.

<img width="1442" height="671" alt="Screenshot 2026-04-26 174605" src="https://github.com/user-attachments/assets/6c0a1456-8bd8-4dc8-99d2-a5981a2dae00" />
