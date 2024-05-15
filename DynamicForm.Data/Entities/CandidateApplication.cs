using DynamicForm.Domain.Common.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Data.Entities
{
    public class CandidateApplication
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("progamId")]
        public string ProgamId { get; set; }

        [JsonProperty("answers")]
        public List<CandidateAnswerDto> Answers { get; set; } = [];

        [JsonProperty("dateCreated")]
        public DateTime DateCreated { get; set; }
    }
}
