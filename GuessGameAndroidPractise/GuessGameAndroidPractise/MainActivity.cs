using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
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

        void exitDialog()
        {
            //https://riptutorial.com/xamarin-android/example/17207/simple-alert-dialog-example
            Android.App.AlertDialog.Builder alertDialog =
                new Android.App.AlertDialog.Builder(this);
            //Java寫法: https://stackoverflow.com/questions/6330200/how-to-quit-android-application-programmatically
            //Xamarin: https://stackoverflow.com/questions/39420766/xamarin-c-alertdialog-and-onbackpressed
            alertDialog
                .SetTitle("離開程式確認")
                .SetMessage("若按下「取消」，則再按一次就會離開……")
                .SetCancelable(false)//有這個訊息方塊就不能被取消掉了。此即強制回應的寫法
                                     //.SetPositiveButton("馬上離開", (diaLog, id) =>//https://docs.microsoft.com/zh-tw/dotnet/api/system.eventhandler-1?view=netcore-3.1
                .SetPositiveButton("馬上離開", (object sender, DialogClickEventArgs args) =>//https://docs.microsoft.com/zh-tw/dotnet/api/android.content.dialogclickeventargs?view=xamarin-android-sdk-9
                {
                    // what to do if YES is tapped
                    FinishAffinity();
                    System.Environment.Exit(0);
                })
                .SetNegativeButton("不離開", (object sender, DialogClickEventArgs args) =>
                 {
                     exitApp = false;
                 })
                .SetNeutralButton("取消",(sender,args)=>{});//Lambda 參數用法：必須全部為指明類型或全部不指明
            Android.App.AlertDialog dialog = alertDialog.Create();
            //Dialog dialog = alertDialog.Create();//以上二行均可
            dialog.Show();
            exitApp = true;
        }

        bool exitApp = false;
        //覆寫「返回上一頁」按鈕的事件程序
        public override void OnBackPressed()
        {
            if (!exitApp)
            {
                exitDialog();
            }
            else
            {
                //https://stackoverflow.com/questions/29257929/how-to-terminate-a-xamarin-application
                this.FinishAffinity();//結束app https://stackoverflow.com/questions/19799071/onbackpressed-with-arguments 
                System.Environment.Exit(0);
                //System.exit(0); 
                /* If you will use only finishAffinity(); without System.exit(0);
                * your application will quit but the allocated memory 
                * will still be in use by your phone, 
                * so... if you want a clean and really quit of an app, 
                * use both of them. https://stackoverflow.com/questions/6330200/how-to-quit-android-application-programmatically 
                */
            }
        }
        void startGame(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Intent game = new Intent(this, typeof(GameActivity));
            //傳送要附帶的資訊給要開啟的活頁對象（Activity,表單）
            game.PutExtra("Number", btn.Text);
            StartActivity(game);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}