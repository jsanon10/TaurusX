using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using TaurusBetaX;
using TaurusBetaX.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomTabbedPage), typeof(iOSTab))]
namespace TaurusBetaX.iOS
{
    public class iOSTab : TabbedRenderer
    {
        // Modify this variable with the height you desire.
        private readonly float tabBarHeight = 120f;

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            TabBar.Frame = new CGRect(TabBar.Frame.X, TabBar.Frame.Y + (TabBar.Frame.Height - tabBarHeight), TabBar.Frame.Width, tabBarHeight);

			//UITextAttributes textAttributes = new UITextAttributes();
			//textAttributes.Font = UIFont.FromName("Arial", 16.0F); // SELECTED

		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			if (TabBar.Items != null)
			{
				var items = TabBar.Items;
				foreach (var t in items)
				{
					var txtSelectedColor = new UITextAttributes()
					{
						TextColor = UIColor.Orange
					};

					var txtFont = new UITextAttributes()
					{
						Font = UIFont.SystemFontOfSize(15)
					};

					t.SetTitleTextAttributes(txtSelectedColor, UIControlState.Normal);
					t.SetTitleTextAttributes(txtFont, UIControlState.Normal);

				}

			}

		}



		//protected override void OnElementChanged(VisualElementChangedEventArgs e)
		//{
		//	base.OnElementChanged(e);

		//	// Set Text Font for unselected tab states
		//	UITextAttributes normalTextAttributes = new UITextAttributes();
		//	normalTextAttributes.Font = UIFont.FromName("Arial", 16.0F); // unselected

		//	UITabBarItem.Appearance.SetTitleTextAttributes(normalTextAttributes, UIControlState.Normal);
		//}

		//public override UIViewController SelectedViewController
		//{
		//	get
		//	{

		//		UITextAttributes selectedTextAttributes = new UITextAttributes();
		//		selectedTextAttributes.Font = UIFont.FromName("Arial", 16.0F); // SELECTED
		//		if (base.SelectedViewController != null)
		//		{
		//			base.SelectedViewController.TabBarItem.SetTitleTextAttributes(selectedTextAttributes, UIControlState.Normal);
		//		}
		//		return base.SelectedViewController;
		//	}
		//	set
		//	{
		//		base.SelectedViewController = value;

		//		foreach (UIViewController viewController in base.ViewControllers)
		//		{
		//			UITextAttributes normalTextAttributes = new UITextAttributes();
		//			normalTextAttributes.Font = UIFont.FromName("Arial", 16.0F); // unselected

		//			viewController.TabBarItem.SetTitleTextAttributes(normalTextAttributes, UIControlState.Normal);
		//		}
		//	}
		//}

	}
}