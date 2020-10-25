﻿using Project.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Navigated(object sender, NavigationEventArgs e)
        {
            Page page = e.Content as Page; if (page != null) ApplicationHelper.NavigationService = page.NavigationService;
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //initialize the splash screen and set it as the application main window
            var splashScreen = new SplashScreen();
            this.MainWindow = splashScreen;
            splashScreen.Show();

            //in order to ensure the UI stays responsive, we need to
            //do the work on a different thread
            Task.Factory.StartNew(() =>
            {
                //simulate some work being done
                System.Threading.Thread.Sleep(4000);

                //since we're not on the UI thread
                //once we're done we need to use the Dispatcher
                //to create and show the main window
                this.Dispatcher.Invoke(() =>
                {
                    //initialize the main window, set it as the application main window
                    //and close the splash screen
                    var mainWindow = new MainWindow();
                    this.MainWindow = mainWindow;
                    mainWindow.Show();
                    splashScreen.Close();
                });
            });
        }

        
    }
}
