﻿using BussinessLogic;
using DataEntities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCheckUpController : ControllerBase
    {
        IPatientCheckUP _logic;
        public PatientCheckUpController(IPatientCheckUP logic)
        {
            _logic = logic;

        }
        [HttpGet("GetCheckUpDetailsByAppointmentId")]
        public ActionResult Get([FromHeader] Guid appointment_id)
        {
            var checkUpDetails=_logic.GetCheckUpDetails(appointment_id);
            if(checkUpDetails != null) {
                return Ok();
            }
            else
            {
                return NoContent();
            }

        }


        [HttpPost("AddCheckUpDetails")]
        public ActionResult Add([FromBody] Models.PatientIntialCheckUp patientIntialCheckup)
        {
            try
            {


                _logic.AddCheckUpDetails(patientIntialCheckup);
                return Ok();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
