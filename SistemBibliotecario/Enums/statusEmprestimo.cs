using System.ComponentModel;

namespace statusEmprestimo.Enums
{
    public enum StatusEmprestimo
    {
        [Description("Disponível")]
        Disponivel = 1,
        [Description("Aguardando Retirada")]
        Aguardando = 2,
        [Description("Emprestado")]
        Emrpestado = 3
    }
}
