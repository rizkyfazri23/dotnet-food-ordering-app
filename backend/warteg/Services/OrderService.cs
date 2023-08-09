using System;
using System.Collections.Generic;
using System.Linq;
using warteg.Models;
using warteg.Repositories;
using System.Text.Json;

namespace warteg.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly FoodRepository _foodRepository;
        private readonly PaymentRepository _paymentRepository;

        public OrderService(OrderRepository orderRepository, FoodRepository foodRepository, PaymentRepository paymentRepository)
        {
            _orderRepository = orderRepository;
            _foodRepository = foodRepository;
            _paymentRepository = paymentRepository;
        }

        public Order CreateOrder(List<OrderDetail> orderDetails)
        {
            if (orderDetails == null || orderDetails.Count == 0)
            {
                throw new ArgumentException("Order details are required.");
            }

            Console.WriteLine("Data sent from frontend:");
            Console.WriteLine(JsonSerializer.Serialize(orderDetails, new JsonSerializerOptions { WriteIndented = true }));

            foreach (var orderDetail in orderDetails)
            {
                if (orderDetail.Quantity <= 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid quantity.");
                }

                var food = _foodRepository.GetFoodById(orderDetail.FoodId);
                if (food == null)
                {
                    throw new ArgumentException("Invalid food ID.");
                }

                orderDetail.UnitPrice = food.Price;
                orderDetail.Subtotal = orderDetail.UnitPrice * orderDetail.Quantity; // Calculate subtotal
            }

            var order = new Order
            {
                OrderTime = DateTime.UtcNow,
                OrderDetails = orderDetails
            };

            _orderRepository.CreateOrder(order);
            return order;
        }

        public Payment ProcessPayment(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentException("Payment information is required.");
            }

            var order = _orderRepository.GetOrderById(payment.OrderId);
            if (order == null)
            {
                throw new ArgumentException("Invalid order ID.");
            }

            if (payment.Amount < order.OrderDetails.Sum(detail => detail.Subtotal))
            {
                throw new ArgumentException("Insufficient payment amount.");
            }

            payment.PaymentDate = DateTime.UtcNow;

            _paymentRepository.ProcessPayment(payment);

            return payment;
        }
    }
}
