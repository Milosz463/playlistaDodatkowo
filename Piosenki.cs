using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace WpfApp14
{
   public class Piosenki
    {
        public string Wykonawca { get; set; }
        public string Tytul {  get; set; }
        public int ilosc {  get; set; }
        public int rokcznik { get; set; }
        public int pobrania { get; set; }

        public Piosenki(string tytul, string wykonawca, int ilosc, int rokcznik, int pobrania)
        {
            Wykonawca = wykonawca;
            Tytul = tytul;
            this.ilosc = ilosc;
            this.rokcznik = rokcznik;
            this.pobrania = pobrania;
        }
        public void Zwieksz()
        {
            pobrania++;
        }
        
    }
}
