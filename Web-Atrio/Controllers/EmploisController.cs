using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Atrio.Models.Dto;
using Web_Atrio.Services;

namespace Web_Atrio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploisController : ControllerBase
    {
        private readonly IEmploisService _emploisService;
        private readonly IPersonneService _personneService;

        public EmploisController(IEmploisService emploisService, IPersonneService personneService)
        {
            _emploisService = emploisService;
            _personneService = personneService;
        }

        [HttpPost]
        [Route("CreateEmplois")]
        public async Task<ActionResult<EmploisDto>> Ajouter(EmploisDto emploisDto)
        {
            if(emploisDto == null) 
                return BadRequest(ModelState);
            var personne = await _personneService.GetById(emploisDto.PersonneId.Value);
            if(personne == null)
                return BadRequest(ModelState);

            try
            {
                var response = await _emploisService.CreateEmplois(emploisDto,personne);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());

            }
        }

        [HttpGet]
        [Route("EntreDeuxDates")]
        public async Task<ActionResult<EmploisDto>> GetBetweenDates([FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
        {
            try
            {
                var response = await _emploisService.GetAllEmplois(startDate, endDate);
                return Ok(response);
            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());

            }
        }


    }
}
