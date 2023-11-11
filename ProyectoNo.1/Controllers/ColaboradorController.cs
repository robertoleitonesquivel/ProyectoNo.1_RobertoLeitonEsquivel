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
       
        public ActionResult Index()
        {
            var estados = new List<SelectListItem>
                        {
                            new SelectListItem { Text = "--Seleccione--", Value = "" },
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
                if (ModelState.IsValid)
                {
                    var modelo = colaboradorDTO.Adapt<Colaborador>();

                    await colaboradorService.Add(modelo);

                    return Json(new { Succes = true, Message = "Colaborador agregado con éxito." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Succes = false, Message = "Datos Inválidos." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                return Json(new { Succes = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}