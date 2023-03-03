using System.Security.Claims;
using application;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;

namespace otus_order_service.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private DataBaseService _dbService;

    public OrderController(ILogger<OrderController> logger, DataBaseService service)
    {
        _logger = logger;
        _dbService = service;
    }
    
    [HttpPost]
    [Route("/Order")]
    [ActionName("sdfsd")]
    public IActionResult CreateOrderID()
    {
        var _order = _dbService.Create(new Order());
        return Ok(new Response() { Data = _order.OrderID });
    }
    [HttpPut]
    [Route("{orderID}")]
    public IActionResult CreateOrder(string orderID, OrderRequest orderrequest)
    {
        var checkorder = _dbService.Find(orderID);
        if (checkorder.OrderID is null)
            return NotFound();
        else
        {
            _dbService.Update(orderID, orderrequest);
            return Ok();
        }
    }

    [HttpGet]
    [Route("{orderID}")]
    public IActionResult GetOrderDetails(string orderID)
    {
        var order = _dbService.Find(orderID);
        return Ok(new Response() { Data = order });

    }
    [HttpPut]
    [Route("cancel/{orderID}")]
    public IActionResult CancelOrder(string orderID)
    {
        var checkorder = _dbService.Find(orderID);
        if (checkorder.OrderID is null)
            return NotFound();
        else
        {
            _dbService.Update(orderID);
            return Ok();
        }
    }
}

