# ProductSale

API to manage products and orders.

## Prerequesites
- Docker

## How to execute
1. Stop the local MySQL service as it will conflict with the Docker container
2. Run the command 'docker-compose up -d'
3. Run the command 'docker container ls' and get the port of the container with the name 'product-sale-api'
4. Access 'localhost:{container port}/swagger/index.html' in your browser to see the list of endpoints

## Tips
If you whant to delete the infos of MySQL and Redis when shutdown containers, try 'docker-compose down -v'.

## Infos
The API endpoints must be called using HTTPS.
The requests body must be in JSON format.

## Documentation

### Products
#### Create a new product
- URL: `/Product`
- Method: POST
- Description: Create a new product
- Request Body: JSON object representing the product information
  - Example:
    ```json
    {
        "name": "Table",
        "value": 500,
        "amountInStock": 2,
        "description": "A dinner table",
        "productionCost": 100
    }
    ```
#### Delete a product
- URL: `/Product/{productId}`
- Method: DELETE
- Description: Delete a product
- Path Parameter: `productId` (integer) - The identifier of the product to be deleted

#### Get a product by ID
- URL: `/Product/{productId}`
- Method: GET
- Description: Get product information by ID
- Path Parameter: `productId` (integer) - The identifier of the product
- Response: JSON object representing the product information
  - Example:
    ```json
    {
        "name": "Table",
        "value": 500,
        "amountInStock": 2,
        "description": "A dinner table",
        "productionCost": 100
    }
    ```
#### Get all products
- URL: `/Product`
- Method: GET
- Description: Get all products
- Response: List of JSON objects representing the products
  - Example:
    ```json
    [
        {
            "name": "Table",
            "value": 500,
            "amountInStock": 2,
            "description": "A dinner table",
            "productionCost": 100
        },
        {
            "name": "Bed",
            "value": 300,
            "amountInStock": 5,
            "description": "A bed",
            "productionCost": 80
        }
    ]
    ```

#### Update product information
- URL: `/Product/{productId}`
- Method: PATCH
- Description: Update product information
- Path Parameter: `productId` (integer) - The identifier of the product to be updated
- Request Body: JSON Patch document specifying the changes to be made to the product information
  - Example:
    ```json
    [
        { 
            "op": "replace", 
            "path": "/name", 
            "value": "Diner table"
        }
    ]
    ```

### Customers
#### Create a new customer
- URL: `/Customer`
- Method: POST
- Description: Create a new customer
- Request Body: JSON object representing the customer information
  - Example:
    ```json
    {
        "name": "Nick",
        "phone": "51 986026879",
        "register": "853.908.910-75"
    }
    ```
    **Note:** The register must be a CPF or CNPJ in the valid format

#### Get a customer by ID
- URL: `/Customer/{customerId}`
- Method: GET
- Description: Get customer information by ID
- Path Parameter: `customerId` (integer) - The identifier of the customer
- Response: JSON object representing the customer information
  - Example:
    ```json
    {
        "name": "Nick",
        "phone": "51 986026879",
        "register": "853.908.910-75"
    }
    ```

#### Get all customers
- URL: `/Customer`
- Method: GET
- Description: Get all customers
- Response: List of JSON objects representing the customers
  - Example:
    ```json
    [
        {
            "name": "Pedro",
            "phone": "51 986026879",
            "register": "853.908.910-75"
        },
        {
            "name": "Marcos",
            "phone": "48 98385-1557",
            "register": "12.345.678/0001-00"
        }
    ]
    ```

#### Update customer information
- URL: `/Customer/{customerId}`
- Method: PATCH
- Description: Update customer information
- Path Parameter: `customerId` (integer) - The identifier of the customer to be updated
- Request Body: JSON Patch document specifying the changes to be made to the customer information
  - Example:
    ```json
    [
        { 
            "op": "replace", 
            "path": "/name", 
            "value": "Roberto" 
        }
    ]
    ```

### Orders
#### Create a new order
**An Order can't be created without a existing product or customer**

- URL: `/Order`
- Method: POST
- Description: Create a new order
- Request Body: JSON object representing the order information
  - Example:
    ```json
    {
        "stage": 1,
        "amount": "150",
        "customerId": 1,
        "orderProducts": [
            {
                "productId": 1,
                "quantity": 10
            }
        ]
    }
    ```

#### Get an order by ID
- URL: `/Order/{orderId}`
- Method: GET
- Description: Get order information by ID
- Path Parameter: `orderId` (integer) - The identifier of the order
- Response: JSON object representing the order information
  - Example:
    ```json
    {
        "stage": 1,
        "amount": "150",
        "customerId": 1,
        "orderProducts": [
            {
                "productId": 1,
                "quantity": 10
            }
        ]
    }
    ```

#### Update order information
- URL: `/Order/{orderId}`
- Method: PATCH
- Description: Update order information
- Path Parameter: `orderId` (integer) - The identifier of the order to be updated
- Request Body: JSON Patch document specifying the changes to be made to the order information
  - Example:
    ```json
    [
        { 
            "op": "replace", 
            "path": "/amount", 
            "value": 140 
        }
    ]
    ```

#### Update product information in an order
- URL: `/Order/{orderId}/product/{productId}`
- Method: PATCH
- Description: Update information of a product in an order
- Path Parameters:
  - `orderId` (integer) - The identifier of the order
  - `productId` (integer) - The identifier of the product in the order
- Request Body: JSON Patch document specifying the changes to be made to the product information
  - Example:
    ```json
    [
        { 
            "op": "replace", 
            "path": "/quantity", 
            "value": 1 
        }
    ]
    ```