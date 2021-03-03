# CS_ASP.NET_Forum
FTIT C# ASP .NET final project: a __Web Forum__ web application.

Basic aspects and idea:
* user accounts:
  - e-mail address : used for registration and sending notifications (eg.: registration, quoted by other user, account suspension);
  - user name : unique alphanumeric string, max 10-20 characters, except special characters, no vulgar /crass words contained;
  - login password : private alphanumeric string, max 10-20 characters, except special characters;
  - portrait : a small image, approx max 125-250 px ? , the "avatar" of a user, in threads connected to "posts" next to the user name.

* any user should be able to list and access any other user's _public threads_ and _posts_.

* depending on User privileges, perform "Create Read Update Delete" operations for:
  - "primary board"-s / "forum"-s : a collection of globally visible data collection collections (secondary boards) .. admin only;
  - "secondary board"-s : a collection of globally visible data collections (thread containers) .. admin only;
  - "thread"-s : a collection of globally visible data (posts);
  - "post"-s : a globally visible data "pack"/ object.

* by admins .. suspend /ban user account activities for varying periods of time, and activity type (eg.: cannot post for 30 seconds).

* possible "post" content to add:
  - directly in "posts" : text, not too lagre images (img, png, jpg, gif);
  - attachments to "posts" : not too large files (single files or packages like: zip, rar).

* in primary & secondary boards and threads for their contained elements (primary board : secondary boards, sec.boards : threads, threads : posts):
  - show which user created the elemet;
  - when was it created;
  - which user added a new element to it (primary board /forum, secondary board, thread, post);
  - when was the new content added;
  - title of the new element;
  - wether it is open for new element creation or set read-only (eg.: not everyone should be able to modify elements listing posting regulations).

MAYBE aspects: allow to be part of the "post" : embedded video, webm.

Made with:
* Mostly written using C# , .NET Core 5 ;
* Database is managed with (at least until the end of the course): Xampp, written with MySQL.
