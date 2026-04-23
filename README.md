# CameraDevice





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
