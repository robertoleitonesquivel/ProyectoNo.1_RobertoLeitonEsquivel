using Mapster;
using Models;
using ProyectoNo._1.Models;
using Services;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoNo._1.Controllers
{
    public class HerramientaController : Controller
    {

        private readonly IHerramientaService herramientaService;

        public HerramientaController()
        {
            herramientaService = new HerramientaService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Add(HerramientaDTO herramientaDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await herramientaService.GetHerramientas(herramientaDTO.Codigo);

                    if (result is object)
                        return Json(new { Succes = true, Message = "La herramienta ya se encuentra registrada." }, JsonRequestBehavior.AllowGet);

                    var modelo = herramientaDTO.Adapt<Herramienta>();

                    await herramientaService.Add(modelo);

                    return Json(new { Succes = true, Message = "Herramienta agregada con éxito." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Succes = false, Message = "Datos Inválidos." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                return Json(new { Succes = false, Message = ex.InnerException?.InnerException?.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetHerramientaByColaborador(string cedula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await herramientaService.GetHerramientasByColaborador(cedula);

                    if (result is object)
                        return Json(new { Succes = true, Message = "La herramienta ya se encuentra registrada." }, JsonRequestBehavior.AllowGet);

                    var modelo = result.Adapt<HerramientaDTO>();

                    return Json(new { Succes = true, Message = "", Data = modelo }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Succes = false, Message = "Datos Inválidos." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                return Json(new { Succes = false, Message = ex.InnerException?.InnerException?.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}