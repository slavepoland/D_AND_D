using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace D_AND_D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int suma_oczek;
        private int modyfikator;
        private static readonly int[] Kosc_number = { 1, 5, 7, 9, 11, 13, 21 };
        private static readonly string[] Kosc_rodzaj = { "k4", "k6", "k8", "k10", "k12", "k20" };
        private double total_rzuty;
        private int num_rzut;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BigNumberThrowADice()
        {
            ImageGrid.Visibility = Visibility.Hidden;
            DataGrid_k4.Visibility = Visibility.Visible;
            try
            {
                for (int i = 0; i < Convert.ToInt32(Cb_k4.Text); i++)
                {
                    int liczba = Random_kosc.RandomNumber(Kosc_number[0], Kosc_number[1]);
                    suma_oczek += liczba;
                    num_rzut += 1;
                    ItemsPhoto.GenerateRowsAdd(DataGrid_k4, liczba, Kosc_rodzaj[0], num_rzut);
                }
                for (int i = 0; i < Convert.ToInt32(Cb_k6.Text); i++)
                {
                    int liczba = Random_kosc.RandomNumber(Kosc_number[0], Kosc_number[2]);
                    suma_oczek += liczba;
                    num_rzut += 1;
                    ItemsPhoto.GenerateRowsAdd(DataGrid_k4, liczba, Kosc_rodzaj[1], num_rzut);
                }
                for (int i = 0; i < Convert.ToInt32(Cb_k8.Text); i++)
                {
                    int liczba = Random_kosc.RandomNumber(Kosc_number[0], Kosc_number[2]);
                    suma_oczek += liczba;
                    num_rzut += 1;
                    ItemsPhoto.GenerateRowsAdd(DataGrid_k4, liczba, Kosc_rodzaj[2], num_rzut);
                }
                for (int i = 0; i < Convert.ToInt32(Cb_k10.Text); i++)
                {
                    int liczba = Random_kosc.RandomNumber(Kosc_number[0], Kosc_number[3]);
                    suma_oczek += liczba;
                    num_rzut += 1;
                    ItemsPhoto.GenerateRowsAdd(DataGrid_k4, liczba, Kosc_rodzaj[3], num_rzut);
                }
                for (int i = 0; i < Convert.ToInt32(Cb_k12.Text); i++)
                {
                    int liczba = Random_kosc.RandomNumber(Kosc_number[0], Kosc_number[4]);
                    suma_oczek += liczba;
                    num_rzut += 1;
                    ItemsPhoto.GenerateRowsAdd(DataGrid_k4, liczba, Kosc_rodzaj[4], num_rzut);
                }
                for (int i = 0; i < Convert.ToInt32(Cb_k20.Text); i++)
                {
                    int liczba = Random_kosc.RandomNumber(Kosc_number[0], Kosc_number[5]);
                    suma_oczek += liczba;
                    num_rzut += 1;
                    ItemsPhoto.GenerateRowsAdd(DataGrid_k4, liczba, Kosc_rodzaj[5], num_rzut);
                }
            }
            catch (FormatException)
            { }
            LabelSumaWynik();
        }

        private void Btn_start_Click(object sender, RoutedEventArgs e) //Rzut kostką
        {
            string[] combobox_text = { Cb_k4.Text, Cb_k6.Text, Cb_k8.Text, Cb_k10.Text, Cb_k12.Text, Cb_k20.Text };
            bool? tempfacility = Check_facilitation.IsChecked;
            bool? tempimpediment = Check_impediment.IsChecked;
            int a = 0;

            txt_modyfikator.Text = txt_modyfikator.Text.Replace(" ", "");
            if (txt_modyfikator.Text != "")
            {
                modyfikator = Convert.ToInt32(txt_modyfikator.Text);
            }
            else
            {
                txt_modyfikator.Text = "0";
                modyfikator = Convert.ToInt32(txt_modyfikator.Text);
            }


            Clear_data(); //clear all data

            // ustawienie wpisanych wartości w polach ComboBox
            try
            {
                foreach (object child in MainGrid.Children)
                {
                    if (child.GetType().Name == "ComboBox")
                    {
                        ComboBox combo = child as ComboBox;
                        combo.Text = combobox_text[a];
                        total_rzuty += Convert.ToDouble(combobox_text[a]);
                        a++;
                    }
                }
            }
            catch { }

            txt_modyfikator.Text = modyfikator.ToString();
            Check_facilitation.IsChecked = tempfacility;
            Check_impediment.IsChecked = tempimpediment;

            if (total_rzuty > 10)
            {
                BigNumberThrowADice();
            }
            else
            {
                if (Cb_k4.Text != "0" && Cb_k4.Text != "")
                {
                    try
                    {
                        for (int i = 0; i < Convert.ToInt32(Cb_k4.Text); i++)
                        {
                            int liczba = Random_kosc.RandomNumber(Kosc_number[0], Kosc_number[1]);
                            suma_oczek += liczba;
                            AddLabelBackground(liczba, Kosc_rodzaj[0]);
                        }
                    }
                    catch (FormatException)
                    { }
                }
                if (Cb_k6.Text != "0" && Cb_k6.Text != "")
                {
                    try
                    {
                        for (int i = 0; i < Convert.ToInt32(Cb_k6.Text); i++)
                        {
                            int liczba = Random_kosc.RandomNumber(Kosc_number[0], Kosc_number[2]);
                            suma_oczek += liczba;
                            AddLabelBackground(liczba, Kosc_rodzaj[1]);
                        }
                    }
                    catch (FormatException)
                    { }
                }
                if (Cb_k8.Text != "0" && Cb_k8.Text != "")
                {
                    try
                    {
                        for (int i = 0; i < Convert.ToInt32(Cb_k8.Text); i++)
                        {
                            int liczba = Random_kosc.RandomNumber(Kosc_number[0], Kosc_number[3]);
                            suma_oczek += liczba;
                            AddLabelBackground(liczba, Kosc_rodzaj[2]);
                        }
                    }
                    catch (FormatException)
                    { }
                }
                if (Cb_k10.Text != "0" && Cb_k10.Text != "")
                {
                    try
                    {
                        for (int i = 0; i < Convert.ToInt32(Cb_k10.Text); i++)
                        {
                            int liczba = Random_kosc.RandomNumber(Kosc_number[0], Kosc_number[4]);
                            suma_oczek += liczba;
                            AddLabelBackground(liczba, Kosc_rodzaj[3]);
                        }
                    }
                    catch (FormatException)
                    { }
                }
                if (Cb_k12.Text != "0" && Cb_k12.Text != "")
                {
                    try
                    {
                        for (int i = 0; i < Convert.ToInt32(Cb_k12.Text); i++)
                        {
                            int liczba = Random_kosc.RandomNumber(Kosc_number[0], Kosc_number[5]);
                            suma_oczek += liczba;
                            AddLabelBackground(liczba, Kosc_rodzaj[4]);
                        }
                    }
                    catch (FormatException)
                    { }
                }
                if (Cb_k20.Text != "0" && Cb_k20.Text != "")
                {
                    //int liczba, liczba1;
                    try
                    {
                        if (Check_impediment.IsChecked == true)
                        {
                            K20Show();
                        }
                        else if (Check_facilitation.IsChecked == true)
                        {
                            K20Show();
                        }
                        else
                        {
                            for (int i = 0; i < Convert.ToInt32(Cb_k20.Text); i++)
                            {
                                int liczba;
                                liczba = Random_kosc.RandomNumber(Kosc_number[0], Kosc_number[6]);
                                suma_oczek += liczba;
                                AddLabelBackground(liczba, Kosc_rodzaj[5]);
                            }
                        }
                    }
                    catch (FormatException)
                    { }
                }
                //wyświetl wynik w lbl_suma
                LabelSumaWynik();
            }
        }

        private void LabelSumaWynik()
        {
            try
            {
                modyfikator = Convert.ToInt32(txt_modyfikator.Text);
                if (modyfikator != 0)
                {
                    if (radio_mod_up.IsChecked == true)
                    {
                        int temp = suma_oczek + modyfikator;
                        lbl_suma.Content = "Wynik: " + suma_oczek.ToString() + ", +" + modyfikator.ToString() + " Suma: " + temp.ToString();
                    }
                    else
                    {
                        int temp = suma_oczek - modyfikator;
                        lbl_suma.Content = "Wynik: " + suma_oczek.ToString() + ", -" + modyfikator.ToString() + " Suma: " + temp.ToString();
                    }

                }
                else
                {
                    lbl_suma.Content = "Suma: " + suma_oczek.ToString();
                }
            }
            catch { }
        }

        private void K20Show()
        {
            int liczba; int liczba1;
            K20Window k20Window = K20WindowShow();
            liczba = Random_kosc.RandomNumber(Kosc_number[0], Kosc_number[6]);
            liczba1 = Random_kosc.RandomNumber(Kosc_number[0], Kosc_number[6]);
            K20Class k20 = new(liczba, liczba1, Check_facilitation.IsChecked, Check_impediment.IsChecked);
            k20.PokazWynikK20(Kosc_rodzaj[5], liczba, k20Window.k20Grid);
            k20.PokazWynikK20(Kosc_rodzaj[5], liczba1, k20Window.k20Grid);
            k20Window.ShowDialog();
        }

        private static K20Window K20WindowShow()
        {
            K20Window k20Window = new();
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            k20Window.Left = mainWindow.Left + ((mainWindow.Width - k20Window.Width) / 2);
            k20Window.Top = mainWindow.Top + ((mainWindow.Height - k20Window.Height) / 2);
            return k20Window;
        }

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            Clear_data();
        }
        private void Cb_k20_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex != -1)
            {
                try
                {
                    if (Check_facilitation != null)
                    {
                        string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
                        if (text == "0")
                        {
                            Check_facilitation.IsEnabled = false; Check_facilitation.IsChecked = false;
                            Check_impediment.IsEnabled = false; Check_impediment.IsChecked = false;
                        }
                        else
                        {
                            Check_facilitation.IsEnabled = true; Check_facilitation.IsChecked = false;
                            Check_impediment.IsEnabled = true; Check_impediment.IsChecked = false;
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    Check_facilitation.IsEnabled = false; Check_facilitation.IsChecked = false;
                    Check_impediment.IsEnabled = false; Check_impediment.IsChecked = false;
                }
            }
        }
        private void Combo_box_keyup(object sender, KeyEventArgs e)
       {
            switch (e.Key)
            {
                case Key.Space:
                    ComboBox comboBox = sender as ComboBox;
                    comboBox.Text = comboBox.Text.Replace(" ", "");
                    if (comboBox != null)
                    {
                        if (comboBox.Template.FindName("PART_EditableTextBox", comboBox) is TextBox txt)
                        {
                            txt.Select(txt.Text.Length, 0);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        private void Combo_box_keydown(object sender, KeyEventArgs e)
        {
                switch (e.Key)
                {
                    case Key.NumPad0:
                    case Key.NumPad1:
                    case Key.NumPad2:
                    case Key.NumPad3:
                    case Key.NumPad4:
                    case Key.NumPad5:
                    case Key.NumPad6:
                    case Key.NumPad7:
                    case Key.NumPad8:
                    case Key.NumPad9:
                    case Key.D0:
                    case Key.D1:
                    case Key.D2:
                    case Key.D3:
                    case Key.D4:
                    case Key.D5:
                    case Key.D6:
                    case Key.D7:
                    case Key.D8:
                    case Key.D9:
                        break;
                    default:
                        e.Handled = true;
                        break;
                }            
        }
        //clear all data 
        private void Clear_data()
        {
            ImageGrid.Visibility = Visibility.Visible;
            DataGrid_k4.Visibility = Visibility.Hidden;
            DataGrid_k4.Items.Clear();
            lbl_suma.Content = "Suma: ";
            suma_oczek = 0; txt_modyfikator.Text = "0"; total_rzuty = 0; num_rzut = 0;
            try
            {
                foreach (object child in ImageGrid.Children)
                {
                    if (child.GetType().Name == "Label")
                    {
                        Label label = child as Label;
                        label.Background = null;
                        label.Tag = "background_no";
                    }
                }
            }
            catch { }
            try
            {
                foreach (object child in MainGrid.Children)
                {
                    if (child.GetType().Name == "ComboBox")
                    {
                        ComboBox comboBox = child as ComboBox;
                        comboBox.SelectedIndex = 0;
                    }
                }
            }
            catch { }
            Check_facilitation.IsEnabled = false; Check_facilitation.IsChecked = false;
            Check_impediment.IsEnabled = false; Check_impediment.IsChecked = false;
        }

        public class ItemPhoto
        {
            public int Num_rzut { get; set; }
            public int Num { get; set; }
            public Bitmap bitmap { get; set; }
            public ImageSource img
            {
                get => Imaging.CreateBitmapSourceFromHBitmap(
                    bitmap.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
                set { }
            }
        }
        public class ItemsPhoto : List<ItemPhoto>//Generate_columns(string Header_name, DataGrid dataGrid, int liczba)
        {
            //public ItemsPhoto(int liczba, Bitmap bitmapresources)
            //{
            //    Add(new ItemPhoto()
            //        {   Num = liczba, 
            //            bitmap = bitmapresources
            //        }); 

            //}
            public static void GenerateRowsAdd(DataGrid dataGrid, int liczba, string kostka_rodzaj, int num_rzut)
            {
                //DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();
                //templateColumn.CellTemplate = new DataTemplate();
                //DataTemplate dataTemplate = new DataTemplate();
                //Binding binding = new Binding("img");
                //FrameworkElementFactory imageFactory = new FrameworkElementFactory(typeof(System.Windows.Controls.Image));
                //imageFactory.SetBinding(System.Windows.Controls.Image.SourceProperty, binding);
                //dataTemplate.VisualTree = imageFactory;
                //templateColumn.CellTemplate = dataTemplate;
                //dataGrid.Columns.Add(templateColumn);

                //generate *.png for DataGrid
                string png_name = kostka_rodzaj + "_" + liczba;
                Bitmap bitmap1 = Resource1.ResourceManager.GetObject(png_name) as Bitmap;
                _ = dataGrid.Items.Add(new ItemPhoto { Num_rzut = num_rzut, Num = liczba, bitmap = bitmap1 });
            }
        }

        private void AddLabelBackground(int liczba, string kostka_rodzaj)
        {
            string png_name = kostka_rodzaj + "_" + liczba.ToString() + ".png";
            string url = Directory.GetCurrentDirectory() + @"/img/" + png_name;
            try
            {
                foreach (var Object_children in ImageGrid.Children)
                {
                    if (Object_children.GetType().Name == "Label")
                    {
                        Label label = Object_children as Label;
                        if (label.Tag.ToString() == "background_no")
                        {
                            label.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                            label.Tag = "background_yes";
                            //label.ToolTip = "test";
                            break;
                        }
                    }
                }
            }
            catch { }
        }


        private void Check_facilitation_Checked(object sender, RoutedEventArgs e)
        {
            Check_impediment.IsEnabled = false;
        }
        private void Check_facilitation_Unchecked(object sender, RoutedEventArgs e)
        {
            Check_impediment.IsEnabled = true;
        }

        private void Check_impediment_Checked(object sender, RoutedEventArgs e)
        {
            Check_facilitation.IsEnabled = false;
        }

        private void Check_impediment_Unchecked(object sender, RoutedEventArgs e)
        {
            Check_facilitation.IsEnabled = true;
        }
    }
}
