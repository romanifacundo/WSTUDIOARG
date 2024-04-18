using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using W_Studio_Arg.Models;
using W_Studio_Arg.Servicios;

namespace W_Studio_Arg.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IRepositorioEmpresa repositorioEmpresa;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger,
                              IRepositorioEmpresa repositorioEmpresa,
                              IRepositorioProyectos repositorioProyectos,
                              IConfiguration configuration)
        {
            this.logger = logger;
            this.repositorioEmpresa = repositorioEmpresa;
            this.repositorioProyectos = repositorioProyectos;
            //this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var nombreEmpresa = repositorioEmpresa.NombreEmpresa();

            var empresa = new EmpresaViewModel
            {
                Nombre = nombreEmpresa
            };

            var proyectos = repositorioProyectos.ObtenerProyecto().Take(3).ToList();

            var modelo = new HomeIndexViewModel()
            {
                Proyectos = proyectos,
                Nombre = empresa
            };

            return View(modelo);
        }

        [HttpGet]
        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyecto();

            return View(proyectos);
        }

        [HttpGet]
        public IActionResult Contacto()
        {   
            return View(); 
        }

        [HttpPost]
        public IActionResult Contacto(ContactoViewModel contactoViewModel)
        {
            return RedirectToAction("MensajeDeConfirmacionFormulario");
        }

        [HttpGet]
        public IActionResult MensajeDeConfirmacionFormulario()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
