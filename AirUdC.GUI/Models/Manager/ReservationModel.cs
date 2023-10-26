using System.ComponentModel;

namespace AirUdC.GUI.Models.Manager
{
    public class ReservationModel
    {
        [DisplayName("Precio Reserva")]
        public decimal Price { get; set; }

        [DisplayName("Fecha de entrada")]
        public string EnterDate { get; set; }

        [DisplayName("Fecha de salida")]
        public string OutDate { get; set; }
      //  public PropertyModel property { get; set; }
      //  public CustumerModel custumer { get; set; }
    }
}