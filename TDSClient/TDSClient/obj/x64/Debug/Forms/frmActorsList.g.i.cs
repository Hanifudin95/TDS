﻿#pragma checksum "..\..\..\..\Forms\frmActorsList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7A7CD8E3CEAFA9545DA9EE3AEAEEA1D4"
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
using TDSClient.Properties;


namespace TDSClient.Forms {
    
    
    /// <summary>
    /// frmActorsList
    /// </summary>
    public partial class frmActorsList : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\Forms\frmActorsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtGridActors;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\..\Forms\frmActorsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdNew;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\..\Forms\frmActorsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdDelete;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\..\Forms\frmActorsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdExit;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Forms\frmActorsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdShowMe;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Forms\frmActorsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdActivities;
        
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
            System.Uri resourceLocater = new System.Uri("/TDSClient;component/forms/frmactorslist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\frmActorsList.xaml"
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
            
            #line 5 "..\..\..\..\Forms\frmActorsList.xaml"
            ((TDSClient.Forms.frmActorsList)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.Window_Unloaded);
            
            #line default
            #line hidden
            
            #line 5 "..\..\..\..\Forms\frmActorsList.xaml"
            ((TDSClient.Forms.frmActorsList)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dtGridActors = ((System.Windows.Controls.DataGrid)(target));
            
            #line 7 "..\..\..\..\Forms\frmActorsList.xaml"
            this.dtGridActors.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.dtGridActors_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\..\Forms\frmActorsList.xaml"
            this.dtGridActors.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.dtGridActors_PreviewMouseMove);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cmdNew = ((System.Windows.Controls.Button)(target));
            
            #line 8 "..\..\..\..\Forms\frmActorsList.xaml"
            this.cmdNew.Click += new System.Windows.RoutedEventHandler(this.cmdNew_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmdDelete = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\..\..\Forms\frmActorsList.xaml"
            this.cmdDelete.Click += new System.Windows.RoutedEventHandler(this.cmdDelete_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmdExit = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\..\Forms\frmActorsList.xaml"
            this.cmdExit.Click += new System.Windows.RoutedEventHandler(this.cmdExit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cmdShowMe = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\Forms\frmActorsList.xaml"
            this.cmdShowMe.Click += new System.Windows.RoutedEventHandler(this.cmdShowMe_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cmdActivities = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\..\Forms\frmActorsList.xaml"
            this.cmdActivities.Click += new System.Windows.RoutedEventHandler(this.cmdActivities_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
