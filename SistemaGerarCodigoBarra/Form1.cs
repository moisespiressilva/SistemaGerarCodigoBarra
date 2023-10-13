using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenCode128;

namespace SistemaGerarCodigoBarra
{
    public partial class Form1 : Form
    {
        //Define a altura do código de barras
        public int altura = 2;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            // Gera o código de barras de acordo com o texto digitado, na altura definida e TRUE PARA adicionar um espaço antes 
            Image codigoBarras = Code128Rendering.MakeBarcodeImage(txtCodigo.Text, altura, true);
            pictureCodigoBarra.Image = codigoBarras;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Pega a picture e sava com o nome do código digitado e a extensão JPG
            pictureCodigoBarra.Image.Save(txtCodigo.Text+".jpg");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            using (var g = e.Graphics)
            {           // Definindo os parametros do código digitado para ser exibido
                using (var fnt = new Font("Courier New", 16))
                {
                    g.DrawImage(this.pictureCodigoBarra.Image, 20, 50); // 20 Margem a esquerda e 50 margem superior

                    var caption = txtCodigo.Text;
                    // Exibir o código digitado na cor preta, com as coordenadas
                    g.DrawString(caption, fnt, Brushes.Black, 130, 110);
                }
            }
        }
    }
}
