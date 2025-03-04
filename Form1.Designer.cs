namespace Chess;

partial class Form1 : Form
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private const int TamanhoDaMatriz = 8;
    private Button[,] matriz = new Button[TamanhoDaMatriz, TamanhoDaMatriz];


    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.SuspendLayout();
        // 
        // Form1
        // 
        this.ClientSize = new System.Drawing.Size(8 * TamanhoCelula, 8 * TamanhoCelula); // Ajuste o tamanho do formulário
        this.Name = "Form1";
        this.ResumeLayout(false);
    }

    #endregion
}





