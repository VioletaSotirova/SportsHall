Application Structure

1. Public Part (guests)
  Users who are not logged in have access to the following:
* The Home Page with general information about the application.
* A Sports Page where they can view details about different sports.
* A Coaches Page displaying information about the coaches.
* A Training Sessions Page to browse available sessions (sign-up functionality is restricted for guests).
* Register and Login Pages for account creation and access.
* My Reservations Section is not visible to guests.
2. Private Part (Authenticated Users)
Authenticated users have access to:
* All features of the Public Part.
* Additional functionality:
o Admins can:
* Create, edit, and delete sports.
* Create, edit, and delete coaches.
* Create, edit, and delete training sessions.
o Regular Logged-In Users can:
* Sign up for training sessions.
* Manage their registrations through the "My Reservations" section by canceling reservations if needed.

Project Architecture

       This project follows the MVC architectural pattern to ensure separation of concerns, maintainability, and scalability.
  1. Models:
    - The Models represent the application's core data structure and define the entities used in the database. These classes are mapped to the database tables using Entity Framework Core as the ORM.
  2. Controllers:
    - The Controllers act as the entry point for HTTP requests. They handle the flow of data between the Views and the Services.
  3. Views:
    - The Views are responsible for presenting data to the user. They use Razor Pages for dynamic rendering and are located in the Views folder.
  4. Services: 
    - The Services layer contains business logic and acts as a bridge between the Controllers and the Repositories.
  5. Repositories
    - The Repository layer is responsible for data access and interaction with the database.
  6. AutoMapper
    - The project uses AutoMapper to map between models and view models. This reduces boilerplate code and ensures a consistent transformation of data across layers.
 

