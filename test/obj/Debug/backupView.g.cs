﻿#pragma checksum "..\..\backupView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B497B46B538B0882BA64686ACF9B6EB27E6F827CC8010E7F3AC51C63A623F0E1"
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
using UCGeneraFi;
using test;


namespace test {
    
    
    /// <summary>
    /// backupView
    /// </summary>
    public partial class backupView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\backupView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UCGeneraFi.ucFormulaire form;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\backupView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboDB;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\backupView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboPeriode;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\backupView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Openfile;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\backupView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbhebdo;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\backupView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbMens;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\backupView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbheure;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\backupView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbminute;
        
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
            System.Uri resourceLocater = new System.Uri("/test;component/backupview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\backupView.xaml"
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
            this.form = ((UCGeneraFi.ucFormulaire)(target));
            
            #line 9 "..\..\backupView.xaml"
            this.form.EnregistrerClick += new System.Windows.RoutedEventHandler(this.ucform_EnregistrerClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ComboDB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.ComboPeriode = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Openfile = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\backupView.xaml"
            this.Openfile.Click += new System.Windows.RoutedEventHandler(this.Savefile_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmbhebdo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.cmbMens = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.cmbheure = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.cmbminute = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
