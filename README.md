# CS_ASP.NET_Forum
FTIT C# ASP .NET final project: a __Web Forum__ web application.

## Basic aspects and idea:
* user accounts:
  - [x] e-mail address : used for registration;
  - [x] user name : unique alphanumeric string, max 10-20 characters;
  - [x] login password : private alphanumeric string, max 10-20 characters, hashed;

* [ ] depending on User privileges, perform "Create Read Update Delete" operations for:
  - board-s, forum-s : CRUD .. admin only;
  - thread-s : CR .. anyone; U .. owner, mod, admin; D .. admin; lock against new posts .. mod;
  - post-s : CR .. anyone; U .. owner, mod, admin; D .. owner, mod, admin; mark "bad" & hide .. mod, admin.

* [ ] post content:
  - directly inside : text.

* [ ] showing basic information in the listings:
  - boards: 
	- title of newest thread;
	- 
  - which user created it (thread, post);
  - when was it created;
  - what is its title;
  - which user added the newest content to it (eg.: who made the latest post in the thread);
  - when was the new content added (1st post's creation date is the same as the thread's);
  - is it open or locked (against expansion/ modification until unlocked).

## Advanced aspects and idea:
* user accounts:
  - e-mail notifications (eg.: post quoted, getting post/thread replies, account suspension, etc.);
  - user name: no special characters, no vulgar /crass words (english);
  - portrait : a small image, approx max 125-250 px ? , the "avatar" of a user, in threads connected to "posts" next to the user name.

* any user should be able to list and access any other user's _public threads_ and _posts_.

* admins & mods : suspend /ban user account activities/ access for varying periods of time (eg.: cannot post for 30 seconds, OR cannot log in for 1 week).

* post content:
  - directly inside : not too lagre images (img, png, jpg, gif);
  - file attachments : not too large files (single files or packages like: zip, rar).

## MAYBE aspects:
* allow to be part of the "post" : embedded video, webm.

## Made with:
* Mostly written using C# , .NET Core 5, Entity Framework Core; using MVC patern ;
* Database is SQLite, manually managed with DB Browser (SQLite).
