﻿

#pragma checksum "C:\Users\UGent\Source\Repos\gandavisit\GandaVisit\GandaVisit\Detail.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6671358D231AB1B21A676170E99903ED"
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
    partial class Detail : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 13 "..\..\Detail.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnRoute_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 18 "..\..\Detail.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.BtnClear_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 67 "..\..\Detail.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.Email_Pressed;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 61 "..\..\Detail.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.Website_pressed;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 51 "..\..\Detail.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.Phone_Pressed;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 31 "..\..\Detail.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.BtnAddVisit_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


