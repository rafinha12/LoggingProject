# LoggingProject
This project contains a netcore simple logging framework and a login simulation to show the usability of the framework.

#Introduction
The project consists of a console login application that register the logs using the LogginFramework also included in the project.

With the LoggingFramework you can register logs on files and on the console with 4 types of levels: Info, Warning, Error and Fatal.

A log consists in a timestamp, a session ID, a error code and a message.

The login example consist in a predefined login application whose the only active user is "Admin" with the password "1234", the user have 3 attemps to login with these credentials; otherwise the applitacion will be closed. For this example, the incorrect login generate a warning, the end of the execution due a max attemps reached generate a Error, a correct login generates a Info and an application error generates a Fatal.The logging output is a file call, log.txt.

#Needs 
NetCore (https://dotnet.microsoft.com/download)




