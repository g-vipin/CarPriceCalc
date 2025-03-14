#!/bin/bash
# Start the Kestrel service
systemctl start kestrel-carpricecalc.service

# Check if the service is active
if systemctl is-active --quiet kestrel-carpricecalc.service; then
  echo "Kestrel service started successfully."
else
  echo "Failed to start Kestrel service." >&2
  exit 1
fi
