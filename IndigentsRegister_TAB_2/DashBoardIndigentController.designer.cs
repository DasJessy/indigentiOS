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
    [Register ("DashBoardIndigentController")]
    partial class DashBoardIndigentController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem DashboardTabItem { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DashboardTabItem != null) {
                DashboardTabItem.Dispose ();
                DashboardTabItem = null;
            }
        }
    }
}