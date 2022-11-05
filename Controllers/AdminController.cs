using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DummyDataMaker.Models;
using DummyDataMaker.ViewModels;
using DummyDataMaker.Services;

namespace DummyDataMaker.Controllers
{
    public class AdminController : Controller
    {
        private IAdminRepository adminRepository;

        //constructor 
        public AdminController(IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        /// <summary>
        /// to display the main page for Admin Portal
        /// </summary>
        /// <returns>Admin Home view</returns>
        [Authorize(Roles = "Admin")]
        public IActionResult AdminHome()
        {
            DataPoolViewModel model = new DataPoolViewModel();
            model.FirstNamePools = adminRepository.GetAllFirstNames();
            model.LastNamePools = adminRepository.GetAllLastNames();
            return View(model);
        }

        /// <summary>
        /// To Add a FirstName to the DataPool
        /// </summary>
        [Authorize(Roles = "Admin")]
        public IActionResult AddFirstName(string firstName)
        {
            if(firstName==null || firstName.Length==0)
            {
                ViewBag.Message = "Field blank. No value added to First Name Data Pool";
            }
            else
            {
                adminRepository.AddFirstName(firstName);
            }
            return RedirectToAction("AdminHome");
        }

        /// <summary>
        /// To Add a LastName to the DataPool
        /// </summary>
        [Authorize(Roles = "Admin")]
        public IActionResult AddLastName(string lastName)
        {
            if (lastName==null || lastName.Length == 0)
            {
                ViewBag.Message = "Field blank. No value added to Last Name Data Pool";
            }
            else
            {
                adminRepository.AddLastName(lastName);
            }
            return RedirectToAction("AdminHome");
        }

        /// <summary>
        /// To delete a FirstName from the DataPool
        /// </summary>
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteFirstName(int? id)
        {
            adminRepository.DeleteFirstNameRecord(id);
            return RedirectToAction("AdminHome");
        }

        /// <summary>
        /// To delete a LastName from the DataPool
        /// </summary>
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteLastName(int? id)
        {
            adminRepository.DeleteLastNameRecord(id);
            return RedirectToAction("AdminHome");
        }

    }
}
