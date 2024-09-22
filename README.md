# Dropship Project README

- **Overview**: ASP.NET Core web application for managing products, categories, and tags.
  
- **Prerequisites**:
  - .NET Core SDK (download from the official .NET website).
  - SQLite database.
  - Visual Studio Code or another code editor.

- **Setup Instructions**:
  1. Clone the repository: 
     ```bash
     git clone https://github.com/Affansaleem/dropship.git
     cd dropship
     ```
  2. Restore dependencies: 
     ```bash
     dotnet restore
     ```
  3. Update the connection string in `appsettings.json`.
 
     
  4. Create the database and apply migrations:
     ```bash
     dotnet ef migrations add [migartion_name]
     dotnet ef database update
     ```
  5. Run the application:
     ```bash
     dotnet watch run
     ```
     Access it at `http://localhost:5084`.

- **Features**:
  - Add products with categories.
  - View and filter products by name.
  - Edit and delete products.

- **Directory Structure**:
  - **Controllers**: Application controllers.
  - **Models**: Data models and view models.
  - **Data**: Database context.
  - **Views**: csHTML views.
