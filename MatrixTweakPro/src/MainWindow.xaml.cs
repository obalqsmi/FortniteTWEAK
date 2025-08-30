using System.Windows;

namespace MatrixTweakPro
{
    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Preview_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Preview not implemented", "Matrix Tweak Pro");
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Apply not implemented", "Matrix Tweak Pro");
        }

        private void Revert_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Revert not implemented", "Matrix Tweak Pro");
        }
    }
}
