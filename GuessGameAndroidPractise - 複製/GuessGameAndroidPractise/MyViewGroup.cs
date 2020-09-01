using Android.Content;
using Android.Views;
using Android.Util;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
//using Android.Support.V4;

namespace GuessGameAndroidPractise
{
    public class MyViewGroup : ViewGroup
    {
        //Called from layout when this view should assign a size and position to each of its children.
        //https://docs.microsoft.com/zh-tw/dotnet/api/android.views.viewgroup.onlayout?view=xamarin-android-sdk-9#Android_Views_ViewGroup_OnLayout_System_Boolean_System_Int32_System_Int32_System_Int32_System_Int32_
        int _childCount = 0;

        public new int ChildCount { get => _childCount; set => _childCount = value; }

        public MyViewGroup(Context context) :base(context)
        { 
            
        }
        
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            //throw new System.NotImplementedException();
            if (changed)
            {
                Left = l;Top = t;
                Right = r;Bottom = b;
            }
            else
            {
                Left = l; Top = t;
                Right = r; Bottom = b;
            }
        }

        
        public override void FindViewsWithText(IList<View> outViews,
            Java.Lang.ICharSequence text, FindViewsWith flags)
        {
            
            //Java super是調用父類別的指標/參考,C#則是 base
            //super.findViewsWithText(outViews, text, flags);
            base.FindViewsWithText(outViews, text, flags);
            int mChildrenCount = ChildCount;            
            //Java final相當於 C# const 或 Readonly
            //final int childrenCount = mChildrenCount;            
            int childrenCount = mChildrenCount;
            //final View[] children = mChildren;
            //View[] children = mChildren;
            for (int i = 0; i < childrenCount; i++)
            {
                //View child = children[i];
                MyView child = new MyView( GetChildAt(i));                
                //if ((child.mViewFlags & VISIBILITY_MASK) == VISIBLE &&
                //    (child.mPrivateFlags & PFLAG_IS_ROOT_NAMESPACE) == 0)
                if (child._v.Visibility==ViewStates.Visible && 
                    child._v.RootView != null)
                {
                    child.FindViewsWithText(outViews, text, flags);
                }
            }
        }

    }

}