#!/bin/bash

# Change to the working directory of your Saga service
cd /home/rdasa/gerdisc/

# Start the Saga service using Docker Compose
docker-compose -f docker-compose.yaml up -d
