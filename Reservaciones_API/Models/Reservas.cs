namespace Reservaciones_API.Models
{
    public class Reservas
    {
        public int Id { get; set; }
        public string NombreReservacion { get; set; }
        public DateOnly Fecha { get; set; }
        public string Cliente { get; set; }
    }
}
