using System;
using System.Collections.Generic;
using System.Text;

namespace Classes_Projeto
{
    public class Lista
    {
        public int Numero { get; set; }

        private Celula prim, ult, pos;
        public int tam = 0;
        public int maior = 0;

        private class Celula
        {
            public int numero;
            public Celula Prox; // ponteiro
        }

        public Lista()
        {
            this.prim = new Celula();
            this.pos = this.prim;
            this.ult = this.prim;
            this.ult.Prox = null;
        }

        public Lista(int numero)
        {
            this.Numero = numero;
        }

        public void insere(int num)
        {
            if (num > maior)
            {
                this.maior = num;
            }

            this.ult.Prox = new Celula(); // insere na última posição, em uma nova célula
            this.ult = this.ult.Prox;
            this.ult.numero = num;
            tam++;
    }

        public int primeiro()
        {
            this.pos = prim;
            return pos.Prox.numero;
        }

        public int proximo()
        {
            this.pos = this.pos.Prox;

            if (this.pos == null)
            {
                return -1;
            }
            else
                return this.pos.numero;
        }

        public int tamanho()
        {
            return tam;
        }

        public bool vazia()
        {
            return this.prim == this.ult;
        }

        public int pesquisa_id(int chave)
        {
            if ((this.vazia()) || (chave == 0))
            {
                return -1;
            }

            Celula aux = this.prim;

            while (aux.Prox != null)
            {
                if (aux.Prox.numero.Equals(chave))
                {
                    return aux.Prox.numero;
                }
                aux = aux.Prox;
            }
            return -1;
        }
    }
}
