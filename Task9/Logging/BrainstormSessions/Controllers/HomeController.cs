using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BrainstormSessions.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;
        readonly ILogger _logger;

        public HomeController(ILogger logger, IBrainstormSessionRepository sessionRepository)
        {
            _logger = logger is not null ? logger : throw new ArgumentNullException(nameof(logger));
            _sessionRepository = sessionRepository;
        }

        public async Task<IActionResult> Index()
        {
            var sessionList = await _sessionRepository.ListAsync();

            var model = sessionList.Select(session => new StormSessionViewModel()
            {
                Id = session.Id,
                DateCreated = session.DateCreated,
                Name = session.Name,
                IdeaCount = session.Ideas.Count
            });
            _logger.Information("Current session parameters: {@StormSessionViewModel}", model.First());
            return View(model);
        }

        public class NewSessionModel
        {
            [Required]
            public string SessionName { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Index(NewSessionModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.Warning("Warning: Bad session params: {@NewSessionModel}", model);
                return BadRequest(ModelState);
            }
            else
            {
                await _sessionRepository.AddAsync(new BrainstormSession()
                {
                    DateCreated = DateTimeOffset.Now,
                    Name = model.SessionName
                });
            }
            _logger.Information($"Adding session with name: {model.SessionName}");
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
