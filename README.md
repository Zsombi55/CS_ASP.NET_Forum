# CS_ASP.NET_Forum
FTIT C# ASP .NET last project: a __Web Forum__ web application.

The primary purpose of this project is providing me with a learning experience by creating something. This is a demo, just a basic system with relatively minimal features. Visual design is not a focus.

## Features:
* user accounts:
  - [x] e-mail address : used for registration;
  - [x] user name : unique alphanumeric string, max 10-20 characters;
  - [x] login password : private alphanumeric string, max 10-20 characters, hashed;
  - signed in "Settings":
    - [x] user name, e-mail address (used at registration), rating, join date & time;
	- [x] view user profile picture;
	- [ ] add/ change user profile picture (THE code is mostly there for remote, eg. MS Azure cloud server side, file storage, there is just no viable connection data, so it doesn't work; this was not really planned so it is just placeholder for possible future functionality);

* depending on User privileges, perform "Create Read Update Delete" operations for:
  - [ ] board-s, forum-s : CRUD .. admin only ("CR" works for any user);
  - [ ] thread-s : CR .. anyone; U .. owner, mod, admin; D .. admin; lock against new posts .. mod ("CR" works for any user);
  - [ ] post-s : CR .. anyone; U .. owner, mod, admin; D .. owner, mod, admin; mark "bad" & hide .. mod, admin ("CR" works for any user);
  - [x] Read any content : everyone, even non-registered or non-logged-in "guest" users.
  - [ ] private correspondence between registered users, & or high privilege user restricted discussion areas (eg. administrator & moderator only forums);

* post content:
  - [x] directly inside : text.

* basic content information:
  - boards:
	- [x] list of forums by title;
	- [ ] set as the home View instead of a list of all the Forums;
  - forums:
    - [x] list of threads by title;
	- per thread item:
	  - [x] created by user name (with user rating);
	  - [x] creation time or date (even if it contains only the 1st);
	  - [ ] modification date & time;
	  - [x] status markers: open / locked (DOESN'T actually do anything but it does show up);
	  - [x] post count (minus the 1st, original);
  - threads:
    - [ ] site-map links from "Home" to "current forum" (eg.: Home > Forums-Index > Board-Name > Forum-Name);
    - [x] title; created by; date or time of creation;
	- [ ] is it open or locked (against expansion/ modification until unlocked) (WIP, shows the marker text but doesn't actually allow different behavior, eg.: no posting in closed threads);
    - [ ] page count & links;
	- [x] list of posts, newest ones appearing at the end;
	- [x] "New Post" Button at the bottom of the last thread post;
	- [ ] basic "new post" area at the bottom of each thread page;
  - posts:
	- [x] created by "info-box" : user name, avatar picture (if exists), other user-set public information;
	- [x] content;
	- [x] last post edit time or date;
	- [ ] "reply" to post button.

## Made with:
* Mostly written using C# , .NET Core 5, Entity Framework Core; using MVC patern ;

* Database is SQLite, manually managed with DB Browser (SQLite).
