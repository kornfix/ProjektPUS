using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Gra : Form
    {
        public Gra()
        {
            InitializeComponent();
        }

        public async void WczytajDane()
        {
            UC_plansza uc_plansza = new UC_plansza(this);
            uc_plansza.WczytajPlansze();
            tableLayoutPanel2.Controls.Add(uc_plansza);
        }
    }
}
