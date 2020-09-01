using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
//using Android.Support.V4;
using Java.Lang;
using Java.Lang.Reflect;

namespace GuessGameAndroidPractise
{
    public class MyView //: View
    {
        string ContentDescription="";
        internal View _v;
        public  MyView (View v)
        {
            _v = v;
            ContentDescription = v.ContentDescription;
        } 
        //public MyView(Context context, IAttributeSet attrs) :
        //    base(context, attrs)
        //{
        //    Initialize();
        //}

        //public MyView(Context context, IAttributeSet attrs, int defStyle) :
        //    base(context, attrs, defStyle)
        //{
        //    Initialize();
        //}

        //private void Initialize()
        //{
        //}


        //public override void FindViewsWithText(IList<View> outViews,
        public void FindViewsWithText(IList<View> outViews,
             Java.Lang.ICharSequence searched, FindViewsWith flags)
        {
            string mContentDescription = ContentDescription;
            //View.AccessibilityDelegate vAccDelegate = new AccessibilityDelegate();
            //if (vAccDelegate.GetAccessibilityNodeProvider(this) != null)
            //{
            //    //if ((flags & FIND_VIEWS_WITH_ACCESSIBILITY_NODE_PROVIDERS) != 0)
            //    //{
            //    outViews.Add(this);
            //    //}
            //}
            //else if ((flags & FindViewsWith.ContentDescription) != 0 &&
            if ((flags & FindViewsWith.ContentDescription) != 0 &&
              (searched != null && searched.Length() > 0) &&
              (mContentDescription != null && mContentDescription.Length > 0))
            {
                System.String searchedLowerCase = searched.ToString().ToLower();
                System.String contentDescriptionLowerCase =
                        mContentDescription.ToString().ToLower();//the containment is case insensitive. 包含的内容是不分大小写的。//https://developer.android.com/reference/android/view/View#findViewsWithText(java.util.ArrayList%3Candroid.view.View%3E,%20java.lang.CharSequence,%20int)
                if (contentDescriptionLowerCase.Contains(searchedLowerCase))
                {
                    outViews.Add(_v);
                }
            }
        }

    }

}