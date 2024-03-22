using System.ComponentModel;

namespace statusReserva.Enums
{
    public enum StatusReserva
    {
        [Description("Disponível")]
        Disponivel = 1,
        [Description("Reservado")]
        Reservado = 2
    }
}
