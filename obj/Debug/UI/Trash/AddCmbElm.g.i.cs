﻿#pragma checksum "..\..\..\..\UI\Trash\AddCmbElm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2E6CBD5A06EE68FDD4FF57F1B02FE1501928E57487C7A8C0913A7DC54F859C16"
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
using TrayApp.UI.UserControls;


namespace TrayApp.UI.UserControls {
    
    
    /// <summary>
    /// AddCmbElm
    /// </summary>
    public partial class AddCmbElm : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\UI\Trash\AddCmbElm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Border;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\UI\Trash\AddCmbElm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtInput;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\UI\Trash\AddCmbElm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TblContext;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\UI\Trash\AddCmbElm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAdd;
        
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
            System.Uri resourceLocater = new System.Uri("/TrayApp;component/ui/trash/addcmbelm.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Trash\AddCmbElm.xaml"
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
            
            #line 15 "..\..\..\..\UI\Trash\AddCmbElm.xaml"
            this.TxtInput.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtInput_TextChanged);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\..\UI\Trash\AddCmbElm.xaml"
            this.TxtInput.GotFocus += new System.Windows.RoutedEventHandler(this.TextInput_GotFocus);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\..\UI\Trash\AddCmbElm.xaml"
            this.TxtInput.LostFocus += new System.Windows.RoutedEventHandler(this.TextInput_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TblContext = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.BtnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\UI\Trash\AddCmbElm.xaml"
            this.BtnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

