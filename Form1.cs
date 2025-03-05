using System;
using System.Drawing;
using System.Windows.Forms;
using Chess;

namespace Chess
{
    public partial class Form1 : Form
    {
        private const int TamanhoCelula = 50; // Defina o tamanho das células do tabuleiro
        private Tabuleiro tabuleiro;
        private Peca pecaSelecionada;
        private Panel casaSelecionada;

        public Form1()
        {
            InitializeComponent();
            tabuleiro = new Tabuleiro();
            InicializarInterface();
        }

        private void InicializarInterface()
        {
            for (int linha = 0; linha < 8; linha++)
            {
                for (int coluna = 0; coluna < 8; coluna++)
                {
                    Panel casa = new Panel
                    {
                        Width = TamanhoCelula,
                        Height = TamanhoCelula,
                        Location = new Point(coluna * TamanhoCelula, linha * TamanhoCelula),
                        BackColor = (linha + coluna) % 2 == 0 ? Color.White : Color.Gray,
                        Tag = new Point(linha, coluna) // Armazena a posição da casa
                    };
                    casa.Click += new EventHandler(Casa_Click);
                    this.Controls.Add(casa);

                    Peca peca = tabuleiro.Pecas[linha, coluna];
                    if (peca != null && !string.IsNullOrEmpty(peca.Imagem))
                    {
                        PictureBox pictureBox = new PictureBox
                        {
                            Width = TamanhoCelula,
                            Height = TamanhoCelula,
                            Location = new Point(0, 0), // Relativo ao panel
                            Image = Image.FromFile(peca.Imagem),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Tag = peca // Armazena a peça no PictureBox
                        };
                        pictureBox.Click += new EventHandler(Peca_Click);
                        casa.Controls.Add(pictureBox); // Adiciona a peça dentro da casa do tabuleiro
                    }
                }
            }
        }

        private void Peca_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            pecaSelecionada = pictureBox.Tag as Peca;
            casaSelecionada = pictureBox.Parent as Panel;
        }

      private void Casa_Click(object sender, EventArgs e)
        {
            if (pecaSelecionada == null) return;

            Panel casaDestino = sender as Panel;
            Point posicaoDestino = (Point)casaDestino.Tag;

            // Mensagem de debug: Tentativa de movimento
            MessageBox.Show($"Tentando mover {pecaSelecionada.GetType().Name} de ({pecaSelecionada.Linha}, {pecaSelecionada.Coluna}) para ({posicaoDestino.X}, {posicaoDestino.Y})", "Debug - Movimento");

            // Verifica se o movimento é válido
            if (pecaSelecionada.MovimentoValido(posicaoDestino.X, posicaoDestino.Y, tabuleiro.Pecas))
            {
                // Mensagem de debug: Movimento válido
                MessageBox.Show($"Movimento válido para {pecaSelecionada.GetType().Name} em ({posicaoDestino.X}, {posicaoDestino.Y})", "Debug - Movimento Válido");

                // Verifica se há uma peça adversária na casa de destino
                Peca pecaDestino = tabuleiro.Pecas[posicaoDestino.X, posicaoDestino.Y];
                if (pecaDestino is not CasaVazia && pecaDestino.Cor != pecaSelecionada.Cor)
                {
                    // Mensagem de debug: Captura possível
                    MessageBox.Show($"Captura possível: {pecaSelecionada.GetType().Name} pode capturar {pecaDestino.GetType().Name} em ({posicaoDestino.X}, {posicaoDestino.Y})", "Debug - Captura Possível");

                    // Remove a peça adversária do tabuleiro lógico
                    tabuleiro.Pecas[posicaoDestino.X, posicaoDestino.Y] = new CasaVazia(posicaoDestino.X, posicaoDestino.Y);

                    // Remove a peça adversária da interface gráfica
                    casaDestino.Controls.Clear();

                    // Mensagem de debug: Captura bem-sucedida
                    MessageBox.Show($"Captura bem-sucedida: {pecaSelecionada.GetType().Name} capturou {pecaDestino.GetType().Name} em ({posicaoDestino.X}, {posicaoDestino.Y})", "Debug - Captura Bem-Sucedida");
                }

                // Remove a peça da casa de origem no tabuleiro lógico
                tabuleiro.Pecas[pecaSelecionada.Linha, pecaSelecionada.Coluna] = new CasaVazia(pecaSelecionada.Linha, pecaSelecionada.Coluna);

                // Move a peça para a casa de destino no tabuleiro lógico
                tabuleiro.Pecas[posicaoDestino.X, posicaoDestino.Y] = pecaSelecionada;

                // Atualiza a posição da peça
                pecaSelecionada.Linha = posicaoDestino.X;
                pecaSelecionada.Coluna = posicaoDestino.Y;

                // Remove a peça da casa de origem na interface gráfica
                casaSelecionada.Controls.Clear();

                // Adiciona a peça na casa de destino na interface gráfica
                PictureBox pictureBox = new PictureBox
                {
                    Width = TamanhoCelula,
                    Height = TamanhoCelula,
                    Location = new Point(0, 0), // Relativo ao panel
                    Image = Image.FromFile(pecaSelecionada.Imagem),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = pecaSelecionada // Armazena a peça no PictureBox
                };
                pictureBox.Click += new EventHandler(Peca_Click);
                casaDestino.Controls.Add(pictureBox);

                // Mensagem de debug: Peça movida
                MessageBox.Show($"Peça {pecaSelecionada.GetType().Name} movida para ({posicaoDestino.X}, {posicaoDestino.Y})", "Debug - Peça Movida");

                // Limpa a seleção
                pecaSelecionada = null;
                casaSelecionada = null;
            }
            else
            {
                // Mensagem de debug: Movimento inválido
                MessageBox.Show($"Movimento inválido para {pecaSelecionada.GetType().Name} em ({posicaoDestino.X}, {posicaoDestino.Y})", "Debug - Movimento Inválido");
            }
        }
    }
}

