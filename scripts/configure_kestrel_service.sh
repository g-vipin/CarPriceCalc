#!/bin/bash

# Build the app from source
dotnet publish /var/www/carpricecalc/CarPriceApi.csproj -c Release -o /var/www/carpricecalc/publish

# Create the systemd service file for Kestrel
cat <<EOF > /etc/systemd/system/kestrel-carpricecalc.service
[Unit]
Description=Car Price Calculator Web App powered by Kestrel
After=network.target

[Service]
WorkingDirectory=/var/www/carpricecalc
ExecStart=/root/.dotnet/dotnet /var/www/carpricecalc/CarPriceApi.dll
Restart=always
RestartSec=10
SyslogIdentifier=carpricecalc
User=www-data
Environment=ASPNETCORE_ENVIRONMENT=Production

[Install]
WantedBy=multi-user.target
EOF

# Reload systemd and enable the service
systemctl daemon-reload
systemctl enable kestrel-carpricecalc.service