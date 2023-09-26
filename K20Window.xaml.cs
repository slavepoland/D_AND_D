using System.Windows;

namespace D_AND_D
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class K20Window : Window
    {
        public K20Window()
        {
            InitializeComponent();
        }

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            k20_lbl1.Tag = "background_no";
            k20_lbl2.Tag = "background_no";
            Close();
        }
    }
}
