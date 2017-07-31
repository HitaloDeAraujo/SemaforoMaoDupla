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
    class Pedestre
    {
        //picturebox
        private PictureBox pbPedestre;

        //ovalshape
        private OvalShape Sinal;

        //Variaveis de posicao
        private int PosXInicial;
        private int PosYInicial;
        private int PosFinal;

        //Variaveis para verificacao de movimento
        private static bool AndandoDireita = false;
        private static bool AndandoEsquerda = false;
        private static bool AndandoCima = false;
        private static bool AndandoBaixo = false;

        //timer para movimento
        private Timer timer1 = new Timer();

        public Pedestre(ref PictureBox Pedestre, int PosFinal, ref OvalShape Sinal)
        {
            this.pbPedestre = Pedestre;
            this.Sinal = Sinal;
            this.PosFinal = PosFinal;

            PosXInicial = Pedestre.Location.X;
            PosYInicial = Pedestre.Location.Y;
        }

        #region Metodos para verificacao de movimento
        public static bool PedestreAndandoDireita()
        {
            return AndandoDireita;
        }

        public static bool PedestreAndandoEsquerda()
        {
            return AndandoEsquerda;
        }

        public static bool PedestreAndandoCima()
        {
            return AndandoCima;
        }

        public static bool PedestreAndandoBaixo()
        {
            return AndandoBaixo;
        }
        #endregion

        #region Metodos para escolha de direcao
        //Direita
        public void MovDireita()
        {
            AdicionaEventoDireita(timer1);  //Adiciona evento
            timer1.Enabled = true;          //Habilita timer
            timer1.Interval = 1;            //Define intervalo
            timer1.Enabled = true;          //Desabilita timer
        }

        //Esquerda
        public void MovEsquerda()
        {
            AdicionaEventoEsquerda(timer1); //Adiciona evento
            timer1.Enabled = true;          //Habilita timer
            timer1.Interval = 1;            //Define intervalo
            timer1.Enabled = true;          //Define intervalo
        }

        //Cima
        public void MovCima()
        {
            AdicionaEventoCima(timer1);        //Adiciona evento
            timer1.Enabled = true;          //Habilita timer
            timer1.Interval = 1;            //Define intervalo
            timer1.Enabled = true;          //Define intervalo
        }

        //Baixo
        public void MovBaixo()
        {
            AdicionaEventoBaixo(timer1);        //Adiciona evento
            timer1.Enabled = true;          //Habilita timer
            timer1.Interval = 1;            //Define intervalo
            timer1.Enabled = true;          //Define intervalo
        }
        #endregion

        #region Evento1 Direita
        //Adiciona evento
        private void AdicionaEventoDireita(Timer t)
        {
            t.Tick += new EventHandler(EventoDireita);
        }

        //evento a ser adicionado
        private void EventoDireita(object sender, EventArgs e)
        {
            Timer t = sender as Timer;

            if (pbPedestre.Location.X < PosFinal)       //Verifica se o pedestre esta antes da posicao inicial
            {
                if (Sinal.BackColor != Color.Red && pbPedestre.Location.X == PosXInicial)   //Verifica se o sinal nao esta vermelho e se o pedestre esta na posicao inicial
                {
                    pbPedestre.Visible = false;

                    AndandoDireita = false;
                }
                else
                {
                    AndandoDireita = true;

                    pbPedestre.Visible = true;
                    pbPedestre.Location = new System.Drawing.Point(pbPedestre.Location.X + 2, pbPedestre.Location.Y);   //Incrementa posicao X
                }
            }
            else
                pbPedestre.Location = new System.Drawing.Point(PosXInicial, PosYInicial);       //Volta para posicao inicial
        }
        #endregion

        #region Evento2 Esquerda
        private void AdicionaEventoEsquerda(Timer t)
        {
            t.Tick += new EventHandler(EventoEsquerda);
        }

        //evento a ser adicionado
        private void EventoEsquerda(object sender, EventArgs e)
        {
            Timer t = sender as Timer;

            if (pbPedestre.Location.X > PosFinal)   //Verifica se o pedestre esta depois da posicao inicial
            {
                if (Sinal.BackColor != Color.Lime)
                {
                    pbPedestre.Visible = false;

                    AndandoEsquerda = false;
                }
                else
                {
                    AndandoEsquerda = true;

                    pbPedestre.Visible = true;

                    pbPedestre.Location = new System.Drawing.Point(pbPedestre.Location.X - 2, pbPedestre.Location.Y);   //Incrementa posicao X
                }
            }
            else
                pbPedestre.Location = new System.Drawing.Point(PosXInicial, PosYInicial);   //Volta para posicao inicial
        }
        #endregion

        #region Evento3 Cima
        private void AdicionaEventoCima(Timer t)
        {
            t.Tick += new EventHandler(Evento3);  //Adiciona evento de mouse
        }

        //evento a ser adicionado
        private void Evento3(object sender, EventArgs e) //Evento de clique com o mouse
        {
            Timer t = sender as Timer;

            if (pbPedestre.Location.X < PosFinal)
            {
                if (Sinal.BackColor != Color.Lime)
                {
                    pbPedestre.Visible = false;

                    AndandoCima = false;
                }
                else
                {
                    AndandoCima = true;

                    pbPedestre.Visible = true;

                    pbPedestre.Location = new System.Drawing.Point(pbPedestre.Location.X, pbPedestre.Location.Y - 2);
                }
            }
            else
                pbPedestre.Location = new System.Drawing.Point(PosXInicial, PosYInicial);
        }
        #endregion

        #region Evento4 Baixo
        //Adiciona evento
        private void AdicionaEventoBaixo(Timer t)
        {
            t.Tick += new EventHandler(Evento4);  
        }

        //evento a ser adicionado
        private void Evento4(object sender, EventArgs e) 
        {
            Timer t = sender as Timer;

            if (pbPedestre.Location.Y < PosFinal)
            {
                if (Sinal.BackColor != Color.Red && pbPedestre.Location.Y == PosYInicial)   //Verifica se o sinal nao esta vermelho e se o pedestre esta na posicao inicial
                {
                    pbPedestre.Visible = false;

                    AndandoBaixo = false;
                }
                else
                {
                    AndandoBaixo = true;

                    pbPedestre.Visible = true;

                    pbPedestre.Location = new System.Drawing.Point(pbPedestre.Location.X, pbPedestre.Location.Y + 2);   //Incrementa posicao Y
                }
            }
            else
                pbPedestre.Location = new System.Drawing.Point(PosXInicial, PosYInicial);   //Volta para posicao inicial
        }
        #endregion
    }
}
