using FlatBrowser.Database;
using FlatBrowser.Models;
using System.Windows;

namespace FlatBrowser {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            using FlatBrowserDBContext dbContext = new FlatBrowserDBContext();
            DataContext = new MainWindowViewModel(new FolderCategoryRepository(dbContext));
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
