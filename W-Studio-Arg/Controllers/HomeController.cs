using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portafolio.Servicios;
using System.Diagnostics;
using W_Studio_Arg.Models;
using W_Studio_Arg.Servicios;

namespace W_Studio_Arg.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IRepositorioEmpresa repositorioEmpresa;
        private readonly IServicioEmail _servicioEmail;

        // Inyección de dependencias
        public HomeController(ILogger<HomeController> logger,
                              IRepositorioEmpresa repositorioEmpresa,
                              IServicioEmail servicioEmail)
        {
            this.logger = logger;
            this.repositorioEmpresa = repositorioEmpresa;
            this._servicioEmail = servicioEmail;
        }

        // Acción para la página principal
        [HttpGet]
        public IActionResult Index()
        {
            var nombreEmpresa = repositorioEmpresa.NombreEmpresa();

            var empresa = new EmpresaViewModel
            {
                Nombre = nombreEmpresa
            };

            var modelo = new HomeIndexViewModel()
            {
                Nombre = empresa
            };

            return View(modelo);
        }

        // Acción para la página de contacto
        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        // Acción para la confirmación del mensaje
        [HttpGet]
        public IActionResult Gracias()
        {
            return View();
        }

        // Acción para manejar los errores
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Acción para procesar el formulario de contacto
        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            if (ModelState.IsValid)
            {
                // Enviar el correo usando el servicio IServicioEmail
                await _servicioEmail.Enviar(contactoViewModel);

                // Redirigir a la página de agradecimiento
                return RedirectToAction("Gracias");
            }

            // Si hay algún error en el formulario, volvemos a mostrar la página de contacto con los datos enviados
            return View(contactoViewModel);
        }
    }
}
