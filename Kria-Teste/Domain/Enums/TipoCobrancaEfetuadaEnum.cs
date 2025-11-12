using System.ComponentModel;

namespace Domain.Enums
{
    public enum TipoCobrancaEfetuadaEnum
    {
        [Description("Manual")]
        Manual = 1,
        [Description("TAG")]
        Tag = 2,
        [Description("OCR/Placa")]
        ocrPlaca = 3
    }
}
