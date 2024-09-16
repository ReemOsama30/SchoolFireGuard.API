<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SchoolFireGuard.API - README</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }
        .container {
            max-width: 800px;
            margin: auto;
            background: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1, h2, h3 {
            color: #333;
        }
        code {
            background: #f4f4f4;
            padding: 2px 5px;
            border-radius: 4px;
        }
        pre {
            background: #333;
            color: #fff;
            padding: 10px;
            border-radius: 8px;
            overflow-x: auto;
        }
        ul {
            list-style-type: square;
            margin-left: 20px;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }
        table, th, td {
            border: 1px solid #ddd;
        }
        th, td {
            padding: 10px;
            text-align: left;
        }
        th {
            background-color: #f4f4f4;
        }
        a {
            color: #007bff;
            text-decoration: none;
        }
        a:hover {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <div class="container">
        <h1>SchoolFireGuard.API</h1>
        <p>
            <strong>SchoolFireGuard.API</strong> is an API designed for managing school fire safety systems, ensuring the safety of students, staff, and infrastructure. </p>

        <h2>Table of Contents</h2>
        <ul>
            <li><a href="#features">Features</a></li>
            <li><a href="#technologies">Technologies</a></li>
            <li><a href="#prerequisites">Prerequisites</a></li>
            <li><a href="#installation">Installation</a></li>
            <li><a href="#running-the-api">Running the API</a></li>
            <li><a href="#usage">Usage</a></li>
            <li><a href="#api-endpoints">API Endpoints</a></li>
            <li><a href="#contributing">Contributing</a></li>
            <li><a href="#license">License</a></li>
        </ul>

        <h2 id="features">Features</h2>
        <ul>
      
            <li><strong>Incident reporting</strong>: Log incidents, track their status, and report on fire safety events.</li>
        </ul>

        <h2 id="technologies">Technologies</h2>
        <ul>
            <li><strong>ASP.NET Core</strong>: Backend framework</li>
            <li><strong>SQL Server</strong>: Database for storing incident logs, schedules, and users</li>
            <li><strong>Swagger</strong>: API documentation</li>
        </ul>

        <h2 id="prerequisites">Prerequisites</h2>
        <ul>
            <li>.NET 8.0 or later</li>
            <li>Access Database</li>
            <li>Postman (for testing API endpoints)</li>
        </ul>

        <h2 id="installation">Installation</h2>
        <p>Follow these steps to install and set up the project:</p>
        <pre><code>git clone https://github.com/ReemOsama30/SchoolFireGuard.API.git
cd SchoolFireGuard.API

