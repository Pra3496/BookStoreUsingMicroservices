# Bookstore Project Based on Microservices

## Table of Contents

1. [Introduction](#introduction)
2. [Project Structure](#project-structure)
3. [Features](#features)
4. [Technologies](#technologies)
5. [Getting Started](#getting-started)
6. [Usage](#usage)
7. [Contributing](#contributing)
8. [License](#license)

---

## Introduction

The Bookstore Microservices Project is a robust and scalable solution for managing a bookstore using microservices architecture. This project is composed of four individual microservices, each designed to perform specific functions related to user management, admin management, book catalog management, and order processing. These microservices work cohesively to provide a seamless bookstore experience.

---

## Project Structure

The project is organized into four separate microservices:

1. **Bookstore.Users**: This microservice handles user-related functionalities such as user registration, login, password reset, and account management.

2. **Bookstore.Admins**: Admins can register, log in, reset their passwords, and manage their accounts using this microservice.

3. **Bookstore.Books**: This microservice is responsible for managing the bookstore's catalog. It allows the addition of new books, retrieval of all available books, and fetching specific book details by ID.

4. **Bookstore.Orders**: Order management is facilitated by this microservice, enabling users to place orders and view their order histories.

The communication between microservices is established through HTTP requests, and `Bookstore.Orders` communicates with both `Bookstore.Books` and `Bookstore.Users` using HttpClient for data retrieval.

---

## Features

- **User Management**:
  - User registration and login.
  - Password reset and reset confirmation.

- **Admin Management**:
  - Admin registration and login.
  - Password reset and reset confirmation.

- **Book Management**:
  - Add books to the catalog.
  - Retrieve a list of all available books.
  - Fetch book details by ID.

- **Order Management**:
  - Place orders.
  - Retrieve order history.

- **Communication**:
  - The `Bookstore.Orders` microservice communicates with `Bookstore.Books` and `Bookstore.Users` using HttpClient for data retrieval.

---

## Technologies

- **Framework**: .NET 6
- **Microservices**: .NET Microservices
- **Authentication**: JWT (JSON Web Tokens)
- **HTTP Communication**: HttpClient
- **Database**: Entity Framework Core
- **API Documentation**: Swagger
- **Dependency Injection**: Built-in .NET DI

---

## Getting Started

To get started with the Bookstore Microservices Project, follow these steps:

1. Clone the repository.
2. Open each individual microservice solution in your preferred development environment.
3. Configure the connection strings and settings (e.g., database connection, authentication) in each microservice's `appsettings.json` file.
4. Build and run each microservice separately.
5. Test the functionality of each microservice independently.
6. Use Postman or a similar tool to interact with the APIs.

For more detailed setup instructions, refer to the documentation within each microservice's solution.

---

## Usage

Once the microservices are up and running, you can use them as follows:

- **User and Admin Management**: Register, log in, reset passwords, and perform other user or admin-related actions using the `Bookstore.Users` and `Bookstore.Admins` microservices.

- **Book Management**: Add books to the catalog, retrieve a list of all books, and fetch book details by ID using the `Bookstore.Books` microservice.

- **Order Management**: Place orders and retrieve your order history using the `Bookstore.Orders` microservice.

Remember that these microservices are designed to work together, and `Bookstore.Orders` communicates with `Bookstore.Books` and `Bookstore.Users` to provide a comprehensive bookstore experience.

---

Thank you for your interest in the Bookstore Microservices Project! 
