using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainstormSessions.Api;
using BrainstormSessions.Controllers;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using Serilog;
using Moq;
using Xunit;
using BrainstormSessions.ClientModels;

namespace BrainstormSessions.Test.UnitTests
{
    public class LoggingTests : IDisposable
    {
        Mock<ILogger> loggerMock;
        public LoggingTests()
        {
            loggerMock = new Mock<ILogger>();
            Log.Logger = loggerMock.Object;
        }

        public void Dispose() => Log.CloseAndFlush();

        [Fact]
        public async Task HomeController_Index_LogInfoMessages()
        {


            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync()).ReturnsAsync(GetTestSessions());
            var controller = new HomeController(loggerMock.Object, mockRepo.Object);
            var result = await controller.Index();
            loggerMock.Verify(x => x.Information(It.IsAny<string>()), Times.AtLeast(1), "Expected Information messages in the logs");
        }


        [Fact]
        public async Task HomeController_IndexPost_LogWarningMessage_WhenModelStateIsInvalid()
        {
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync()).ReturnsAsync(GetTestSessions());

            var controller = new HomeController(loggerMock.Object, mockRepo.Object);
            controller.ModelState.AddModelError("SessionName", "Required");
            var newSession = new HomeController.NewSessionModel();
            var result = await controller.Index(newSession);

            loggerMock.Verify(x => x.Warning(It.IsAny<string>(), newSession), Times.AtLeast(1), "Expected Information messages in the logs");
        }


        [Fact]
        public async Task IdeasController_CreateActionResult_LogErrorMessage_WhenModelStateIsInvalid()
        {
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            var controller = new IdeasController(loggerMock.Object, mockRepo.Object);
            controller.ModelState.AddModelError("error", "some error");
            var result = await controller.CreateActionResult(model: null);

            loggerMock.Verify(x => x.Warning(It.IsAny<string>(), new NewIdeaModel()), Times.AtLeast(1), "Expected Error messages in the logs");

        }

        [Fact]
        public async Task SessionController_Index_LogDebugMessages()
        {
            int testSessionId = 1;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync(GetTestSessions().FirstOrDefault(
                    s => s.Id == testSessionId));
            var controller = new SessionController(loggerMock.Object, mockRepo.Object);
            var result = await controller.Index(testSessionId);

            loggerMock.Verify(x => x.Warning(It.IsAny<string>()), Times.AtLeast(2), "Expected 2 Debug messages in the logs");

        }

        private List<BrainstormSession> GetTestSessions()
        {
            var sessions = new List<BrainstormSession>
            {
                new BrainstormSession()
                {
                    DateCreated = new DateTime(2016, 7, 2),
                    Id = 1,
                    Name = "Test One"
                },
                new BrainstormSession()
                {
                    DateCreated = new DateTime(2016, 7, 1),
                    Id = 2,
                    Name = "Test Two"
                }
            };
            return sessions;
        }

    }
}
