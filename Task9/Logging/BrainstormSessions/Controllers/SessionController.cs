using System;
using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;


namespace BrainstormSessions.Controllers
{
    public class SessionController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;
        readonly ILogger _logger;

        public SessionController(ILogger logger, IBrainstormSessionRepository sessionRepository)
        {
            _logger = logger is not null ? logger : throw new ArgumentNullException(nameof(logger));
            _sessionRepository = sessionRepository;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (!id.HasValue)
            {
                _logger.Warning("Session id is null");
                return RedirectToAction(actionName: nameof(Index), controllerName: "Home");
            }

            var session = await _sessionRepository.GetByIdAsync(id.Value);
            if (session == null)
            {
                _logger.Warning("Session not found.");
                return Content("Session not found.");
            }

            var viewModel = new StormSessionViewModel()
            {
                DateCreated = session.DateCreated,
                Name = session.Name,
                Id = session.Id
            };

            return View(viewModel);
        }
    }
}
