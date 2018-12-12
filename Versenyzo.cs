using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak11_F1
{
    class Versenyzo
    {
        public string Nev { get; private set; }
        public string Orszag { get; private set; }
        public string Zaszlo { get; private set; }
        public string RajtSzam { get; private set; }
        public TimeSpan IdoEredmeny { get; private set; }

        private static int sorszam;

        public Versenyzo(string nev, string orszag, string zaszlo)
        {
            this.Nev = nev;
            this.Orszag = orszag;
            this.Zaszlo = zaszlo;
            sorszam++;
            this.RajtSzam = (sorszam < 10) ? ("0" + sorszam) : sorszam.ToString();
        }

        public void Versenyez(TimeSpan idoEredmeny)
        {
            this.IdoEredmeny = idoEredmeny;
        }

        public override string ToString()
        {
            return Nev + " " + IdoEredmeny.ToString();
        }
    }
}
