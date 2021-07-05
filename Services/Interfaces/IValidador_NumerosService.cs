using System;
using System.Collections.Generic;
using System.Text;
using Classes_Projeto;

namespace Services.Interfaces
{
    public interface IValidador_NumerosService
    {
        Resposta Calcular_Valores(int numero);
        bool Validar_Digito(int numero);
    }
}
