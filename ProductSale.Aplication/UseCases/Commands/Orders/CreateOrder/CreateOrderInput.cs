﻿using ProductSale.Domain.Entities;
using ProductSale.Domain.Enums;

namespace ProductSale.Aplication.UseCases.Commands.Orders.CreateOrder
{
    public record CreateOrderInput
    {
        public Stage Stage { get; private set; }
        public double Value { get; private set; }
        public double Profit { get; private set; }
        public int CustomerId { get; private set; }
        public HashSet<OrderProductInput> OrderProducts { get; private set; }

        public CreateOrderInput(Stage stage, double value, int customerId, HashSet<OrderProductInput> orderProducts)
        {
            Stage = stage;
            Value = value;
            CustomerId = customerId;
            OrderProducts = orderProducts;
        }

        public Order ToEntity()
        {
            var orderProducts = OrderProducts.Select(op =>
                                    new OrderProduct(op.ProductId, op.Quantity)
                                    ).ToHashSet();

            return new Order(Stage, Value, Profit, CustomerId, orderProducts);
        }
    }

    public record OrderProductInput
    {
        public int Quantity { get; private set; }
        public int ProductId { get; private set; }

        public OrderProductInput(int productId, int quantity)
        {
            Quantity = quantity;
            ProductId = productId;
        }
    }
}