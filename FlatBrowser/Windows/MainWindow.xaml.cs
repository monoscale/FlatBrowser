using FlatBrowser.Database;
using FlatBrowser.Models;
using FlatBrowser.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace FlatBrowser {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new MainWindowViewModel(new FolderCategoryRepository(new FlatBrowserDBContext()));
        }

        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e) {
            if (e.NewValue.GetType() == typeof(File)) {
                ((MainWindowViewModel)DataContext).SelectedFile = (File)e.NewValue;
            } else {
                ((MainWindowViewModel)DataContext).SelectedFile = null;
            }

        }
    }
}
