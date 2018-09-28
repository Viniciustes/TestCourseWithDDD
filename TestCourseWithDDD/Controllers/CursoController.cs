using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestCourseWithDDD.Domain.Dtos;
using TestCourseWithDDD.Utilities;

namespace TestCourseWithDDD.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Index()
        {
            var cursos = new List<CursoDto>();

            return View("Index", PaginatedList<CursoDto>.CreatePaginatedList(cursos, Request));
        }

        public IActionResult Create()
        {
            return View("Cadastrar_Editar", new CursoDto());
        }

        [HttpPost]
        public IActionResult Save(CursoDto curso)
        {
            return Ok();
        }
    }
}