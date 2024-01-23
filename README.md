# Chrome-Extension-BE
##
## Introduction
This API is designed to simply handle file uploads to a server and downloads from a server
##
## Features
- Upload Files: Easily upload files to the server with a simple POST request.
- Download Files: Retrieve specific files from the server using a GET request.
- File Metadata: Access file information from a database such as file size and URL, file path, etc.

##
The live link is at [http://fortunate3d-001-site1.atempurl.com/](http://fortunate3d-001-site1.atempurl.com/)
##
For more detailed information on the API endpoints and usage, refer to the full API documentation at [DOCUMENTATION.md](Chrome-Extension-BE/DOCUMENTATION.md)

##
## Installation on your local machine
1. **Clone the repository to your local machine:**
```sh
$ git clone https://github.com/FortunateOmonuwa/FileStorage.API.git
```
2. **Change to the project directory:**
```sh
$ cd FileStorage.API
```
3. **Open the appsettings.json file in the project and add your database connection string to the "ConnectionStrings" section.**
```sh
"ConnectionStrings": {
  "AppConnection": "Data Source=YourDataSource/Server;Initial Catalog=YourDbName;User Id=Db user id if you have one;Password=Your password if you have an id",
}
```
4. **Apply Database Migration and Update your Database.**
- For Visual Studio, run these commands
```sh
  $ add-migration initial-migration
  $ update-database
```
- For Visual Studio Code, run these commands
```sh
$ dotnet ef migrations add InitialCreate
$ dotnet ef database update
```
These commands will create an initial database schema for you based on the data model(s)
##
5. **Run the application using dotnet run for Visual Studio code or clicking on the play icon on Visual Studio**
 ```sh
 $ dotnet run
 ```
