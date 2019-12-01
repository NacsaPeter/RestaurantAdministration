using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAdministration.Application.Dtos;
using RestaurantAdministration.Application.Interfaces;

namespace RestaurantAdministration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentAppService _service;

        public PaymentController(IPaymentAppService service)
        {
            _service = service;
        }

        [HttpPost("invoice")]
        public async Task<ActionResult<InvoiceDto>> GenerateInvoice(GenerateInvoiceDto generateInvoiceDto)
        {
            if (generateInvoiceDto == null)
            {
                return BadRequest("Invoice data must be set!");
            }
            try
            {
                return Ok(await _service.GenerateInvoiceAsync(generateInvoiceDto));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Pay(OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Order data must be set!");
            }
            try
            {
                await _service.PayAsync(orderDto);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost("payment")]
        public async Task<ActionResult<PaymentResultDto>> GeneratePayment(GeneratePaymentDto generatePaymentDto)
        {
            if (generatePaymentDto == null)
            {
                return BadRequest("Payment data must be set!");
            }
            try
            {
                return Ok(await _service.GeneratePaymentAsync(generatePaymentDto));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}