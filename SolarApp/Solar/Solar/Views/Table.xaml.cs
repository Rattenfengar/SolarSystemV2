﻿using Solar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Solar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Table : ContentPage
    {
        public Table()
        {
            BindingContext = Startup.ServiceProvider.GetService<ResultViewModel>();
            InitializeComponent();
        }
    }
}