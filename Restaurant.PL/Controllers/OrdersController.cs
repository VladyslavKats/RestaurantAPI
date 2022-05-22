using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL;
using Restaurant.BLL.Interfaces;
using Restaurant.BLL.Models;
using Restaurant.PL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetAll()
        {
            try
            {
                var ordersFromService = await orderService.GetAllOrdersAsync();
                var orders = mapper.Map<IEnumerable<OrderViewModel>>(ordersFromService);
                return Ok(orders);
            } catch (RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderViewModel>> Add([FromBody] OrderCreateModel model)
        {
            try
            {
                var orderToAdd = mapper.Map<OrderDto>(model);
                var orderAdded = await orderService.AddOrderAsync(orderToAdd);
                var order = mapper.Map<OrderViewModel>(orderAdded);
                return Ok(order);
            }
            catch (RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await orderService.DeleteOrderAsync(id);
                return Ok();
            } catch (RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> CompleteOrder(int id)
        {
            try
            {
                await orderService.CompleteOrderAsync(id);
                return Ok();
            } catch (RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{userLogin}")]
        public async Task<ActionResult<IEnumerable<OrderDetailModel>>> OrdersByUser(string userLogin){
            try
            {
                var ordersFromService = await orderService.GetOrdersByUser(userLogin);
                var orders = mapper.Map<IEnumerable<OrderDetailModel>>(ordersFromService);
                return Ok(orders);

            }
            catch (RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
