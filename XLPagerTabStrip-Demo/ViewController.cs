using System;
using UIKit;
using XLPagerTabStripBinding;
using Foundation;

namespace XLPagerTabStripDemo
{
    public partial class ViewController : XLButtonBarPagerTabStripViewController
    {
        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override NSObject[] ChildViewControllersForPagerTabStripViewController(XLPagerTabStripViewController pagerTabStripViewController)
        {
            var c1 = new ChildViewController();
            var c2 = new ChildViewController();
            var c3 = new ChildViewController();

            c1.View.BackgroundColor = UIColor.Red;
            c2.View.BackgroundColor = UIColor.Yellow;
            c3.View.BackgroundColor = UIColor.Green;

            return new NSObject[] { c1, c2, c3 };
        }

    }

    public class ChildViewController : UIViewController, IXLPagerTabStripChildItem
    {
        public string TitleForPagerTabStripViewController(XLPagerTabStripViewController pagerTabStripViewController)
        {
            return View.BackgroundColor.ToString();
        }

        [Foundation.Export("colorForPagerTabStripViewController:")]
        public UIColor ColorForPagerTabStripViewController(XLPagerTabStripViewController pagerTabStripViewController)
        {
            return UIColor.White;
        }
    }
}

