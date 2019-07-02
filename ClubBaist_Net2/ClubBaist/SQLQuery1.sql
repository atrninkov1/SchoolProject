CREATE DATABASE ClubBAIST

GO

USE ClubBAIST

GO

DROP TABLE StandingTeeTimeDetails
DROP TABLE TeeTimeDetails
DROP TABLE Handicap
DROP TABLE Member
DROP TABLE MembershipLevel
DROP TABLE TeeTime
DROP TABLE StandingTeeTime

CREATE TABLE TeeTime(
TeeTimeID INT NOT NULL PRIMARY KEY,
ScheduledTime DATETIME,
Canceled BIT,
Carts INT
)

CREATE TABLE MembershipLevel(
MembershipLevelID INT NOT NULL PRIMARY KEY,
Description VARCHAR(180) NOT NULL,
CanGolfBefore TIME NOT NULL,
CanGolfAfter TIME NOT NULL
)

CREATE TABLE Member(
MemberID INT NOT NULL PRIMARY KEY,
FirstName VARCHAR(50),
LastName VARCHAR(50),
Username VARCHAR(180) NOT NULL,
CanGolf BIT NOT NULL,
CanMakeStandingTeeTime BIT NOT NULL,
Password VARCHAR(512) NOT NULL,
Email VARCHAR(150),
AnnualMembership MONEY NOT NULL,
IsMember BIT NOT NULL,
MembershipLevelID INT NOT NULL FOREIGN KEY REFERENCES MembershipLevel(MembershipLevelID)
)

CREATE TABLE TeeTimeDetails(
TeeTimeID INT NOT NULL FOREIGN KEY REFERENCES TeeTime(TeeTimeID),
MemberID INT NOT NULL FOREIGN KEY REFERENCES Member(MemberID),
CONSTRAINT PK_StandingTeeTime PRIMARY KEY(TeeTimeID, MemberID)
)

CREATE TABLE StandingTeeTime(
StandingTeeTimeID INT NOT NULL PRIMARY KEY,
StartDate DATETIME,
EndDate DATETIME,
TeeTimeTime TIME,
Approved BIT
)

CREATE TABLE StandingTeeTimeDetails(
StandingTeeTimeID INT NOT NULL FOREIGN KEY REFERENCES StandingTeeTime(StandingTeeTimeID),
MemberID INT NOT NULL FOREIGN KEY REFERENCES Member(MemberID),
CONSTRAINT PK_StandingTeeTimeDetails PRIMARY KEY(StandingTeeTimeID, MemberID)
)

CREATE TABLE Handicap
(
	HandicapID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	MemberID INT NOT NULL FOREIGN KEY REFERENCES Member(MemberID),
	DatePlayed DATE NOT NULL,
	Hole1Score INT NOT NULL,
	Hole2Score INT NOT NULL,
	Hole3Score INT NOT NULL,
	Hole4Score INT NOT NULL,
	Hole5Score INT NOT NULL,
	Hole6Score INT NOT NULL,
	Hole7Score INT NOT NULL,
	Hole8Score INT NOT NULL,
	Hole9Score INT NOT NULL,
	Hole10Score INT NOT NULL,
	Hole11Score INT NOT NULL,
	Hole12Score INT NOT NULL,
	Hole13Score INT NOT NULL,
	Hole14Score INT NOT NULL,
	Hole15Score INT NOT NULL,
	Hole16Score INT NOT NULL,
	Hole17Score INT NOT NULL,
	Hole18Score INT NOT NULL,
	Handicap FLOAT NOT NULL
)

GO

DROP PROCEDURE GetBookedTeeTimes

GO

CREATE PROCEDURE GetBookedTeeTimes(@Day DATE = NULL)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1
    IF @Day IS NULL
        RAISERROR('GetBookedTeeTimes - Required parameter: @Day', 16, 1)
    ELSE
        BEGIN
            SELECT tt.TeeTimeID, ScheduledTime FROM TeeTime tt RIGHT OUTER JOIN TeeTimeDetails ON tt.TeeTimeID = TeeTimeDetails.TeeTimeID
			WHERE DAY(ScheduledTime) = DAY(@Day) AND Canceled = 0 AND NOT EXISTS (SELECT MemberID FROM TeeTime INNER JOIN TeeTimeDetails ON TeeTimeDetails.TeeTimeID = TeeTime.TeeTimeID
			 WHERE ScheduledTime = tt.ScheduledTime)
			GROUP BY tt.TeeTimeID, ScheduledTime HAVING COUNT(TeeTimeDetails.MemberID) = 4

        IF @@ERROR = 0
            SET @ReturnCode = 0
        ELSE
            RAISERROR('GetBookedTeeTimes - SELECT error: TeeTime table', 16, 1)
        END
    RETURN @ReturnCode


