using W_Studio_Arg.Models;

namespace W_Studio_Arg.Servicios
{
    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<Proyecto> ObtenerProyecto()
        {
            return new List<Proyecto>()
            {
                new Proyecto()
                {
                    Titulo = "Gestion de turnos",
                    Descripcion = "Sistema de gestion de turnos para barberia",
                    Link = "https://www.youtube.com/"
                },
                new Proyecto()
                {
                    Titulo = "Gestion de turnos",
                    Descripcion = "Sistema de gestion de turnos para barberia",
                    Link = "https://www.youtube.com/"
                },
                new Proyecto()
                {
                    Titulo = "Gestion de turnos",
                    Descripcion = "Sistema de gestion de turnos para barberia",
                    Link = "https://www.youtube.com/"
                }
            };
        }
    }
}
