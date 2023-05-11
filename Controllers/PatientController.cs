using CoronaManagement.BL;
using CoronaManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientBL _patientBL;

        public PatientController(IPatientBL patientBL)
        {
            _patientBL = patientBL;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<PersonalDetail> Get()
        {
            return _patientBL.GetDetails();
        }
        [HttpGet("ActivePatients")]
     
        public object ActivePatients(DateTime day)
        {
            return (activePatient: _patientBL.ActivePatients(day), date: day);
        }
        [HttpGet("NotVaccinated")]
        public int NotVaccinated()
        {
            return _patientBL.NotVaccinated();
        }
        // POST api/<ValuesController>
        [HttpPost]
        //add picture for patient
        public void Post([FromBody] PersonalDetail personalDetail)
        {
            _patientBL.PostPatient(personalDetail);
        }
        //POST api/<ValuesController>
        //add picture for patient
        //[HttpPost("PostImg/{id}")]
        //public async Task<IActionResult> PostImg(int id, [FromForm] Picture picture)
        //{
        //    var patient = await _patientBL.GetPatientById(id);
        //    if (await _patientBL.PostImg(picture, id) > 0)
        //    {
        //        return Ok();
        //    }
        //    return NotFound();
        //}
    }
}
