using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.PowerPacks;
using System.Windows.Forms;
using System.Drawing;

namespace SemaforoCruzamentoMaoDupla
{
    class Semaforo
    {
        #region variaveis
        private static Timer timer1 = new Timer();
        private static Timer timer2 = new Timer(); 
        private static Timer timerPedestre = new Timer();

        private static int cont = 0;
        private static int cont2 = 0;

        private static OvalShape VerdeMestre = new OvalShape();
        private static OvalShape AmareloMestre = new OvalShape();
        private static OvalShape VermelhoMestre = new OvalShape();
        private static PictureBox PedestreVerdeMestre = new PictureBox();
        private static PictureBox PedestreVermelhoMestre = new PictureBox();
        private static bool Mestre;

        private static OvalShape VerdeSicronizado = new OvalShape();
        private static OvalShape AmareloSicronizado = new OvalShape();
        private static OvalShape VermelhoSicronizado = new OvalShape();
        private static PictureBox PedestreVerdeSincronizado = new PictureBox();
        private static PictureBox PedestreVermelhoSincronizado = new PictureBox();

        private static OvalShape VerdeEscravoMestre = new OvalShape();
        private static OvalShape AmareloEscravoMestre = new OvalShape();
        private static OvalShape VermelhoEscravoMestre = new OvalShape();
        private static PictureBox PedestreVerdeEscravoMestre = new PictureBox();
        private static PictureBox PedestreVermelhoEscravoMestre = new PictureBox();

        private static OvalShape VerdeEscravoSicronizado = new OvalShape();
        private static OvalShape AmareloEscravoSicronizado = new OvalShape();
        private static OvalShape VermelhoEscravoSicronizado = new OvalShape();
        private static PictureBox PedestreVerdeEscravoSincronizado = new PictureBox();
        private static PictureBox PedestreVermelhoEscravoSincronizado = new PictureBox();
        #endregion

        public Semaforo(ref OvalShape Verde, ref OvalShape Amarelo, ref OvalShape Vermelho, ref PictureBox SinalPedestreVerde, ref PictureBox SinalPedestreVermelho)
        {
            //atribui a cor branca para todos ovalshapes
            Verde.BackColor = Color.White;
            Amarelo.BackColor = Color.White;
            Vermelho.BackColor = Color.White;

            //atribui imagem de sinal desligado aos sinais de pedestres
            SinalPedestreVerde.ImageLocation = @"pverdedesligado.jpg";
            SinalPedestreVermelho.ImageLocation = @"pvermelhodesligado.jpg";

            //Verifica se o sinal mestre ja foi criado
            if (Mestre)
            {
                Vermelho.BackColor = Color.Red;     //Acende o sinal vermelho               

                VerdeSicronizado = Verde;
                AmareloSicronizado = Amarelo;
                VermelhoSicronizado = Vermelho;

                PedestreVerdeSincronizado = SinalPedestreVerde;
                PedestreVermelhoSincronizado = SinalPedestreVermelho;

                PedestreVerdeSincronizado.ImageLocation = @"pverdeligado.jpg";
                PedestreVermelhoSincronizado.ImageLocation = @"pvermelhodesligado.jpg";

                timer2.Tick += new EventHandler(Evento2SinalSincronzado); //adiciona evento

                timer2.Interval = 1000;     //Define intervalo
                timer2.Enabled = true;      //Habilita timer
            }
            else            //Sinal mestre
            {
                Mestre = true;

                Verde.BackColor = Color.Lime;   //Acende o sinal verde  

                VerdeMestre = Verde;
                AmareloMestre = Amarelo;
                VermelhoMestre = Vermelho;

                PedestreVerdeMestre = SinalPedestreVerde;
                PedestreVermelhoMestre = SinalPedestreVermelho;

                PedestreVerdeMestre.ImageLocation = @"pverdedesligado.jpg";
                PedestreVermelhoMestre.ImageLocation = @"pvermelholigado.jpg";

                timer1.Tick += new EventHandler(Evento1SinalMestre);    //adiciona evento

                timer1.Interval = 1000; //Define intervalo
                timer1.Enabled = true;  //Habilita timer

                timerPedestre.Tick += new EventHandler(EventoPedestre); //adiciona evento
                timerPedestre.Interval = 500;   //Define intervalo
                timerPedestre.Enabled = true;   //Habilita timer
            }         
        }

        public Semaforo(ref OvalShape Verde, ref OvalShape Amarelo, ref OvalShape Vermelho, ref PictureBox SinalPedestreVerde, ref PictureBox SinalPedestreVermelho, bool EspelhadoComMestre)
        {
            //atribui a cor branca para todos ovalshapes
            Verde.BackColor = Color.Lime;
            Amarelo.BackColor = Color.White;
            Vermelho.BackColor = Color.White;

            SinalPedestreVerde.ImageLocation = @"pverdedesligado.jpg";
            SinalPedestreVermelho.ImageLocation = @"pvermelhodesligado.jpg";

            if (EspelhadoComMestre)     //Verifica se o sinal sera espelhado com o sinal mestre
            {
                VerdeEscravoMestre = Verde;
                AmareloEscravoMestre = Amarelo;
                VermelhoEscravoMestre = Vermelho;

                PedestreVerdeEscravoMestre = SinalPedestreVerde;
                PedestreVermelhoEscravoMestre = SinalPedestreVermelho;

                PedestreVerdeEscravoMestre.ImageLocation = @"pverdeligado.jpg";
                PedestreVermelhoEscravoMestre.ImageLocation = @"pvermelhodesligado.jpg";
            }
            else  //Verifica se o sinal sera espelhado com o sinal sincronizado
            {
                VerdeEscravoSicronizado = Verde;
                AmareloEscravoSicronizado = Amarelo;
                VermelhoEscravoSicronizado = Vermelho;

                PedestreVerdeEscravoSincronizado = SinalPedestreVerde;
                PedestreVermelhoEscravoSincronizado = SinalPedestreVermelho;

                PedestreVerdeEscravoSincronizado.ImageLocation = @"pverdeligado.jpg";
                PedestreVermelhoEscravoSincronizado.ImageLocation = @"pvermelhodesligado.jpg";
            }
        }

