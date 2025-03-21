#!/bin/bash
apt update -y
apt install -y unzip

# Install .NET SDK (LTS version, defaults to /home/ubuntu/.dotnet/)
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --channel 9.0

# Symlink to /usr/local/bin for system-wide access
sudo ln -sf /home/ubuntu/.dotnet/dotnet /usr/local/bin/dotnet