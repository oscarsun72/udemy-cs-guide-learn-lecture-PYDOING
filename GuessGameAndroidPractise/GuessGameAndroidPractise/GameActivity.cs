using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang.Reflect;
using Java.Util;

namespace GuessGameAndroidPractise
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : Activity
    {
        //OnCreate就是在初始化
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_game);

            //將數字按鈕設定為無效，不可按下：
            Button btn = FindViewById<Button>(Resource.Id.button1);
            int i=0;//以後再研究ViewGroup
            //ViewGroup thisViews = (ViewGroup) FindViewById(Android.Resource.Id.Content);            
            LinearLayout gameLayout =(LinearLayout) FindViewById<LinearLayout>
                (Resource.Id.linearLayoutGame);            
            LinearLayout gameLayoutLayout = new LinearLayout(gameLayout.Context);
            for (int j = 0; j < gameLayout.ChildCount; j++)
            {
                View v= gameLayout.GetChildAt(j);
                if (v.GetType().FullName.IndexOf("Button")!=-1) { //判斷型別是否是Button
                    btn = (Button)v;
                    if(int.TryParse( btn.Text,out i))//判斷Text值（按鈕所示者）是否為數字
                    btn.Enabled = false;
                }
                else if (v.GetType().FullName.IndexOf("LinearLayout")!=-1)//如果還是LinearLayout,就還要再往它的下一層找去
                {
                    gameLayoutLayout = (LinearLayout)v;
                    for (int k = 0; k < gameLayoutLayout.ChildCount; k++)
                    {
                        View vk = gameLayoutLayout.GetChildAt(k);
                        if (vk.GetType().FullName.IndexOf("Button")!=-1)//判斷型別是否是Button
                        {
                            Button btnk = (Button)vk;
                            if (int.TryParse( btnk.Text,out i))//判斷Text值（按鈕所示者）是否為數字
                                btnk.Enabled = false;
                            
                        }
                    }
                }                
            }
            

            Button btnReset = FindViewById<Button>(Resource.Id.buttonReset);
            btnReset.Click += (sender,e) => {
                Intent main = new Intent(this, typeof(MainActivity));
                StartActivity(main);
            };

            Button btnNewGame = FindViewById<Button>(Resource.Id.buttonNewGame);
            btnNewGame.Click += (sender, e)=>{

            };
        }
    }
}