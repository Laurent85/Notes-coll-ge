using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Notes_collège
{
    /// <summary>
    /// Logique d'interaction pour Graphique.xaml
    /// </summary>
    public partial class Graphique : Window
    {
        public Graphique()
        {
            InitializeComponent();
            DataContext = this;
            Init();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Init()
        {
            _data.Add(new Point("1er trimestre", Principal.moy1));
            _data.Add(new Point("2ème trimestre", Principal.moy2));
            _data.Add(new Point("3ème trimestre", Principal.moy3));
            this.Title = Principal.elève + " - " + Principal.classe;
        }

        private ObservableCollection<Point> _data = new ObservableCollection<Point>();

        public ObservableCollection<Point> Data
        {
            get { return _data; }
        }

        public class Point : DependencyObject
        {
            public static readonly DependencyProperty trimestre = DependencyProperty.Register("Trimestre", typeof(String), typeof(Point));

            public Point(String période, double note)
            {
                Trimestre = période;
                Moyenne = note;
            }

            public String Trimestre
            {
                get { return (String)GetValue(trimestre); }
                set { SetValue(trimestre, value); }
            }

            public static readonly DependencyProperty valeur = DependencyProperty.Register("Moyenne", typeof(double), typeof(Point));

            public double Moyenne
            {
                get { return (double)GetValue(valeur); }
                set { SetValue(valeur, value); }
            }
        }
    }
}