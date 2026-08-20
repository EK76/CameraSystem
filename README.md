# CameraDevice

The goal with this IT project project was to record videos with a certain length when a motion sensor or magnetic connector switch was triggered. This project contains of two motion sensors and a magnetic connector switch
that control the usb camera. There is also a LCD display that show info when a event occur (e.g motion detection). The recordings are saved automatically to local hard drive and optionally to cloud share. For cloud share I have used Google drive. Search online with the phrase 
*"How to setup Google drive share in linux"* to learn more about to setup Google drive in linux. 

It is also possible to watch or delete these video recordings both from local storage and
from cloushare with the Visual Studio C# project or with a 3rd-party application. It is even possible to send notifications to a email adress of your choosing. Search online with the phrase 
*"How to setup email notifications in linux"* to learn more about to setup email notifications. In my case I used a Google account.
 
### Requirements for this Visual Studio C# project.
- .NET 9.0
-  C# language version 13.0

I have also installed one external plugin trough Visual Studio NuGet Package Manager for this Visaul Studio C# project, which is MySql.Data from Oracle Corporation.
MySql.Data makes it easier to read from and make changes to MySQL database when using Visual Studio.

### List over the hardware for this project.
- Raspberry Pi 5
- Usb camera
- 2 PIR motion sensors
- Magnetic connector switch
- 4 leds
- 16x2 LCD display with I2C interface
  
Usb camera, motion sensors and magnetic connector switch are connected to Raspberry PI 5, which have Debian GNU/Linux 13 (trixie) version installed. A python script makes it for example possible to create the video recordings, 
when a motion sensor or a magnetic connection switch is trigged. 
The python code can be found (located) at the folder Python within this project. I used python version 3.13.5 for this project. In my case the python script is located at **/home/camerauser/camerasystem** and I have chosen
**camerauser** as my username for Raspberry Pi 5 device.

### USB camera.
<img width="202" height="182" alt="usbcamera" src="https://github.com/user-attachments/assets/17e0fe59-68d8-4e98-9dc2-6c02407fb6fc" />

In my case I used the opencv library for controlling the usb camera with python.

### The installation of library for using usb camera.

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

The connection between Raspberry PI5 and sensor motions.
- Both motion sensor's pin labelled VCC is connected to the 5V pin on the Raspberry Pi5. 
- Both motion sensor's pin labelled GND is connected to a ground pin on the Raspberry Pi5. 
- In my case motion sensor1's pin labelled OUT is connected to GPIO 12 on the Raspberry Pi5.
- in my cate motion sensor2's pin labelled OUT is connected to GPIO 16 on the Raspberry Pi5.
  
### The installation of library for the motion sensor.

#### Raspberry Pi OS (Recommended).
```
sudo apt update
sudo apt install python3-gpiozero
```
#### Using pip (For other OS or virtual environments).
```
sudo pip3 install gpiozero

```
### Magnetic connector switch

<img width="150" height="150" alt="magnetic switch" src="https://github.com/user-attachments/assets/730fab61-e872-4f0d-8429-35c5d90dd72e" />

The connection between Raspberry PI5 and magnetic connector switch
- One of the magnetic connector switch connection is connected to GPIO 5 on the Raspberry Pi5.
- The other connection is connected to a ground pin on the Raspberry Pi5.

### The installation of library for the magnetic connector switch.

Magnetic connector switch uses the same the library as motion sensor.

### Leds

I have used 3 yellow leds acting as sensor indicators and 1 rgb (red and green color) led as a indicator for the Raspberry PI's condition.

The connection between Raspberry PI5 and the leds.
- The yellow leds are connected to the to GPIO21, GPIO 23 and GPIO 24 on the Raspberry Pi5.
- The RGB red are connected to GPIO17 (red) and GPIO27 (green) on the Raspberry Pi5.
- The leds other connection is connected to ground on the Raspberry Pi5.

### The installation of library for the leds.

Leds are using the same the library as motion sensor and magnetic connector switch.

### LCD display
<img width="300" height="120" alt="lcddisplay2" src="https://github.com/user-attachments/assets/9430baf6-e434-4600-8474-941897cef9af" />
<img width="300" height="120" alt="lcddisplay1" src="https://github.com/user-attachments/assets/3e0e12c3-9224-4cb3-8161-25d2c61f2e7c" />

The LCD display used in this project is 16x2 with I2C protocol connection. 16x2 means it contains of two rows, which both can contain of 16 characters.
I2C stands for Inter-Integrated Circuit. It is a simple two-wire communication system in this case between the LCD display and Raspberry Pi5.

 #### Information about I2C protocol's function.
