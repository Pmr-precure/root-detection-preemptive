using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Root_Detection_Sample
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RootCheck();

        }
        private void RootCheck()
        {

        }

        private void RootSink(bool rooted)
        {
            Console.WriteLine(rooted.ToString());
            if (rooted)
            {
                var builder = new AlertDialog.Builder(this);
                builder.SetMessage("Root detected");
                builder.SetCancelable(false);
                builder.SetPositiveButton("OK", (sender, args) =>
                {
                    // Close the app after the OK button is clicked
                    Java.Lang.JavaSystem.Exit(0);
                });

                this.RunOnUiThread(() =>
                {
                    builder.Create().Show();
                });
                Task.Run(async () =>
                {
                    await Task.Delay(10000);
                    Java.Lang.JavaSystem.Exit(0);


                });

            }

        }
    }

   
}
