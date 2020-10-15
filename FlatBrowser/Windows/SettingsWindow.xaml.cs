using FlatBrowser.Database;
using FlatBrowser.ViewModels;
using System.Windows;

namespace FlatBrowser.Windows {
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window {
        public SettingsWindow(IFolderCategoryRepository folderCategoryRepository) {
            InitializeComponent();
            DataContext = new SettingsWindowViewModel(folderCategoryRepository);
        }
    }
}
