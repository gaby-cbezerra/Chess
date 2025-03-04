using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess
{
    public class Rei : Peca
    {
        public Rei(string cor, int linha, int coluna, string imagem) : base(cor, linha, coluna, imagem) { }

        public override bool MovimentoValido(int linhaDestino, int colunaDestino, Peca[,] tabuleiro)
        {
            int diffLinha = Math.Abs(linhaDestino - Linha);
            int diffColuna = Math.Abs(colunaDestino - Coluna);

            // O rei pode se mover uma casa em qualquer direção
            if (diffLinha <= 1 && diffColuna <= 1)
            {
                return PodeCapturar(linhaDestino, colunaDestino, tabuleiro); // Verifica se pode capturar
            }

            return false;
        }
    }
}