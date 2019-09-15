using RepositoryDesignPatternInASP.NETMVC.Models;
using RepositoryDesignPatternInASP.NETMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryDesignPatternInASP.NETMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController()
        {
            _employeeRepository = new EmployeeRepository(new CRUDDbContext());
        }
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        // GET: Home
        public ActionResult Index()
        {
            var employee = _employeeRepository.GetEmployees();
            return View(employee);
        }

        public ActionResult Details(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.NewEmployee(employee);
                _employeeRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.UpdateEmployee(employee);
                _employeeRepository.Save();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View(employee);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            _employeeRepository.Save();
            return RedirectToAction("Index", "Home");
        }
    }
}