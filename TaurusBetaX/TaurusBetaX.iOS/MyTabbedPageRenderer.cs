using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using TaurusBetaX.iOS;
using TaurusBetaX;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using UIKit;
using CoreGraphics;

[assembly: ExportRenderer(typeof(Exercise_Page), typeof(MyTabbedPageRenderer))]
namespace TaurusBetaX.iOS
{
    public class MyTabbedPageRenderer : TabbedRenderer
    {
        bool _loaded;
        Size _queuedSize;



        Page Page => Element as Page;


        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            if (Element == null)
                return;

            if (!Element.Bounds.IsEmpty)
            {
                View.Frame = new System.Drawing.RectangleF((float)Element.X, (float)10, (float)Element.Width, (float)(Element.Height - 10));
            }

            //var frame = View.Frame;
            var tabBarFrame = TabBar.Frame;

            var frame = ParentViewController != null ? ParentViewController.View.Frame : View.Frame;
            var height = frame.Height - 2 * tabBarFrame.Height - 10;


            Page.ContainerArea = new Rectangle(0, 0, frame.Width, height);

            if (!_queuedSize.IsZero)
            {
                Element.Layout(new Rectangle(Element.X, Element.Y, _queuedSize.Width, _queuedSize.Height));
                _queuedSize = Size.Zero;
            }

            _loaded = true;
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            this.TabBar.InvalidateIntrinsicContentSize();


            nfloat tabSize = 44.0f;

            UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;

            if (UIInterfaceOrientation.LandscapeLeft == orientation || UIInterfaceOrientation.LandscapeRight == orientation)
            {
                tabSize = 32.0f;
            }

            var tabFrame = this.TabBar.Frame;
            tabFrame.Height = tabSize;
            tabFrame.Y = View.Frame.Y;
            this.TabBar.Frame = tabFrame;

            //this.TabBar.TopAnchor = false;
            this.TabBar.Translucent = false;
            this.TabBar.Translucent = true;
        }
    }
}