        //Atualiza todos os sinais
        private void AtualizarEscravos()
        {
            VerdeEscravoMestre.BackColor = VerdeMestre.BackColor;
            AmareloEscravoMestre.BackColor = AmareloMestre.BackColor;
            VermelhoEscravoMestre.BackColor = VermelhoMestre.BackColor;

            VerdeEscravoSicronizado.BackColor = VerdeSicronizado.BackColor;
            AmareloEscravoSicronizado.BackColor = AmareloSicronizado.BackColor;
            VermelhoEscravoSicronizado.BackColor = VermelhoSicronizado.BackColor;

            PedestreVerdeEscravoMestre.Image = PedestreVerdeMestre.Image;
            PedestreVermelhoEscravoMestre.Image = PedestreVermelhoMestre.Image;

            PedestreVerdeEscravoSincronizado.Image = PedestreVerdeSincronizado.Image;
            PedestreVermelhoEscravoSincronizado.Image = PedestreVermelhoSincronizado.Image;
        }

        #region Eventos
        //evento a ser adicionado
        private void Evento1SinalMestre(object sender, EventArgs e)
        {
            Timer t = sender as Timer;

            cont++;     //Incrementa contador
            
            //Liga sinais nos tempos 5, 2 e 7 segundos
            if (cont <= 5)
            {
                VerdeMestre.BackColor = Color.Lime;

                VermelhoMestre.BackColor = Color.White;

                PedestreVerdeMestre.ImageLocation = @"pverdedesligado.jpg";
                PedestreVermelhoMestre.ImageLocation = @"pvermelholigado.jpg";
            }
            else if (cont <= 7)
            {
                VerdeMestre.BackColor = Color.White;

                AmareloMestre.BackColor = Color.Yellow;
            }
            else if (cont <= 14)
            {
                AmareloMestre.BackColor = Color.White;

                VermelhoMestre.BackColor = Color.Red;

                PedestreVerdeMestre.ImageLocation = @"pverdeligado.jpg";
                PedestreVermelhoMestre.ImageLocation = @"pvermelhodesligado.jpg";
            }
            else
                cont = 0;   //Reinicia contador
        }

        private void Evento2SinalSincronzado(object sender, EventArgs e)
        {
            Timer t = sender as Timer;

            cont2++;        //Incrementa contador

            //Liga sinais nos tempos 7, 5 e 2 segundos
            if (cont2 <= 7)
            {
                VermelhoSicronizado.BackColor = Color.Red;

                AmareloSicronizado.BackColor = Color.White;

                PedestreVerdeSincronizado.ImageLocation = @"pverdeligado.jpg";
                PedestreVermelhoSincronizado.ImageLocation = @"pvermelhodesligado.jpg";
            }
            else if (cont2 <= 12)
            {
                VerdeSicronizado.BackColor = Color.Lime;

                VermelhoSicronizado.BackColor = Color.White;

                PedestreVerdeSincronizado.ImageLocation = @"pverdedesligado.jpg";
                PedestreVermelhoSincronizado.ImageLocation = @"pvermelholigado.jpg";
            }
            else if (cont2 <= 14)
            {
                AmareloSicronizado.BackColor = Color.Yellow;
               
                VerdeSicronizado.BackColor = Color.White;
            }
            else
                cont2 = 0;      //Reinicia contador
        }

        //Variaveis Auxiliar
        private static bool AuxPiscaPedestreMestre = true;
        private static bool AuxPiscaPedestreSincronizado = true;

        //Evento para controle do sinal de pedestres
        private void EventoPedestre(object sender, EventArgs e)
        {
            AtualizarEscravos();    //Atualiza semaforos escravos

            Timer t = sender as Timer;

            //Verifica situacao do semaforo mestre
            if (cont > 12 && cont <= 14)
            {
                if (AuxPiscaPedestreMestre)
                {
                    PedestreVerdeMestre.ImageLocation = @"pverdedesligado.jpg";
                    AuxPiscaPedestreMestre = false;
                }
                else
                {
                    PedestreVerdeMestre.ImageLocation = @"pverdeligado.jpg";
                    AuxPiscaPedestreMestre = true;
                }
            }

            //Verifica situacao do semaforo sincronizado
            if (cont2 > 5 && cont2 <= 7)
            {
                if (AuxPiscaPedestreSincronizado)
                {
                    PedestreVerdeSincronizado.ImageLocation = @"pverdedesligado.jpg";
                    AuxPiscaPedestreSincronizado = false;
                }
                else
                {
                    PedestreVerdeSincronizado.ImageLocation = @"pverdeligado.jpg";
                    AuxPiscaPedestreSincronizado = true;
                }
            }
            AtualizarEscravos();
        }
        #endregion
    }
}