GO

DROP PROCEDURE GetAllMembers

GO

CREATE PROCEDURE GetAllMembers
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1
    BEGIN
        SELECT
         MemberID, FirstName, LastName, Email
        FROM Member
    IF @@ERROR = 0
            SET @ReturnCode = 0
        ELSE
            RAISERROR('GetAllMembers - SELECT error: member table', 16, 1)
    END
RETURN @ReturnCode

GO

DROP PROCEDURE ScheduleTeeTime

GO

CREATE PROCEDURE ScheduleTeeTime(@TeeTimeDate DATETIME = NULL, @MemberID INT = NULL, @Carts INT = NULL)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1
    DECLARE @TeeTimeID INT
    SELECT @TeeTimeID = ISNULL(MAX(TeeTimeID), 0) + 1 FROM TeeTime
    BEGIN
        IF @TeeTimeDate IS NULL
            RAISERROR('ScheduleTeeTime - @TeeTimeDate',16,1)
        ELSE
        IF @MemberID IS NULL
            RAISERROR('ScheduleTeeTime - @MemberID',16,1)	
		ELSE	
		IF (SELECT  COUNT(tt.ScheduledTime) FROM TeeTime tt WHERE tt.ScheduledTime = @TeeTimeDate) >= 4
			RAISERROR('ScheduleTeeTime - cannot have more than 4 members per tee time',16,1)
		ELSE
        IF @MemberID IS NULL
            RAISERROR('ScheduleTeeTime - @Carts',16,1)
        ELSE
            INSERT INTO TeeTime (TeeTimeID, ScheduledTime, Canceled, Carts)VALUES
            (@TeeTimeID, @TeeTimeDate, 0, @Carts)
            INSERT INTO TeeTimeDetails(TeeTimeID, MemberID) VALUES
            (@TeeTimeID, @MemberID)
        IF @@ERROR = 0
            SET @ReturnCode = 0
        ELSE
            RAISERROR('ScheduleTeeTime - Insert error: member or details table', 16, 1)
    END
RETURN @ReturnCode

GO

DROP PROCEDURE CreateStandingTeeTime

GO

CREATE PROCEDURE CreateStandingTeeTime(@TeeTimeTime TIME(7) = NULL, @StartDate DATETIME = NULL, @EndDate DATETIME = NULL,
@Member1ID INT = NULL)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1    
    DECLARE @TeeTimeID INT
    SELECT @TeeTimeID = ISNULL(MAX(StandingTeeTimeID), 0) + 1 FROM StandingTeeTime
    DECLARE @Member1Role VARCHAR(180)
    SELECT @Member1Role = MembershipLevel.Description FROM Member INNER JOIN MembershipLevel ON Member.MembershipLevelID = MembershipLevel.MembershipLevelID WHERE MemberID=@Member1ID
    IF @TeeTimeTime IS NULL
        RAISERROR('CreateStandingTeeTime - @TeeTimeTime',16,1)
    ELSE
    IF @StartDate IS NULL
        RAISERROR('CreateStandingTeeTime - @StartDate',16,1)
    ELSE    
    IF @EndDate IS NULL
        RAISERROR('CreateStandingTeeTime - @EndDate',16,1)
    ELSE
    IF @Member1ID IS NULL
        RAISERROR('CreateStandingTeeTime - @Member1ID',16,1)
    ELSE
    IF @Member1Role != 'Shareholder'
        RAISERROR('CreateStandingTeeTime - At least one member must be a shareholder',16,1)
	ELSE
	IF (SELECT  COUNT(stt.StartDate) FROM StandingTeeTime stt WHERE stt.StartDate = @StartDate AND stt.EndDate= @EndDate AND stt.TeeTimeTime = @TeeTimeTime) >= 4
		RAISERROR('CreateStandingTeeTime - cannot have more than 4 members per tee time',16,1)
    ELSE
    BEGIN
        INSERT INTO StandingTeeTime
        (StandingTeeTimeID,StartDate,EndDate,TeeTimeTime, Approved) VALUES
        (@TeeTimeID,@StartDate,@EndDate,@TeeTimeTime, 0)
        INSERT INTO StandingTeeTimeDetails
        (MemberID,StandingTeeTimeID) VALUES
        (@Member1ID, @TeeTimeID)
        IF @@ERROR = 0
            SET @ReturnCode = 0
        ELSE
            RAISERROR('CreateStandingTeeTime - Insert error: member or details table', 16, 1)
    END
