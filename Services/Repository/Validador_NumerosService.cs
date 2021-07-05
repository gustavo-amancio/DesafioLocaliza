using System;
using System.Collections.Generic;
using System.Text;
using Services.Interfaces;
using Classes_Projeto;

namespace Services.Repository
{
    public class Validador_NumerosService : IValidador_NumerosService
    {
        Validador_Numeros objValidador = new Validador_Numeros();

        public Resposta Calcular_Valores(int numero)
        {
            //Chamo a biblioteca de classes onde tá a inteligência
            return objValidador.Calcular_Valores(numero);
        }

        public bool Validar_Digito(int numero)
        {
            return objValidador.Validar_Digito(numero);
        }
    }
}
