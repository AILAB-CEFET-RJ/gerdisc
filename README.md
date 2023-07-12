# gerdisc

This readme provides a step-by-step guide on how to clone the repository and run Docker Compose to set up and run the "gerdisc" application.

## Prerequisites

Before you begin, ensure that you have the following prerequisites installed on your machine:

- Docker: Version 20.10.0 or higher
- Git: Version 2.28.0 or higher
- Docker Compose: Version 1.27.0 or higher

## Clone the Repository

1. Open a terminal or command prompt.
2. Change your working directory to the location where you want to clone the repository.
3. Run the following command to clone the repository:

   ```bash
   git clone git@github.com:MLRG-CEFET-RJ/gerdisc.git
   ```

4. Wait for the repository to be cloned to your local machine.

## Run Docker Compose

1. Change your working directory to the root directory of the cloned repository.
2. Verify that you have the `docker-compose.yml` file in the root directory.
3. Open a terminal or command prompt in the root directory of the repository.
4. Run the following command to start the Docker Compose setup:

   ```bash
   docker-compose up -d
   ```

   This command starts the services defined in the `docker-compose.yml` file in detached mode (`-d` flag).

5. Wait for Docker Compose to download the necessary Docker images and start the containers.

## Verify the Setup

After Docker Compose has successfully started the containers, you can verify the setup by accessing the "gerdisc" application.

1. Open a web browser.
2. Enter `http://localhost` in the address bar.
3. If the "gerdisc" application has a web interface, you should see it loaded in your browser.
4. Follow any additional instructions provided in the application's documentation to complete the setup or configuration.

## Shutting Down

To stop and remove the containers created by Docker Compose, follow these steps:

1. Open a terminal or command prompt in the root directory of the repository.
2. Run the following command:

   ```bash
   docker-compose down
   ```

   This command stops and removes the containers defined in the `docker-compose.yml` file.

3. Wait for Docker Compose to stop and remove the containers.

## Additional Notes

- If you encounter any issues during the setup process, refer to the "gerdisc" application's documentation or troubleshooting guide.
- Make sure to read any additional instructions or configuration steps mentioned in the application's documentation.
- It's recommended to update the prerequisites and instructions as needed based on the specific application requirements.

That's it! You have now cloned the repository and successfully set up the "gerdisc" application using Docker Compose. Enjoy using the application!
