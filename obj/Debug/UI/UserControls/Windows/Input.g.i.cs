﻿#pragma checksum "..\..\..\..\..\UI\UserControls\Windows\Input.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BBEF65BB2CB2D19C5640550B6105804718DCE96481B39F397D16A72F8355B04B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace TrayApp.UI.UserControls {
    
    
    /// <summary>
    /// Input
    /// </summary>
    public partial class Input : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\..\UI\UserControls\Windows\Input.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Border;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\UI\UserControls\Windows\Input.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtInput;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\UI\UserControls\Windows\Input.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TblContext;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\UI\UserControls\Windows\Input.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnClear;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TrayApp;component/ui/usercontrols/windows/input.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UI\UserControls\Windows\Input.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Border = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.TxtInput = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\..\..\UI\UserControls\Windows\Input.xaml"
            this.TxtInput.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtInput_TextChanged);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\..\..\UI\UserControls\Windows\Input.xaml"
            this.TxtInput.GotFocus += new System.Windows.RoutedEventHandler(this.TextInput_GotFocus);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\..\..\UI\UserControls\Windows\Input.xaml"
            this.TxtInput.LostFocus += new System.Windows.RoutedEventHandler(this.TextInput_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TblContext = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.BtnClear = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\..\UI\UserControls\Windows\Input.xaml"
            this.BtnClear.Click += new System.Windows.RoutedEventHandler(this.BtnClear_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

