# ProductSale

API to manage products and orders.

## Prerequesites
- Docker

## How to execute
1. Stop the local MySQL service as it will conflict with the Docker container
2. Run the command 'docker-compose up -d'
3. Run the command 'docker container ls' and get the port of the container with the name 'product-sale-api'
4. Access 'localhost:{container port}/swagger/index.html' in your browser to see the list of endpoints

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