RETURN @ReturnCode

GO

DROP PROCEDURE GetTeeTimeByMember

GO

CREATE PROCEDURE GetTeeTimeByMember(@MemberID INT = NULL)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1    
    IF @MemberID IS NULL
        RAISERROR('GetTeeTimeByMember - @MemberID',16,1)
    ELSE
    BEGIN
        SELECT TeeTime.TeeTimeID
      ,ScheduledTime, Carts FROM TeeTime INNER JOIN TeeTimeDetails ON TeeTime.TeeTimeID = TeeTimeDetails.TeeTimeID WHERE TeeTimeDetails.MemberID = @MemberID AND Canceled = 0
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('GetTeeTimeByMember - SELECT error: TeeTime or details table', 16, 1)
    END
RETURN @ReturnCode

GO

DROP PROCEDURE GetTeeTimeByDateAndMember

GO

CREATE PROCEDURE GetTeeTimeByDateAndMember(@MemberID INT = NULL, @Date DATE = NULL)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1    
    IF @MemberID IS NULL
        RAISERROR('GetTeeTimeByDateAndMember - @MemberID',16,1)		
    IF @Date IS NULL
        RAISERROR('GetTeeTimeByDateAndMember - @Date',16,1)
    ELSE
    BEGIN
        SELECT TeeTime.TeeTimeID
      ,ScheduledTime, Carts FROM TeeTime INNER JOIN TeeTimeDetails ON TeeTime.TeeTimeID = TeeTimeDetails.TeeTimeID WHERE TeeTimeDetails.MemberID = @MemberID AND Canceled = 0 AND 
	  CONVERT(DATE,TeeTime.ScheduledTime,23) = @Date
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('GetTeeTimeByMember - SELECT error: TeeTime or details table', 16, 1)
    END
RETURN @ReturnCode

GO

DROP PROCEDURE GetScoresByDateAndMember

GO

CREATE PROCEDURE GetScoresByDateAndMember(@MemberID INT = NULL, @Date DATE = NULL)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1    
    IF @MemberID IS NULL
        RAISERROR('GetScoresByDateAndMember - @MemberID',16,1)		
    IF @Date IS NULL
        RAISERROR('GetScoresByDateAndMember - @Date',16,1)
    ELSE
    BEGIN
        SELECT DatePlayed, Handicap FROM Handicap WHERE Handicap.MemberID = @MemberID AND CONVERT(DATE,DatePlayed,23) = @Date
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('GetTeeTimeByMember - SELECT error: TeeTime or details table', 16, 1)
    END
RETURN @ReturnCode

GO

DROP PROCEDURE CancelTeeTime

GO

CREATE PROCEDURE CancelTeeTime(@TeeTimeID INT = NULL)
AS
    DECLARE @ReturnCode INT
    SET @ReturnCode = 1    
    IF @TeeTimeID IS NULL
        RAISERROR('CancelTeeTime - @TeeTimeID',16,1)
    ELSE
    BEGIN
        UPDATE TeeTime SET Canceled = 1 WHERE TeeTime.TeeTimeID = @TeeTimeID
    IF @@ERROR = 0
        SET @ReturnCode = 0
    ELSE
        RAISERROR('CancelTeeTime - UPDATE error: TeeTime table', 16, 1)
    END
RETURN @ReturnCode

GO

DROP PROCEDURE Login

GO

CREATE PROCEDURE Login(@Username VARCHAR(180) = NULL, @Password VARCHAR(512) = NULL)
AS
IF @Username IS NULL
	RAISERROR('Login - @Username is null',16,1)
