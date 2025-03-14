#!/bin/bash
# Create the systemd service file for Kestrel
cat <<EOF > /etc/systemd/system/kestrel-carpricecalc.service
[Unit]
Description=Car Price Calculator Web App powered by Kestrel
After=network.target

[Service]
WorkingDirectory=/var/www/carpricecalc
ExecStart=/usr/bin/dotnet /var/www/carpricecalc/CarPriceConsole.dll
Restart=always
RestartSec=10
SyslogIdentifier=carpricecalc
User=www-data
Environment=ASPNETCORE_ENVIRONMENT=Production

[Install]
WantedBy=multi-user.target
EOF

# Reload systemd to pick up the new service file
systemctl daemon-reload

# Enable the service to start on boot
systemctl enable kestrel-carpricecalc.service
