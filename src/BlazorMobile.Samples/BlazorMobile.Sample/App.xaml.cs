﻿using BlazorMobile.Components;
using BlazorMobile.Services;
using System;
using Xamarin.Forms;

namespace BlazorMobile.Sample
{
	public partial class App : BlazorApplication
    {
        public const string BlazorAppPackageName = "BlazorMobile.Sample.Blazor.zip";

        public App()
        {
            InitializeComponent();

#if DEBUG
            WebApplicationFactory.EnableDebugFeatures();
#endif
            WebApplicationFactory.SetHttpPort(8888);

            //Register Blazor application package resolver
            WebApplicationFactory.RegisterAppStreamResolver(() =>
            {
                //This app assembly
                var assembly = typeof(App).Assembly;

                //Name of our current Blazor package in this project, stored as an "Embedded Resource"
                //The file is resolved through AssemblyName.FolderAsNamespace.YourPackageNameFile

                //In this example, the result would be BlazorMobile.Sample.Package.BlazorMobile.Sample.Blazor.zip
                return assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Package.{BlazorAppPackageName}");
            });

            MainPage = new MainPage();
        }
    }
}
