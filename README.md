# CameraDevice

The goal of this IT project was to record video clips of a specified length whenever a motion sensor or a magnetic contact switch was triggered. The project consists of two motion sensors and one magnetic contact switch that control two USB cameras.
An LCD display is also included to show information whenever an event occurs, such as motion detection. The recordings are automatically saved to a local hard drive and can optionally be uploaded to a cloud storage service. 

For cloud storage, I used Google Drive. Search online for the phrase **"How to set up Google Drive sharing in Linux"** to learn more about configuring Google Drive on Linux.
It is also possible to view or delete video recordings from both local storage and cloud storage using the Visual Studio C# application or a third-party application. 
In addition, email notifications can be sent to an email address of your choice. Search online for the phrase **"How to set up email notifications in Linux"** to learn more about configuring email notifications. In my case, I used a Google account.
 
### Visual Studio C# Project requirements
- .NET 9.0
-  C# language version 13.0

This Visual Studio C# project uses the **MySql.Data** package from Oracle Corporation, which was installed through the Visual Studio NuGet Package Manager. 
The package provides a .NET data provider for MySQL and enables the application to connect to, read from, and modify data stored in a MySQL database efficiently.

### Hardware used in this project.
- Raspberry Pi 5
- 2 usb cameras
- 2 PIR motion sensors
- Magnetic connector switch
- 4 leds
- 16x2 LCD display with I2C interface
  
The hardware components, including the USB camera, motion sensors, and magnetic contact switch, are connected to a Raspberry Pi 5 running Debian GNU/Linux 13 (Trixie). 
System functionality is controlled by a Python script, which handles event detection and initiates video recording when a motion sensor or magnetic contact switch is triggered.
The Python source code is located in the Python folder of this project. The project was developed and tested using Python 3.13.5.
In the reference installation, the Python application is stored in the directory **/home/camerauser/camerasystem.** The username **camerauser** is used on the Raspberry Pi 5 system 
and should be replaced if a different username is configured.

### USB camera.
<img width="202" height="182" alt="usbcamera" src="https://github.com/user-attachments/assets/17e0fe59-68d8-4e98-9dc2-6c02407fb6fc" />

In my case I used the opencv library for controlling the usb camera with python.

### Installation of the USB camera library

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
The HC-SR501 PIR (Passive Infrared) sensor was used as the motion detection sensor in this project. PIR sensors are commonly used 
in automation, surveillance, and security applications because they can detect movement by monitoring changes in infrared radiation within their field of view.

When motion is detected, the HC-SR501 generates a signal that is processed by the Raspberry Pi 5. This event can then trigger predefined actions, 
such as initiating video recording, updating the LCD display, or sending an email notification.

The connection between Raspberry PI5 and sensor motions.
- Both motion sensor's pin labelled VCC is connected to the 5V pin on the Raspberry Pi5. 
- Both motion sensor's pin labelled GND is connected to a ground pin on the Raspberry Pi5. 
- In my case motion sensor1's pin labelled OUT is connected to GPIO 12 on the Raspberry Pi5.
- In my case motion sensor2's pin labelled OUT is connected to GPIO 16 on the Raspberry Pi5.
  
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

The magnetic contact switch detects whether a door, window, or other monitored object is open or closed. 
When the switch changes state, the Raspberry Pi 5 detects the signal on GPIO 5 and can trigger predefined actions, 
such as starting a video recording, updating the LCD display, or sending an email notification.

### Library Installation for the Magnetic Contact Switch.

The magnetic contact switch uses the same Python library as the motion sensor. Therefore, no additional libraries are required specifically for the magnetic contact switch. 
Once the motion sensor library has been installed, it can also be used to read the state of the magnetic contact switch through the Raspberry Pi GPIO pins.

### Leds

I have used 3 yellow leds acting as sensor indicators and 1 rgb (red and green color) led as a indicator for the Raspberry PI's condition.

Connection between Raspberry PI5 and the leds.
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

### Library installation for the LCD display.

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
camera1 int,
camera2 int,
primary key(id)
);
```
The MySQL version 11.8.6-MariaDB-0+deb13u1 acts as my database server for this project.

#### Settings that can be changed for the python script.
- Enable email notification.
- Change email address.
- The recording length for video.
- Enable cloud share.
- Choose if sensor motion 1 and sensor motion2 are enabled or disabled.
- Choose if the magnetic connector switch is enabled or disabled.

The system configuration settings can be managed through the Visual Studio C# application, which is compatible with the Windows 11 operating system.
A systemd service named camerasystem.service has been configured on the Raspberry Pi 5. The service monitors configuration changes and automatically 
restarts the Python application whenever one or more settings are updated. This ensures that all changes are applied without requiring a manual restart of the Python program.
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
When developing applications, it is considered a security best practice to protect sensitive information such as passwords, API keys, and authentication tokens. 
In this project, environment variables are used to store these credentials instead of embedding them directly in the source code. 
This approach improves security, simplifies maintenance, and reduces the risk of exposing sensitive data.

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
This project also contains a PHP file called **updatesql**, which functions as a command-line (CLI) application. 
Its purpose is to delete old rows from the **cameralogs** table while retaining the most recent entries based on the value stored in **$row[6]**.
In addition, PHP must be installed on the operating system where the script is executed.
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
