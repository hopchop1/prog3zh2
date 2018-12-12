using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gyak11_F1
{
    public partial class ZaszloForm : Form
    {
        public ZaszloForm()
        {
            InitializeComponent();
        }
        private List<Versenyzo> versenyzok;
        private List<String> zaszlok = new List<string>();
        private List<String> feliratok = new List<string>();

        private int bal = 10, fent = 10,
                    tavX = 120, tavY = 80,
                    zaszloX = 75, zaszloY = 75,
                    oszlopSzam =4 ;



        internal void Atvesz(List<Versenyzo> versenyzok)
        {
            this.versenyzok = versenyzok;
        }
        private void ZaszloForm_Load(object sender, EventArgs e)
        {
            ZaszloKigyujt();
            ZaszloFelrak();
        }

        private void ZaszloKigyujt()
        {
            foreach (var versenyzok in versenyzok)
            {
                if (!zaszlok.Contains(versenyzok.Zaszlo))
                {
                    zaszlok.Add(versenyzok.Zaszlo);
                    feliratok.Add(versenyzok.Orszag);
                };
            }
        }
            private void ZaszloFelrak()
            {
                PictureBox pctbox;
                Label felirat;
                int sor = 0, oszlop = 0;

                for (int i = 0; i < zaszlok.Count; i++)
                {
                    pctbox = new PictureBox();
                    pctbox.Location = new Point(bal + oszlop * (tavX), fent + sor * (tavY));
                    pctbox.Size = new Size(zaszloX, zaszloY);
                    pctbox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pctbox.Image = Image.FromFile(zaszlok[i] + ".gif");

                    felirat = new Label();
                    felirat.Location = new Point(pctbox.Location.X, pctbox.Location.Y + zaszloY);
                    felirat.Size = new Size(zaszloX, tavY);
                    felirat.TextAlign = ContentAlignment.MiddleCenter;
                    felirat.Text = feliratok[i];
                    pnlKozponti.Controls.Add(pctbox);
                    pnlKozponti.Controls.Add(felirat);
                    oszlop++;
                    if (oszlop == oszlopSzam)
                    {
                        oszlop = 0;
                        sor++;
                    }
                }
            }
        }
    }




