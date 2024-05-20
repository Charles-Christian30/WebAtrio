using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Atrio.Models.Dto;
using Web_Atrio.Services;

namespace Web_Atrio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnesController : ControllerBase
    {
        private readonly IPersonneService _personneService;
        public PersonnesController(IPersonneService personneService)
        {
            _personneService = personneService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<PersonneDtoRequest>> Ajouter(PersonneDtoRequest personne)
        {
            if (personne == null)
                return BadRequest();
            if ((DateTime.Now - personne.DateNaissance).TotalDays / 365 > 150)
                throw new Exception("La personne doit être agés moins de 150 ans");

            try
            {
                await _personneService.CreatePersonne(personne);
                return Ok(personne);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<PersonneDtoResponse>> List([FromQuery] string? companyName = null)
        {
            try
            {
                var response = await _personneService.GetAllPersonnes(companyName);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
