using System;
using System.Collections.Generic;
using System.Text;
using Services.Interfaces;
using Classes_Projeto;

namespace Services.Class_Services
{
    public class ControllerInjection
    {
        private readonly IValidador_NumerosService _validacao;

        public ControllerInjection(IValidador_NumerosService validacao)
        {
            _validacao = validacao;
        }

        public Resposta Calcular_Valores(int numero)
        {
            return _validacao.Calcular_Valores(numero);
        }

        public bool Validar_Digito(int numero)
        {
            return _validacao.Validar_Digito(numero);
        }

    }
}
