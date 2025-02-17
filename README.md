# Project Portfolio Website

````markdown
This is a project portfolio website built with .NET ASP Core. It includes an admin page that allows users to add, edit, and delete projects dynamically. The frontend is developed using JavaScript, CSS, HTML, and Bootstrap.

## Features
- **Project Management:** Admins can add, edit, and delete projects.
- **User-Friendly Interface:** Responsive design with Bootstrap.
- **Dynamic Content:** Projects are stored in a database and displayed dynamically.
- **Secure Admin Access:** Authentication and authorization for admin functionalities.

## Technologies Used
- **Backend:** .NET ASP Core (MVC)
- **Frontend:** JavaScript, HTML, CSS, Bootstrap
- **Database:** Microsoft SQL Server
- **Version Control:** Git & GitHub

## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/project-portfolio.git
   cd project-portfolio
````

2. Install dependencies and restore packages:
   ```bash
   dotnet restore
   ```
3. Configure the database connection in `appsettings.json`.
4. Apply migrations and update the database:
   ```bash
   dotnet ef database update
   ```
5. Run the application:
   ```bash
   dotnet run
   ```
6. Open the browser and navigate to `http://localhost:5000`.

## Usage

- Visit the homepage to view the portfolio projects.
- Admins can log in to the admin panel to manage projects.

## Contributing

Feel free to fork this repository and submit pull requests.


