namespace BibliotecaApp.Application.DTOs.MaterialDtos
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int TipoId { get; set; }
        public int CantidadRegistrada { get; set; }
        public int CantidadActual { get; set; }
    }
}
