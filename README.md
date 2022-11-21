## Purpose
This is a small sample but also complete that shows how to use Apache Royale (compiles to JS) for frontend + .NET 7 for backend + SQL Server for database.

## Comunications
Frontend <> Backend => Using HTTP Methods for RESTful Services (alternative: RPC)
Backend <> Database => LINQ to SQL Server

## Features
- Loading screen with a CSS animation while checking the server status (after that, there is a automatically check every 20 seconds)
- List of questions (top 10 with offset of 10)
- Possibility to load the next 10 and share the list by e-mail
- There is also a search text box to filter the list
- The App accepts a parameter FILTER (if is omissed, than the list get the focus, if the parameters exists without value, the search text box get focus and if have value, the list is automatically filtered)
- When the user select an item from the list (or pass the id by App parameter), then the App navigates to a new screen with the question full detail with a grid of choices and votes
- There is also the possibility to navigate back from the details or share the the details page by e-mail

## Compile from the source code
- You can recreate the database with a small test data (just run the ScripDB.sql) and the database, tables and data will be created
- About the backend, you need VS 2022 with .NET 7
- About the frontend, you need VS Code (or ANT if it's your way) + Apache Royale SDK

## License
- This library is MIT licensed
- Feel free to use it in any way you wish
