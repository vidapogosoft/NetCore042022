using System.ComponentModel.DataAnnotations;


namespace ApiDemo1.Modelo.DTO
{
    public class DTOResultSet
    {
        [Key]
        public int IdMensaje { get; set; }
        public string Mensaje { get; set; }

    }
}
