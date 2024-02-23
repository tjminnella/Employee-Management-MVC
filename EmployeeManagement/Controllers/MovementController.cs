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
    public class MovementController : Controller
    {
        private readonly IMovementRepository _movementRepository;
        //private readonly IHostingEnvironment hostingEnvironment;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ILogger logger;
        private readonly IDataProtector protector;

        public MovementController(IMovementRepository movementRepository,
                              IWebHostEnvironment webHostEnvironment,
                              //IHostingEnvironment hostingEnvironment,
                              ILogger<HomeController> logger,
                              IDataProtectionProvider dataProtectionProvider,
                              DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            _movementRepository = movementRepository;
            //this.hostingEnvironment = hostingEnvironment;
            this.webHostEnvironment = webHostEnvironment;

            this.logger = logger;
            protector = dataProtectionProvider
                .CreateProtector(dataProtectionPurposeStrings.EmployeeIdRouteValue);

        }
        public JsonResult Results()
        {
            return Json(new { id = 1, name = "Thomas" });
        }

        public string Result(int? Id, string location = "", string size = "")
        {
            string str = "ID: " +  Id.ToString() +  "   Location: "  +  location  + "   Size: " + size;
            return str;
        }

        public JsonResult JDetail(int? Id)
        {
            Movement model = _movementRepository.GetMovement(Id ?? 1);
            return Json(model);
        }

        public JsonResult JDetails()
        {
            IEnumerable<Movement> model = _movementRepository.GetAllMovements();
            return Json(model);
        }
        public ViewResult Index() 
        {

            return View(_movementRepository.GetAllMovements());
        }
    }
}
