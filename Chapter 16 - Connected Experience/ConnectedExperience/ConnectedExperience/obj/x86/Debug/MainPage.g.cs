﻿#pragma checksum "C:\Users\Bilal\Documents\Visual Studio 2017\Projects\ConnectedExperience\ConnectedExperience\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EBAFD911BABCEED952EB769E8C6A0456"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConnectedExperience
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.MainGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2:
                {
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.BrownRadioButton = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 28 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.BrownRadioButton).Checked += this.radioButton_Checked;
                    #line default
                }
                break;
            case 4:
                {
                    this.GrayRadioButton = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 31 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.GrayRadioButton).Checked += this.radioButton_Checked;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
