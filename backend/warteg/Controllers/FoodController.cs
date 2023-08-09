using Microsoft.AspNetCore.Mvc;
using warteg.Models;
using warteg.Services;
using System.Collections.Generic; 
namespace warteg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly FoodService _foodService;
        private readonly OrderService _orderService;

        public FoodController(FoodService foodService, OrderService orderService)
        {
            _foodService = foodService;
            _orderService = orderService;
        }

        [HttpGet("{foodId}")]
        public ActionResult<Food> GetFoodDetail(int foodId)
        {
            var food = _foodService.GetFoodById(foodId);
            if (food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }

        [HttpPost("create-order")]
        public ActionResult<Order> CreateOrder(List<OrderDetail> orderDetails)
        {
            if (orderDetails == null || orderDetails.Count == 0)
            {
                return BadRequest("Order details are required.");
            }

            var order = _orderService.CreateOrder(orderDetails);
            return Ok(order);
        }

        [HttpGet("get-all-food")]
        public ActionResult<List<Food>> GetAllFood()
        {
            var foods = _foodService.GetAllFood();
            return Ok(foods);
        }
        
        [HttpPost("process-payment")]
        public ActionResult<Payment> ProcessPayment(Payment payment)
        {
            if (payment == null)
            {
                return BadRequest("Payment information is required.");
            }

            var processedPayment = _orderService.ProcessPayment(payment);
            return Ok(processedPayment);
        }
    }
}
