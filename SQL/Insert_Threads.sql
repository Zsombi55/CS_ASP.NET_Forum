-- 0 /00 = Open+Normal; 01 /1 = Open+Sticky (priority); 10 = Closed+Normal; 11 = Closed+Sticky.
-- Open = any User can crud; Closed = only staff (admin, mods) can crud, rest read only.

INSERT INTO Threads (Content, CreatedAt, ForumId, ModifiedAt, Status, Title, UserId)
VALUES
("Introduction & Table of Contents: ", datetime('now', 'localtime'), 1, datetime('now', 'localtime'), 11, "Culinary Basics", ""),
("A simple, healthy dish recipe great for any time of the day. Personally I like to eat it for breakfast, though.", datetime('now', 'localtime'), 1, datetime('now', 'localtime'), 0, "Fried Egg Filled Bell Pepper", ""),
("Each story must contain at the top of its 1st page: the name of the story, its completion status or if it's dead /abandoned, link to prequel /sequel if applicable, age /maturity rating, tag categories, and a short summary. For now we do not have a system implemented for setting these so everyone has to follow these guidelines. These are the minimum.", datetime('now', 'localtime'), 2, datetime('now', 'localtime'), 11, "Creative Writing Forum Rules", ""),
("This is a thread for discussing and showing off model settings, scenics and environments made from common items and junk, such as: tin cans, plastic bottles, foam boards, cotton etc. Here's an example: https://www.youtube.com/watch?v=uxlQ748pDkE", datetime('now', 'localtime'), 8, datetime('now', 'localtime'), 0, "DIY Scenics", ""),
("so, I've been looking for some citybuilder or nation builder games that came out recently for a chill passtime. Is there any good? I've tried and really loved ""Frostpunk"" and heard ""Cities: Skylines"" quite fun if you can spare the time.", datetime('now', 'localtime'), 9, datetime('now', 'localtime'), 0, "Popular City and Nation builders of late 2020", "")