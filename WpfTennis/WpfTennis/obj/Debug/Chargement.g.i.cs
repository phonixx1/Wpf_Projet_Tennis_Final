﻿#pragma checksum "..\..\Chargement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AD5A30199D29D15F19E6889E96330AAF7D465F841786939153130AD3679B29AD"
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
    /// Chargement
    /// </summary>
    public partial class Chargement : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\Chargement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnChargerLesLillas;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Chargement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnChargerAceClub;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Chargement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelChargement;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Chargement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelChargement2;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Chargement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button retourChargement;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfTennis;component/chargement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Chargement.xaml"
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
            this.btnChargerLesLillas = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Chargement.xaml"
            this.btnChargerLesLillas.Click += new System.Windows.RoutedEventHandler(this.btnChargerLesLillas_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnChargerAceClub = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\Chargement.xaml"
            this.btnChargerAceClub.Click += new System.Windows.RoutedEventHandler(this.btnChargerAceClub_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.labelChargement = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.labelChargement2 = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.retourChargement = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\Chargement.xaml"
            this.retourChargement.Click += new System.Windows.RoutedEventHandler(this.retourChargement_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