ELSE
	IF @Password IS NULL
		RAISERROR('Login - @Password is null',16,1)
	ELSE
		BEGIN
			SELECT Username, MembershipLevel.Description AS Role, IsMember, MemberID FROM Member INNER JOIN MembershipLevel 
			ON Member.MembershipLevelID = MembershipLevel.MembershipLevelID WHERE Member.Username = @Username AND Member.Password = @Password
		END
	IF @@ERROR != 0
		RAISERROR('Login - SELECT Error', 16, 1)

GO

DROP PROCEDURE GetStandingRequests

GO

CREATE PROCEDURE GetStandingRequests 
AS
BEGIN
	/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [StandingTeeTimeID]
      ,[StartDate]
      ,[EndDate]
      ,[TeeTimeTime]
      ,[Approved]
  FROM [ClubBaist].[dbo].[StandingTeeTime]
END

GO

DROP PROCEDURE ApproveStandingRequest

GO

CREATE PROCEDURE ApproveStandingRequest (@StandingTeeTimeID INT = NULL)
AS
IF @StandingTeeTimeID IS NULL
	RAISERROR('ApproveStandingRequest - @StandingTeeTimeID is null',16,1)
BEGIN
	UPDATE StandingTeeTime SET Approved = 1 WHERE @StandingTeeTimeID = StandingTeeTimeID
END

GO

DROP PROCEDURE UpdateTeeTime

GO

CREATE PROCEDURE UpdateTeeTime(@TeeTimeID INT = NULL, @Carts INT)
AS
BEGIN
	UPDATE TeeTime SET Carts=@Carts WHERE TeeTimeID = @TeeTimeID
END

GO

DROP PROCEDURE AddPlayerHandicap

GO

CREATE PROCEDURE AddPlayerHandicap(@MemberID INT = NULL, @DatePlayed DATE = NULL, @Hole1 INT = 0, @Hole2 INT = 0,@Hole3 INT = 0, @Hole4 INT = 0,
@Hole5 INT = 0, @Hole6 INT = 0,@Hole7 INT = 0, @Hole8 INT = 0,@Hole9 INT = 0, @Hole10 INT = 0,@Hole11 INT = 0, @Hole12 INT = 0,@Hole13 INT = 0, 
@Hole14 INT = 0,@Hole15 INT = 0, @Hole16 INT = 0,@Hole17 INT = 0, @Hole18 INT = 0, @Handicap FLOAT = NULL) 
AS
BEGIN
IF @MemberID IS NULL OR @DatePlayed   IS  NULL OR  @Hole1    IS  NULL OR  @Hole2    IS  NULL OR @Hole3    IS  NULL OR  @Hole4    IS  NULL OR 
@Hole5    IS  NULL OR  @Hole6    IS  NULL OR @Hole7    IS  NULL OR  @Hole8    IS  NULL OR @Hole9    IS  NULL OR  @Hole10 IS  NULL OR @Hole11 IS  NULL OR  @Hole12 IS  NULL 
OR @Hole13 IS  NULL OR @Hole14 IS NULL OR @Hole15 IS  NULL OR  @Hole16    IS  NULL OR @Hole17    IS  NULL OR  @Hole18 IS  NULL OR @Handicap iS NULL
	RAISERROR('Please provide valid values for all of the fields',16,1)
ELSE
IF EXISTS (SELECT HandicapID FROM Handicap WHERE DatePlayed = @DatePlayed AND MemberID = @MemberID)
	RAISERROR('Score already entered for this date', 16 ,1)
ELSE
IF NOT EXISTS(SELECT MemberID FROM Member WHERE MemberID = @MemberID)
	RAISERROR('Invalid member ID please enter the ID of an existing member',16,1)
ELSE
	INSERT INTO Handicap(DatePlayed, MemberID, Hole1Score, Hole2Score, Hole3Score,Hole4Score,Hole5Score, Hole6Score, Hole7Score, Hole8Score, Hole9Score, Hole10Score,
	Hole11Score, Hole12Score, Hole13Score, Hole14Score, Hole15Score, Hole16Score, Hole17Score, Hole18Score, Handicap) VALUES
	(@DatePlayed, @MemberID, @Hole1, @Hole2,@Hole3, @Hole4,
	@Hole5, @Hole6,@Hole7, @Hole8,@Hole9, @Hole1,@Hole11, @Hole12,@Hole13, 
	@Hole14,@Hole15, @Hole16,@Hole17, @Hole18, @Handicap)
