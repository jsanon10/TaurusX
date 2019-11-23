using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyViewCell : ViewCell
    {
        public MyViewCell()
        {
            InitializeComponent();

            //void ChangeStatusColor(string status)
            //{

            

                string status = "Ready";

                switch (status)
                {
                    case "Ready":
                        workoutStatus_label.TextColor = Color.Green;
                        break;

                    case "In Progress":
                        workoutStatus_label.TextColor = Color.LightGreen;
                        break;

                    case "Completed":
                        workoutStatus_label.TextColor = Color.Blue;
                        break;

                    case "*Completed":
                        workoutStatus_label.TextColor = Color.Blue;
                        break;

                    case "Set for today":
                        workoutStatus_label.TextColor = Color.Gray;
                        break;

                    case "On break today":
                        workoutStatus_label.TextColor = Color.LightGray;
                        break;

                    case "Un-Scheduled":
                        workoutStatus_label.TextColor = Color.Red;
                        break;

                }


            //}
        }
    }
}