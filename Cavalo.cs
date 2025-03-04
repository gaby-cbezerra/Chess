using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess
{
    public class Cavalo : Peca
    {
        public Cavalo(string cor, int linha, int coluna, string imagem) : base(cor, linha, coluna, imagem) { }

        public override bool MovimentoValido(int linhaDestino, int colunaDestino, Peca[,] tabuleiro)
{
    int diffLinha = Math.Abs(linhaDestino - Linha);
    int diffColuna = Math.Abs(colunaDestino - Coluna);

    // Movimento em "L"
    if ((diffLinha == 2 && diffColuna == 1) || (diffLinha == 1 && diffColuna == 2))
    {
        return PodeCapturar(linhaDestino, colunaDestino, tabuleiro);
    }

    return false;
}
    }
}