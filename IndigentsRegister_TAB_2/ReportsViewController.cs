using Foundation;
using System;
using UIKit;

namespace IndigentsRegister_TAB_2
{
    public partial class ReportsViewController : UIViewController
    {


		public static UIWebView webview_Main  = MainTabController.webview_main;

		public static string previousUri = "http://mtraders.co.za/officer_mobile/login_mobile.aspx";

		public static string uriLOGIN = "http://mtraders.co.za/officer_mobile/login_mobile.aspx";

		public static string uri = "http://mtraders.co.za/officer_mobile/login_mobile.aspx";

		public static string uriA = "http://mtraders.co.za/officer_mobile/Applicants_mobile.aspx";
		public static string uriA2 = "http://mtraders.co.za/DataCapturers_Mobile/Applicants_mobile.aspx";
		public static string uriD = "http://mtraders.co.za/officer_mobile/Main_mobile.aspx";
		public static string uriR = "http://mtraders.co.za/Indigentsreport.aspx";

		private static LoadingOverlay loadingOverlay;
		private int keeptrackLoading = 0;




		public ReportsViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			webview_Main = MainTabController.webview_main;

			var url = uriR;

			//loadingOverlay.Hide();

			webview_Main = MainTabController.webview_main;

			webview_Main.Frame = new CoreGraphics.CGRect(0, 20, View.Bounds.Width, View.Bounds.Height - 20);

			webview_Main.LoadRequest(new NSUrlRequest(new NSUrl(url)));
			// Perform any additional setup after loading the view, typically from a nib.

		
			webview_Main.ScalesPageToFit = true;

			View.AddSubview(webview_Main);
			keeptrackLoading++;



		}

		public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate(fromInterfaceOrientation);

			webview_Main.Frame = new CoreGraphics.CGRect(0, 20, View.Bounds.Width, View.Bounds.Height - 20);

		}



		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			//loadingOverlay.Hide();




		}

		void Webview_Main_LoadStarted(object sender, EventArgs e)
		{
			//var bounds = UIScreen.MainScreen.Bounds;
			// show the loading overlay on the UI thread using the correct orientation i
			//loadingOverlay = new LoadingOverlay(bounds);
			//View.Add(loadingOverlay);
		}

		void Webview_Main_LoadFinished(object sender, EventArgs e)
		{
			//loadingOverlay.Hide();
			var currentURL = webview_Main.Request.Url.AbsoluteString;
			//new UIAlertView("App Be", "Url: " + currentURL, null, "Ok", null).Show(
			if (currentURL == uriLOGIN)
			{
				



			}
			else
			{


			}
		}

    }
}