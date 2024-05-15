using DynamicForm.Application.Interfaces;
using DynamicForm.Data.Entities;
using DynamicForm.Domain.Common.Dtos;
using DynamicForm.Domain.Common.Models;
using DynamicForm.Domain.Common.Models.Settings;
using Mapster;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Application.Implementations
{
    public class ProgramService : BaseService, IProgramService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly CosmosDbSettings _cosmosDbSettings;
        private readonly Container _programContainer;
        private readonly Container _answerContainer;
        private readonly string _programContainerName = string.Empty;
        private readonly string _answerContainerName = string.Empty;
        public ProgramService(
            IOptions<CosmosDbSettings> cosmosDbSettings,
            CosmosClient cosmosClient)
        {
            _cosmosDbSettings = cosmosDbSettings.Value;
            _cosmosClient = cosmosClient;
            _programContainerName = "Programs";
            _answerContainerName = "Answers";
            _programContainer = cosmosClient.GetContainer(_cosmosDbSettings.DatabaseName, _programContainerName);
            _answerContainer = cosmosClient.GetContainer(_cosmosDbSettings.DatabaseName, _answerContainerName);

        }

        public Result<EmployeeApplicationForm> GetEmployerProgram(string programId)
        {
            var result = new Result<EmployeeApplicationForm>();
            var query = _programContainer.GetItemLinqQueryable<EmployeeApplicationForm>().Where(x => x.Id == programId).FirstOrDefault();

            if (query == null)
            {
                return SetError(404, "Program not found", result);
            }

            return SetSuccess(query, result);
        }

        public Result<List<EmployeeQuestions>> GetEmployerQuestions(string programId)
        {
            var result = new Result<List<EmployeeQuestions>>();
            var query = _programContainer.GetItemLinqQueryable<EmployeeApplicationForm>().Where(x => x.Id == programId).FirstOrDefault();

            if (query == null)
            {
                return SetError(404, "Program not found", result);
            }

            return SetSuccess(query.Questions, result);
        }

        public Result<EmployeeApplicationForm> GetEmployerProgram()
        {
            var result = new Result<EmployeeApplicationForm>();
            var query = _programContainer.GetItemLinqQueryable<EmployeeApplicationForm>().FirstOrDefault();

            if (query == null)
            {
                return SetError(404, "Program not found", result);
            }

            result.IsSuccessful = true;
            result.Data = query;

            return result;
        }

        public async Task<Result<EmployeeApplicationForm>> AddProgramAsync(EmployeeApplicationFormDto request)
        {
            var result = new Result<EmployeeApplicationForm>();

            var dbInsert = request.Adapt<EmployeeApplicationForm>();
            dbInsert.Id = Guid.NewGuid().ToString();
            dbInsert.DateCreated = DateTime.Now;
            dbInsert.DateModified = DateTime.Now;
            foreach (var item in dbInsert.Questions)
            {
                item.Id = Guid.NewGuid().ToString();
            }

            var query = await _programContainer.CreateItemAsync(dbInsert);

            if (query.StatusCode != System.Net.HttpStatusCode.Created)
            {
                return SetError(404, "Could not save Program", result);
            }

            return SetSuccess(query.Resource, result);
        }

        public async Task<Result<EmployeeApplicationForm>> UpdateProgram(UpdateEmployerApplicationFormDto request, string id)
        {
            var result = new Result<EmployeeApplicationForm>();

            var program = _programContainer.GetItemLinqQueryable<EmployeeApplicationForm>().Where(x => x.Id == id).FirstOrDefault();

            if (program == null)
            {
                return SetError(404, "Program not found", result);
            }

            //var dbInsert = request.Adapt<EmployeeApplicationForm>();
            program.DateModified = DateTime.Now;
            program.ProgramTitle = request.ProgramTitle;
            program.ProgramDescription = request.ProgramDescription;
            program.Questions = request.Questions;

            foreach (var item in program.Questions)
            {
                if (string.IsNullOrWhiteSpace(item.Id))
                    item.Id = Guid.NewGuid().ToString();
            }

            var query = await _programContainer.ReplaceItemAsync(program, program.Id);

            if (query.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return SetError(404, "Could not save Program", result);
            }

            return SetSuccess(query.Resource, result);
        }

        public async Task<Result<CandidateApplication>> SaveAnswersAsync(CandidateApplicationDto request)
        {
            var result = new Result<CandidateApplication>();
            var program = _programContainer.GetItemLinqQueryable<EmployeeApplicationForm>().Where(x => x.Id == request.ProgamId).FirstOrDefault();

            if (program == null)
            {
                return SetError(404, "Program not found", result);
            }

            var answers = request.Adapt<CandidateApplication>();
            answers.Id = Guid.NewGuid().ToString();
            answers.DateCreated = DateTime.Now;

            var query = await _answerContainer.CreateItemAsync(answers);

            if (query.StatusCode != System.Net.HttpStatusCode.Created)
            {
                return SetError(404, "Could not save Program answers", result);
            }

            return SetSuccess(query.Resource, result);

        }

    }
}
