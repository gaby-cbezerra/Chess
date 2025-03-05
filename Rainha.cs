using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess
{
    public class Rainha : Peca
    {
        public Rainha(string cor, int linha, int coluna, string imagem) : base(cor, linha, coluna, imagem) { }

        public override bool MovimentoValido(int linhaDestino, int colunaDestino, Peca[,] tabuleiro)
        {
            // Verifica se o movimento é na mesma linha ou coluna (movimento da torre)
            if (linhaDestino == Linha || colunaDestino == Coluna)
            {
                int passoLinha = linhaDestino == Linha ? 0 : (linhaDestino > Linha ? 1 : -1);
                int passoColuna = colunaDestino == Coluna ? 0 : (colunaDestino > Coluna ? 1 : -1);

                int linhaAtual = Linha + passoLinha;
                int colunaAtual = Coluna + passoColuna;

                while (linhaAtual != linhaDestino || colunaAtual != colunaDestino)
                {
                    if (!(tabuleiro[linhaAtual, colunaAtual] is CasaVazia))
                        return false; // Peça bloqueando o caminho

                    linhaAtual += passoLinha;
                    colunaAtual += passoColuna;
                }

                return PodeCapturar(linhaDestino, colunaDestino, tabuleiro); // Verifica se pode capturar
            }

            // Verifica se o movimento é diagonal (movimento do bispo)
            if (Math.Abs(linhaDestino - Linha) == Math.Abs(colunaDestino - Coluna))
            {
                int passoLinha = linhaDestino > Linha ? 1 : -1;
                int passoColuna = colunaDestino > Coluna ? 1 : -1;

                int linhaAtual = Linha + passoLinha;
                int colunaAtual = Coluna + passoColuna;

                while (linhaAtual != linhaDestino || colunaAtual != colunaDestino)
                {
                    if (!(tabuleiro[linhaAtual, colunaAtual] is CasaVazia))
                        return false; // Peça bloqueando o caminho

                    linhaAtual += passoLinha;
                    colunaAtual += passoColuna;
                }

                return PodeCapturar(linhaDestino, colunaDestino, tabuleiro); // Verifica se pode capturar
            }

            return false;
        }
                
    }
}

