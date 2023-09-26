using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace D_AND_D
{
    public class K20Class
    {
        public int K20first { set; get; }
        public int K20second { set; get; }
        public bool? K20facilitation { set; get; }
        public bool? K20impediment { set; get; }

        public K20Class(int first, int second, bool? facilitation, bool? impediment)
        {
            K20first = first;
            K20second = second;
            K20facilitation = facilitation;
            K20impediment = impediment;
        }

        public void PokazWynikK20(string kostka_rodzaj, int liczba, Grid grid)
        {
            string png_name = kostka_rodzaj + "_" + liczba.ToString() + ".png";
            string url = Directory.GetCurrentDirectory() + @"/img/" + png_name.ToString();

            foreach (object Object_children in grid.Children)
            {
                try
                {
                    if (Object_children.GetType().Name == "Label")
                    {
                        Label label = Object_children as Label;
                        if (label.Name == "k20_lbl_suma")
                        {
                            if (K20facilitation == true)
                            {
                                if (K20first > K20second)
                                {
                                    label.Content = "Wynik: " + K20first.ToString();
                                }
                                else
                                {
                                    label.Content = "Wynik: " + K20second.ToString();
                                }
                            }
                            if (K20impediment == true)
                            {
                                if (K20first > K20second)
                                {
                                    label.Content = "Wynik: " + K20second.ToString();
                                }
                                else
                                {
                                    label.Content = "Wynik: " + K20first.ToString();
                                }
                            }
                        }
                    }
                }
                catch { }
            }

            foreach (object Object_children in grid.Children)
            {
                try
                {
                    if (Object_children.GetType().Name == "Label")
                    {
                        Label label = Object_children as Label;
                        if (label.Tag.ToString() == "background_no")
                        {
                            label.Background = new ImageBrush(new BitmapImage(new Uri(url)));
                            label.Tag = "background_yes";
                            return;
                        }
                    }
                }
                catch { }

            }
        }
    }
}
