using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace IndigentsRegister_TAB_2
{
    public partial class MainTabController : UITabBarController
    {
		public static UIWebView webview_main;
		public static bool showTabBar = true;
		public static int keeptrack = 0;
		LoadingOverlay loadingOverlay;
		public static bool LoggedIn = false;


		public static string previousUri = "http://mtraders.co.za/officer_mobile/login_mobile.aspx";

		public static string uriLOGIN = "http://mtraders.co.za/officer_mobile/login_mobile.aspx";

		public static string uri = "http://mtraders.co.za/officer_mobile/login_mobile.aspx";

		public static string uriA = "http://mtraders.co.za/officer_mobile/Applicants_mobile.aspx";
		public static string uriA2 = "" +
			"" +
			"/Applicants_mobile.aspx";
		public static string uriD = "http://mtraders.co.za/officer_mobile/Main_mobile.aspx";
		public static string uriR = "http://mtraders.co.za/Indigentsreport.aspx";
		public static string urERROR = "http://mtraders.co.za/officer_mobile/Indigentregister.aspx";



		public MainTabController (IntPtr handle) : base (handle)
        {



        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			webview_main = new UIWebView();

			webview_main.LoadStarted += Webview_Main_LoadStarted;
			webview_main.LoadFinished += Webview_Main_LoadFinished;


			webview_main.Frame = new CoreGraphics.CGRect(0, 20, View.Bounds.Width, View.Bounds.Height-20);

			TabBar.Hidden = true;

		

	

		}

		public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate(fromInterfaceOrientation);
			webview_main.Frame = new CoreGraphics.CGRect(0, 20, View.Bounds.Width, View.Bounds.Height - 20);

		}
	


		public void Webview_Main_LoadStarted (object sender, EventArgs e)
		{
			var bounds = UIScreen.MainScreen.Bounds;
			// show the loading overlay on the UI thread using the correct orientation sizi
			loadingOverlay = new LoadingOverlay(bounds);
			View.Add(loadingOverlay);
		}

		public  void Webview_Main_LoadFinished (object sender, EventArgs e)
		{
			
			if (webview_main.Request.Url.AbsoluteString.Contains("http://mtraders.co.za/DataCapturers_mobile"))
			{

				IndigentApplicantsViewController.BackStack++;
				//new UIAlertView("TEST", "backstack: " + IndigentApplicantsViewController.BackStack.ToString(), null, "Continue", null).Show();


			}
			else
			{

				IndigentApplicantsViewController.BackStack = 0;
			
			}

			
			var currentURL = webview_main.Request.Url.AbsoluteString;
			previousUri = currentURL;
			//new UIAlertView("App Be", "Url: " + currentURL, null, "Ok", null).Show();



			if (currentURL == uriLOGIN || currentURL == urERROR)
			{


				TabBar.Hidden = true;

			}
			else
			{
				LoggedIn = true;
				TabBar.Hidden = false;
				keeptrack++;
				if (keeptrack == 1 && LoggedIn)
				{

					new UIAlertView("Welcome", "Welcome to indigent Register ", null, "Continue", null).Show();

				}


			}

			if (currentURL == urERROR)
			{ 

				webview_main.LoadRequest(new NSUrlRequest(new NSUrl(uriLOGIN)));
				
			}

			loadingOverlay.Hide();

		


		}
	}
}