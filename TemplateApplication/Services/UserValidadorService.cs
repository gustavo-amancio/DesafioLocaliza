using System;
using System.Collections.Generic;
using System.Text;
using TemplateApplication.Interface;
using Classes_Projeto;

namespace TemplateApplication.Services
{
    public class UserValidadorService : IUserValidadorService
    {
        public Resposta Calcula_Dados_Numero(int numero)
        {
            Validador_Numeros validador = new Validador_Numeros();
            return validador.Calcular_Valores(numero);
        }
    }
}