END

GO

INSERT INTO TeeTime
(TeeTimeID, ScheduledTime, Canceled, Carts) VALUES
(1, '01-01-2019 07:00:00', 0, 2)

INSERT INTO TeeTime
(TeeTimeID, ScheduledTime, Canceled, Carts) VALUES
(2, '01-01-2019 07:00:00', 0, 1)

INSERT INTO TeeTime
(TeeTimeID, ScheduledTime, Canceled, Carts) VALUES
(3, '01-01-2019 07:00:00', 0, 4)

INSERT INTO TeeTime
(TeeTimeID, ScheduledTime, Canceled, Carts) VALUES
(4, '01-01-2019 07:00:00', 0, 2)

INSERT INTO TeeTime
(TeeTimeID, ScheduledTime, Canceled) VALUES
(5, '01-01-2019 07:07:00', 0)

INSERT INTO TeeTime
(TeeTimeID, ScheduledTime, Canceled, Carts) VALUES
(6, '01-01-2019 07:07:00', 0, 0)

INSERT INTO TeeTime
(TeeTimeID, ScheduledTime, Canceled, Carts) VALUES
(7, '01-01-2019 07:07:00', 0, 3)

INSERT INTO MembershipLevel
(MembershipLevelID, Description, CanGolfBefore, CanGolfAfter)VALUES
(1, 'Shareholder', '12:00:00','12:00:00')

INSERT INTO Member
(MemberID, FirstName, LastName,Username,CanGolf,CanMakeStandingTeeTime,Password, Email, AnnualMembership, MembershipLevelID, IsMember)VALUES
(1, 'John', 'Doe','jdoe1',1,1,'flower', 'jdoe@Baist.ca', 1000, 1, 1)


INSERT INTO Member
(MemberID, FirstName, LastName,Username,CanGolf,CanMakeStandingTeeTime,Password, Email, AnnualMembership, MembershipLevelID, IsMember)VALUES
(2, 'Jane', 'Doe','jdoe2',1,1,'flower', 'jdoe@Baist.ca', 1000, 1, 1)


INSERT INTO Member
(MemberID, FirstName, LastName,Username,CanGolf,CanMakeStandingTeeTime,Password, Email, AnnualMembership, MembershipLevelID, IsMember)VALUES
(3, 'Sebas', 'Doe','sdoe1',1,1,'flower', 'jdoe@Baist.ca', 1000, 1, 1)


INSERT INTO Member
(MemberID, FirstName, LastName,Username,CanGolf,CanMakeStandingTeeTime,Password, Email, AnnualMembership, MembershipLevelID, IsMember)VALUES
(4, 'Doug', 'Doe','ddoe1',1,1,'flower', 'jdoe@Baist.ca', 1000, 1, 1)


INSERT INTO Member
(MemberID, FirstName, LastName,Username,CanGolf,CanMakeStandingTeeTime,Password, Email, AnnualMembership, MembershipLevelID, IsMember)VALUES
(5, 'Ian', 'Doe','idoe1',1,1,'flower', 'jdoe@Baist.ca', 1000, 1, 0)

INSERT INTO TeeTimeDetails
(TeeTimeID, MemberID) VALUES
(1,1)

INSERT INTO TeeTimeDetails
(TeeTimeID, MemberID) VALUES
(1,2)

INSERT INTO TeeTimeDetails
(TeeTimeID, MemberID) VALUES
(1,3)

INSERT INTO TeeTimeDetails
(TeeTimeID, MemberID) VALUES
(1,4)

INSERT INTO TeeTimeDetails
(TeeTimeID, MemberID) VALUES
(2,1)

INSERT INTO TeeTimeDetails
(TeeTimeID, MemberID) VALUES
(2,2)

INSERT INTO TeeTimeDetails
(TeeTimeID, MemberID) VALUES
(3,3)

INSERT INTO TeeTimeDetails
(TeeTimeID, MemberID) VALUES
(3,4)