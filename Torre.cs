using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess
{
    public class Torre : Peca
    {
        public Torre(string cor, int linha, int coluna, string imagem) : base(cor, linha, coluna, imagem) { }

        public override bool MovimentoValido(int linhaDestino, int colunaDestino, Peca[,] tabuleiro)
        {
            // Verifica se o movimento é na mesma linha ou coluna
            if (linhaDestino == Linha || colunaDestino == Coluna)
            {
                int passoLinha = linhaDestino == Linha ? 0 : (linhaDestino > Linha ? 1 : -1);
                int passoColuna = colunaDestino == Coluna ? 0 : (colunaDestino > Coluna ? 1 : -1);

                int linhaAtual = Linha + passoLinha;
                int colunaAtual = Coluna + passoColuna;

                // Percorre o caminho até o destino
                while (linhaAtual != linhaDestino || colunaAtual != colunaDestino)
                {
                    // Verifica se há uma peça bloqueando o caminho
                    if (!(tabuleiro[linhaAtual, colunaAtual] is CasaVazia))
                    {
                        return false; // Peça bloqueando o caminho
                    }

                    linhaAtual += passoLinha;
                    colunaAtual += passoColuna;
                }

                // Verifica se a casa de destino está vazia ou contém uma peça adversária
                return PodeCapturar(linhaDestino, colunaDestino, tabuleiro);
            }

            return false; // Movimento inválido (não é na mesma linha ou coluna)
        }
    }
}