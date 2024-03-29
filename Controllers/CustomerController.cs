using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RJP.Exceptions;
using RJP.Models;
using RJP.Requests;
using RJP.Responses;
using RJP.Services;

namespace RJP.Controllers;


public class CustomerController : Controller{
     
    private readonly DataDbContext _dbContext;
    private readonly ICustomerService _customerService;

    public CustomerController(DataDbContext dataDbContext, ICustomerService customerService){
        _customerService = customerService;
        _dbContext = dataDbContext;
    }
   

    [HttpGet("Customer/{customerId}/account-info")]
    public IActionResult GetInfo([FromRoute] int customerId )
    {
        try{
            
            var info = _customerService.GetAccountInfo(customerId);
            //return View("CustomerDetails",info);
            return Ok(info);

        }catch(CustomerNotFoundException e){
            return NotFound();
        }
    }

    [HttpPost("Customer/OpenAccount")]
    public IActionResult OpenAccount([FromBody] OpenAccountRequest request)
    {   
        try
        {
            _customerService.OpenAccount(request.CustomerId, request.InitialCredit);
            return Ok(new { success = true });
        }
        catch (CustomerNotFoundException e){
            return NotFound("Customer not found");
        }
    }


    [HttpGet("Customer")]
    public IActionResult Index()
    {   
        var customers = _customerService.GetAll();
        // var viewModel = new CustomerListViewModel
        // {
        //     Customers = customers
        // };
        // return View("Customer",viewModel);
        return Ok(customers);
    }

}