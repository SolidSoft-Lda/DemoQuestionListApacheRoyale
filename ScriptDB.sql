IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DemoListQuestion')
    CREATE DATABASE DemoListQuestion
GO

USE DemoListQuestion

DECLARE @IdQuestion INT

IF NOT EXISTS (SELECT * FROM sysobjects WHERE xtype = 'U' AND name = 'Choice')
    CREATE TABLE Choice
    (
        Id          INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
        Description VARCHAR(30) NOT NULL,
        Votes       INT NOT NULL
    )

IF NOT EXISTS (SELECT * FROM sysobjects WHERE xtype = 'U' AND name = 'Question')
    CREATE TABLE Question
    (
        Id          INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
        Description VARCHAR(100) NOT NULL,
        ImageURL    VARCHAR(200) NOT NULL,
        ThumbURL    VARCHAR(200) NOT NULL,
        PublishedAt DATETIME NOT NULL,
    )

IF NOT EXISTS (SELECT * FROM sysobjects WHERE xtype = 'U' AND name = 'QuestionChoice')
    CREATE TABLE QuestionChoice
    (
        IdQuestion  INT NOT NULL,
        IdChoice    INT NOT NULL,
        CONSTRAINT PK_QuestionChoice PRIMARY KEY (IdQuestion, IdChoice)
    )

IF NOT EXISTS (SELECT 1 FROM QuestionChoice) BEGIN
    INSERT INTO Choice (Description, Votes)
    VALUES ('SWIFT', 2048)

    INSERT INTO Choice (Description, Votes)
    VALUES ('Python', 1024)

    INSERT INTO Choice (Description, Votes)
    VALUES ('Objective-C', 512)

    INSERT INTO Choice (Description, Votes)
    VALUES ('Ruby', 256)
END

IF NOT EXISTS (SELECT 1 FROM Question)
    INSERT INTO Question (Description, ImageURL, ThumbURL, PublishedAt)
    VALUES ('Favourite programming language', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', GETDATE())

SELECT @IdQuestion = Id  FROM Question WHERE Description = 'Favourite programming language'

IF NOT EXISTS (SELECT 1 FROM QuestionChoice) BEGIN
    INSERT INTO QuestionChoice (IdQuestion, IdChoice)
    SELECT @IdQuestion, Id FROM Choice WHERE Description = 'SWIFT'

    INSERT INTO QuestionChoice (IdQuestion, IdChoice)
    SELECT @IdQuestion, Id FROM Choice WHERE Description = 'Python'

    INSERT INTO QuestionChoice (IdQuestion, IdChoice)
    SELECT @IdQuestion, Id FROM Choice WHERE Description = 'Objective-C'

    INSERT INTO QuestionChoice (IdQuestion, IdChoice)
    SELECT @IdQuestion, Id FROM Choice WHERE Description = 'Ruby'
END

