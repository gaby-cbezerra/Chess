using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class Peca
    {
        public string Cor { get; set; } // "branco" ou "preto"
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public string Imagem { get; set; } // Adiciona a propriedade Imagem

        public Peca(string cor, int linha, int coluna, string imagem)
        {
            Cor = cor;
            Linha = linha;
            Coluna = coluna;
            Imagem = imagem;
        }

        public abstract bool MovimentoValido(int linhaDestino, int colunaDestino, Peca[,] tabuleiro);

        // Método auxiliar para verificar se pode capturar
      protected bool PodeCapturar(int linhaDestino, int colunaDestino, Peca[,] tabuleiro)
        {
            Peca pecaDestino = tabuleiro[linhaDestino, colunaDestino];
            return pecaDestino == null || pecaDestino.Cor != this.Cor;  // Casa vazia ou peça adversária
        }
    }
}

       