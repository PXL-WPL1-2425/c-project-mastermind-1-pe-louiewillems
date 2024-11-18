using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Mastermind
{
    public partial class MainWindow : Window
    {

        private int attempts = 0;
        private bool isCorrect = false;

        private List<(string name, SolidColorBrush color)> selectedColors = new List<(string name, SolidColorBrush color)> ();
        private readonly List<(string name, SolidColorBrush color)> _colorOptions = new List<(string, SolidColorBrush)>()
        {
            ("Red", Brushes.Red),
            ("Orange", Brushes.Orange),
            ("Yellow", Brushes.Yellow),
            ("White", Brushes.White),
            ("Green", Brushes.Green),
            ("Blue", Brushes.Blue)
        };
        private readonly List<Label> _labels = new List<Label>();
        private readonly List<ComboBox> _comboBoxes = new List<ComboBox>();

        public MainWindow()
        {
            InitializeComponent();
            InitGame();
        }

        private void InitGame()
        {
            attempts = 0;
            mainWindow.Title = "Mastermind";
            selectedColors = GenerateRandomColorCodes();
            _comboBoxes.AddRange(new List<ComboBox>() { chooseCombobox1, chooseCombobox2, chooseCombobox3, chooseCombobox4 });
            _labels.AddRange(new List<Label>() { chooseLabel1, chooseLabel2, chooseLabel3, chooseLabel4 });

            for (int i = 0; i < _comboBoxes.Count(); i++)
            {
                for (int j = 0; j < _colorOptions.Count; j++)
                {
                    _comboBoxes[i].Items.Add(_colorOptions[j].name);
                }

                _comboBoxes[i].SelectionChanged += OnDropdownSelection;
            }

        }

        private void validateButton_Click(object sender, RoutedEventArgs e)
        {
            ClearGame(onlyLabels: true);

            if (isCorrect)
            {
                //generate new game
                selectedColors = GenerateRandomColorCodes();
                attempts = 0;
            }


            if (selectedColors.Any() && selectedColors.Count == 4)
            {
                string selectedColorString = string.Join(',', selectedColors.Select(x => x.name));

                ControlColors(selectedColors.Select(x => x.name).ToArray());

                //mainWindow.Title = $"Mastermind ({selectedColorString})";

                if (!isCorrect)
                {
                    attempts++;
                    mainWindow.Title = $"Poging {attempts}";
                }
                else
                {
                    //mainWindow.Title = $"Correct";
                }
            }
        }

        private List<(string name, SolidColorBrush color)> GenerateRandomColorCodes()
        {
            List<(string, SolidColorBrush)> selectedOptions = new List<(string, SolidColorBrush)>();

            var rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                if (_colorOptions.ElementAt(rand.Next(0, _colorOptions.Count()))
                    is (string, SolidColorBrush) keyPair)
                {
                    selectedOptions.Add(keyPair);
                }
            }
            return selectedOptions;
        }

        private void OnDropdownSelection(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (_labels.FirstOrDefault(x => x.Name.EndsWith(comboBox.Name.Last())) is Label foundLabel)
                {
                    if (_colorOptions.FirstOrDefault(x => x.name == comboBox.SelectedValue.ToString())
                            is (string name, SolidColorBrush color) foundColor)
                    {
                        foundLabel.Background = foundColor.color;
                        foundLabel.BorderThickness = new Thickness(0.3);
                        foundLabel.BorderBrush = Brushes.Gray;
                    }
                }
            }

        }

        private void ControlColors(string[] correctColors)
        {
            if (_comboBoxes.Any(x => x.SelectedValue == null))
            {
                MessageBox.Show("Some values are not selected", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int boxIndex = 0;
            int correctCount = 0;
            _comboBoxes.ForEach(box =>
            {
                if (box.SelectedValue is string value &&
                    _labels.FirstOrDefault(x => x.Name.EndsWith(box.Name.Last())) is Label foundLabel)
                {
                    if (correctColors.Contains(box.SelectedValue.ToString()))
                    {
                        foundLabel.BorderThickness = new Thickness(3);
                        foundLabel.BorderBrush = Brushes.Wheat;
                        if (value.Equals(correctColors[boxIndex]))
                        {
                            foundLabel.BorderBrush = Brushes.DarkRed;
                            correctCount++;
                        }
                    }
                }
                boxIndex++;
            });

            if (correctCount == _comboBoxes.Count)
            {
                isCorrect = true;
            }

        }
        private void ClearGame(bool onlyLabels = false)
        {
            //clear labels
            _labels.ForEach(label =>
            {
                label.BorderThickness = new Thickness(0.3);
                label.BorderBrush = Brushes.Gray;

                if (!onlyLabels)
                {
                    label.BorderThickness = new Thickness(0);
                    label.BorderBrush = null;
                    label.Background = null;
                }
            });

            //clear boxes
            if (!onlyLabels)
            {
                _comboBoxes.ForEach(box =>
                {
                    box.SelectedValue = null;
                });
            }

            mainWindow.Title = "Mastermind";
        }

    }
}