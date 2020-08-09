using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace GuessGameAndroidDemo
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

            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += (sender, e) =>
            {
                var game = new Intent(this, typeof(GameActivity));
                game.PutExtra("Number", "3");
                StartActivity(game);//其實就是OpenForm:Form=Activity,Open=Start;抽換詞面爾
            };

            Button button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += (sender, e) =>
            {
                var game = new Intent(this, typeof(GameActivity));
                game.PutExtra("Number", "4");
                StartActivity(game);
            };

            Button button3 = FindViewById<Button>(Resource.Id.button3);
            button3.Click += (sender, e) =>
            {
                var game = new Intent(this, typeof(GameActivity));
                game.PutExtra("Number", "5");
                StartActivity(game);
            };

            Button button4 = FindViewById<Button>(Resource.Id.button4);
            button4.Click += (sender, e) =>
            {
                var game = new Intent(this, typeof(GameActivity));
                game.PutExtra("Number", "6");
                StartActivity(game);
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

// 《程式語言教學誌》的範例程式
// https://kaiching.org
// 專案：GuessGameAndroidDemo
// 檔名：MainActivity.cs
// 功能：示範猜數字遊戲的 Android App
// 作者：張凱慶