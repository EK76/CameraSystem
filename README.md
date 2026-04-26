# CameraDevice

The goal with this Visual Studio C# (Github) project was to record a video with certain length when a motion sensor was triggered. The recordings are saved automatically to local hard drive. You can also optionally 
- Copy the same recording at same time when the sensor motion is trigged to a cloud share. For cloud share I have used Gdrive. Search online with the phrase "How to setup Gdrive share in linux" to learn more about to setup Gdrive in linux.
- Send notifications to a email adress of your choosing. Search online with the phrase "How to setup email notifications in linux" to learn more about to setup email notifications In my case I used a Google account.

Both camera and sensor motion are connected to Raspberry PI 5, which have Debian GNU/Linux 13 (trixie) version installed. A python script makes it for example possible to create the recordings, when a motion sensor is trigged.

The python code can be found (located) at the folder Python within this project.

### List over the hardware for this project.
- Raspberry Pi 5
- Camera module 3
- Motion sensor

### Camera module 3

<img width="126" height="119" alt="cameramodule3" src="https://github.com/user-attachments/assets/83a743a1-d3f6-4641-ba1c-f902c450003d" />

Camera Module 3 comes with an improved 12MP IMX708 Quad Bayer sensor and features a High Dynamic Range mode.
The following schema below this text shows how Raspberry Pi 5 and Camera Module 3 are connected to each other using a 15-22pin FPC cable. The MIPI-csi connector of the Raspberry Pi 5 is 22pin, while the Camera Module 3 uses a 15pin connector.

<img width="338" height="146" alt="cameraschema" src="https://github.com/user-attachments/assets/35b0accc-21f2-4893-b123-261b108a4a0d" />

In my case I used the picamzero library for controlling the Camera Module 3 with python.
How to install the picamzero library for python.

#### Raspberry Pi OS (Recommended):
```
sudo apt update
sudo apt install python3-python3-picamzero
```
#### Using pip (For other OS or virtual environments):
```
sudo pip3 install picamzero
```
### Motion sensor

<img width="143" height="123" alt="image" src="https://github.com/user-attachments/assets/d85f2d60-32a4-4a5e-932e-370d10e6ed53" />

The following schema below this text shows how Raspberry Pi 5 and Motion sensor are connected to each other.
<img width="362" height="257" alt="image" src="https://github.com/user-attachments/assets/b0f1249e-f78d-47fb-a6ee-357365dfe7b3" />
The connection between Raspberry PI5 and sensor motion.
- Motion sensors pin labelled pin VCC to the 5V pin on the Raspberry Pi5. 
- Motion sensors pin labelled GND to a ground pin on the Raspberry Pi5. 
- Motion sensors pin labelled OUT to GPIO 4  on the Raspberry Pi5.

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

- cameralogs – where the alert text is saved to the when motion sensor is triggeded.
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
alerttext varchar(250),
sendemail varchar(250),
stream int,
datecreated datetime default (current_timestamp),
primary key(id)
);
```
#### There are some settings, that you can change
- Enable email notification.
- Change email address.
- The recording length for video.
- Enable cloud share.
- Alert text when motion sensor is trigged.

When one or more of these changes are made, a service is run that restart the python program, that I have created and in my case named it to camerasystem.service

```
[Unit]
Description=Camera System
After=multi-user.target

[Service]
Type=simple
ExecStart=python3 /home/camerauser/camerasystem/camera.py
Restart=on-abort

[Install]
WantedBy=multi-user.target
```
You can make these setting with both a Visual Studio C# App and trough web browser with help of php. PHP files can be found (located) at the folder Homepage.
You can also view the recordings located at local hard drive, check alert texts and delete recordings Delete recordings work only with Visual Studio C# App.

I have also installed obe external plugin trough Visual Studio NuGet Package Manager when I developed the Visual Studio C# application, which is MySql.Data from Oracle Corporation.
MySql.Data makes it easier to read from and make changes to MySQL database when using Visual Studio.


### Two pictures about this GitHub project.

##### Visual Studio C# verion.
<img width="1442" height="671" alt="Screenshot 2026-04-26 174605" src="https://github.com/user-attachments/assets/6c0a1456-8bd8-4dc8-99d2-a5981a2dae00" />

##### Web version.
<img width="897" height="1031" alt="Screenshot 2026-04-26 151416" src="https://github.com/user-attachments/assets/150805b1-0444-44fc-831e-5135bcdc5c59" />




You can clone this repository with git by using https://github.com/EK76/CameraSystem.git.
If you discover any fault or inaccurate information, feel free to contact me trough epost address: ken.ekholm@live.com

