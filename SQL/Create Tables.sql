--
-- Database "Forums".
--

-- Default type is "Regular", only an Admin can promote /demote users.
CREATE TABLE forums.Users (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Name VARCHAR2(25) NOT NULL UNIQUE ,
	Pass VARCHAR2(50) NOT NULL ,
	Email VARCHAR2(255) NOT NULL UNIQUE ,
	Reg_Date DATETIME NOT NULL ,
	UserType_ID INT NOT NULL DEFAULT 1,
	PRIMARY KEY (Id) ,
	CONSTRAINT FK_Users_UserType
		FOREIGN KEY (UserType_ID)
		REFERENCES UserType (Id)
) ENGINE = InnoDB;

-- Admin > Moderator > Regular
CREATE TABLE forums.UserType (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Name VARCHAR2(25) NOT NULL UNIQUE ,
	PRIMARY KEY (Id)
) ENGINE = InnoDB;

-- Forum / Board / Category
CREATE TABLE forums.Boards (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Name VARCHAR2(255) NOT NULL UNIQUE ,
	Description VARCHAR2(255) NOT NULL UNIQUE ,
	Reg_By_Admin_User_ID INT NOT NULL ,
	PRIMARY KEY (Id) ,
	CONSTRAINT FK_Boards_Admin_Users FOREIGN KEY (Reg_By_Admin_User_ID) REFERENCES Users (Id)
) ENGINE = InnoDB; -- ONLY "Admin" TYPE Users CAN BE HERE !  How to reference with a constraint like that ?

-- Thread / Topic
CREATE TABLE forums.Threads (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Name VARCHAR2(255) NOT NULL UNIQUE ,
	Reg_Date DATETIME NOT NULL ,
	Board_ID INT NOT NULL ,
	Reg_By_User_ID INT NOT NULL ,
	PRIMARY KEY (Id) ,
	CONSTRAINT FK_Threads_Boards FOREIGN KEY (Board_ID) REFERENCES Boards (Id) ,
	CONSTRAINT FK_Threads_Users FOREIGN KEY (Reg_By_User_ID) REFERENCES Users (Id)
) ENGINE = InnoDB; -- Limit "Thread" count: no reason to store more than 1.000 posts per Thread; make new Thread instead.

CREATE TABLE forums.Posts (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Content VARCHAR(60000) NOT NULL ,
	Reg_Date DATETIME NOT NULL ,
	Thread_ID INT NOT NULL UNIQUE ,
	Reg_By_User_ID INT NOT NULL ,
	PRIMARY KEY (Id) ,
	CONSTRAINT FK_UserType_Users FOREIGN KEY (Thread_ID) REFERENCES Threads (Id) ,
	CONSTRAINT FK_Posts_Users FOREIGN KEY (Reg_By_User_ID) REFERENCES Users (Id)
) ENGINE = InnoDB; -- "Content" size: if users want to post book volumes, let them.

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

