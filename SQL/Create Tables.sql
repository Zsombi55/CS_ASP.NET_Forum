--
-- Database "Forums".
--
-- basic table aspects:
--

CREATE TABLE forums.Users (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Name VARCHAR2(25) NOT NULL UNIQUE ,
	Pass VARCHAR2(50) NOT NULL ,
	Email VARCHAR2(255) NOT NULL UNIQUE ,
	Reg_Date DATETIME NOT NULL ,
	PRIMARY KEY (Id)
) ENGINE = InnoDB;

-- Admin > Moderator > Regular
CREATE TABLE forums.UserType (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Name VARCHAR2(25) NOT NULL UNIQUE ,
	User_ID INT NOT NULL ,
	PRIMARY KEY (Id) ,
	CONSTRAINT FK_UserType_Users
		FOREIGN KEY (User_ID)
		REFERENCES Users (Id)
) ENGINE = InnoDB;

-- Forum / Board / Category
CREATE TABLE forums.Boards (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Name VARCHAR2(255) NOT NULL UNIQUE ,
	Description VARCHAR2(255) NOT NULL UNIQUE ,
	PRIMARY KEY (Id)
) ENGINE = InnoDB;

-- Thread / Topic
CREATE TABLE forums.Threads (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Name VARCHAR2(255) NOT NULL UNIQUE ,
	Reg_Date DATETIME NOT NULL ,
	Board_ID INT NOT NULL ,
	Reg_By_User_ID INT NOT NULL ,
	PRIMARY KEY (Id) ,
	CONSTRAINT FK_Threads_Boards FOREIGN KEY (Board_ID) REFERENCES Boards (Id) ,
	CONSTRAINT FK_UserType_Users FOREIGN KEY (Reg_By_User_ID) REFERENCES Users (Id)
) ENGINE = InnoDB;

CREATE TABLE forums.Posts (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Content NVARCHAR2(255) NOT NULL UNIQUE ,
	Reg_Date DATETIME NOT NULL ,
	Thread_ID INT NOT NULL ,
	Reg_By_User_ID INT NOT NULL ,
	PRIMARY KEY (Id) ,
	CONSTRAINT FK_UserType_Users FOREIGN KEY (Thread_ID) REFERENCES Threads (Id) ,
	CONSTRAINT FK_UserType_Users FOREIGN KEY (Reg_By_User_ID) REFERENCES Users (Id)
) ENGINE = InnoDB;

------------
-- Forums --
------------
-- Forum /Board /Category_1 (SET, DELETE: ADMIN)
--- Thread /Topic_1 (SET: ANY | DELETE: ADMIN)
----- Post_1 (SET: OWNER | HIDE-DELETE: ADMIN)
----- Post_2 (SET: ANY | HIDE: OWNER | HIDE-DEL.: ADMIN)
----- Post_n
--
--- Thread /Topic_n
-- Forum /Board /Category_n
------------

