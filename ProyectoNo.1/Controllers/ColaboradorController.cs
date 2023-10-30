using Mapster;
using Models;
using Services;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoNo._1.Controllers
{
    public class ColaboradorController : Controller
    {

        private readonly IColaboradorService colaboradorService;

        public ColaboradorController()
        {
            colaboradorService = new ColaboradorService();
        }
        // GET: Colaborador
        public ActionResult Index()
        {
            var estados = new List<SelectListItem>
                        {
                            new SelectListItem { Text = "Activo", Value = "Activo" },
                            new SelectListItem { Text = "Inactivo", Value = "Inactivo" }
                        };

            ViewBag.EstadoList = new SelectList(estados, "Value", "Text");


            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Add(ColaboradorDTO colaboradorDTO)
        {
            try
            {
                var modelo = colaboradorDTO.Adapt<Colaborador>();
                await colaboradorService.Add(modelo);

                return View(colaboradorDTO);
            }
            catch (Exception ex)
            {

              return View(colaboradorDTO);  
            }
        }
    }
}