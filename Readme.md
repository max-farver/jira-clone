# Discount Jira

Discount Jira is just that, a barebones clone of Jira.

I had a few reasons for creating this:

1. Jira is expensive.
2. Trello doesn't have a few features that I feel are helpful when following an AGILE workflow with a team.
3. I wanted something that I could add on to whenever the need arose.
4. I wanted to dig into ASP<span><span/>.NET Core to build the backend REST Api.

## Demo

View the application live at **notareallink<span></span>.com**

## Tech Used

### Backend

- C# and ASP<span><span/>.NET Core
- .NET Identity for Auth
- Entity Framework for an ORM
- PostgreSql
- SignalR for PubSub (realtime comments)
- XUnit for testing

### Frontend

- React (create-react-app)
  - _This may change in the future (NextJS, Angular, Vue, etc.)_
- Typescript
- TailwindCSS

## Architecture Choices

I tried to adhere to Clean Architecture and decouple my Persistence, Domain, Application, and API layers as much as possible. Dependency injection is used throughout the project to promote easy testing and code uniformity.

I elected to go with a Code First workflow for the Database part of the project. I don't suspect that Discount Jira will end up getting so complex that queries need to be optimized further than what Entity Framework will do for me, and it allows me to focus on the code part of the project instead of fiddling with the Database all the time.

I am using a UnitOfWork pattern along with a Repository/Service pattern to further the separation of concerns in the project.

Data Transfer Objects are used between the Controllers and Services to allow for passing models in a different shape to and from the client.

## Installing Discount Jira

Docker:

1. Clone the repo
2. (still working on this)

// TODO

## Contact

If you want to contact me you can reach me at <mfarver99@gmail.com>.
