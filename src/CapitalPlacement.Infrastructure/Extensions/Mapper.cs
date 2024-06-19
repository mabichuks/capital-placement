using CapitalPlacement.Core.Models;
using CapitalPlacement.Core.Utils;
using CapitalPlacement.Infrastructure.Entities;
using System.Text.Json;

namespace CapitalPlacement.Infrastructure.Extensions
{
    public static class Mapper
    {
        public static QuestionEntity ToEntity(this Question model, string id)
        {

            return new QuestionEntity
            {
                AllowMultiSelect = model.AllowMultiSelect,
                HasOther = model.HasOther,
                Id = Guid.NewGuid().ToString(),
                IsHidden = model.IsHidden,
                IsInternal = model.IsInternal,
                IsMandatory = model.IsMandatory,
                Max = model.Max,
                MaxLength = model.MaxLength,
                Min = model.Min,
                Options = model.Options,
                QuestionType = model.QuestionType.ToString(),
                Text = model.Text,
                IsPersonalInformaton = model.IsPersonalInformaton,
                ProgramEntityId = id
            };
        }

        public static Question ToModel(this QuestionEntity model, string id)
        {
            return new Question
            {

                AllowMultiSelect = model.AllowMultiSelect,
                HasOther = model.HasOther,
                Id = model.Id,
                IsHidden = model.IsHidden,
                IsInternal = model.IsInternal,
                IsMandatory = model.IsMandatory,
                Max = model.Max,
                MaxLength = model.MaxLength,
                Min = model.Min,
                Options = model.Options,
                QuestionType = EnumParser.ToEnum<QuestionType>(model.QuestionType),
                Text = model.Text,
                IsPersonalInformaton = model.IsPersonalInformaton,
                ProgramEntityId = id
            };
        }

        public static AnswerEntity ToEntity(this Answer model)
        {
            return new AnswerEntity
            {
                Question = model.Question,
                QuestionId = model.QuestionId,
                Response = JsonSerializer.Serialize(model.Response)
            };
        }

        public static Answer ToModel(this AnswerEntity model)
        {
            return new Answer
            {
                Question = model.Question,
                QuestionId = model.QuestionId,
                Response = model.Response
            };
        }
    }
}
