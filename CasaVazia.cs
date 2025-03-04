using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess
{
    public class CasaVazia : Peca
    {
        public CasaVazia(int linha, int coluna) : base("vazia", linha, coluna, null) { }

        public override bool MovimentoValido(int linhaDestino, int colunaDestino, Peca[,] tabuleiro)
        {
            return false; // Uma casa vazia não pode se mover
        }
    }
}