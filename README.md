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
| | | | |
| <b>Category</b> | | | |
| `/api/Category` | `GET` | Returns all categories. | `200 OK` <br> `400 Bad Request` |
| `/api/Category/{categoryId}` | `GET` | Returns a specified category. | `200 OK` <br> `400 Bad Request` <br> `404 Not Found` |
| `/api/Category/{categoryId}/product` | `GET` | Returns all products of a specified category. | `200 OK` <br> `400 Bad Request` <br> `404 Not Found` |
| `/api/Category/{productId}/category` | `GET` | Returns all categories of a specified product. | `200 OK` <br> `400 Bad Request` <br> `404 Not Found` |
| `/api/Category` | `POST` | Creates a new category. | `200 OK` <br> `400 Bad Request` <br> `422 Unprocessable Content` |
| `/api/Category/{categoryId}` | `PUT` | Updates a specified category. | `200 OK` <br> `400 Bad Request` <br> `404 Not Found` <br> `500 Internal Server Error` |
| `/api/Category/{categoryId}` | `DELETE` | Deletes a specified category. |
| | | |
| <b>Country</b> | | |
| `/api/Country` | `GET` | Returns all countries. |
| `/api/Country/{countryId}` | `GET` | Returns a specified country. |
| `/api/Country/{countryId}/sellers` | `GET` | Returns all sellers of a specified country. |
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
| `/api/Review/{productId}/product` | `GET` | Returns all reviews of a specified product. |
| `/api/Review/{reviewId}/reviewer` | `GET` | Returns the reviewer of a specified review. |
| `/api/Review` | `POST` | Creates a new review. |
| `/api/Review/{reviewId}` | `PUT` | Updates a specified review. |
| `/api/Review/{reviewId}` | `DELETE` | Deletes a specified review. |
| | | |
| <b>Reviewer</b> | | |
| `/api/Reviewer` | `GET` | Returns all reviewers. |
| `/api/Reviewer/{reviewerId}` | `GET` | Returns a specified reviewer. |
| `/api/Reviewer/{reviewerId}/reviews` | `GET` | Returns all reviews of a specified reviewer. |
| `/api/Reviewer` | `POST` | Creates a new reviewer. |
| `/api/Reviewer/{reviewerId}` | `PUT` | Updates a specified reviewer. |
| `/api/Reviewer/{reviewerId}` | `DELETE` | Deletes a specified reviewer. |
| | | |
| <b>Seller</b> | | |
| `/api/Seller` | `GET` | Returns all sellers. |
| `/api/Seller/{sellerId}` | `GET` | Returns a specified seller. |
| `/api/Seller/{sellerId}/product` | `GET` | Returns all products of a specified seller. |
| `/api/Seller/{productId}/seller` | `GET` | Returns all sellers of a specified product. |
| `/api/Seller` | `POST` | Creates a new seller. |
| `/api/Seller/{sellerId}` | `PUT` | Updates a specified seller. |
| `/api/Seller/{sellerId}` | `DELETE` | Deletes a specified seller. |

### Application Architecture

![architecture-diagram](https://github.com/codyh587/online-store-api/assets/108317527/4f3e42bd-2881-4a6f-abcf-2692cf7c5d69)

### Entity Relationships

![entity-relationship-diagram](https://github.com/codyh587/online-store-api/assets/108317527/2507bce4-44f2-4c91-9922-bc20da67f6d4)

### Application Screenshots

> <img src="https://github.com/codyh587/online-store-api/assets/108317527/aa17ed0b-8576-4031-aee5-8ed013fa282e" width="700">

> <img src="https://github.com/codyh587/online-store-api/assets/108317527/bef9464e-ef9b-442f-be43-0753340d825e" width="700">

> <img src="https://github.com/codyh587/online-store-api/assets/108317527/d0018204-c80a-4489-95b9-39660ae9dfc9" width="700">
