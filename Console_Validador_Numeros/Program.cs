using System;
using RestSharp;



namespace Console_Validador_Numeros
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string digito = string.Empty;
            bool digitoValido = false, fechar = false;

            do
            {
                digito = Solicita_Digito();

                if (digito == string.Empty)
                {
                    digitoValido = true;
                    fechar = true;
                    Environment.Exit(0);
                }
                else
                {
                    digitoValido = Valida_Numero_Digitado(digito);

                    if(digitoValido == true)
                    {
                        Executa_Validacao(Convert.ToInt32(digito));

                        fechar = Deseja_Fechar();
                    }
                }

            } while (fechar == false);
        }

        private static string Solicita_Digito()
        {
            Console.Clear();
            Console.WriteLine("\n\n ********** Bem vindo ao Validador de Números da Localiza! **********");
            Console.WriteLine("\n\n Por favor, digite um número maior que zero ou enter para encerrar. ");
            return Console.ReadLine();
        }

        private static bool Valida_Numero_Digitado(string digito)
        {
            int numero = 0;

            try
            {
                numero = Convert.ToInt32(digito);
            }
            catch
            {
                Console.WriteLine("\n Digito incorreto! Pressione qualquer tecla para continuar ... ");
                Console.ReadKey();
                return false;
            }

            if (numero > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("\n Digito incorreto! Pressione qualquer tecla para continuar ... ");
                Console.ReadKey();
                return false;
            }
        }

        private static void Executa_Validacao(int numero)
        {
            IRestResponse resposta = Realiza_RestAPI(numero);

            if (resposta != null)
            {
                if (resposta.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine(resposta.Content);
                }
                else
                {
                    Console.WriteLine("\n A API encontrou falha para a requisição. Gentileza tentar novamente.");
                }
            }
            else
            {
                Console.WriteLine("\n A API não retornou uma resposta válida para a requisição. Gentileza tentar novamente.");
            }
        }

        private static IRestResponse Realiza_RestAPI(int numero)
        {
            IRestResponse retorno;

            try
            {
                var client = new RestClient("https://localhost:5001/api/values/" + numero.ToString());

                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                
                retorno = response;
            }
            catch (Exception ex)
            {
                retorno = null;
                Console.WriteLine("\n Erro na chamada da API. Erro:" + ex.Message);
            }

            return retorno;
        }

        private static bool Deseja_Fechar()
        {
            Console.WriteLine("\n Pressione enter para fechar a aplicação e outra tecla para continuar! ");
            string digito = Console.ReadLine();

            if (digito == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
