using DynamicForm.Data.Entities;
using DynamicForm.Domain.Common.Dtos;
using DynamicForm.Domain.Common.Models;

namespace DynamicForm.Application.Interfaces
{
    public interface IProgramService
    {
        Task<Result<EmployeeApplicationForm>> AddProgramAsync(EmployeeApplicationFormDto request);
        Result<EmployeeApplicationForm> GetEmployerProgram();
        Result<EmployeeApplicationForm> GetEmployerProgram(string programId);
        Result<List<EmployeeQuestions>> GetEmployerQuestions(string programId);
        Task<Result<CandidateApplication>> SaveAnswersAsync(CandidateApplicationDto request);
        Task<Result<EmployeeApplicationForm>> UpdateProgram(UpdateEmployerApplicationFormDto request, string id);
    }
}