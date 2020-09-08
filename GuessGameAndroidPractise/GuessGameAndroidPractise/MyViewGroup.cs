using Android.Content;
using Android.Views;
using Android.Util;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Android.Widget;
using System.Xml;
using Android.Content.Res;
using Android.App;

namespace GuessGameAndroidPractise
{
    public class MyViewGroup : ViewGroup
    {
        //Called from layout when this view should assign a size and position to each of its children.
        //https://docs.microsoft.com/zh-tw/dotnet/api/android.views.viewgroup.onlayout?view=xamarin-android-sdk-9#Android_Views_ViewGroup_OnLayout_System_Boolean_System_Int32_System_Int32_System_Int32_System_Int32_
        int _childCount = 0;

        public new int ChildCount { get => _childCount; set => _childCount = value; }        
        Context _context1; static Activity activity;
        public MyViewGroup(Context context) : base(context)
        {
            _context1 = context;
            activity = (Activity)_context1;//https://stackoverflow.com/questions/9891360/getting-activity-from-context-in-android
        }
        
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            //throw new System.NotImplementedException();
            if (changed)
            {
                Left = l; Top = t;
                Right = r; Bottom = b;
            }
            else
            {
                Left = l; Top = t;
                Right = r; Bottom = b;
            }
        }

        public enum whatTraverseMethodToBeRun
        {
            xml, recursion, withoutRecursion
        }

        //巡覽遍歷想要找的View，並取得List<View>，以便於對此群組作統一的操作
        public void FindViewsWithText(//traverse_any_view_hierarchy_in_android
            ref List<View> vList,whatTraverseMethodToBeRun method,
            chooseAXmlMethodforTraverseViewGroup c
                = chooseAXmlMethodforTraverseViewGroup.SelectNodes,
            string contentDescription = "buttonNum",
            string nodeForGot = "Button", string attributeName = "contentDescription",
            int attributevalue = Resource.String.buttonNum,
            int layoutXmlFileName = Resource.Layout.activity_game,
            int layoutID=Resource.Id.linearLayoutGame)
        {
            //凡4種方式來巡覽遍歷所有的 View Button：
            switch (method)
            {
                case whatTraverseMethodToBeRun.xml:
                    switch (c)
                    {
                        case chooseAXmlMethodforTraverseViewGroup.GetElementsByTagName:
                        case chooseAXmlMethodforTraverseViewGroup.SelectNodes:
                        case chooseAXmlMethodforTraverseViewGroup.SelectNodes_XmlNamespaceManager:
                            traverseViewGroup_Xml(ref vList, c, nodeForGot
                                , attributeName, attributevalue, layoutXmlFileName);
                            break;
                        default:
                            break;
                    }
                    break;
                case whatTraverseMethodToBeRun.recursion:
                    View view = activity.FindViewById<LinearLayout>(layoutID);
                    int viewsCount = traverseViewGroup_recursion(ref vList,
                        view, contentDescription);//遞歸（recursion）
                    break;
                case whatTraverseMethodToBeRun.withoutRecursion:
                    View v = activity.FindViewById<LinearLayout>(layoutID);
                    int viewsCnt = traverseViewGroup(ref vList,
                        v, contentDescription);//不遞迴（recursion）
                    break;
                default:
                    break;
            }



        }

        public enum chooseAXmlMethodforTraverseViewGroup
        {
            GetElementsByTagName, SelectNodes, SelectNodes_XmlNamespaceManager
        }

