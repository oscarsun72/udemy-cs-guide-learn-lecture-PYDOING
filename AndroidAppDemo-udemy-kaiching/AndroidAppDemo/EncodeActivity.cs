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
using Xamarin.Essentials;

namespace AndroidAppDemo
{
    [Activity(Label = "EncodeActivity")]
    public class EncodeActivity : Activity
    {
        private string result;
        public string Result { get => result; set => result = value; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, bundle: savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_encode);

            Button backButton = FindViewById<Button>(Resource.Id.button_home);
            backButton.Click += (sender, e) =>
            {
                StartActivity(new Intent(this, typeof(MainActivity)));
            };

            EditText userinput = (EditText)FindViewById<EditText>(Resource.Id.edit_text);
            TextView resulttext = (TextView)FindViewById<TextView>(Resource.Id.text_view);
            Button encodeButton = FindViewById<Button>(Resource.Id.button_encode);
            encodeButton.Click += (sender, e) =>
            {
                Encrypt encryptObject = new Encrypt();
                if (userinput.Text == "")
                {
                    resulttext.Text = "沒有輸入英文句子!";
                }
                else
                {
                    resulttext.Text = encryptObject.ToEncode(userinput.Text);
                    Result = resulttext.Text;
                }
            };

            Button copyButton = FindViewById<Button>(Resource.Id.button_copy);
            copyButton.Click += async (sender, e) =>
            {
                await Clipboard.SetTextAsync(resulttext.Text);
            };
        }
    }
}

// 《程式語言教學誌》的範例程式
// https://kaiching.org
// 專案：AndroidAppDemo
// 檔名：EncodeActivity.cs
// 功能：示範編密碼的 Android App
// 作者：張凱慶