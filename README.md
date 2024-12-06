# **ECommerceApi**

## **Overview**
ECommerceApi is an e-commerce project developed using the Onion Architecture to ensure scalability, maintainability, and testability. The project incorporates modern technologies and follows industry-standard principles to deliver robust and efficient solutions.

---

## **Technologies Used**
- **.NET 6/7**: Used for developing the backend services.
- **SignalR**: Enables real-time web functionality, ensuring seamless communication between server and client.
- **Hub Technologies**: Implemented for message communication and asynchronous processes.
- **SQL Server**: Used as the primary database for data storage and management.
- **Entity Framework Core**: For object-relational mapping (ORM) and database operations.

---

## **Architecture**
- **Onion Architecture**: The project is structured to separate concerns and dependencies systematically:
  - **Core**: Contains the domain entities and business logic.
  - **Infrastructure**: Handles data access, external API calls, and third-party dependencies.
  - **Presentation**: Includes API endpoints for client interaction.
  - **SignalR Layer**: Manages real-time notifications and communication.

---

## **Principles Followed**
- **SOLID Principles**:
  - **S**ingle Responsibility Principle
  - **O**pen-Closed Principle
  - **L**iskov Substitution Principle
  - **I**nterface Segregation Principle
  - **D**ependency Inversion Principle
- **Clean Code Practices**: Ensures readable, maintainable, and extensible code.

---

## **Features**
- Modular and decoupled architecture.
- Real-time communication using SignalR.
- Scalable database design with SQL Server.
- Adherence to software design patterns.