        //用Xml提供的方法來遍歷巡覽View https://docs.microsoft.com/zh-tw/dotnet/api/system.xml.xmlnode.selectnodes?view=netcore-3.1
        void traverseViewGroup_Xml(ref List<View> vList,
            chooseAXmlMethodforTraverseViewGroup c,
            string nodeForGot = "Button", string attributeName = "contentDescription",
            int attributevalue = Resource.String.buttonNum,
            int layoutID = Resource.Layout.activity_game
            )
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Resources.GetLayout(layoutID));
            XmlElement xmlElement = doc.DocumentElement;
            XmlNodeList xmlNodeList = doc.ChildNodes;
            switch (c)
            {
                case chooseAXmlMethodforTraverseViewGroup.GetElementsByTagName:
                    xmlNodeList = doc.GetElementsByTagName(nodeForGot);
                    break;
                case chooseAXmlMethodforTraverseViewGroup.SelectNodes:
                    xmlNodeList = xmlElement.SelectNodes("//" + nodeForGot);//case-sensitive
                    break;
                case chooseAXmlMethodforTraverseViewGroup.SelectNodes_XmlNamespaceManager:
                    XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(doc.NameTable);
                    xmlNamespaceManager.AddNamespace("android", "http://schemas.android.com/apk/res/android");
                    xmlNodeList = xmlElement.SelectNodes("//" + nodeForGot, xmlNamespaceManager);
                    break;
                default:
                    break;
            }
            if (xmlNodeList.Count != doc.ChildNodes.Count)//因為以doc.ChildNodes初始化故
            {
                foreach (XmlNode item in xmlNodeList)
                {
                    XmlAttribute attributeContentDescription = item.Attributes["p0:" + attributeName];
                    if (attributeContentDescription != null)//具有指定名稱的屬性。 如果屬性 (attribute) 不存在，這個屬性 (property) 會傳回 null。https://docs.microsoft.com/zh-tw/dotnet/api/system.xml.xmlattributecollection.itemof?view=netcore-3.1#System_Xml_XmlAttributeCollection_ItemOf_System_String_
                    {
                        string valueAttributeContentDescription = attributeContentDescription.Value;
                        if (valueAttributeContentDescription != null &&
                            valueAttributeContentDescription.Contains//如果是數字按鈕
                                (Convert.ToString(attributevalue)))//因屬性值前有1個「@」
                        {
                            
                            //View gameActivity = new View(_context1);                            
                            vList.Add(activity.FindViewById<Button>
                                (int.Parse(item.Attributes["p0:id"].Value
                                    .Substring(1))));
                        }
                    }
                }
            }
        }

        ////用XmlDocument.GetElementsByTagName 方法來遍歷巡覽View https://docs.microsoft.com/zh-tw/dotnet/api/system.xml.xmldocument.getelementsbytagname?view=netcore-3.1#System_Xml_XmlDocument_GetElementsByTagName_System_String_
        //void traverseViewGroup_GetElementsByTagName_EnabledFalse()
        //{
        //    XmlDocument doc = new XmlDocument();
        //    //XmlReader xmrder = Application.Resources.GetLayout(2131427356);
        //    XmlReader xmrder = Application.Resources.GetLayout(Resource.Layout.activity_game);
        //    doc.Load(xmrder);
        //    //下列網頁說明所示的R類別，其實是Java中的實作，在C#中則是如上，直接用「Resources」這個類別，就是R類別！
        //    //doc=R.layout.activity_game;// error :https://developer.android.com/guide/topics/resources/accessing-resources#ResourcesFromCode

        //    XmlNodeList xmlNodeList = doc.GetElementsByTagName("Button");
        //    foreach (XmlNode item in xmlNodeList)
        //    {
        //        XmlAttribute xAtt = item.Attributes["p0:contentDescription"];
        //        if (xAtt != null)
        //        {
        //            //以上2行為優化，與下2行等效
        //            //foreach (XmlAttribute xa in item.Attributes)
        //            //{
        //            //    //if (xa.Name=="p0:contentDescription")//與以下一行同
        //            //    if (xa.Name.Contains("contentDescription"))
        //            //    {
        //            //string contentDescription = item.Attributes["p0:contentDescription"].Value;
        //            string contentDescription = xAtt.Value;
        //            if (contentDescription != null
        //                && contentDescription.Contains("@" + Resource.String.buttonNum))
        //            {
        //                FindViewById<Button>
        //                    (int.Parse(item.Attributes["p0:id"].Value.Substring(1)))
        //                    .Enabled = false;//Name="p0:id", Value="@2131230760"//要去掉首位「@」符
        //                                     //break; //foreach (XmlAttribute xa in item.Attributes)
        //            }
        //            //    } 
        //            //}
        //        }
        //    }
        //}


        //用遞迴。〈Android 算法：遍历ViewGroup找出所有子View〉https://blog.csdn.net/l707941510/article/details/82912526
        int traverseViewGroup_recursion(ref List<View> vList,
            View view, string contentDescription = "buttonNum")//Passing Parameters (C# Programming Guide):https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/classes-and-structs/passing-parameters
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
                            traverseViewGroup_recursion(
                                ref vList, vw, contentDescription);
                    }
                    else
                    {
                        viewCount++;
                        var cntDscrpt = vw.ContentDescription;
                        if (cntDscrpt != null &&
                            cntDscrpt.IndexOf(contentDescription) > -1)
                            vList.Add(vw);

                    }
                }
            }
            else
            {
                viewCount++;
                var cntDscrpt = view.ContentDescription;
                if (cntDscrpt != null
                    && cntDscrpt.IndexOf(contentDescription) > -1)
                    vList.Add(view);
            }
            return viewCount;

        }

        //不用遞迴（recursion）
        int traverseViewGroup(
                ref List<View> vList, View view,
                string contentDescription = "buttonNum")
        {
            if (view == null) return 0;
            int viewCount = 0;
            var abstractType = typeof(ViewGroup);
            if (abstractType.IsInstanceOfType(view))
            {
                List<ViewGroup> lVg = new List<ViewGroup>();
                ViewGroup vg = (ViewGroup)view;
                lVg.Add(vg);
                while (lVg.Count > 0)
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
                            var cntDscrp = vw.ContentDescription;
                            if (cntDscrp != null &&
                                cntDscrp.IndexOf(contentDescription) > -1)
                                vList.Add(vw);
                        }
                    }

                }
            }
            else
            {
                viewCount++;
                var cntDscrp = view.ContentDescription;
                if (cntDscrp != null &&
                    cntDscrp.IndexOf(contentDescription) > -1)
                    vList.Add(view);
            }

            return viewCount;
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
                if (GetChildAt(i) != null)
                {
                    MyView child = new MyView(GetChildAt(i));
                    //if ((child.mViewFlags & VISIBILITY_MASK) == VISIBLE &&
                    //    (child.mPrivateFlags & PFLAG_IS_ROOT_NAMESPACE) == 0)
                    if (child._v.Visibility == ViewStates.Visible &&
                        child._v.RootView != null)
                    {
                        child.FindViewsWithText(outViews, text, flags);
                    }
                }
            }
        }

    }

}