using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//
namespace TaurusBetaX
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Repetition_Page : ContentPage
	{
        int repInt;
        bool is_paid;
        string w_choice;



        public Repetition_Page(bool paid)
        {
            InitializeComponent();

            is_paid = paid;

            workout_btn.Text = "<< Back";

            SetPicker.Items.Add("5");
            SetPicker.Items.Add("10");
            SetPicker.Items.Add("20");
            SetPicker.Items.Add("30");
            SetPicker.Items.Add("40");
            SetPicker.Items.Add("50");
            SetPicker.Items.Add("60");
            SetPicker.Items.Add("70");
            SetPicker.Items.Add("80");
            SetPicker.Items.Add("90");
            SetPicker.Items.Add("100");
        }
          

        private void SetPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var set_num = SetPicker.Items[SetPicker.SelectedIndex];

            repInt = Convert.ToInt32(set_num);
        }


        public void Excercise_Button_Clicked(object sender, EventArgs e)
        {

            App.Current.MainPage = new Exercise_Page(repInt, "HSquat", 5, 0);
        }

        private void Workout_Selection_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Workout_Selection_Page(is_paid, repInt, w_choice); 
        }
    }
}