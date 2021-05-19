using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Joe_s_Automotive
{
    class VM : INotifyPropertyChanged
    {
        const decimal oil = 26m;
        const decimal lube = 18m;
        const decimal radiator = 30m;
        const decimal transmission = 80m;
        const decimal inspections = 15m;
        const decimal muffler = 100m;
        const decimal tire = 20m;
        const decimal other = 20m;
        const double tax = 0.6;
        private const string E = "ERROR";


        private int servicetime = 0;
        public int Servicetime
        {
            get { return servicetime; }
            set { servicetime = value; notifyChanged("Servicetime"); }
        }

        private string errortime = "";
        public string Errortime
        {
            get { return errortime; }
            set { errortime = value; notifyChanged("Errortime"); }
        }

        private decimal oilcharges = 0;
        public decimal Oilcharges
        {
            get { return oilcharges; }
            set { oilcharges = value; notifyChanged("Oilcharges"); }
        }

        private decimal lubecharges = 0;
        public decimal Lubecharges
        {
            get { return lubecharges; }
            set { lubecharges = value; notifyChanged("Lubecharges"); }
        }

        private decimal oillubecharges = 0;
        public decimal Oillubecharges
        {
            get { return oillubecharges; }
            set { oillubecharges = value; notifyChanged("Oillubecharges"); }
        }

        private decimal radiatorflush = 0;
        public decimal Radiatorflush
        {
            get { return radiatorflush; }
            set { radiatorflush = value; notifyChanged("Radiator lush"); }
        }

        private decimal transmissionflush = 0;
        public decimal Transmissionflush
        {
            get { return transmissionflush; }
            set { transmissionflush = value; notifyChanged("Transmissionflush"); }
        }

        private decimal flushcharges = 0;
        public decimal Flushcharges
        {
            get { return flushcharges; }
            set { flushcharges = value; notifyChanged("Flushcharges"); }
        }

        private decimal inspection = 0;
        public decimal Inspection
        {
            get { return inspection; }
            set { inspection = value; notifyChanged("Inspection"); }
        }

        private decimal mufflerreplacement = 0;
        public decimal Mufflerreplacement
        {
            get { return mufflerreplacement; }
            set { mufflerreplacement = value; notifyChanged("Mufflerreplacement"); }
        }

        private decimal tirerotation = 0;
        public decimal Tirerotation
        {
            get { return tirerotation; }
            set { tirerotation = value; notifyChanged("Tirerotation"); }
        }

        private decimal misccharges = 0;
        public decimal Misccharges
        {
            get { return misccharges; }
            set { misccharges = value; notifyChanged("Misccharges"); }
        }

        private decimal othercharges = 0;
        public decimal Othercharges
        {
            get { return othercharges; }
            set { othercharges = value; notifyChanged("Othercharges"); }
        }

        private decimal taxcharges = 0;
        public decimal Taxcharges
        {
            get { return taxcharges; }
            set { taxcharges = value; notifyChanged("Taxcharges"); }
        }

        private decimal totalcharges = 0;
        public decimal Totalcharges
        {
            get { return totalcharges; }
            set { totalcharges = value; notifyChanged("Totalcharges"); }
        }

        #region Calc
        public void clear()
        {
            Oillubecharges = 0;
            Flushcharges = 0;
            Misccharges = 0;
            Othercharges = 0;
        }

        public void calc()
        {
            Totalcharges = Oillubecharges + Flushcharges + Misccharges + Othercharges + Taxcharges;
        }

        #region Oillubecharges
        public void calcoil()
        {
            Oillubecharges += oil;
        }
        public void calclube()
        {
            Oillubecharges += lube;

        }
        public void calcoillube()
        {
            Oillubecharges = oil + lube;
        }
        #endregion

        #region Flushcharges
        public void calcradiator()
        {
            Flushcharges += radiator;
        }
        public void calctransmission()
        {
            Flushcharges += transmission;
        }
        public void calcflush()
        {
            Flushcharges = radiator + transmission;
        }
        #endregion

        #region Misccharges
        public void calcinspection()
        {
            Misccharges += inspections;
        }
        public void calcmuffler()
        {
            Misccharges += muffler;
        }
        public void calctire()
        {
            Misccharges += tire;
        }
        public void calcinstir()
        {
            Misccharges = inspections + tire;
        }
        public void calcmuftir()
        {
            Misccharges = muffler + tire;
        }
        public void calcinsmuf()
        {
            Misccharges = inspections + muffler;
        }
        public void calcmisc()
        {
            Misccharges = inspections + muffler + tire;
        }
        #endregion

        #region Others
        private decimal AmountOther(int severcetime, decimal price)
        {
            decimal amount = 0;

            amount = servicetime * price;
            return amount;
        }
        public void calcother()
        {
            bool isVaild = Servicetime > 0;
            if (isVaild)
            {
                Errortime = "";
                Othercharges = AmountOther(Servicetime, other);
            }
            else
            {
                Errortime = $"{E}";
            }

        }
        /*public bool tryServicetime(int severcetime, decimal price, out decimal amount)
        {
            bool isVaild = Servicetime > 0;
            if (isVaild)
            {
                amount = servicetime * price;
            }
            else
            {
                Errortime = $"{E}";
            }
            return amount;
        }*/
        #endregion

        #region Tax
        private decimal AmountTax(decimal price, double tax)
        {
            decimal amounttax = 0;
            double taxprice;
            taxprice = (double)price;
            amounttax = (decimal)(taxprice * tax);
            return amounttax;
        }
        public void calctax()
        {
            Taxcharges = AmountTax(Othercharges, tax);
        }
        #endregion

        #endregion

        #region Clear
        public void ClearOilLube()
        {
            Oillubecharges = 0;
        }

        public void ClearFlushes()
        {
            Flushcharges = 0;
        }

        public void ClearMisc()
        {
            Misccharges = 0;
        }

        public void ClearOther()
        {
            Othercharges = 0;
            Errortime = "";
        }

        public void ClearTaxAndTotal()
        {
            Servicetime = 0;
            Taxcharges = 0;
            Totalcharges = 0;
        }
        #endregion

        #region PropertyChanged       
        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        #endregion
    }
}
