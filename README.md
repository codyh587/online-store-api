# online-store-api

### RESTful web API for manipulating entity relationships representing an e-commerce website.

Built using:
* ASP.NET Core
* Entity Framework Core O/RM
* Docker deployment to GCP Cloud Run
* Microsoft SQL Server deployment to GCP Cloud SQL
* CI/CD pipeline with GCP Cloud Build

The following design patterns/techniques were used:
* DTOs
* MVC pattern
* Repository pattern
* Dependency injection
* Database schema migrations via EF Core
* EF Core "<a target="_blank" rel="noopener noreferrer" href="https://www.thereformedprogrammer.net/updating-many-to-many-relationships-in-ef-core-5-and-above/">indirect many-to-many relationships</a>" (explicit join tables)

### API Endpoints

| Resource | Method | Description | Returns |
| --- | --- | --- | --- |
| /api/Categories | GET | Returns all categories. | 200 OK |

### Application Architecture

![architecture-diagram](https://github.com/codyh587/online-store-api/assets/108317527/4f3e42bd-2881-4a6f-abcf-2692cf7c5d69)

### Entity Relationships

![entity-relationship-diagram](https://github.com/codyh587/online-store-api/assets/108317527/2507bce4-44f2-4c91-9922-bc20da67f6d4)

### Application Screenshots

> <img src="https://github.com/codyh587/online-store-api/assets/108317527/aa17ed0b-8576-4031-aee5-8ed013fa282e" width="700">

> <img src="https://github.com/codyh587/online-store-api/assets/108317527/bef9464e-ef9b-442f-be43-0753340d825e" width="700">

> <img src="https://github.com/codyh587/online-store-api/assets/108317527/d0018204-c80a-4489-95b9-39660ae9dfc9" width="700">
