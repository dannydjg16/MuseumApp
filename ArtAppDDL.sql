-- DROP TABLE [ArtApp].[Artwork]
CREATE TABLE [ArtApp].[Artwork] (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    FileName NVARCHAR(max) NOT NULL,
    YearCreated INT,
    Title NVARCHAR(150) NOT NULL,
    Description NVARCHAR(max),
    Likes INT,
    ArtistID INT NOT NULL FOREIGN KEY REFERENCES [ArtApp].[Artist](ID),
    MediumID INT FOREIGN KEY REFERENCES [ArtApp].[ArtType](ID),
    LocationNow INT FOREIGN KEY REFERENCES [ArtApp].[Location](ID)
);

Select * from [ArtApp].[Artwork]

-- Add UserID who added Artwork to User Table
ALTER TABLE [ArtApp].[Artwork]
ADD ArtWorkAdderID INT
--------------------------------------------------------------------------------------


-- DROP TABLE [ArtApp].[Artist]
CREATE TABLE [ArtApp].[Artist] (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Born NVARCHAR(50),
    Died NVARCHAR(50),
    BornLocation NVARCHAR(100),
    Bio NVARCHAR (500),
    PictureUrl NVARCHAR(250)
);

Select * from [ArtApp].[Artist]
--------------------------------------------------------------------------------------


-- DROP TABLE [ArtApp].[User]
CREATE TABLE [ArtApp].[User] (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    EMAIL NVARCHAR(50) UNIQUE NOT NULL,
    Name NVARCHAR(50),
    FromLocation NVARCHAR(100)
);

Select * from [ArtApp].[User]

-- Add Profile Picture URL to User Table
ALTER TABLE [ArtApp].[User]
ADD ProfilePicURL NVARCHAR(max)
--------------------------------------------------------------------------------------


-- DROP TABLE [ArtApp].[Location]
CREATE TABLE [ArtApp].[Location] (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    LocationName NVARCHAR(150) NOT NULL,
    Description NVARCHAR(max) NOT NULL,
    LocationURL NVARCHAR(max) NOT NULL,
    TypeID INT FOREIGN KEY REFERENCES [ArtApp].[LocationType](ID)
);

Select * from [ArtApp].[Location]
--------------------------------------------------------------------------------------


-- DROP TABLE [ArtApp].[LocationType]
CREATE TABLE [ArtApp].[LocationType] (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150)
);

Select * from [ArtApp].[LocationType]
--------------------------------------------------------------------------------------


-- DROP TABLE [ArtApp].[Likes]
CREATE TABLE [ArtApp].[Likes] (
    UserID INT NOT NULL FOREIGN KEY REFERENCES [ArtApp].[User](ID),
    ArtID INT NOT NULL FOREIGN KEY REFERENCES [ArtApp].[Artwork](ID)
);

Select * from [ArtApp].[Likes]

-- <<<<<<<<>>>>>>>>>> Add Composite Primary Key <<<<<<<<>>>>>>>>>>  --
-- ALTER TABLE [ArtApp].[Likes] DROP CONSTRAINT PK_UserIDArtID
ALTER TABLE [ArtApp].[Likes]
ADD CONSTRAINT PK_UserIDArtID
PRIMARY KEY (UserID, ArtID);

--------------------------------------------------------------------------------------


-- DROP TABLE [ArtApp].[ArtType]
CREATE TABLE [ArtApp].[ArtType] (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150),
    Description NVARCHAR(300)
);

Select * from [ArtApp].[ArtType]


-- All Tables Easy Select 
Select * from [ArtApp].[Artwork]
Select * from [ArtApp].[Artist]
Select * from [ArtApp].[User]
Select * from [ArtApp].[Location]
Select * from [ArtApp].[LocationType]
Select * from [ArtApp].[Likes]
Select * from [ArtApp].[ArtType]