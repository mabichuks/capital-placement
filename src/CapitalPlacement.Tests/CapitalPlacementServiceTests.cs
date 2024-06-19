using CapitalPlacement.Core.Exceptions;
using CapitalPlacement.Core.Interface.Repositories;
using CapitalPlacement.Core.Models;
using CapitalPlacement.Core.Services;
using FluentAssertions;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace CapitalPlacement.Tests
{
    public class CapitalPlacementServiceTests
    {
        private readonly Mock<ICandidateApplicationRepository> _candidateRepo;
        private readonly Mock<IProgramRepository> _programRepo;
        private readonly CandidateApplicationService candidateApplicationService;
        private readonly ProgramService programService;

        public CapitalPlacementServiceTests()
        {
            _candidateRepo = new Mock<ICandidateApplicationRepository>();
            _programRepo = new Mock<IProgramRepository>();
            candidateApplicationService = new CandidateApplicationService(_candidateRepo.Object, _programRepo.Object);
            programService = new ProgramService(_programRepo.Object);
        }


        [Fact]
        public async Task Create_Program_Returns_Program_With_Id()
        {
            //arrange
            var prog = new ProgramModel
            {
                Title = "Summer Internship",
                Questions =
                {
                    new Question
                    {
                        Text = "First Name",
                        IsMandatory = true,
                        IsPersonalInformaton = true,
                        QuestionType = QuestionType.Text
                    },
                    new Question
                    {
                        Text = "Years of experience",
                        IsMandatory = true,
                       IsPersonalInformaton = false,
                       QuestionType = QuestionType.Number
                    }
                }
            };

            _programRepo.Setup(x => x.Add(prog)).ReturnsAsync(prog);

            var result = await programService.CreateProgram(prog);

            result.Should().NotBeNull();
            result.Id.Should().NotBeNull();
        }

        [Fact]
        public async Task Update_Program_Throws_Error_When_Id_Not_Found()
        {
            //arrange
            var prog = new ProgramModel
            {
                Title = "Summer Internship",
                Questions =
                {
                    new Question
                    {
                        Text = "First Name",
                        IsMandatory = true,
                        IsPersonalInformaton = true,
                        QuestionType = QuestionType.Text
                    },
                    new Question
                    {
                        Text = "Years of experience",
                        IsMandatory = true,
                       IsPersonalInformaton = false,
                       QuestionType = QuestionType.Number
                    }
                }
            };

            _programRepo.Setup(x => x.Update(prog)).ReturnsAsync(It.IsAny<ProgramModel>());
            _programRepo.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(It.IsAny<ProgramModel>());
            _programRepo.Setup(x => x.Delete(It.IsAny<string>()));

            var updateResult = async () => await programService.UpdateQuestions(prog);
            var getResult = async () => await programService.GetById(Guid.NewGuid().ToString());
            var deleteResult = async () => await programService.GetById(Guid.NewGuid().ToString());
            await Assert.ThrowsAsync<NotFoundException>(updateResult);
            await Assert.ThrowsAsync<NotFoundException>(getResult);
            await Assert.ThrowsAsync<NotFoundException>(deleteResult);

        }

        [Fact]
        public async Task Submit_Application_Throws_Validation_Error_When_Candidate_ProgramId_Is_Empty()
        {
            var answer = new CandidateApplication
            {
                Answers =
                {
                    new Answer
                    {
                        QuestionId = "213234234",
                        Response = "test response"
                    }
                }
            };

            var response = async () => await candidateApplicationService.SubmitCandidateApplicationAsync(answer);
            await Assert.ThrowsAsync<ValidationException>(response);

        }

        [Fact]
        public async Task Submit_Application_Throws_NotFound_Error_When_Candidate_Program_Is_NotFound()
        {
            var answer = new CandidateApplication
            {
                ProgramId = "23323-fef-f2",
                Answers =
                {
                    new Answer
                    {
                        QuestionId = "213234234",
                        Response = "test response"
                    }
                }
            };

            _programRepo.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(It.IsAny<ProgramModel>());

            var response = async () => await candidateApplicationService.SubmitCandidateApplicationAsync(answer);
            await Assert.ThrowsAsync<NotFoundException>(response);

        }

        [Fact]
        public async Task SubmitApplication_Returns_Application_With_Id()
        {
            var answer = new CandidateApplication
            {
                ProgramId = "23323-fef-f2",
                Answers =
                {
                    new Answer
                    {
                        QuestionId = "213234234",
                        Response = "test response"
                    }
                }
            };

            _programRepo.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(new ProgramModel());

            var result = await candidateApplicationService.SubmitCandidateApplicationAsync(answer);

            result.Should().NotBeNull();
            result.Id.Should().NotBeNull();
        }
    }
}
