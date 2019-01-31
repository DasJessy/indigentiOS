using Foundation;
using System;
using UIKit;

namespace IndigentsRegister_TAB_2
{
    public partial class logoutViewController : UIViewController
    {
        public logoutViewController (IntPtr handle) : base (handle)
        {




        }
		public override void ViewDidAppear(bool animated)
		{
	

			base.ViewDidAppear(animated);

			MainTabController.LoggedIn = false;

			MainTabController.keeptrack = 0;

			this.TabBarController.SelectedIndex = 0;

		

		}





	}
}