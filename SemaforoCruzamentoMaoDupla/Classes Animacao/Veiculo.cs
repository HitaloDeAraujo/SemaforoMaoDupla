using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using System.Drawing;

namespace SemaforoCruzamentoMaoDupla
{
    class Veiculos
    {
        PictureBox Veiculo;
        Panel Caminho;

        LineShape Linha;
        OvalShape Sinal;

        //Variaveis auxiliares para posicao
        int PosXInicial;
        int PosYInicial;

        //Timer para movimentacao
        Timer timer1 = new Timer();

        public Veiculos(ref PictureBox Veiculo, Panel Caminho, LineShape Linha, ref OvalShape Sinal)
        {
            this.Veiculo = Veiculo;
            this.Caminho = Caminho;

            this.Linha = Linha;
            this.Sinal = Sinal;

            PosXInicial = Veiculo.Location.X;
            PosYInicial = Veiculo.Location.Y;
        }

        #region Metodos para movimentos
        public void MovDireita()
        {
            AdicionaEvento1Direita(timer1);     //Adiciona evento
            timer1.Enabled = true;          //Habilita timer
            timer1.Interval = 1;            //Define intervalo
            timer1.Enabled = true;          //Desabilita timer
        }

        public void MovEsquerda()
        {
            AdicionaEvento2Esquerda(timer1);     //Adiciona evento
            timer1.Enabled = true;          //Habilita timer
            timer1.Interval = 1;            //Define intervalo
            timer1.Enabled = true;          //Desabilita timer
        }

        public void MovCima()
        {
            AdicionaEvento3Cima(timer1);     //Adiciona evento
            timer1.Enabled = true;          //Habilita timer
            timer1.Interval = 1;            //Define intervalo
            timer1.Enabled = true;          //Desabilita timer
        }

        public void MovBaixo()
        {
            AdicionaEvento4Baixo(timer1);     //Adiciona evento
            timer1.Enabled = true;          //Habilita timer
            timer1.Interval = 1;            //Define intervalo
            timer1.Enabled = true;          //Desabilita timer
        }
        #endregion

        #region Evento1 Direita
        private void AdicionaEvento1Direita(Timer t)
        {
            t.Tick += new EventHandler(Evento1Direita);
        }

        //evento a ser adicionado
        private void Evento1Direita(object sender, EventArgs e)
        {
            Timer t = sender as Timer;

            //Verifica se a posicao atual ainda esta no plano
            if (Veiculo.Location.X < Caminho.Size.Width)
            {
                //Verifica se o sinal esta fechado e se algum pedestre esta atravessando
                if (Veiculo.Location.X + Veiculo.Size.Width > Linha.X1 - 2 && Veiculo.Location.X + Veiculo.Size.Width < Linha.X1 + 2 && (Sinal.BackColor != Color.Lime || Pedestre.PedestreAndandoBaixo() || Pedestre.PedestreAndandoCima()))
                {
                }
                else
                {
                    //Incrementa posicao X
                    Veiculo.Location = new System.Drawing.Point(Veiculo.Location.X + 3, Veiculo.Location.Y);
                }
            }
            else
                Veiculo.Location = new System.Drawing.Point(PosXInicial, PosYInicial);      //Volta para posicao inicial
        }
        #endregion

        #region Evento2 Esquerda
        private void AdicionaEvento2Esquerda(Timer t)
        {
            t.Tick += new EventHandler(Evento2Esquerda);
        }

        //evento a ser adicionado
        private void Evento2Esquerda(object sender, EventArgs e)
        {
            Timer t = sender as Timer;

            //Verifica se a posicao atual ainda esta no plano
            if (Veiculo.Location.X + Veiculo.Size.Width > 0)
            {
                //Verifica se o sinal esta fechado e se algum pedestre esta atravessando
                if (Veiculo.Location.X > Linha.X1 - 2 && Veiculo.Location.X < Linha.X1 + 2 && (Sinal.BackColor != Color.Lime || Pedestre.PedestreAndandoCima() || Pedestre.PedestreAndandoBaixo()))
                {
                }
                else
                {
                    //Diminui posicao X
                    Veiculo.Location = new System.Drawing.Point(Veiculo.Location.X - 3, Veiculo.Location.Y);
                }
            }
            else
                Veiculo.Location = new System.Drawing.Point(PosXInicial, PosYInicial);  //Volta para posicao inicial
        }
        #endregion

        #region Evento3 Cima
        private void AdicionaEvento3Cima(Timer t)
        {
            t.Tick += new EventHandler(Evento3Cima);  //Adiciona evento de mouse
        }

        //evento a ser adicionado
        private void Evento3Cima(object sender, EventArgs e) //Evento de clique com o mouse
        {
            Timer t = sender as Timer;

            //Verifica se a posicao atual ainda esta no plano
            if (Veiculo.Location.Y + Veiculo.Size.Height > 0)
            {
                //Verifica se o sinal esta fechado e se algum pedestre esta atravessando
                if (Veiculo.Location.Y > Linha.Y1 - 2 && Veiculo.Location.Y < Linha.Y1 + 2 && (Sinal.BackColor != Color.Lime || Pedestre.PedestreAndandoDireita() || Pedestre.PedestreAndandoEsquerda()))
                {
                }
                else
                {
                    //Diminui posicao Y
                    Veiculo.Location = new System.Drawing.Point(Veiculo.Location.X, Veiculo.Location.Y - 3);
                }
            }
            else
                Veiculo.Location = new System.Drawing.Point(PosXInicial, PosYInicial);  //Volta para posicao inicial
        }
        #endregion

        #region Evento4 Baixo
        private void AdicionaEvento4Baixo(Timer t)
        {
            t.Tick += new EventHandler(Evento4Baixo);
        }

        //evento a ser adicionado
        private void Evento4Baixo(object sender, EventArgs e)
        {
            Timer t = sender as Timer;

            //Verifica se a posicao atual ainda esta no plano
            if (Veiculo.Location.Y < Caminho.Size.Height)
            {
                //Verifica se o sinal esta fechado e se algum pedestre esta atravessando
                if (Veiculo.Location.Y + Veiculo.Size.Height > Linha.Y1 - 2 && Veiculo.Location.Y + Veiculo.Size.Height < Linha.Y1 + 2 && (Sinal.BackColor != Color.Lime || Pedestre.PedestreAndandoDireita() || Pedestre.PedestreAndandoEsquerda()))
                {
                }
                else
                {
                    //Incrementa posicao Y
                    Veiculo.Location = new System.Drawing.Point(Veiculo.Location.X, Veiculo.Location.Y + 3);
                }
            }
            else
                Veiculo.Location = new System.Drawing.Point(PosXInicial, PosYInicial);  //Volta para posicao inicial
        }
        #endregion
    }
}
