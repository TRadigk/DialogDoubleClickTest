// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
using System.Diagnostics;
using System.Threading;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DialogDoubleClickTest
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private readonly SynchronizationContext _context;

        public MainWindow()
        {
            this.InitializeComponent();
            ContentDialog.PrimaryButtonText = "OK";
            ContentDialog.Closed += ContentDialogOnClosed;
            _context = SynchronizationContext.Current;
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            await ContentDialog.ShowAsync();
        }

        private void UIElement_OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Debug.WriteLine("double tapped");

            _context.Post(_ => ContentDialog.Hide(), null);
        }

        private void ContentDialogOnClosed(ContentDialog sender, ContentDialogClosedEventArgs args)
        {
            Debug.WriteLine("closed dialog");
        }

        private void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            Debug.WriteLine("tapped single");
        }
    }
}