using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess
{
    public class Peao : Peca
    {
        public Peao(string cor, int linha, int coluna, string imagem) : base(cor, linha, coluna, imagem) { }

        public override bool MovimentoValido(int linhaDestino, int colunaDestino, Peca[,] tabuleiro)
        {
            int direcao = Cor == "branco" ? 1 : -1;
            int linhaInicial = Cor == "branco" ? 1 : 6;

            // Movimento para frente
            if (colunaDestino == Coluna)
            {
                // Verifica se a casa de destino está vazia (é uma CasaVazia)
                if (tabuleiro[linhaDestino, colunaDestino] is CasaVazia)
                {
                    if (linhaDestino == Linha + direcao)
                    {
                        return true;
                    }
                    if (Linha == linhaInicial && linhaDestino == Linha + 2 * direcao && tabuleiro[Linha + direcao, Coluna] is CasaVazia)
                    {
                        return true;
                    }
                }
            }

            // Captura (movimento diagonal)
            if (Math.Abs(colunaDestino - Coluna) == 1 && linhaDestino == Linha + direcao)
            {
                Peca pecaDestino = tabuleiro[linhaDestino, colunaDestino];
                // Verifica se a casa de destino contém uma peça adversária (não é CasaVazia e a cor é diferente)
                if (!(pecaDestino is CasaVazia) && pecaDestino.Cor != Cor)
                {
                    return true;
                }
            }

            return false;
        }
    }
}