------------
-- Forums -- THIS IS SOMEWHAT OUTDATED --
------------
-- Board /Category_1		(SET, DELETE: ADMIN)
--- Forum /Sub-Category_1	(SET, DELETE: ADMIN)
---- Thread /Topic_1		(SET: ANY | DELETE: ADMIN)
------ Post_1 (initial)	(SET: OWNER | HIDE-DELETE: ADMIN)
------ Post_2			(SET: ANY | HIDE: OWNER | HIDE-DEL.: ADMIN)
------ Post_n
------------

--
-- Database "ForumDB".
--

-- Default type is "Regular", only an Admin can promote /demote users.
CREATE TABLE ForumDB.Users (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Name VARCHAR2(25) NOT NULL UNIQUE ,
	Pass VARCHAR2(50) NOT NULL ,
	Email VARCHAR2(255) NOT NULL UNIQUE ,
	JoinedAt DATETIME NOT NULL ,
	RoleID INT NOT NULL DEFAULT 1,
	PRIMARY KEY (Id) ,
	CONSTRAINT FK_Users_Roles
		FOREIGN KEY (RoleID)
		REFERENCES Roles (Id)
) ENGINE = InnoDB;

-- Admin > Moderator > Regular
CREATE TABLE ForumDB.Roles (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Name VARCHAR(25) NOT NULL UNIQUE ,
	PRIMARY KEY (Id)
) ENGINE = InnoDB;

-- Board / Category
CREATE TABLE ForumDB.Boards (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Name VARCHAR(100) NOT NULL UNIQUE ,
	ForumID INT NOT NULL ,
	PRIMARY KEY (Id) ,
	CONSTRAINT FK_Boards_Forums FOREIGN KEY (ForumID) REFERENCES Boards (Id)
) ENGINE = InnoDB;

-- Forum / Sub-Category
CREATE TABLE ForumDB.Forums (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Name VARCHAR(100) NOT NULL UNIQUE ,
	Description VARCHAR(255) NOT NULL UNIQUE ,
	BoardID INT NOT NULL ,
	PRIMARY KEY (Id) ,
	CONSTRAINT FK_Forums_Boards FOREIGN KEY (BoardID) REFERENCES Boards (Id)
) ENGINE = InnoDB;

-- Thread / Topic
CREATE TABLE ForumDB.Threads (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Name VARCHAR(255) NOT NULL UNIQUE ,
	CreatedAt DATETIME NOT NULL ,
	ForumID INT NOT NULL ,
	CreatedByID INT NOT NULL ,
	PRIMARY KEY (Id) ,
	CONSTRAINT FK_Threads_Forums FOREIGN KEY (ForumID) REFERENCES Forums (Id) ,
	CONSTRAINT FK_Threads_Users FOREIGN KEY (CreatedByID) REFERENCES Users (Id)
) ENGINE = InnoDB; -- "Thread" size limit: <= 100_K posts per Thread; make new Thread instead -> in app, check count before.

CREATE TABLE ForumDB.Posts (
	Id INT(8) UNSIGNED NOT NULL AUTO_INCREMENT ,
	Content VARCHAR(60000) NOT NULL ,
	CreatedAt DATETIME NOT NULL ,
	ThreadID INT NOT NULL UNIQUE ,
	CreatedByID INT NOT NULL ,
	PRIMARY KEY (Id) ,
	CONSTRAINT FK_Roles_Users FOREIGN KEY (ThreadID) REFERENCES Threads (Id) ,
	CONSTRAINT FK_Posts_Users FOREIGN KEY (CreatedByID) REFERENCES Users (Id)
) ENGINE = InnoDB; -- "Content" size: if users want to post book volumes, let them.


-- TODO: add unique constraints like in the "contacts" mssql example. 
