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

| Resource | Method | Description |
| --- | --- | --- |
| | | |
| <b>Category</b> | | |
| `/api/Category` | `GET` | Returns all categories. |
| `/api/Category/{categoryId}` | `GET` | Returns a specified category. |
| `/api/Category/{categoryId}/product` | `GET` | Returns all products with a specified category. |
| `/api/Category/{productId}/category` | `GET` | Returns the categories of a specified product. |
| `/api/Category` | `POST` | Creates a new category. |
| `/api/Category/{categoryId}` | `PUT` | Updates a specified category. |
| `/api/Category/{categoryId}` | `DELETE` | Deletes a specified category. |
| | | |
| <b>Country</b> | | |
| `/api/Country` | `GET` | Returns all countries. |
| `/api/Country/{countryId}` | `GET` | Returns a specified country. |
| `/api/Country/{countryId}/sellers` | `GET` | Returns all sellers from a specified country. |
| `/api/Country/{sellerId}/country` | `GET` | Returns the country of a specified seller. |
| `/api/Country` | `POST` | Creates a new country. |
| `/api/Country/{countryId}` | `PUT` | Updates a specified country. |
| `/api/Country/{countryId}` | `DELETE` | Deletes a specified country. |
| | | |
| <b>Product</b> | | |
| `/api/Product` | `GET` | Returns all products. |
| `/api/Product/{productId}` | `GET` | Returns a specified product. |
| `/api/Product/{productId}/rating` | `GET` | Returns the average rating of a specified product. |
| `/api/Product` | `POST` | Creates a new product. |
| `/api/Product/{productId}` | `PUT` | Updates a specified product. |
| `/api/Product/{productId}` | `DELETE` | Deletes a specified product. |
| | | |
| <b>Review</b> | | |
| `/api/Review` | `GET` | Returns all reviews. |
| `/api/Review/{reviewId}` | `GET` | Returns a specified review. |
| `/api/Review/{productId}/product` | `GET` | Returns the reviews of a specified product. |
| `/api/Review/{reviewId}/reviewer` | `GET` | Returns the reviewer of a specified review. |
| `/api/Review` | `POST` | Creates a new review. |
| `/api/Review/{reviewId}` | `PUT` | Updates a specified review. |
| `/api/Review/{reviewId}` | `DELETE` | Deletes a specified review. |
| | | |
| <b>Reviewer</b> | | |
| `/api/Reviewer` | `GET` | Returns all reviews. |
| `/api/Review/{reviewId}` | `GET` | Returns a specified review. |
| `/api/Review/{productId}/product` | `GET` | Returns the reviews of a specified product. |
| `/api/Review/{reviewId}/reviewer` | `GET` | Returns the reviewer of a specified review. |
| `/api/Review` | `POST` | Creates a new review. |
| `/api/Review/{reviewId}` | `PUT` | Updates a specified review. |
| `/api/Review/{reviewId}` | `DELETE` | Deletes a specified review. |


### Application Architecture

![architecture-diagram](https://github.com/codyh587/online-store-api/assets/108317527/4f3e42bd-2881-4a6f-abcf-2692cf7c5d69)

### Entity Relationships

![entity-relationship-diagram](https://github.com/codyh587/online-store-api/assets/108317527/2507bce4-44f2-4c91-9922-bc20da67f6d4)

### Application Screenshots

> <img src="https://github.com/codyh587/online-store-api/assets/108317527/aa17ed0b-8576-4031-aee5-8ed013fa282e" width="700">

> <img src="https://github.com/codyh587/online-store-api/assets/108317527/bef9464e-ef9b-442f-be43-0753340d825e" width="700">

> <img src="https://github.com/codyh587/online-store-api/assets/108317527/d0018204-c80a-4489-95b9-39660ae9dfc9" width="700">
