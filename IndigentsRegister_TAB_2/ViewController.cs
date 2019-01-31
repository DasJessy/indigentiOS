using System;
using Foundation;
using UIKit;

namespace IndigentsRegister_TAB_2
{
	public partial class ViewController : UIViewController
	{
		public static UIWebView webview_Main;


		public static string previousUri = "http://mtraders.co.za/officer_mobile/login_mobile.aspx";

		public static string uriLOGIN = "http://mtraders.co.za/officer_mobile/login_mobile.aspx";

		public static string uri = "http://mtraders.co.za/officer_mobile/login_mobile.aspx";

		public static string uriA = "http://mtraders.co.za/officer_mobile/Applicants_mobile.aspx";
		public static string uriA2 = "http://mtraders.co.za/DataCapturers_Mobile/Applicants_mobile.aspx";
		public static string uriD = "http://mtraders.co.za/officer_mobile/Main_mobile.aspx";
		public static string uriR = "http://mtraders.co.za/Indigentsreport.aspx";

		private static LoadingOverlay loadingOverlay;



		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();






			var url = uri;

			//loadingOverlay.Hide();

			webview_Main = new UIWebView();

			webview_Main.Frame = new CoreGraphics.CGRect(0, 0, View.Bounds.Width, View.Bounds.Height);



			webview_Main.LoadRequest(new NSUrlRequest(new NSUrl(url)));
			// Perform any additional setup after loading the view, typically from a nib.

			webview_Main.LoadStarted += Webview_Main_LoadStarted;
			webview_Main.LoadFinished += Webview_Main_LoadFinished;
			webview_Main.ScalesPageToFit = true;

			View.AddSubview(webview_Main);
			//View.BringSubviewToFront(webview_Main);




		}

		void Webview_Main_LoadStarted(object sender, EventArgs e)
		{
			var bounds = UIScreen.MainScreen.Bounds;
			// show the loading overlay on the UI thread using the correct orientation sizing
			loadingOverlay = new LoadingOverlay(bounds);
			View.Add(loadingOverlay);
		}

		 void Webview_Main_LoadFinished(object sender, EventArgs e)
		{
			loadingOverlay.Hide();
			var currentURL = webview_Main.Request.Url.AbsoluteString;
			//new UIAlertView("App Be", "Url: " + currentURL, null, "Ok", null).Show();
			if (currentURL != uriLOGIN)
			{
				//new UIAlertView("Welcome", "Welcome to indigent Register ", null, "Continue", null).Show();


				//UIStoryboard board = UIStoryboard.FromName("ViewController", null);

				//UIViewController ctrl = (UIViewController)board.InstantiateViewController("MainTabController");

				//ctrl.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;

				//this.PresentViewController(ctrl, true, null);


				this.PerformSegue("MainTabController", this);

				//UIApplication.SharedApplication.Windows[0].RootViewController = UIStoryboard.FromName(" MainTabController", null);

				//var detail = this.Storyboard.InstantiateViewController("MainTabController") as MainTabController;

				//NavigationController.PushViewController(detail,true);

				//detail.Title = "Indigent Register";


			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
