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
    public class PrestarHerramientaController : Controller
    {
        private readonly IColaboradorService colaboradorService;
        private readonly IHerramientaService herramientaService;
  

        public PrestarHerramientaController()
        {
            colaboradorService = new ColaboradorService();
            herramientaService = new HerramientaService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Add(List<PrestarHerramientaDTO> prestarHerramientaDTO)
        {

            try
            {
                var modelo = prestarHerramientaDTO.Adapt<List<PrestarHerramienta>>();

                await herramientaService.Prestar(modelo);

                return Json(new { Succes = true, Message = "Prestamo agregado con éxito", Data = modelo }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Succes = false, Message = ex.InnerException?.InnerException?.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetColaborador(string cedula)
        {

            try
            {
                var result = await colaboradorService.GetByCedula(cedula);
                var modelo = result.Adapt<GetColaboradorDTO>();

                string message = modelo is object ? "" : "No se obtuvieron datos.";

                return Json(new { Succes = true, Message = message, Data = modelo }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Succes = false, Message = ex.InnerException?.InnerException?.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetHerramientas(int codigo)
        {

            try
            {
                var result = await herramientaService.GetHerramientas(codigo);
                var modelo = result.Adapt<GetHerramientaDTO>();

                string message = modelo is object ? "" : "No se obtuvieron datos.";

                return Json(new { Succes = true, Message = message, Data = modelo }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Succes = false, Message = ex.InnerException?.InnerException?.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}