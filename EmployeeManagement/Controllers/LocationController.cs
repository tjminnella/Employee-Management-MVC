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
    public class LocationController : Controller
    {
        private readonly ILocationRepository _locationRepository;
        //private readonly IHostingEnvironment hostingEnvironment;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ILogger logger;
        private readonly IDataProtector protector;

        public LocationController(ILocationRepository locationRepository,
                              IWebHostEnvironment webHostEnvironment,
                              //IHostingEnvironment hostingEnvironment,
                              ILogger<LocationController> logger,
                              IDataProtectionProvider dataProtectionProvider,
                              DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            _locationRepository = locationRepository;
            //this.hostingEnvironment = hostingEnvironment;
            this.webHostEnvironment = webHostEnvironment;

            this.logger = logger;
            protector = dataProtectionProvider
                .CreateProtector(dataProtectionPurposeStrings.EmployeeIdRouteValue);
        }
        public JsonResult JResult(int Id)
        {
            return Json(new { Location = "Here", Movement = "There", Desription = "Neither Here nor There" });
        }
        public ViewResult Index(int? Id)
        {
            Location location = _locationRepository.GetLocation(Id ?? 1);
            LocationViewModel model = new LocationViewModel
            {
                Location = location,
                Locations = _locationRepository.GetAllLocations(),
                PageTitle = "This is the Location Page"
            };
            return View(model);
            
        }
    }
}
