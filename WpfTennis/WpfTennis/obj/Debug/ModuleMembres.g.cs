﻿#pragma checksum "..\..\ModuleMembres.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D01669EBE92B224D072E315B2B7EEBBC60B70F0CD729E0DD3CB6AA6D9392E512"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
using WpfTennis;


namespace WpfTennis {
    
    
    /// <summary>
    /// ModuleMembres
    /// </summary>
    public partial class ModuleMembres : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\ModuleMembres.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grilleDonnees;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ModuleMembres.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRetourMainWindow;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ModuleMembres.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEffacer;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ModuleMembres.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAjout;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ModuleMembres.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAide;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfTennis;component/modulemembres.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ModuleMembres.xaml"
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
            this.grilleDonnees = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\ModuleMembres.xaml"
            this.grilleDonnees.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dataGrid1_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnRetourMainWindow = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\ModuleMembres.xaml"
            this.btnRetourMainWindow.Click += new System.Windows.RoutedEventHandler(this.btnRetourMainWindow_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnEffacer = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\ModuleMembres.xaml"
            this.btnEffacer.Click += new System.Windows.RoutedEventHandler(this.btnEffacer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAjout = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\ModuleMembres.xaml"
            this.btnAjout.Click += new System.Windows.RoutedEventHandler(this.btnAjout_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnAide = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\ModuleMembres.xaml"
            this.btnAide.Click += new System.Windows.RoutedEventHandler(this.btnAide_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

