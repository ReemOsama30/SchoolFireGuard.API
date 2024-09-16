SchoolFireGuard.API
SchoolFireGuard.API is an API designed for managing school fire safety systems, ensuring the safety of students, staff, and infrastructure. This API enables features such as fire alarm monitoring, fire drills scheduling, incident reporting, and real-time safety notifications.

Table of Contents
Features
Technologies
Prerequisites
Installation
Running the API
Usage
API Endpoints
Contributing
License
Features
Fire alarm monitoring: Track fire alarm events in real-time.
Fire drill scheduling: Schedule fire drills and send notifications to students and staff.
Incident reporting: Log incidents, track their status, and report on fire safety events.
Real-time notifications: Send alerts for fire drills and emergencies to all concerned parties.
Role-based access control: Differentiate between admin, staff, and students for security and access to features.
Technologies
ASP.NET Core: Backend framework
Entity Framework Core: ORM for database management
SQL Server: Database for storing incident logs, schedules, and users
JWT Authentication: Secured access to APIs
Swagger: API documentation
Prerequisites
.NET 8.0 or later
Access Database
Postman (for testing API endpoints)
Installation
Clone the repository:

bash
Copy code
git clone https://github.com/ReemOsama30/SchoolFireGuard.API.git
cd SchoolFireGuard.API
Install dependencies:

Navigate to the project folder and restore dependencies using .NET CLI:

