#!/bin/bash
# Update package list and install dependencies
apt update -y
apt install -y unzip

# Install .NET runtime (LTS version)
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --channel 9.0 --install-dir /root/.dotnet

export PATH=$PATH:/root/.dotnet