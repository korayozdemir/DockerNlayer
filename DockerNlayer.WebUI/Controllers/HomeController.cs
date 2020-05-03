using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DockerNlayer.WebUI.Models;
using DockerNlayer.BLL.Abstract;
using DockerNlayer.DTO;

namespace DockerNlayer.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        public HomeController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        public IActionResult Index()
        {
            return View(categoryService.getAll());
        }

        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(CategoryDTO categoryDTO)
        {
            categoryService.newCategory(categoryDTO);
            return RedirectToAction("Index");
        }
    }
}
