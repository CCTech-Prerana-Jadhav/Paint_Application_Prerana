using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint
{
    public partial class MainWindow : Window
    {
        private Point currentPoint;
        private double brushSize = 4; // Default brush size
        private Brush brushColor = Brushes.Black; // Default brush color
        private string drawingMode = "Free Style"; // Default drawing mode

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Paint_Window.Children.Clear();
        }

        private void Select_Brush_Size_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Select_Brush_Size.SelectedItem is ComboBoxItem selectedItem)
            {
                if (double.TryParse(selectedItem.Content.ToString(), out double size))
                {
                    brushSize = size; // Set the selected brush size
                }
            }
        }

        private void Select_Brush_Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Select_Brush_Color.SelectedItem is ComboBoxItem selectedItem)
            {
                // Set the brush color based on selection
                switch (selectedItem.Content.ToString())
                {
                    case "Red":
                        brushColor = Brushes.Red;
                        break;
                    case "Blue":
                        brushColor = Brushes.Blue;
                        break;
                    case "Green":
                        brushColor = Brushes.Green;
                        break;
                    case "Black":
                        brushColor = Brushes.Black;
                        break;
                }
            }
        }

        private void Select_Mode_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Select_Mode.SelectedItem is ComboBoxItem selectedItem)
            {
                drawingMode = selectedItem.Content.ToString(); // Set the drawing mode (Free Style or Straight Line)
            }
        }

        private void Canvas_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(Paint_Window);
        }

        private void Canvas_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (drawingMode == "Free Style")
                {
                    // Draw free style line
                    Line line = new Line
                    {
                        Stroke = brushColor,
                        StrokeThickness = brushSize,
                        X1 = currentPoint.X,
                        Y1 = currentPoint.Y,
                        X2 = e.GetPosition(Paint_Window).X,
                        Y2 = e.GetPosition(Paint_Window).Y
                    };

                    currentPoint = e.GetPosition(Paint_Window);

                    Paint_Window.Children.Add(line);
                }
                else if (drawingMode == "Straight Line")
                {
                    // Draw straight line (drawing from the starting point to the current point)
                    Line line = new Line
                    {
                        Stroke = brushColor,
                        StrokeThickness = brushSize,
                        X1 = currentPoint.X,
                        Y1 = currentPoint.Y,
                        X2 = e.GetPosition(Paint_Window).X,
                        Y2 = e.GetPosition(Paint_Window).Y
                    };
                    Paint_Window.Children.Clear();
                    Paint_Window.Children.Add(line); // Add the new straight line
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Select_Brush_Color_TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }
    }
}
