# MovieLibrary

`MovieLibrary` is a web application for managing and organizing movie collections. It provides features to browse, search, and track movies, allowing users to maintain their own personalized movie library.

## Features

- **Movie Catalog**: Browse a comprehensive collection of movies with details such as title, release year, genre, and ratings.
- **Search**: Easily search for movies by title, genre, or any other relevant criteria.
- **User Accounts**: Create user accounts to personalize your movie library and keep track of your favorite movies.
- **Watchlist**: Maintain a watchlist to keep track of movies you plan to watch in the future.
- **Rating and Reviews**: Rate and review movies, and read reviews from other users.
- **Movie Recommendations**: Get personalized movie recommendations based on your viewing history and preferences.
- **Manager Dashboard**: A Manager dashboard with additional features for only managing movies, which also the admin has.
- **Admin Dashboard**: An admin dashboard with additional features for managing movies and user accounts.

## Technologies Used

- ASP.NET Core: A cross-platform web development framework.
- C#: The primary programming language for the backend development.
- Entity Framework Core: A powerful object-relational mapping (ORM) framework for database operations.
- SQL Server: A relational database management system for storing movie and user data.
- HTML/CSS/JavaScript: Frontend technologies for creating the user interface and interactivity.
- Bootstrap: A popular CSS framework for responsive and visually appealing designs.
- FontAwesome: Another popular CSS framework.

## Installation and Database Setup

1. Clone the repository:

   ```shell
   git clone https://github.com/VasilKostov/MovieLibrary.git

2. Open the solution file `MovieLibrary.sln` in Visual Studio.

3. Update the connection string in the `appsettings.json` file to match your local SQL Server instance. Modify the following section with your connection details:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=MovieLibraryDB;Trusted_Connection=True;"
   }
   
4. Open the Package Manager Console in Visual Studio (Tools -> NuGet Package Manager -> Package Manager Console).

5. Run the following command in the Package Manager Console to apply the database migrations and create the necessary tables:

   ```shell
   Update-Database

This command will execute the migrations defined in the project and create the required tables in the database.

Build and run the project. The MovieLibrary application will now connect to the configured database.

Please note that you should have a local instance of SQL Server installed and running before setting up the database for the application.

### Contributing

Contributions are welcome! If you find any bugs or have suggestions for new features, please open an issue or submit a pull request.

### License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.
