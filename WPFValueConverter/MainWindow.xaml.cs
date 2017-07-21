using System.Windows;

namespace WPFValueConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// A static property for using ValueConverter
        /// </summary>
        public static ValueConverter<string> inputConverter =
                    new ValueConverter<string>(
                        inputText1 => inputText1 + inputText1
                        );

        /// <summary>
        /// A static property for using MultiValueConverter
        /// </summary>
        public static MultiValueConverter<string, string> StringStringConverter =
            new MultiValueConverter<string, string>(
                (inputText1, inputText2) =>
                {
                    string input12 = string.Empty;
                    if (!string.IsNullOrEmpty(inputText1))
                    {
                        input12 += inputText1;
                    }

                    if (!string.IsNullOrEmpty(inputText2))
                    {
                        input12 += inputText2;
                    }

                    return string.IsNullOrEmpty(inputText2) ? "No input" : input12 + " MultiValueConverter is cool!";
                });

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}