using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace IndigentsRegister_TAB_2
{
	public partial class DashBoardIndigentController : UIViewController
	{
		public static UIWebView webview_Main = MainTabController.webview_main;
		List<UIViewController> ListItems;


		public static string previousUri = "http://mtraders.co.za/officer_mobile/login_mobile.aspx";

		public static string uriLOGIN = "http://mtraders.co.za/officer_mobile/login_mobile.aspx";

		public static string uri = "http://mtraders.co.za/officer_mobile/login_mobile.aspx";

		public static string uriA = "http://mtraders.co.za/officer_mobile/Applicants_mobile.aspx";
		public static string uriA2 = "http://mtraders.co.za/DataCapturers_Mobile/Applicants_mobile.aspx";
		public static string uriD = "http://mtraders.co.za/officer_mobile/Main_mobile.aspx";
		public static string uriR = "http://mtraders.co.za/Indigentsreport.aspx";
		public string urlToLoad;
		LoadingOverlay loadingOverlay;


		public DashBoardIndigentController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			this.TabBarController.SelectedIndex = 0;





		}
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			//ListItems = new List<UIViewController>(TabBarController.ViewControllers)
			if (MainTabController.LoggedIn)
			{
				urlToLoad = uriD;
			}
			else {
				urlToLoad = uri;
			}

				
			//loadingOverlay.Hide();

			webview_Main = MainTabController.webview_main;

			webview_Main.Frame = new CoreGraphics.CGRect(0, 20, View.Bounds.Width, View.Bounds.Height - 20);


			webview_Main.LoadRequest(new NSUrlRequest(new NSUrl(urlToLoad)));
			// Perform any additional setup after loading the view, typically from a nib.


			webview_Main.ScalesPageToFit = true;


			View.AddSubview(webview_Main);
			View.SendSubviewToBack(webview_Main);

		}

		public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate(fromInterfaceOrientation);

			webview_Main.Frame =  new CoreGraphics.CGRect(0, 20, View.Bounds.Width, View.Bounds.Height - 20);

		}

		void Webview_Main_LoadStarted(object sender, EventArgs e)
		{
			//var bounds = UIScreen.MainScreen.Bounds;
			// show the loading overlay on the UI thread using the correct orientation sizin
			//loadingOverlay = new LoadingOverlay(bounds);
			//View.Add(loadingOverlay);

			var currentURL = webview_Main.Request.Url.AbsoluteString;
			//new UIAlertView("App Be", "Url: " + currentURL, null, "Ok", null).Show()
			if (currentURL == uriLOGIN)
			{




			}
			else
			{


			}


		}

		void Webview_Main_LoadFinished(object sender, EventArgs e)
		{


			//loadingOverlay.Hide();
			var currentURL = webview_Main.Request.Url.AbsoluteString;
			//new UIAlertView("App Be", "Url: " + currentURL, null, "Ok", null).Show()
			if (currentURL == uriLOGIN)
			{


				DashboardTabItem.Enabled = false;

			}
			else
			{

				DashboardTabItem.Enabled = true;

				MainTabController.keeptrack++;
				
				if (MainTabController.keeptrack == 1)
				{

					new UIAlertView("Welcome", "Welcome to indigent Register ", null, "Continue", null).Show();

				}


				uri = uriD;


			}
		}
    }
}