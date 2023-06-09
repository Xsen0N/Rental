﻿#pragma checksum "..\..\..\House.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76A2AB2318733D565DB0EC653DCCA54072C2F4BD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using RentalAvenue;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace RentalAvenue {
    
    
    /// <summary>
    /// House
    /// </summary>
    public partial class House : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\House.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Header;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\House.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MenuToggleButton;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\House.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popupMenu;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\House.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox availableLanguagesList;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\House.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Ru;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\House.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Eng;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\House.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Returnblock;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\..\House.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\..\House.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\..\House.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Disc;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RentalAvenue;component/house.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\House.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 13 "..\..\..\House.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.AddReview_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 14 "..\..\..\House.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.MainButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 15 "..\..\..\House.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ExitButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 16 "..\..\..\House.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.RentButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Header = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            
            #line 42 "..\..\..\House.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnNavigateToRentalForm);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 43 "..\..\..\House.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MainButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MenuToggleButton = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\House.xaml"
            this.MenuToggleButton.Click += new System.Windows.RoutedEventHandler(this.MenuToggleButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.popupMenu = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 10:
            
            #line 52 "..\..\..\House.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowLikeed_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.availableLanguagesList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.Ru = ((System.Windows.Controls.ComboBoxItem)(target));
            
            #line 60 "..\..\..\House.xaml"
            this.Ru.Selected += new System.Windows.RoutedEventHandler(this.Ru_Selected);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Eng = ((System.Windows.Controls.ComboBoxItem)(target));
            
            #line 63 "..\..\..\House.xaml"
            this.Eng.Selected += new System.Windows.RoutedEventHandler(this.Eng_Selected);
            
            #line default
            #line hidden
            return;
            case 14:
            this.Returnblock = ((System.Windows.Controls.Grid)(target));
            return;
            case 15:
            this.Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.Email = ((System.Windows.Controls.TextBox)(target));
            
            #line 185 "..\..\..\House.xaml"
            this.Email.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 17:
            this.Disc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 18:
            
            #line 204 "..\..\..\House.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

