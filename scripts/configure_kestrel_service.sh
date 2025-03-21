#!/bin/bash
# Build the app from source
/usr/local/bin/dotnet publish /var/www/carpricecalc/CarPriceApi.csproj -c Release -o /var/www/carpricecalc/publish

# Set permissions
chown -R www-data:www-data /var/www/carpricecalc
chmod -R 755 /var/www/carpricecalc

# Create the systemd service file
cat <<EOF > /etc/systemd/system/kestrel-carpricecalc.service
[Unit]
Description=Car Price Calculator Web App powered by Kestrel
After=network.target

[Service]
WorkingDirectory=/var/www/carpricecalc/publish
ExecStart=/usr/local/bin/dotnet /var/www/carpricecalc/publish/CarPriceApi.dll
Restart=always
RestartSec=10
SyslogIdentifier=carpricecalc
User=www-data
Environment=ASPNETCORE_ENVIRONMENT=Production

[Install]
WantedBy=multi-user.target
EOF

systemctl daemon-reload
systemctl enable kestrel-carpricecalc.service