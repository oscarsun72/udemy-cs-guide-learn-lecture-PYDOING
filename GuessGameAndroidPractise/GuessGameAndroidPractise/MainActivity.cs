using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using System;

namespace GuessGameAndroidPractise
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button button3 = FindViewById<Button>(Resource.Id.buttonNum3);
            button3.Click += startGame;
            Button button4 = FindViewById<Button>(Resource.Id.buttonNum4);
            button4.Click += startGame;
            Button button5 = FindViewById<Button>(Resource.Id.buttonNum5);
            button5.Click += startGame;
            Button button6 = FindViewById<Button>(Resource.Id.buttonNum6);
            button6.Click += startGame;
        }
        void startGame(object sender,EventArgs e){
            Button btn = (Button)sender;
            Intent game = new Intent(this, typeof(GameActivity));
            game.PutExtra("Number",btn.Text) ;
            StartActivity(game);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}