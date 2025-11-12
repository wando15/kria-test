using System.ComponentModel;

namespace Domain.Enums
{
    public enum TipoVeiculoEnum
    {
        [Description("Passeio")]
        Passeio = 1,
        [Description("Comercial")]
        Comercial = 2,
        [Description("Moto")]
        Moto = 3
    }
}
