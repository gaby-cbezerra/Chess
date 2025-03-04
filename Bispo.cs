using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess
{
    public class Bispo : Peca
    {
        public Bispo(string cor, int linha, int coluna, string imagem) : base(cor, linha, coluna, imagem) { }

        public override bool MovimentoValido(int linhaDestino, int colunaDestino, Peca[,] tabuleiro)
        {
            // Movimento na diagonal
            if (Math.Abs(linhaDestino - Linha) == Math.Abs(colunaDestino - Coluna))
            {
                int passoLinha = linhaDestino > Linha ? 1 : -1;
                int passoColuna = colunaDestino > Coluna ? 1 : -1;

                int linhaAtual = Linha + passoLinha;
                int colunaAtual = Coluna + passoColuna;

                while (linhaAtual != linhaDestino || colunaAtual != colunaDestino)
                {
                    if (tabuleiro[linhaAtual, colunaAtual] != null)
                        return false; // Peça bloqueando o caminho

                    linhaAtual += passoLinha;
                    colunaAtual += passoColuna;
                }

                // Verifica se a casa de destino está vazia ou tem uma peça adversária
                Peca pecaDestino = tabuleiro[linhaDestino, colunaDestino];
                return pecaDestino == null || pecaDestino.Cor != Cor;
            }

            return false;
        }
    }
}