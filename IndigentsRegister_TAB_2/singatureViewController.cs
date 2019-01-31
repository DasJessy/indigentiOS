using Foundation;
using System;
using UIKit;
using SignaturePad;
using CoreGraphics;
using System.Drawing;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IndigentsRegister_TAB_2
{
    public partial class singatureViewController : UIViewController
    {

		private SignaturePadView signature;
		public static string RefNo;
		LoadingOverlay loading;
		public static bool backFromsign = false;
		 



        public singatureViewController (IntPtr handle) : base (handle)
        {
        }


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			signature = new SignaturePadView();

			NavigationItem.Title = "Indigent Signature";

			this.Title = "Indigent Signature";

			CGRect ScreenBounds = UIScreen.MainScreen.Bounds;

			SignatureFrame();

			signature.StrokeWidth = 3F;
			signature.BackgroundColor = UIColor.White;




			View.AddSubview(signature);





		


		}


		 public static bool uploadSignature(byte[] signatureArray)
		{

			System.Net.ServicePointManager.Expect100Continue = false;
			string con_string = GetConnectionstring();
			bool sucess = false;

			using (SqlConnection conn = new SqlConnection())
			{

				conn.ConnectionString = con_string;
				SqlCommand command = new SqlCommand("UPDATE Indigents SET Signature = @Sign WHERE AccountNumber =" + RefNo.ToString() + ";");
				command.Connection = conn;
				command.Parameters.AddWithValue("@Sign", signatureArray);
				conn.Open();
				command.ExecuteNonQuery();
				conn.Close();
				sucess = true;

			}

			return sucess;
		}



		public static string GetConnectionstring()
		{

			return "Data Source = winsql01.hkdns.co.za,1433; Initial Catalog = DevRegister_sql; Persist Security Info = True; User ID = DEVAdmin_sql; Password =P@ssw0rd14";
		}



		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			var bounds = UIScreen.MainScreen.Bounds;
			loading = new LoadingOverlay(bounds, "Updating Signature");

			this.SetToolbarItems(new UIBarButtonItem[] {
				new UIBarButtonItem(UIBarButtonSystemItem.Cancel, (s,e) => {
					DismissViewController(true, null);


					Console.WriteLine("Cancel clicked");
					})
					, new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace) { Width = 50 }
					, new UIBarButtonItem(UIBarButtonSystemItem.Save, async(s,e) => {

					//var detail = this.Storyboard.InstantiateViewController("IndigentApplicantsViewController") as IndigentApplicantsViewController;


					//NavigationController.PopViewController(true);

					var img = signature.GetImage();


					 try
						{
						
					// show the loading overlay on the UI thread using the correct orientation sizi
					
					View.Add(loading);


						using(NSData imageData = img.AsPNG())
						{
							Byte[] myByteAray = new Byte[imageData.Length];
							System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, myByteAray, 0, Convert.ToInt32(imageData.Length));


							await Task.Delay(1000);
							bool upload = uploadSignature(myByteAray);
							loading.Hide();

						}

						new UIAlertView("Sucess","Signature Updated" , null, "Ok", null).Show();

						}
					catch(Exception ex)
					{
						new UIAlertView("Error",ex.Message , null, "Ok", null).Show();

					//new Android.Support.V7.App.AlertDialog.Builder(Activity).SetTitle("Indigent App Error").SetMessage("Upload failed: " + ex.Message + "\n \nPlease try again later").SetCancelable(true).Show();
					}

					backFromsign = true;
					DismissViewController(true, null);

				Console.WriteLine ("Save clicked");
				})
				}, false);

			this.NavigationController.ToolbarHidden = false;

		}

		public  void SignatureFrame()
		{


			signature.Frame = new CoreGraphics.CGRect(0, 65, View.Bounds.Width, View.Bounds.Height - 110);
			//CGRect ScreenBounds = UIScreen.MainScreen.Bounds;
			//float buttonWidth = (float)ScreenBounds.X / 4;
			//btnSave.Frame = new CGRect(0f, 0f, buttonWidth, 50f);
			//btnSave.SetTitle("Save Signature", UIControlState.Normal);




		}
	public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate(fromInterfaceOrientation);

			SignatureFrame();
		}



    }
}