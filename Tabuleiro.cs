using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess;

namespace Chess
{
    public class Tabuleiro
    {
        public Peca[,] Pecas { get; set; } = new Peca[8, 8];

        public Tabuleiro()
        {
            InicializarTabuleiro();
        }

        private void InicializarTabuleiro()
        {

            for (int linha = 0; linha < 8; linha++)
            {
                for (int coluna = 0; coluna < 8; coluna++)
                {
                    // Inicializa todas as casas como CasaVazia
                     Pecas[linha, coluna] = new CasaVazia(linha, coluna);
                }
            }
            // Peões
            for (int coluna = 0; coluna < 8; coluna++)
            {
                Pecas[1, coluna] = new Peao("branco", 1, coluna, "imagens/peao_branco.png");
                Pecas[6, coluna] = new Peao("preto", 6, coluna, "imagens/peao_preto.png");
            }

            // Torres
            Pecas[0, 0] = new Torre("branco", 0, 0, "imagens/torre_branca.png");
            Pecas[0, 7] = new Torre("branco", 0, 7, "imagens/torre_branca.png");
            Pecas[7, 0] = new Torre("preto", 7, 0, "imagens/torre_preta.png");
            Pecas[7, 7] = new Torre("preto", 7, 7, "imagens/torre_preta.png");

            // Cavalos
            Pecas[0, 1] = new Cavalo("branco", 0, 1, "imagens/cavalo_branco.png");
            Pecas[0, 6] = new Cavalo("branco", 0, 6, "imagens/cavalo_branco.png");
            Pecas[7, 1] = new Cavalo("preto", 7, 1, "imagens/cavalo_preto.png");
            Pecas[7, 6] = new Cavalo("preto", 7, 6, "imagens/cavalo_preto.png");

            // Bispos
            Pecas[0, 2] = new Bispo("branco", 0, 2, "imagens/bispo_branco.png");
            Pecas[0, 5] = new Bispo("branco", 0, 5, "imagens/bispo_branco.png");
            Pecas[7, 2] = new Bispo("preto", 7, 2, "imagens/bispo_preto.png");
            Pecas[7, 5] = new Bispo("preto", 7, 5, "imagens/bispo_preto.png");

            // Rainhas
            Pecas[0, 3] = new Rainha("branco", 0, 3, "imagens/rainha_branca.png");
            Pecas[7, 3] = new Rainha("preto", 7, 3, "imagens/rainha_preta.png");

            // Reis
            Pecas[0, 4] = new Rei("branco", 0, 4, "imagens/rei_branco.png");
            Pecas[7, 4] = new Rei("preto", 7, 4, "imagens/rei_preto.png");
        }

        public void MoverPeca(int linhaOrigem, int colunaOrigem, int linhaDestino, int colunaDestino)
        {
            Peca peca = Pecas[linhaOrigem, colunaOrigem];

            if (peca != null && peca.MovimentoValido(linhaDestino, colunaDestino, Pecas))
            {
                // Verifica se há uma peça adversária na casa de destino
                if (!(Pecas[linhaDestino, colunaDestino] is CasaVazia) && Pecas[linhaDestino, colunaDestino].Cor != peca.Cor)
                {
                    // Remove a peça adversária (captura)
                    Pecas[linhaDestino, colunaDestino] = new CasaVazia(linhaDestino, colunaDestino);
                }

                // Move a peça para o destino
                Pecas[linhaDestino, colunaDestino] = peca;
                Pecas[linhaOrigem, colunaOrigem] = new CasaVazia(linhaOrigem, colunaOrigem);

                // Atualiza a posição da peça
                peca.Linha = linhaDestino;
                peca.Coluna = colunaDestino;
            }
        }
    }
}