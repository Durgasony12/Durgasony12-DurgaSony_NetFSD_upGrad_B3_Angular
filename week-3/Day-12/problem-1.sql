-- create database in sql server
USE EventDb


CREATE TABLE Userinfo
(
	EmailId varchar(50) PRIMARY KEY,
	UserName varchar(50) NOT NULL,
	[Role] varchar(10) NOT NULL 
	CHECK(Role IN('Admin','Participant')),
	[Password] varchar NOT NULL CHECK(len(Password) BETWEEN 6 AND 20)

);


---INSERT INTO UserInfo values("sony@gmail.com","Durga","Admin","Sony123");
---INSERT INTO UserInfo values("jeeva@gmail.com","jeevani","Admin","jeeva123");
---INSERT INTO UserInfo values("sria@gmail.com","Sria","Participant","sria123");
---INSERT INTO UserInfo values("rishi@gmail.com","Rishitha","Participant","rishi123");

CREATE TABLE EventDetails
(
	EventId int PRIMARY KEY,
	EventName  varchar(50) NOT NULL,
	EventCategory varchar(50) NOT NULL,
	EventDate DATETIME Not Null,
	Description varchar(100) Null,
	Status varchar(10) CHECK(Status IN('Active','In-Active'))
);

CREATE TABLE SpeakerDetails
(
	SpeakerId	int  PRIMARY KEY,
	SpeakerName varchar(50) NOT NULL
);



CREATE TABLE SessionInfo
(
	SessionId	int PRIMARY KEY,
	EventId	int,
	SessionTitle varchar(50) NOT NULL, 
	SpeakerId	int  NOT NULL,
	Description	varchar(100) NULL,
	SessionStart datetime NOT NULL,
	SessionEnd	datetime NOT NULL,
	SessionUrl	varchar(20),
	FOREIGN KEY(EventId)
	REFERENCES EventDetails(EventId),
	FOREIGN KEY(SpeakerId)
	REFERENCES SpeakerDetails(SpeakerId)
);

CREATE TABLE ParticipantEventDetails 
(
	Id	int PRIMARY KEY,
	ParticipantEmailId	varchar(50) NOT NULL, 
	EventId	int,
	SessionId int,
	IsAttended	bit,
	FOREIGN KEY(ParticipantEmailId)
	REFERENCES Userinfo(EmailId),
	FOREIGN KEY(EventId)
	REFERENCES EventDetails(EventId),
	FOREIGN KEY(SessionId)
	REFERENCES SessionInfo(SessionId)
);






