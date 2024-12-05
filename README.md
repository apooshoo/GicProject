# Hello, I'm Jon!


## Introduction
I threw this together over the course of two half-days - its incomplete but I hope its enough as a demonstration! <br />
I began with a NET Core API template and Create-React-App and added SQLite support to store the seed data.

## Default Ports
1. API @ https://localhost:5000
2. API backup @ http://localhost:5001
3. Client @ http://localhost:3000

Please edit the API in appsettings.json > Urls or edit the client in .env > PORT if there's a clash or anything.

## How to run
API: <br />
Open a terminal and navigate to solution folder "GicBackend" and run "dotnet run". <br />
Or, if you have visual studio, build and run the solution yourself. <br />
If all else fails, drop me a message and I can send you the published .exe. <br />

Client: <br />
Open another terminal and navigate to client folder "gic-frontend", run "npm install", then "npm start". <br />


## Things I did for back-end:
I created tables for Cafes, Employees and the relationship between the two. <br />
I exposed /cafes?location and /employees?cafe.

## Things I did NOT do for back-end:
POST, PUT and DELETE sections as I ran out of time, but it would have largely been more of the same. <br />

## Afterthoughts for back-end
1. SQLite was a big time-waster for me - I chose it because it seemed easier to startup and deploy as a test project, but working around all the restrictions and language differences ended up costing more time than it saved.  <br />
2. This was my first time working with Autofac so I did my best to understand and implement a rudimentary version in the few hours I had this evening. It seemed very promising for certain tasks that could be reduced to generics (I tried to reduce ICafeSeeder and IEmployeeSeeder to a generic IDbSeeder for example), but for some other tasks with specific business logic like retrieving records (getting employees by cafe) I ended up using it like standard dependency injection.

## Things I did for front-end:
I created a page for viewing Cafes, Employees, and navigating from cafes to employees via the "employee' button, using data from the server. <br />
I used ReactJS, Aggrid and Material-UI. <br />

## Things I did NOT do for front-end:
Add/Edit/Delete sections as I ran out of time. <br />

## Afterthoughts for front-end
1. This was the first time I'd touched React and NPM in many, many years, so I read up as much as I could on the go. I've worked with AngularJS before, so the concepts are similar but it took some getting used to.
