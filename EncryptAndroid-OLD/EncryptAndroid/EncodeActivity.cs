using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EncryptNamespace;
using Xamarin.Essentials;//要引用這個要先裝好相關的套件！詳下copyButton.Click 處備註

namespace EncryptAndroid
{
    [Activity(Label = "EncodeActivity")]
    public class EncodeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            //以上都是「加入→新增項目」精靈自己配置的，以下才我們自己寫的
            //有了SetContentView這行才能展現該有的視圖（View=Form表單），否則會出現空白畫面（表單）
            //intent 是將要表現（出現）的內容，而Content是現在要展露（出現）的內容（View）
            SetContentView(Resource.Layout.activity_encode);
            Button backButton_returnMain = FindViewById<Button>(Resource.Id.button_home);
            backButton_returnMain.Click += (sender, e) =>
                { StartActivity(new Intent(this, typeof(MainActivity))); };


            TextView textView = FindViewById<TextView>(Resource.Id.text_view);
            const string textViewText_EmptyString = "沒有輸入文字";
            const string textViewText_ResultString = "結果是：";
            EditText edit_text = FindViewById<EditText>(Resource.Id.edit_text);
            bool checkEditText_Text()
            {
                if (edit_text.Text == "")
                {
                    textView.Text = textViewText_EmptyString;
                    return false;

                };
                return true;
            }

            string resultText = new string("");
            Encrypt encrypt = new Encrypt();
            Button encodeButton = FindViewById<Button>(Resource.Id.button_encode);
            encodeButton.Click += (sender, e) =>
            {
                if (checkEditText_Text())
                {
                    resultText = encrypt.ToEncode(edit_text.Text);
                    textView.Text = "編碼" + textViewText_ResultString +
                        resultText;
                }
            };
            Button decodeButton = FindViewById<Button>(Resource.Id.button_decode);
            //+=的讀法：掛上方法（+）然後再指定給（=）Click事件
            decodeButton.Click += (sender, e) =>
            {
                if (checkEditText_Text())
                {
                    resultText = encrypt.ToDecode(edit_text.Text);
                    textView.Text = "解碼" + textViewText_ResultString +
                        resultText;
                }

            };

            Button copyButton = FindViewById<Button>(Resource.Id.button_copy);
            //+=的讀法：掛上方法（+）然後再指定給（=）Click事件
            copyButton.Click += async (sender, e) =>
            {
                if (checkEditText_Text())
                    //要使用Clipboard必須引用Xamarin.Essentials;而要引用，則必須在
                    //NuGet: 中，依「Xamarin.Essentials」安裝失敗輸出之訊息，分別先行安裝其相依性之套件：
                    /*  Xamarin.Android.Support.Compat
                        Xamarin.Android.Support.Core.Utils
                        Xamarin.Android.Support.Design
                        Xamarin.Android.Support.v7.RecyclerView
                        Xamarin.Android.Support. Vector.Drawable
                        安裝好這些才能裝Xamarin.Essentials，
                        會自動加入參考中，也才能引用；而張老師
                        《C# 專案開發入門的八堂課》在此，卻未措一辭！*/
                    await Clipboard.SetTextAsync(resultText);
            };
        }
    }
}