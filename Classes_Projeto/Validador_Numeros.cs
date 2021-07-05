using System;
using System.Collections.Generic;

namespace Classes_Projeto
{
    public class Validador_Numeros
    {
        public Validador_Numeros()
        { }

        public Resposta Calcular_Valores(int numero)
        {
            Lista lst_divisores;
            Lista lst_TotalPrimos;
            string resp_Div = string.Empty, resp_Primos = string.Empty;
            Resposta resp;

            lst_divisores = Validar_Divisoes_Digito(numero);
            lst_TotalPrimos = Validar_Numeros_Primos(numero, ref lst_divisores);

            resp_Div = Retorna_Valores_Lista(ref lst_divisores);

            if (lst_TotalPrimos.tam > 0)
            {
                resp_Primos = Retorna_Valores_Lista(ref lst_TotalPrimos);
            }

            resp = new Resposta
            {
                NumeroEntrada = numero,
                Divisores = resp_Div,
                Primos = resp_Primos
            };

            return resp;
        }

        public bool Validar_Digito(int numero)
        {
            if (numero >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Lista Validar_Divisoes_Digito(int numero)
        {
            bool numero_par = false;
            int incremento = 0, inicio = 0;
            Lista lst_numeros = new Lista();

            if (numero == 1) // se for 1, é ele mesmo os divisores
            {
                lst_numeros.insere(1);
            }
            else if (numero == 2) // se for 2, é o número 1 e ele mesmo os divisores
            {
                lst_numeros.insere(1);
                lst_numeros.insere(numero);
            }
            else
            {
                numero_par = Verificar_NumeroPar(numero);

                if (numero_par == false)
                {
                    //Ímpar
                    inicio = 1;
                    incremento = 2;
                }
                else
                {
                    lst_numeros.insere(1); // insiro o 1 direto porque ele tá em todos mesmo
                    inicio = 2;
                    incremento = 1;
                }

                for (int a = inicio; a <= numero; a = a + incremento) // Se for maior então eu faço um laço que irá percorrer de 2 até o número de entrada pegando todos os dividores do número e adicionando na lista
                {
                    if (numero % a == 0)
                    {
                        lst_numeros.insere(a);
                    }
                }
            }

            return lst_numeros;
        }

        private bool Verificar_NumeroPar(int numero)
        {
            if (numero % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Lista Validar_Numeros_Primos(int numero, ref Lista divisores)
        {
            int fator = numero / 2; // faço isso porque, sempre quando o contador chegar na metade do número, o outro divisor será somente o número então não haverá nunca primos entre eles.
            Lista lst_numeros = new Lista();

            if (numero == 2)
            {
                if (divisores.pesquisa_id(2) != -1)
                {
                    lst_numeros.insere(2);
                }
            }
            else
            {
                for (int num_avaliado = 2; num_avaliado <= fator; num_avaliado++)
                {
                    int numero_capturado = 0;

                    if (num_avaliado == 2)
                    {
                        numero_capturado = num_avaliado;
                    }
                    else if (num_avaliado == 3)
                    {
                        numero_capturado = num_avaliado;
                    }
                    else if (num_avaliado == 5)
                    {
                        numero_capturado = num_avaliado;
                    }
                    else if (num_avaliado == 7)
                    {
                        numero_capturado = num_avaliado;
                    }

                    if ((num_avaliado % 2 != 0) && (num_avaliado % 3 != 0) && (num_avaliado % 5 != 0) && (num_avaliado % 7 != 0))
                    {
                        numero_capturado = num_avaliado;
                    }

                    if ((numero_capturado != 0) && (divisores.pesquisa_id(numero_capturado) != -1))
                    {
                        lst_numeros.insere(numero_capturado);
                    }
                }
            }
            
            return lst_numeros;
        }
        
        private string Retorna_Valores_Lista(ref Lista lst)
        {
            lst.primeiro(); // coloco o ponteiro da lista na primeira posição
            bool primeira = true;
            string retorno = string.Empty;
            int numero = lst.proximo(); // pego o primeiro item da lista

            try
            {
                do
                {
                    if (primeira == true)
                    {
                        retorno = numero.ToString();
                        primeira = false;
                    }
                    else
                    {
                        retorno += "," + numero.ToString();
                    }

                    numero = lst.proximo();
                }
                while (numero != -1);
            }
            catch
            { }

            return retorno;
        }

    }
}
