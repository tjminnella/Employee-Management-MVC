using EmployeeManagement.Models;
using EmployeeManagement.Security;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class ActionController : Controller
    {
        private readonly IActionRepository _actionRepository;
        //private readonly IHostingEnvironment hostingEnvironment;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ILogger logger;
        private readonly IDataProtector protector;

        public ActionController(IActionRepository actionRepository,
                              IWebHostEnvironment webHostEnvironment,
                              //IHostingEnvironment hostingEnvironment,
                              ILogger<HomeController> logger,
                              IDataProtectionProvider dataProtectionProvider,
                              DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            _actionRepository = actionRepository;
            //this.hostingEnvironment = hostingEnvironment;
            this.webHostEnvironment = webHostEnvironment;

            this.logger = logger;
            protector = dataProtectionProvider
                .CreateProtector(dataProtectionPurposeStrings.EmployeeIdRouteValue);
        }

        public ViewResult Index(int? Id) 
        {
            EmployeeManagement.Models.Action model = _actionRepository.GetAction(Id ?? 1);
            ActionViewModel actionDetailsViewModel = new ActionViewModel()
            {
                Action = model,
                Actions = _actionRepository.GetAllActions(),
                PageTitle = "This is the Action Page"
            };
            return View(actionDetailsViewModel);
        }
    }
}
