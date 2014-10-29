using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Xamarin.Forms;
using NeuChat.Services;
using GalaSoft.MvvmLight.Ioc;


namespace NeuChat.WinPhone {
    public partial class MainPage : PhoneApplicationPage, ILoginManager {
        public MainPage() {
            InitializeComponent();
            
            Forms.Init();

            // Configure IOC
            Bootstrapper.Configure();
            NeuChat.App.LoginManager = this;

            Content = NeuChat.App.GetMainPage().ConvertPageToUIElement(this);
        }

        public void Logout() {
            Content = NeuChat.App.GetLoginPage().ConvertPageToUIElement(this);
        }

        public void ShowMainPage() {
            Content = NeuChat.App.GetMainPage().ConvertPageToUIElement(this);
        }
    }
}