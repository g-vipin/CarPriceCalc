#!/bin/bash
# Install .NET runtime
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
bash dotnet-install.sh --channel LTS

# Ensure unzip is installed
yum install -y unzip