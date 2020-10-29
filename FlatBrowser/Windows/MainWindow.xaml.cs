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
            if (e.NewValue.GetType() == typeof(FileViewModel)) {
                ((MainWindowViewModel)DataContext).SelectedFilePath = ((FileViewModel) e.NewValue).FullName;
            } else {
                ((MainWindowViewModel)DataContext).SelectedFilePath = string.Empty;
            }

        }
    }
}
