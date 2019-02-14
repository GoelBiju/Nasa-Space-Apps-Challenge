using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapOverlay
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OutlookPage : ContentPage
    {
        Label labelOne = new Label();
        public OutlookPage()
        {
            var b1 = new Button { Text = "This does something 1" };
            var b2 = new Button { Text = "This does something 2" };

            Content = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                Children =
                {
                    b2,
                    b1,
                    labelOne
                }
            };
        }
    }
}