using Foundation;
using System;
using UIKit;

namespace IndigentsRegister_TAB_2
{
    public partial class IndigentApplicantsViewController : UIViewController
    {
        
		public static UIWebView webview_Main = MainTabController.webview_main;

		public static string previousUri = "http://mtraders.co.za/officer_mobile/login_mobile.aspx";

		public static string uriLOGIN = "http://mtraders.co.za/officer_mobile/login_mobile.aspx";

		public static string uri = "http://mtraders.co.za/officer_mobile/login_mobile.aspx";

		public static string uriA = "http://mtraders.co.za/officer_mobile/Applicants_mobile.aspx";
		public static string uriA2 = "http://mtraders.co.za/DataCapturers_mobile/Applicants_mobile.aspx";
		public static string uriD = "http://mtraders.co.za/officer_mobile/Main_mobile.aspx";
		public static string uriR = "http://mtraders.co.za/Indigentsreport.aspx";
		public static int BackStack = 0;
		public static int BackStack2 = 0;
		public static UIBarButtonItem btnBackShared;



		private static LoadingOverlay loadingOverlay;

		public IndigentApplicantsViewController (IntPtr handle) : base (handle)
        {
			

        }

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			BackStack = 0;
			BackStack2 = 0;

			webview_Main = MainTabController.webview_main;

			webview_Main.Frame = new CoreGraphics.CGRect(0, 60, View.Bounds.Width, View.Bounds.Height - 60);

			var url = uriA2;

			//loadingOverlay.Hide();

			webview_Main = MainTabController.webview_main;

			btnSign.Enabled = false;



			webview_Main.LoadRequest(new NSUrlRequest(new NSUrl(url)));
			// Perform any additional setup after loading the view, typically from a nib.
			webview_Main.LoadFinished += Webview_Main_LoadFinished; 

			webview_Main.ScalesPageToFit = true;

			View.AddSubview(webview_Main);
			View.SendSubviewToBack(webview_Main);

			View.BringSubviewToFront(NavigationBarIndigents);






			//UINavigationBar Nav = new UINavigationBar();
			//View.AddSubview(Nav);
			//View.BringSubviewToFront(Nav);

			//Nav.SetItems(new UIBarButtonItem(UIBarButtonSystemItem.Action, (sender, e) => { 

			//}), true);



			//NavigationBarIndigents.BackItem.SetLeftBarButtonItem(new UIBarButtonItem(UIBarButtonSystemItem.Action, (sender, e) => { }), true);

			btnBack.Enabled = false;
		}

		public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate(fromInterfaceOrientation);

			webview_Main.Frame = new CoreGraphics.CGRect(0, 60, View.Bounds.Width, View.Bounds.Height - 60);

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			BackStack2 = 0;

			//btnBack.Enabled = false;




		}



		void Webview_Main_LoadStarted(object sender, EventArgs e)
		{
			
		}

		void Webview_Main_LoadFinished(object sender, EventArgs e)
		{
			
			var currentURL = webview_Main.Request.Url.AbsoluteString;

			if (currentURL.Contains("Register_Applicant.aspx?RefNo="))
			{


				btnBack.Enabled = true;
				btnBack.Title = "Back";
				btnSign.Enabled = true;
				btnSign.Title = "Sign";
				Uri myUri = new Uri(currentURL, UriKind.RelativeOrAbsolute);
				var query = System.Web.HttpUtility.ParseQueryString(myUri.Query);
				singatureViewController.RefNo = query.Get("RefNo");
				//new UIAlertView("Reference", "Reference number: " + singatureViewController.RefNo.ToString(), null, "Continue", null).Show();




			}
			else
			{

				btnBack.Enabled = false;
				btnBack.Title = "";
				btnSign.Enabled = false;
				btnSign.Title = "";


			}


			if (singatureViewController.backFromsign)
			{ 
				BackStack2 = -2;
				singatureViewController.backFromsign = false;
			
			}


			if (this.TabBarController.SelectedIndex == 1 && webview_Main.CanGoBack)
				BackStack2 += 1;

			//new UIAlertView("Backstack Tracker", "Value: " + BackStack2.ToString(), null, "ok", null).Show();




			if (BackStack2 > 1)
			{
				btnBack.Enabled = true;
				btnBack.Title = "Back";
			}
			else {

				btnBack.Enabled = false;
				btnBack.Title = "";
			}


		}




		partial void BtnBack_Activated(UIBarButtonItem sender)
		{
			if (webview_Main.CanGoBack && BackStack >1 )
			{
				webview_Main.GoBack();

				BackStack = BackStack-2;
				if (!(BackStack2 - 2 < 0))
				{ 
					BackStack2 -= 2;
				}
			



			}

			if (webview_Main.CanGoBack && BackStack2 > 1)
			{

				webview_Main.GoBack();
				if (BackStack2 > 1)
				{

					BackStack2 -= 2;
				}
			
			}


		}
	}
}