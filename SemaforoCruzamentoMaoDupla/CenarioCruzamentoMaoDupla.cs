using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaforoCruzamentoMaoDupla
{
    public partial class CenarioCruzamentoMaoDupla : Form
    {
        public CenarioCruzamentoMaoDupla()
        {
            InitializeComponent();

            //Desabilita visibilidade das linhas
            ls1.Visible = false;
            ls2.Visible = false;
            ls3.Visible = false;
            ls4.Visible = false;

            //Cria semaforos
            Semaforos();

            //Cria pedestres
            Pedestres();

            //Cria Veiculos
            Veiculos();
        }

        #region Funcoes
        //Cria semaforos
        private void Semaforos()
        {
            //Cria semaforos
            Semaforo S1 = new Semaforo(ref osVerde1, ref osAmarelo1, ref osVermelho1, ref pbPedestreVerde1, ref pbPedestreVermelho1);

            Semaforo S2 = new Semaforo(ref osVerde2, ref osAmarelo2, ref osVermelho2, ref pbPedestreVerde2, ref pbPedestreVermelho2);

            Semaforo S3 = new Semaforo(ref osVerde3, ref osAmarelo3, ref osVermelho3, ref pbPedestreVerde3, ref pbPedestreVermelho3, true);

            Semaforo S4 = new Semaforo(ref osVerde4, ref osAmarelo4, ref osVermelho4, ref pbPedestreVerde4, ref pbPedestreVermelho4, false);
        }

        //Cria pedestres
        private void Pedestres()
        {
            Pedestre p = new Pedestre(ref pbPedestre1, 662, ref osVermelho1);
            p.MovDireita();

            Pedestre p2 = new Pedestre(ref pbPedestre3, 662, ref osVermelho1);
            p2.MovDireita();

            Pedestre p3 = new Pedestre(ref pbPedestre2, 400, ref osVermelho2);
            p3.MovBaixo();

            Pedestre p4 = new Pedestre(ref pbPedestre4, 400, ref osVermelho2);
            p4.MovBaixo();
        }

        //Cria Veiculos
        private void Veiculos()
        {
            Veiculos v = new Veiculos(ref pbCarroB, pnlCenario, ls3, ref osVerde3);
            v.MovBaixo();

            Veiculos v2 = new Veiculos(ref pbCarroC, pnlCenario, ls1, ref osVerde1);
            v2.MovCima();

            Veiculos v3 = new Veiculos(ref pbCarroE, pnlCenario, ls2, ref osVerde2);
            v3.MovEsquerda();

            Veiculos v4 = new Veiculos(ref pbCarroD, pnlCenario, ls4, ref osVerde4);
            v4.MovDireita();
        }
        #endregion

        #region Eventos

        //Espelha sinais de pedestres
        private void pbPedestreVerde1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pbPedestreVerde1Copia.Image = pbPedestreVerde1.Image;
            pbPedestreVerde3Copia.Image = pbPedestreVerde1.Image;
        }

        //Espelha sinais de pedestres
        private void pbPedestreVermelho1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pbPedestreVermelho1Copia.Image = pbPedestreVermelho1.Image;
            pbPedestreVermelho3Copia.Image = pbPedestreVermelho1.Image;
        }

        //Espelha sinais de pedestres
        private void pbPedestreVerde2_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pbPedestreVerde2Copia.Image = pbPedestreVerde2.Image;
            pbPedestreVerde4Copia.Image = pbPedestreVerde2.Image;
        }

        //Espelha sinais de pedestres
        private void pbPedestreVermelho2_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pbPedestreVermelho2Copia.Image = pbPedestreVermelho2.Image;
            pbPedestreVermelho4Copia.Image = pbPedestreVermelho2.Image;
        }
        #endregion
    }
}
