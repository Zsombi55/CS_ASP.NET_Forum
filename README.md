# CS_ASP.NET_Forum
FTIT C# ASP .NET final project: a __Web Forum__ web application.

Currently there are 2 projects/ solutions: "NC5MvcIdentitySqliteWebApp" and "MyWebForum". They are (/will be) largely the same, with the only difference being the way "Thread content" and "Posts" are handled. For example, in the first all text entries are Posts the 1st of which in a Thread is a mandatory element; while in the latter a Thread's content is an integral part of the Thread itself, not just an attached Post.

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
  - boards:
	- list of forums by title;
	- thread count within;
	- per forum item:
	  - latest thread by title;
	  - created by user;
	  - time or date of latest post (even if it contains only the 1st);
  - forums:
    - list of threads by title;
	- per thread item:
	  - created by user;
	  - creation time or date (even if it contains only the 1st);
	  - total content word count;
	  - view page count with link directly to latest page of the thread (containing the latest post);
	  - open / locked marker;
	  - post count (minus the 1st, original);
	  - view count (minus the owner if logged in, else all is counted, even guest visits);
	  - date or time of latest post;
	  - name of latest post creator (even if it only has the 1st);
  - threads:
    - site-map links from "Home" to "current forum" (eg.: Home > Forums-Index > Board-Name > Forum-Name);
    - title; created by; date or time of creation;
	- is it open or locked (against expansion/ modification until unlocked);
    - page count & links;
	- list of posts by title;
	- basic "new post" area at the bottom of each thread page (new ones appear at the end of the last page);
  - posts:
	- created by "info-box" : user name, avatar picture (if exists), other user-set public information;
	- content;
	- last post edit time or date;
	- "report" link/ button to notify site moderators (mods) of some infraction;
	- "reply" link/button.

## Advanced aspects and idea:
* user accounts:
  - e-mail notifications (eg.: post quoted, getting post/thread replies, account suspension, etc.);
  - user name: no special characters, no vulgar /crass words (english);
  - portrait : a small image, approx max 125-250 px ? , the "avatar" of a user, in threads connected to "posts" next to the user name.

* any user should be able to list and access any other user's threads, posts and a short profile summary.

* admins & mods :
  - set/ mark threads & posts as important or "sticky" or "pinned";
  - suspend /ban user account activities/ access for varying periods of time (eg.: cannot post for 30 seconds, OR cannot log in for 1 week).

* post content:
  - directly inside : not too lagre? images (img, png, jpg, gif);
  - file attachments : not too large? files (single files or packages like: zip, rar).

* content information:
  - forums, threads & posts : set or mark important and auto-sort to top of listings .. by admin, mod.
  - threads : if logged in, "watch" button to set "new post" notifications, with/-out e-mail warning.

* "reply" to posts:
  - jump to bottom of page to the post writer area quoting/ referencing the "replied to" post:
    - creator name & jump-link to said post as quote/ reference title;
    - post content, which if too large/long is "collapsed" short).

## MAYBE aspects:
* post content:
  - directly inside : embedded video, short webm.

* per-thread temporary quoting reference list:
  - Create/ Add and Delete references;
  - holds one or more "added" post references from the same thread .. scrapped if leaving the thread;
  - used during a "Reply" or "New Post" action to insert post references wherever desired: allowing users to eg.: reference & answer to questions or pitch in to various discussions within the same thread .. in one post .. thus following the general unwritten rule of "no double/multiple posting").

## Made with:
* Mostly written using C# , .NET Core 5, Entity Framework Core; using MVC patern ;

* Database is SQLite, manually managed with DB Browser (SQLite) .. for now, it will change in the future to MS SQL Server or another similar.
