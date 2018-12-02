namespace LeadScreen.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using LeadScreen.API.Infrastructure.Filters;
    using LeadScreen.Models.ServiceModels;
    using LeadScreen.Services.Contracts;
    using LeadScreen.AzureTable.Models;

    public class LeadController : BaseApiController
    {
        private const string InvalidLeadRequestError = "A valid lead id must be provided";
        private const string InvalidPinCodeError = "The pin is not valid";

        private readonly ILeadService leadService;
        private readonly ISubAreaService subAreaService;
        //private readonly IAzureService azureService;

        public LeadController(ILeadService leadService, ISubAreaService subAreaService)//, IAzureService azureService)
        {
            this.leadService = leadService;
            this.subAreaService = subAreaService;
            //this.azureService = azureService;
        }

        //[HttpGet("{id:int:min(1)}")]
        [Route("GetLead/{id:int:min(1)}")]
        public async Task<IActionResult> GetLead(int id)
        {
            if (await this.leadService.LeadExists(id))
            {
                return this.Ok(await this.leadService.GetDetails(id));
            }

            return NotFound(InvalidLeadRequestError);
        }

        //[HttpGet("{{pinCode:int:regex(^\\d{6}$)}}")]
        [Route("GetSubAreas/{pinCode:int}")]
        public async Task<IActionResult> GetSubAreas(int pinCode)
        {
            if (await this.subAreaService.PinExists(pinCode))
            {
               return this.Ok(await this.subAreaService.SubAreasByPin(pinCode));
            }
       
            return BadRequest(InvalidPinCodeError);
        }

        [HttpPost]
        [ValidateModelState]
        [ProducesResponseType(200, Type = typeof(LeadCreateModel))]   //AzureLead  //LeadCreateModel
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody]LeadCreateModel lead)   //AzureLead
        {
            await this.leadService.CreateLead(lead);
            return Ok();
        }
    }
}