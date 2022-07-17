using MusicAppMobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MusicAppMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Shell.SetNavBarIsVisible(this, false);
        }
    }
}