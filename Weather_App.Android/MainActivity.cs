using System;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using System.Linq;

namespace Weather_App.Droid
{
    [Activity(Label = "Weather_App", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            GetRequiredPermissions();
        }

        private const int locationPermissionId = 99;
        private void GetRequiredPermissions()
        {
            GetLocationPermission();
        }


        private void GetLocationPermission()
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != Permission.Granted)
            {
                if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.AccessFineLocation))
                {
                    WarnForLocationPermissionDenial();
                }
                else
                {
                    ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessFineLocation }, locationPermissionId);
                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if (requestCode == locationPermissionId)
            {
                if (grantResults[0] == Permission.Denied)
                {
                    Toast.MakeText(this, "Come on moron. You'll have to do typing now.", Android.Widget.ToastLength.Long).Show();
                }
                else
                {
                    //Fetch the location
                }
            }
        }

        private void WarnForLocationPermissionDenial()
        {
            AlertDialog alertDialog = null;
            var builder = new AlertDialog.Builder(this);
            builder.SetPositiveButton("ALLOW", (senderAlert, args) =>
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessFineLocation }, locationPermissionId);
            });
            builder.SetNegativeButton("CANCEL", (senderAlert, args) =>
            {
                alertDialog.Cancel();
                alertDialog.Dismiss();
            });
            builder.SetTitle("Location Permission");
            builder.SetMessage("Not granting location permission will screw my efforts");
            alertDialog = builder.Create();
            alertDialog.Show();
        }
    }
}