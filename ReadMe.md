Event Management API
====================

Overview
--------

The **Event Management API** is a robust and scalable C# Web API application, designed using **Domain-Driven Design (DDD)** principles and **Clean Architecture**. It leverages **Entity Framework Core** with an in-memory database for simplified development and testing, implements the **Mediator Pattern** via MediatR, and offers comprehensive testing using **XUnit** and **Fluent Assertions**.

The API facilitates efficient event management with features like attendee management, notifications, and OpenAPI-compliant documentation.

* * *

Table of Contents
-----------------

*   [Features](#features)
*   [Technologies Used](#technologies-used)
*   [Prerequisites](#prerequisites)
*   [Installation](#installation)
*   [Usage](#usage)
*   [Configuration](#configuration)
*   [Documentation](#documentation)
*   [Testing](#testing)
*   [Contributors](#contributors)
*   [License](#license)

* * *

Features
--------

### Core Functionality

#### **Entities**

*   **Attendees**:
    *   Fields: `Name`, `Email Address`, `IsAttending` (boolean).
    *   Validations:
        *   Field size constraints for `Name` and `Email`.
*   **Events**:
    *   Fields: `Title`, `Description`, `Attendees`, `Start Time`, `End Time`.
    *   Validations:
        *   Sensible field size limits for `Title` and `Description`.
        *   Logical constraints such as valid date ranges.

#### **Notifications**

*   Pluggable notification mechanisms:
    *   **Email** (via SMTP)
    *   **iCal** calendar invites
    *   **Message Queues** (e.g., RabbitMQ)

### API Functions

#### **Must-Have Features**

*   Create an event
*   Update an event
*   Delete/Cancel an event
*   List calendar events with filtering options
*   Search for events

#### **Should-Have Features**

*   Accept/Reject event invitations

### Additional Features

*   **OpenAPI Specification**:
    *   Auto-generated, public-facing documentation accessible via Swagger.
*   **Auto-Generated Client**:
    *   Generate client code for third-party integrations using **NSwag**.
*   **In-Memory Database**:
    *   Simplifies development and testing workflows.
*   **Concurrency Handling**:
    *   Implements optimistic concurrency control to ensure consistent data updates.

* * *

Technologies Used
-----------------

*   **Framework**: ASP.NET Core
*   **Architecture**: Clean Architecture with DDD principles
*   **Database**: Entity Framework Core with In-Memory provider
*   **Mediator Pattern**: MediatR
*   **Testing**: XUnit, Fluent Assertions
*   **Documentation**: Swagger/OpenAPI
*   **Notifications**: Email, iCal, or MQ integrations
*   **Client Generation**: NSwag

* * *

Prerequisites
-------------

*   **.NET SDK**: Version 6.0 or later  
    [Download .NET SDK](https://dotnet.microsoft.com/download)
*   **Postman** or similar API testing tool (optional)  
    Download Postman

* * *

Installation
------------

1.  **Clone the Repository**
    
    bash
    
    Copy code
    
    `git clone https://github.com/your-repo-name.git cd your-repo-name`
    
2.  **Restore Dependencies**
    
    bash
    
    Copy code
    
    `dotnet restore`
    
3.  **Configure Application Settings**  
    Edit the `appsettings.json` file to configure necessary settings:
    
    *   Notification provider configurations (SMTP/MQ)
    *   OpenAPI options
4.  **Run the Application**
    
    bash
    
    Copy code
    
    `dotnet run`
    

* * *

Usage
-----

Once the application is running, access the API documentation at the Swagger UI endpoint:

bash

Copy code

`http://localhost:{port}/swagger`

Use tools like **Postman** or the Swagger UI to interact with the API endpoints.

* * *

Configuration
-------------

### Key Settings in `appsettings.json`

*   **SMTP Settings**: For email notifications.
*   **MQ Settings**: For message queue integrations (e.g., RabbitMQ).
*   **OpenAPI Options**: Configure Swagger-related properties.

Ensure to provide valid configurations for your specific environment.

* * *

Documentation
-------------

The API includes **OpenAPI Specification**, available via Swagger. It allows for:

*   Exploring all available endpoints.
*   Testing API functionality directly.
*   Generating client code via **NSwag**.

To access the Swagger UI:

bash

Copy code

`http://localhost:{port}/swagger`

* * *

Testing
-------

The application includes a comprehensive test suite utilizing:

*   **XUnit** for unit and integration tests.
*   **Fluent Assertions** for readable and expressive assertions.

To run the tests:

bash

Copy code

`dotnet test`

* * *

Contributors
------------

*   **Shaun De Klerk**: Initial development and architecture.
*   

* * *

