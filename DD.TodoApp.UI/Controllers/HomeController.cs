using AutoMapper;
using DD.TodoApp.Business.Interfaces;
using DD.TodoApp.Dtos.WorkDtos;
using DD.TodoApp.UI.Extensions;
using DD.ToDoApp.Common.ResponseObjects;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DD.TodoApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _workservice;

        public HomeController(IWorkService workservice)
        {
            _workservice = workservice;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _workservice.GetAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto dto)
        {
            var response = await _workservice.Create(dto);
            return this.ResponseRedirectToAction(response, "Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var response = (await _workservice.GetById<WorkUpdateDto>(id));
            return this.ResponseView(response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {
            var response = await _workservice.Update(dto);
            return this.ResponseRedirectToAction(response, "Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _workservice.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
        }
        public IActionResult NotFound(int code)
        {
            return View();
        }
    }
}
