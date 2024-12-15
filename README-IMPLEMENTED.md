# Customer Management System - API and UI

This project implements a Customer Management System with an API and UI. The system allows you to create, update, delete, and view customer information. The Customer Model includes necessary data validation, and the API service is integrated with the UI for seamless interaction.

## Features Implemented

1. **Customer Model with Validation**: 
    - Created a `Customer` model class with data validation annotations to ensure data integrity.
    - The model includes validation for fields like `Name`, `Email`, `Phone`, `Zip`, `Country`, and `Contact Information`.

2. **Customer API**: 
    - Created an API controller to expose endpoints for creating, updating, deleting, and retrieving customer information.
    - Added necessary validation to the API methods to handle invalid or missing data gracefully.

3. **Customer API Service**:
    - Created a `CustomerAPIService` to consume the Customer API on the customer page.
    - The service includes methods to perform CRUD operations (Create, Read, Update, Delete) on customer data.

4. **Reusable Helper Code**:
    - Created a `CustomerHelper` class to store reusable functions such as populating the customer form and clearing the form after actions like add, update, or delete.

5. **Swagger/OpenAPI Documentation**:
    - Integrated Swagger/OpenAPI for easy testing and documentation of the API.
    - Access the Swagger UI to view and interact with the API: 
      - [Swagger UI](https://localhost:44358/swagger/ui/index#/Customers)
      - [Swagger JSON](https://localhost:44358/swagger)

6. **UI Updates**:
    - Updated the customer UI to allow for customer creation, updating, and deletion.
    - A dropdown list is used to select a customer for updating or deleting. The form automatically populates when a customer is selected.

7. **Workflow**:
    - **Add Customer**: Use the form to add a new customer to the system.
    - **Select Customer**: Choose a customer from the dropdown list to update or delete their information.
    - **Update/Delete**: After selecting a customer, you can update their details or delete the customer from the system.

8. **Customer Data Validation Test Cases**:
    - Added test cases for validating customer data, ensuring that all fields are correctly validated according to the defined rules (e.g., valid email, valid phone number, correct postal code format for both Canada and the US).

## Workflow

1. **Add a New Customer**:
    - Fill out the customer form with details such as `Name`, `Address`, `City`, `State`, `Country`, `Zip`, and `Contact Information`.
    - Click the **Add Customer** button to add the new customer.

2. **Select a Customer from the List**:
    - After adding a customer, they will appear in the customer dropdown list on the UI.
    - Select a customer from the list to edit or delete their information.

3. **Update or Delete a Customer**:
    - Once a customer is selected, the customer form will be populated with their existing information.
    - You can update the customer’s details and click the **Update Customer** button to save the changes, or click the **Delete Customer** button to remove the customer from the system.

## API Endpoints

- **POST /api/customers**: Create a new customer.
- **GET /api/customers**: Retrieve all customers.
- **GET /api/customers/{id}**: Retrieve a customer by ID.
- **PUT /api/customers/{id}**: Update an existing customer.
- **DELETE /api/customers/{id}**: Delete a customer by ID.

## API Documentation

The API documentation is available through Swagger UI, which can be accessed by visiting the following URL in your browser:

- [Swagger UI](https://localhost:44358/swagger/ui/index#/Customers)

This will provide detailed information about the API endpoints, request parameters, and response formats.

## Setup and Installation

1. Clone this repository to your local machine.
2. Open the solution in Visual Studio or your preferred IDE.
3. Build and run the project locally.
4. Access the UI at `https://localhost:44358`.
5. Use Swagger for testing the API at `https://localhost:44358/swagger`.

## Testing

- The project includes unit tests for validating customer data, such as verifying that zip/postal codes are in the correct format for both Canada and the US, as well as ensuring required fields are filled.

## Conclusion

This project provides a fully functional Customer Management System with a robust API for interacting with customer data. It includes all necessary CRUD operations, customer data validation, and easy-to-use UI, along with thorough testing to ensure data integrity.

---

Feel free to reach out if you have any questions or need further assistance with the project!
