# CS_ASP.NET_Forum
FTIT C# ASP .NET last project: a __Web Forum__ web application.

The primary purpose of this project is providing me with a learning experience by creating something potentially useful. This is a demo, just a basic system with minimal functionality.

## Basic aspects and idea:
* user accounts:
  - [x] e-mail address : used for registration;
  - [ ] user name : unique alphanumeric string, max 10-20 characters (for now it is the same as the e-mail address);
  - [x] login password : private alphanumeric string, max 10-20 characters, hashed;

* [ ] depending on User privileges, perform "Create Read Update Delete" operations for:
  - board-s, forum-s : CRUD .. admin only;
  - thread-s : CR .. anyone; U .. owner, mod, admin; D .. admin; lock against new posts .. mod;
  - post-s : CR .. anyone; U .. owner, mod, admin; D .. owner, mod, admin; mark "bad" & hide .. mod, admin;
  - Read any content : everyone, even non-registered or non-logged-in "guest" users.

* [ ] post content:
  - directly inside : text.

* [ ] basic content information:
  - [x] boards:
	- list of forums by title;
  - [ ] forums:
    - list of threads by title;
	- per thread item:
	  - created by user;
	  - creation time or date (even if it contains only the 1st);
	  - open / locked marker;
	  - post count (minus the 1st, original);
  - [ ] threads:
    - site-map links from "Home" to "current forum" (eg.: Home > Forums-Index > Board-Name > Forum-Name);
    - title; created by; date or time of creation;
	- is it open or locked (against expansion/ modification until unlocked);
    - page count & links;
	- list of posts by title;
	- basic "new post" area at the bottom of each thread page (new ones appear at the end of the last page);
  - [ ] posts:
	- created by "info-box" : user name, avatar picture (if exists), other user-set public information;
	- content;
	- last post edit time or date;
	- "reply" link/button.

## Made with:
* Mostly written using C# , .NET Core 5, Entity Framework Core; using MVC patern ;

* Database is SQLite, manually managed with DB Browser (SQLite).
