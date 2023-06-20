# online-store-api

### RESTful web API for manipulating entity relationships representing an e-commerce application.

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
| `/api/Category/{categoryId}` | `DELETE` | Deletes a specified category. | `204 No Content` <br> `400 Bad Request` <br> `404 Not Found` |
| | | |
| <b>Country</b> | | |
| `/api/Country` | `GET` | Returns all countries. | `200 OK` <br> `400 Bad Request` |
| `/api/Country/{countryId}` | `GET` | Returns a specified country. | `200 OK` <br> `400 Bad Request` <br> `404 Not Found` |
| `/api/Country/{countryId}/sellers` | `GET` | Returns all sellers of a specified country. | `200 OK` <br> `400 Bad Request` <br> `404 Not Found` |
| `/api/Country/{sellerId}/country` | `GET` | Returns the country of a specified seller. | `200 OK` <br> `400 Bad Request` <br> `404 Not Found` |
| `/api/Country` | `POST` | Creates a new country. | `200 OK` <br> `400 Bad Request` <br> `422 Unprocessable Content` <br> `500 Internal Server Error` |
| `/api/Country/{countryId}` | `PUT` | Updates a specified country. | `204 No Content` <br> `400 Bad Request` <br> `404 Not Found` <br> `500 Internal Server Error` |
| `/api/Country/{countryId}` | `DELETE` | Deletes a specified country. | `204 No Content` <br> `400 Bad Request` <br> `404 Not Found` |
| | | |
| <b>Product</b> | | |
| `/api/Product` | `GET` | Returns all products. | `200 OK` <br> `400 Bad Request` |
| `/api/Product/{productId}` | `GET` | Returns a specified product. | `200 OK` <br> `400 Bad Request` <br> `404 Not Found` |
| `/api/Product/{productId}/rating` | `GET` | Returns the average rating of a specified product. | `200 OK` <br> `400 Bad Request` <br> `404 Not Found` |
| `/api/Product` | `POST` | Creates a new product. | `200 OK` <br> `400 Bad Request` <br> `500 Internal Server Error` |
| `/api/Product/{productId}` | `PUT` | Updates a specified product. | `204 No Content` <br> `400 Bad Request` <br> `404 Not Found` <br> `500 Internal Server Error` |
| `/api/Product/{productId}` | `DELETE` | Deletes a specified product. | `204 No Content` <br> `400 Bad Request` <br> `404 Not Found` |
| | | |
| <b>Review</b> | | |
| `/api/Review` | `GET` | Returns all reviews. | `200 OK` <br> `400 Bad Request` |
| `/api/Review/{reviewId}` | `GET` | Returns a specified review. | `200 OK` <br> `400 Bad Request` <br> `404 Not Found` |
| `/api/Review/{productId}/product` | `GET` | Returns all reviews of a specified product. | `200 OK` <br> `400 Bad Request` |
| `/api/Review/{reviewId}/reviewer` | `GET` | Returns the reviewer of a specified review. | `200 OK` <br> `400 Bad Request` |
| `/api/Review` | `POST` | Creates a new review. | `200 OK` <br> `400 Bad Request` <br> `422 Unprocessable Content` <br> `500 Internal Server Error` |
| `/api/Review/{reviewId}` | `PUT` | Updates a specified review. | `204 No Content` <br> `400 Bad Request` <br> `404 Not Found` <br> `500 Internal Server Error` |
| `/api/Review/{reviewId}` | `DELETE` | Deletes a specified review. | `204 No Content` <br> `400 Bad Request` <br> `404 Not Found` |
| | | |
| <b>Reviewer</b> | | |
| `/api/Reviewer` | `GET` | Returns all reviewers. | `200 OK` <br> `400 Bad Request` |
| `/api/Reviewer/{reviewerId}` | `GET` | Returns a specified reviewer. | `200 OK` <br> `400 Bad Request` <br> `404 Not Found` |
| `/api/Reviewer/{reviewerId}/reviews` | `GET` | Returns all reviews of a specified reviewer. | `200 OK` <br> `400 Bad Request` <br> `404 Not Found` |
| `/api/Reviewer` | `POST` | Creates a new reviewer. | `200 OK` <br> `400 Bad Request` <br> `422 Unprocessable Content` <br> `500 Internal Server Error` |
| `/api/Reviewer/{reviewerId}` | `PUT` | Updates a specified reviewer. | `204 No Content` <br> `400 Bad Request` <br> `404 Not Found` <br> `500 Internal Server Error` |
| `/api/Reviewer/{reviewerId}` | `DELETE` | Deletes a specified reviewer. | `204 No Content` <br> `400 Bad Request` <br> `404 Not Found` |
| | | |
| <b>Seller</b> | | |
| `/api/Seller` | `GET` | Returns all sellers. | `200 OK` <br> `400 Bad Request` |
| `/api/Seller/{sellerId}` | `GET` | Returns a specified seller. | `200 OK` <br> `400 Bad Request` <br> `404 Not Found` |
| `/api/Seller/{sellerId}/product` | `GET` | Returns all products of a specified seller. | `200 OK` <br> `400 Bad Request` <br> `404 Not Found` |
| `/api/Seller/{productId}/seller` | `GET` | Returns all sellers of a specified product. | `200 OK` <br> `400 Bad Request` <br> `404 Not Found` |
| `/api/Seller` | `POST` | Creates a new seller. | `200 OK` <br> `400 Bad Request` <br> `422 Unprocessable Content` <br> `500 Internal Server Error` |
| `/api/Seller/{sellerId}` | `PUT` | Updates a specified seller. | `204 No Content` <br> `400 Bad Request` <br> `404 Not Found` <br> `500 Internal Server Error` |
| `/api/Seller/{sellerId}` | `DELETE` | Deletes a specified seller. | `204 No Content` <br> `400 Bad Request` <br> `404 Not Found` |

### Application Architecture

![architecture-diagram](https://github.com/codyh587/online-store-api/assets/108317527/4f3e42bd-2881-4a6f-abcf-2692cf7c5d69)

### Entity Relationships

![entity-relationship-diagram](https://github.com/codyh587/online-store-api/assets/108317527/2507bce4-44f2-4c91-9922-bc20da67f6d4)

### Application Screenshots

> <img src="https://github.com/codyh587/online-store-api/assets/108317527/aa17ed0b-8576-4031-aee5-8ed013fa282e" width="700">

> <img src="https://github.com/codyh587/online-store-api/assets/108317527/bef9464e-ef9b-442f-be43-0753340d825e" width="700">

> <img src="https://github.com/codyh587/online-store-api/assets/108317527/d0018204-c80a-4489-95b9-39660ae9dfc9" width="700">
