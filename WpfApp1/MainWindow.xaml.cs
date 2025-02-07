// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // ボタンクリック時の処理
            string bucketName = "your-bucket-name"; // バケット名を指定
            string prefix = "your-folder/"; // フォルダを指定 (省略可)

            await SampleAWSS3.ListFilesAsync(bucketName, prefix);
        }

        private void WatermarkTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
