using DynamicForm.Application.Interfaces;
using DynamicForm.Data.Entities;
using DynamicForm.Domain.Common.Dtos;
using DynamicForm.Domain.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DynamicForm.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _programService;
        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }

        /// <summary>
        /// An API to get program info
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Result<EmployeeApplicationForm>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        [HttpGet("program/{id}")]
        public IActionResult GetEmployerProgram(string id)
        {
            var result = _programService.GetEmployerProgram(id);
            if(result.IsSuccessful)
            {
                return Ok(result);
            }
            return StatusCode(result.ErrorResponse.ResponseCode, result.ErrorResponse);
        }

        /// <summary>
        /// An API to get program questions
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Result<EmployeeQuestions>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        [HttpGet("programQuestions/{id}")]
        public IActionResult GetProgramQuestions(string id)
        {
            var result = _programService.GetEmployerQuestions(id);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return StatusCode(result.ErrorResponse.ResponseCode, result.ErrorResponse);
        }

        /// <summary>
        /// An API to add program
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Result<EmployeeApplicationForm>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        [HttpPost("addProgram")]
        public async Task<IActionResult> Addprogram([FromBody] EmployeeApplicationFormDto request)
        {
            var result = await _programService.AddProgramAsync(request);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return StatusCode(result.ErrorResponse.ResponseCode, result.ErrorResponse);
        }

        /// <summary>
        /// An API to update program
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Result<EmployeeApplicationForm>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        [HttpPut("updateProgram/{id}")]
        public async Task<IActionResult> Updateprogram([FromBody] UpdateEmployerApplicationFormDto request, string id)
        {
            var result = await _programService.UpdateProgram(request, id);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return StatusCode(result.ErrorResponse.ResponseCode, result.ErrorResponse);
        }

        /// <summary>
        /// An API to save answesr for a  program
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Result<EmployeeApplicationForm>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        [HttpPost("saveProgramAnswers")]
        public async Task<IActionResult> SaveAnswers([FromBody] CandidateApplicationDto request)
        {
            var result = await _programService.SaveAnswersAsync(request);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return StatusCode(result.ErrorResponse.ResponseCode, result.ErrorResponse);
        }


    }
}
