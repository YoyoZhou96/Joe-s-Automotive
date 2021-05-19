using System.Windows;

namespace Joe_s_Automotive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        VM vm = new VM();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void calc_Click(object sender, RoutedEventArgs e)
        {
            vm.clear();
            bool oil_is_clicked = Oil.IsChecked ?? false;
            bool lube_is_clicked = Lube.IsChecked ?? false;
            bool radiator_is_clicked = Radiator.IsChecked ?? false;
            bool transmission_is_clicked = Transmission.IsChecked ?? false;
            bool inspection_is_clicked = Inspection.IsChecked ?? false;
            bool muffler_is_clicked = Muffler.IsChecked ?? false;
            bool tire_is_clicked = Tire.IsChecked ?? false;
            bool other_is_clicked = Others.IsChecked ?? false;

            #region oillube
            if (oil_is_clicked)
            {
                if (lube_is_clicked)
                {
                    vm.calcoillube();
                }
                else
                {
                    vm.calcoil();
                }
            }
            else if (oil_is_clicked is false)
            {
                if (lube_is_clicked)
                {
                    vm.calclube();
                }
            }
            #endregion

            #region flush
            if (radiator_is_clicked)
            {
                if (transmission_is_clicked)
                {
                    vm.calcflush();
                }
                else
                {
                    vm.calcradiator();
                }
            }
            else if (radiator_is_clicked is false)
            {
                if (transmission_is_clicked)
                {
                    vm.calctransmission();
                }
            }
            #endregion

            #region misc

            if (inspection_is_clicked && muffler_is_clicked)
            {
                if (tire_is_clicked)
                {
                    vm.calcmisc();
                }
                else
                {
                    vm.calcinsmuf();
                }
            }
            else if (inspection_is_clicked is false && muffler_is_clicked)
            {
                if (tire_is_clicked)
                {
                    vm.calcmuftir();
                }
                else
                {
                    vm.calcmuffler();
                }
            }
            else if (inspection_is_clicked && muffler_is_clicked is false)
            {
                if (tire_is_clicked)
                {
                    vm.calcinstir();
                }
                else
                {
                    vm.calcinspection();
                }
            }
            else
            {
                if (tire_is_clicked)
                {
                    vm.calctire();
                }
            }
            #endregion

            #region other
            if (other_is_clicked)
            {
                vm.calcother();
            }
            #endregion

            #region tax
            vm.calctax();
            #endregion

            vm.calc();
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            Oil.IsChecked = false;
            Lube.IsChecked = false;
            vm.ClearOilLube();

            Radiator.IsChecked = false;
            Transmission.IsChecked = false;
            vm.ClearFlushes();

            Inspection.IsChecked = false;
            Muffler.IsChecked = false;
            Tire.IsChecked = false;
            vm.ClearMisc();

            Others.IsChecked = false;
            vm.ClearOther();

            vm.ClearTaxAndTotal();

        }
    }
}