- Uses two shared signal lines: SDA (Serial Data Line) to send data, and SCL (Serial Clock Line) to keep the timing synced.
- Operates with a controller (master) device that directs traffic and a peripheral (slave) device that responds.
- Each slave device has a unique address. The master calls this address so only the correct part listens.
- Built-in acknowledgment bits tell the master if data arrived safely.

The connection between Raspberry PI5 and the LCD display.
- The LCD display's SDA pin is connected to SDA pin (GPIO2) on the Raspberry Pi5.
- The LCD display's SCL pin is connected to SCL pin on (GPIO3) on the Raspberry Pi5.
- The LCD display's VCC pin is connected to 5V pin on the Raspberry Pi5.
- The LCD display's GND pin is connected to ground on the Raspberry Pi5.

Before you can use this LCD display, you must activate I2C.
- Type ***sudo raspi-config*** and press Enter in a terminal window.
- Use the arrow keys to select 3 Interface Options or 5 Interfacing Options (depending on your OS version) and press Enter.
- Choose I2C and select Yes to enable the ARM I2C interface.
- Select Ok and then Finish to exit the configuration menu.
- Reboot your Raspberry Pi 5 using ***sudo reboot*** for changes to take effect.

### Installation of library for the LCD display.

```
sudo pip3 install RPLCD smbus2
```
### Database

This project contains of two mysql tables.
- cameralogs – where the alert text is saved to when for example a motion sensor is triggeed.
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
motionchoice1 int,
motionchoice2 int,
openstatus int,
primary key(id)
);
```
The MySQL version 11.8.6-MariaDB-0+deb13u1 acts as my database server for this project.

#### The settings that can be changed how the python script is run.
- Enable email notification.
- Change email address.
- The recording length for video.
- Enable cloud share.
- Choose if sensor motion 1 and sensor motion2 are enabled or disabled.
- Choose if the magnetic connector switch is enabled or disabled.

You can modify these setting with the Visual Studio C# project.
The Visual Studio C# project works only with computers that run under Windows 11 operating system. 

I have created a service which I have named camerasystem.service that when one or more of these changes are changed, it restarts the python program.
```
[Unit]
Description=Control Cameradevice.
After=gdrive.service

[Service]
Type=simple
ExecStartPre=/bin/sleep 30
EnvironmentFile=/etc/cameradevice/cameradevice.conf
WorkingDirectory=/home/camerauser/camerasystem/
User=camerauser
ExecStart=/usr/bin/python3 /home/camerauser/camerasystem/camera.py
Restart=on-abort

[Install]
WantedBy=multi-user.target
```
Both my mysql password and email token for the pyhton script are located at /etc/controldevice/controldevice.conf file.
You should always consider to hide sensative information, for example password. On way to achieve this is to use environment variables,
as I have done.

To use this cameradevice service without sudo password from Visual Studio C# project, I created a simple bash script, **camerarestart.sh**
```
sudo systemctl restart cameradevice
```
As the next step I put this line at bottom of /etc/sudoers file with the help of sudo visudo.
```
camerauser ALL=(ALL) NOPASSWD: /home/camerauser/camerasystem/camerarestart.sh
```
The same procedure is also done if you wan't to shutdown the device from Visual Studio C# project, then you can create a bashscript  **camerashutdown.sh**
```
sudo shutdown now
```
Put this line at bottom of /etc/sudoers file with the help of sudo visudo.
```
camerauser ALL=(ALL) NOPASSWD: /home/camerauser/camerasystem/camerarshutdown.sh
```
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
This project also cointain of php file (updatesql) that works like a cli application, which purpose is to delete all rows for the table cameralogs, except the newest rows according to the value **$row[6]**
In order for updatesql can run as cli application you must put **#!/usr/bin/env php** as the first row in updatesql and make the file runnable with **chmod 777 updatesql**.  You also must install php to your
operatings system.

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
You can use crontab to run this updatesql for example every night at 2 o'clock, by adding this line to rhe crontab config file. <br />
**0 2 * * *  /home/camerauser/camerasystem/updatetable**

To use this updatesql without sudo password, put this line at bottom of /etc/sudoers file with the help of sudo visudo.
```
camerauser ALL=(ALL) NOPASSWD: /home/camerauser/camerasystem/updatesql
```

### Picture about this project.
<img width="1442" height="671" alt="Screenshot 2026-04-26 174605" src="https://github.com/user-attachments/assets/6c0a1456-8bd8-4dc8-99d2-a5981a2dae00" />
