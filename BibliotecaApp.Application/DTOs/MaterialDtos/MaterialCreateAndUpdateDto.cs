using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApp.Application.DTOs.MaterialDtos
{
    public class MaterialCreateAndUpdateDto
    {
        public string Titulo { get; set; }
        public int TipoId { get; set; }
        public int CantidadRegistrada { get; set; }

    }
}
