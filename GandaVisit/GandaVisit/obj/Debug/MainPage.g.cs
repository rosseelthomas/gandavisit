﻿

#pragma checksum "C:\Users\UGent\Source\Repos\gandavisit\GandaVisit\GandaVisit\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "03DD9F10937DFFF711AC9EA0629B4543"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GandaVisit
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 25 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnSearch_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 15 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.GoVisits;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 16 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.GO_Search;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


