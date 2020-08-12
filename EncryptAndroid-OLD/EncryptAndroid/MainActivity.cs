using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Views;

namespace EncryptAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    //主表單
    public class MainActivity : AppCompatActivity
    {
        //主表單的創建 Open & Load or initialize
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            //以上都是「加入→新增項目」精靈自己配置的，以下才我們自己寫的
            //取得「開始編碼」按鈕的控制權
            Button nextButton_startToCode = FindViewById<Button>(Resource.Id.Next);
            //在本「表單」創建時就掛接方法到「開始編碼」按鈕的事件上，作為其事件程序
            //=>Lambda表達式，直接將方法掛接到事件上，省略了方法名稱，其簽名只剩下參數列與主體
            nextButton_startToCode.Click += (sender, e) =>
            { StartActivity(new Intent(this, typeof(EncodeActivity))) ; };

        }


    }
}