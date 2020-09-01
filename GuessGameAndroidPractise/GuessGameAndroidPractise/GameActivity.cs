﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
//using Java.Lang;
//using Java.Lang.Reflect;
using Java.Util;

namespace GuessGameAndroidPractise
{
    public class MyViewClass : IList<View>
    {
        Java.Util.ArrayList _arrView = new Java.Util.ArrayList();
        View IList<View>.this[int index] { get => (View)_arrView.Get(index); set => _arrView.Set(index, (View)value); }
        internal MyViewClass(Java.Util.ArrayList arrView)
        {
            _arrView = arrView;
        }
        int ICollection<View>.Count => _arrView.Size();

        bool ICollection<View>.IsReadOnly =>
        throw new NotImplementedException();

        void ICollection<View>.Add(View item)
        {
            _arrView.Add(item);
            //throw new NotImplementedException();
        }

        void ICollection<View>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<View>.Contains(View item)
        {
            throw new NotImplementedException();
        }

        void ICollection<View>.CopyTo(View[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        IEnumerator<View> IEnumerable<View>.GetEnumerator()
        {

            return new MyViewClassIEnumerator(_arrView);
            //throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        int IList<View>.IndexOf(View item)
        {
            throw new NotImplementedException();
        }

        void IList<View>.Insert(int index, View item)
        {
            throw new NotImplementedException();
        }

        bool ICollection<View>.Remove(View item)
        {
            throw new NotImplementedException();
        }

        void IList<View>.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

    }

    class MyViewClassIEnumerator : IEnumerator<View>
    { //https://docs.microsoft.com/zh-tw/dotnet/api/system.collections.generic.ienumerator-1?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev16.query%3FappId%3DDev16IDEF1%26l%3DZH-TW%26k%3Dk(System.Collections.Generic.IEnumerator%601);k(TargetFrameworkMoniker-MonoAndroid,Version%3Dv9.0);k(DevLang-csharp)%26rd%3Dtrue&view=netcore-3.1
        private Java.Util.ArrayList _collection;
        private int curIndex;
        private View curView;

        public MyViewClassIEnumerator(Java.Util.ArrayList collection)
        {
            _collection = collection;
            curIndex = -1;
            curView = default(View);
        }
        //this is for the identified type
        View IEnumerator<View>.Current => curView;
        //this is for the generic type
        object IEnumerator.Current =>
            throw new NotImplementedException();

        void IDisposable.Dispose() //調用預設版本的Dispose
        {
            //throw new NotImplementedException();
        }

        bool IEnumerator.MoveNext()
        {
            if (++curIndex >= _collection.Size())
            {
                return false;
            }
            else
            {
                // Set current View to next item in collection.
                curView = (View)_collection.Get(curIndex);
            }
            return true;
        }
        void IEnumerator.Reset()
        {
            curIndex = -1;
            //throw new NotImplementedException();
        }
    }

    [Activity(Label = "GameActivity")]
    public class GameActivity : Activity
    {
        //OnCreate就是在初始化，相當於Open、Load、Initialize
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here//此則相當於 SetFocus、Activate、Show
            SetContentView(Resource.Layout.activity_game);

            //將數字按鈕設定為無效，不可按下：
            setButtonEnabledFasle_traverse_any_view_hierarchy_in_android();

            Intent main = new Intent(this, typeof(MainActivity));
            Button btnReset = FindViewById<Button>(Resource.Id.buttonReset);
            btnReset.Click += (sender, e) =>
            {
                StartActivity(main);
            };

            Button btnNewGame = FindViewById<Button>(Resource.Id.buttonNewGame);
            btnNewGame.Click += (sender, e) =>
            {
                StartActivity(main);
            };

        }

        void setButtonEnabledFasle_traverse_any_view_hierarchy_in_android()
        {
            View view = FindViewById<LinearLayout>(Resource.Id.linearLayoutGame);
            //int viewsCount = traverseViewGroup_recursion_EnabledFalse(view);
            int viewsCount = traverseViewGroup_EnabledFalse(view);
        }

        int traverseViewGroup_recursion_EnabledFalse(View view)
        {
            if (view == null) return 0;
            int viewCount = 0;//宣告應該在遞歸（recursion）時不會被覆寫，因其有int冠前也
            //https://docs.microsoft.com/zh-tw/dotnet/api/system.type.isinstanceoftype?view=netcore-3.1
            var abstractType = typeof(ViewGroup);
            if (abstractType.IsInstanceOfType(view))
            {
                ViewGroup vg = (ViewGroup)view;//要取用ChildCount屬性、GetChildAt方法須轉型為子類別，子類別ViewGroup才有定義此屬性、方法
                for (int i = 0; i < vg.ChildCount; i++)
                {
                    View vw = vg.GetChildAt(i);
                    if (abstractType.IsInstanceOfType(vw))
                    {
                        //遞歸（recursion）
                        viewCount +=
                            traverseViewGroup_recursion_EnabledFalse(vw);
                    }
                    else
                    {
                        viewCount++;
                        var contentDescription = vw.ContentDescription;
                        if (contentDescription != null && 
                            contentDescription.IndexOf("buttonNum") > -1)
                            vw.Enabled = false;

                    }
                }
            }
            else
            {
                viewCount++;
                var contentDescription = view.ContentDescription;
                if (contentDescription != null 
                    && contentDescription.IndexOf("buttonNum") > -1)
                    view.Enabled = false;
            }
            return viewCount;

        }
        public int traverseViewGroup_EnabledFalse(View view)
        {
            if (view == null) return 0;
            int viewCount = 0;
            var abstractType = typeof(ViewGroup);
            if (abstractType.IsInstanceOfType(view))
            {
                List<ViewGroup> lVg = new List<ViewGroup>();
                ViewGroup vg = (ViewGroup)view;
                lVg.Add(vg);
                while (lVg.Count() > 0)
                {
                    vg = lVg[0];
                    lVg.RemoveAt(0);
                    for (int i = 0; i < vg.ChildCount; i++)
                    {
                        var vw = vg.GetChildAt(i);
                        if (abstractType.IsInstanceOfType(vw))
                        {
                            lVg.Add((ViewGroup)vw);
                        }
                        else
                        {
                            viewCount++;
                            var contentDescription = vw.ContentDescription;
                            if (contentDescription != null &&
                                contentDescription.IndexOf("buttonNum") > -1)
                                vw.Enabled = false;
                        }
                    }

                }
            }
            else
            {
                viewCount++;
                var contentDescription = view.ContentDescription;
                if (contentDescription != null &&
                    contentDescription.IndexOf("buttonNum") > -1)
                    view.Enabled = false;
            }

            return viewCount;
        }

        //Xamarin C#語法應是沒有實作FindViewsWithText方法，故屢測無效
        void setButtonEnabledFasle_FindViewsWithText()
        {
            //將數字按鈕設定為無效，不可按下：
            Button btn = FindViewById<Button>(Resource.Id.button1);
            int i = 0; //以後再研究ViewGroup
            //ViewGroup thisViews = (ViewGroup) FindViewById(Android.Resource.Id.Content);            
            //LinearLayout就是一種ViewGroup，其實就是View的容器（container）
            LinearLayout gameLayout = FindViewById<LinearLayout>
                (Resource.Id.linearLayoutGame);
            //LinearLayout gameLayout = FindViewById<LinearLayout>
            //    (Resource.Id.linearLayout1);
            //View gameLayout = FindViewById<LinearLayout>
            //    (Resource.Id.linearLayout1);
            //MyViewGroup gamelayout = new MyViewGroup(gameLayout.Context);            
            //gamelayout.ChildCount=gameLayout.ChildCount;
            //for (int j = 0; j < gameLayout.ChildCount; j++)
            //{
            //    View v = gameLayout.GetChildAt(j);
            //    gameLayout.RemoveView(v);
            //    gamelayout.AddView(v);

            //}
            //LinearLayout gameLayout = FindViewById<LinearLayout>
            //    (Resource.Id.linearLayout1);
            ////空的ArrayList
            //Java.Util.ArrayList jArraylist = new Java.Util.ArrayList ();
            ////空的IList<View>
            //IList<View> jArraylist = new List<View>();
            //Java.Lang.ICharSequence vs=new Java.Lang.String("buttonNum");//https://forums.xamarin.com/discussion/37716/how-to-convert-net-string-to-java-lang-icharsequence    https://csharp.hotexamples.com/examples/-/ICharSequence/-/php-icharsequence-class-examples.html       
            /*在.NET(就是C#程式庫）中，gameLayout這樣調用FindViewsWithText
                *其實是以View在在調用，因為C#程式庫在ViewGroup中
                    *沒有覆寫View中的這個方法
                *由此測試發現Xamarin的C# 在ViewGropu的實作，似乎並沒有覆寫View的此一方法
                故其執行完後，jArraylist的Count屬性依然是0。*/
            //gameLayout.FindViewsWithText(jArraylist,
            //vs,FindViewsWith.ContentDescription);
            //gamelayout.FindViewsWithText(jArraylist,
            //vs,FindViewsWith.ContentDescription);

            LinearLayout gameLayoutLayout =
                new LinearLayout(gameLayout.Context);
            //for (int j = 0; j < gameLayout.ChildCount; j++)
            //{
            //    jArraylist.Add(gameLayout.GetChildAt(j));
            //}
            //// 建一個空的MyViewClass物件，作為FindViewsWithText的引數
            //MyViewClass arrayListView = new MyViewClass (jArraylist);
            //gameLayout.FindViewsWithText(arrayListView,
            //    "button", FindViewsWith.ContentDescription);
            ////for (int j = 0; j < 10; j++) {
            ////    gameLayout.FindViewsWithText (arrayListView, j.ToString (), 
            ////        FindViewsWith.Text);

            ////}

            //A way to easily traverse any view hierarchy in Android －－此亦Java版的 https://gist.github.com/gelitenight/7999448
            //以下為末學自己實作的，但也僅止於二層ViewGropu（view hierarchy ）關係而已
            for (int j = 0; j < gameLayout.ChildCount; j++)
            {
                View v = gameLayout.GetChildAt(j);
                if (v.GetType().FullName.IndexOf("Button") != -1)
                { //判斷型別是否是Button
                    btn = (Button)v;
                    if (int.TryParse(btn.Text, out i)) //判斷Text值（按鈕所示者）是否為數字
                        btn.Enabled = false;
                }
                else if (v.GetType().FullName.IndexOf("LinearLayout") != -1) //如果還是LinearLayout,就還要再往它的下一層找去
                {
                    gameLayoutLayout = (LinearLayout)v;
                    for (int k = 0; k < gameLayoutLayout.ChildCount; k++)
                    {
                        View vk = gameLayoutLayout.GetChildAt(k);
                        if (vk.GetType().FullName.IndexOf("Button") != -1) //判斷型別是否是Button
                        {
                            Button btnk = (Button)vk;
                            if (int.TryParse(btnk.Text, out i)) //判斷Text值（按鈕所示者）是否為數字
                                btnk.Enabled = false;

                        }
                    }
                }
            }

        }


    }

}