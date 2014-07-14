using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace HarjVeikLiiga.Controls
{
    public partial class DateView : UserControl
    {
        public DateView(DateTime date)
        {
            InitializeComponent();
            if (date.Date == DateTime.Today.Date)
            {
                Date.Text = "Tänään";
                return;
            }
            Date.Text = date.Day + "." + date.Month + "." + date.Year;
        }
    }
}
