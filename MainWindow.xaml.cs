using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Piosenki> listaPiosenek {  get; set; }=new List<Piosenki>();
        public int idObrazu { get; set; } = 0;
        public MainWindow()
        {
            InitializeComponent();
            string[] linieWpliku = File.ReadAllLines("Data.txt");
            for (int i = 0; i < linieWpliku.Length; i += 6)
            {
                string tytul=linieWpliku[i];
                string wykonawca=linieWpliku[i+1];
                int liczbaUtworow = int.Parse(linieWpliku[i+2]);
                int rok= int.Parse(linieWpliku[i + 3]);
                int pobrania = int.Parse(linieWpliku[i + 4]);
                listaPiosenek.Add(new Piosenki(wykonawca,tytul, liczbaUtworow, rok, pobrania));
                wypiszAlbum(0);
            }
        }
        private void wypiszAlbum(int i)
        {
            WykonawcaTB.Text = listaPiosenek[i].Wykonawca;
            TytulTB.Text= listaPiosenek[i].Tytul;
            IloscTB.Text = listaPiosenek[i].ilosc.ToString();
            IloscPobranTB.Text = listaPiosenek[i].pobrania.ToString();
            RocznikTB.Text = listaPiosenek[i].rokcznik.ToString();
        }
        private void Pobierz(int j)
        {
            Piosenki piosenki = listaPiosenek[j];
            piosenki.Zwieksz();
            IloscPobranTB.Text = listaPiosenek[j].pobrania.ToString();
        }
       

        private void Button_Poprzednie(object sender, RoutedEventArgs e)
        {
            idObrazu--;
            if (idObrazu < 0) { 
            idObrazu=listaPiosenek.Count()-1;
            }
            wypiszAlbum(idObrazu );
        }

        private void Button_Pobierz(object sender, RoutedEventArgs e)
        {
            Pobierz(idObrazu);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            idObrazu++;
            if (idObrazu == listaPiosenek.Count())
            {
                idObrazu = 0;
            }
            wypiszAlbum(idObrazu);
        }
    }
}
