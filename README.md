# CameraDevice

The goal with this Visual Studio C# (Github) project was to record a video with certain length when a motion sensor was triggered. The recordings are saved automatically to local hard drive. You can also optionally 
- Copy the same recording at same time when the sensor motion is trigged to a cloud share. For cloud share I have used Gdrive. Search online with the phrase "How to setup Gdrive share in linux" to learn more about to setup Gdrive in linux.
- Send notifications to a email adress of your choosing. Search online with the phrase "How to setup email notifications in linux" to learn more about to setup email notifications In my case I used a Google account.

Both camera and sensor motion are connected to Raspberry PI 5, which have Debian GNU/Linux 13 (trixie) version installed. A python script makes it for example possible to create the recordings, when a motion sensor is trigged.

The python code can be found (located) at the folder Python within this project.

List over the hardware for this project.
- Raspberry Pi 5
- Camera module 3
- Motion sensor

  Camera module 3

  Motion sensor

This project contains of two mysql tables, which are

- cameralogs – where the alert text is stored.
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

There are some settings, that you can change
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


Two pictures about this GitHub project.





How to clone this repository with git. https://github.com/EK76/CameraSystem.git
If you discover any fault or inaccurate information, feel free to contact me trough epost address: ken.ekholm@live.com

