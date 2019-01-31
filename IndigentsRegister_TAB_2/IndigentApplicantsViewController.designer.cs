// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace IndigentsRegister_TAB_2
{
    [Register ("IndigentApplicantsViewController")]
    partial class IndigentApplicantsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnBack { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnSign { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem IndigentTabItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationBar NavigationBarIndigents { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem NavigationInddigents { get; set; }

        [Action ("BtnBack_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnBack_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnBack != null) {
                btnBack.Dispose ();
                btnBack = null;
            }

            if (btnSign != null) {
                btnSign.Dispose ();
                btnSign = null;
            }

            if (IndigentTabItem != null) {
                IndigentTabItem.Dispose ();
                IndigentTabItem = null;
            }

            if (NavigationBarIndigents != null) {
                NavigationBarIndigents.Dispose ();
                NavigationBarIndigents = null;
            }

            if (NavigationInddigents != null) {
                NavigationInddigents.Dispose ();
                NavigationInddigents = null;
            }
        }
    }
}