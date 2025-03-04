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

        while (linhaAtual != linhaDestino || colunaAtual != colunaDestino)
        {
            if (tabuleiro[linhaAtual, colunaAtual] != null)
                return false; // Peça bloqueando o caminho

            linhaAtual += passoLinha;
            colunaAtual += passoColuna;
        }

        return PodeCapturar(linhaDestino, colunaDestino, tabuleiro);
    }

    return false;
}
}
}