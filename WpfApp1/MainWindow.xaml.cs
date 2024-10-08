using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private Shape selectedShape;
        private AreaDelegate areaDelegate;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик изменения выбора фигуры
        private void ShapeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedShapeName = ((ComboBoxItem)shapeComboBox.SelectedItem).Content.ToString();

            switch (selectedShapeName)
            {
                case "Круг":
                    param1TextBox.Text = "Введите радиус";
                    param2TextBox.Visibility = Visibility.Hidden;
                    break;
                case "Прямоугольник":
                    param1TextBox.Text = "Введите ширину";
                    param2TextBox.Visibility = Visibility.Visible;
                    param2TextBox.Text = "Введите высоту";
                    break;
                case "Треугольник":
                    param1TextBox.Text = "Введите основание";
                    param2TextBox.Visibility = Visibility.Visible;
                    param2TextBox.Text = "Введите высоту";
                    break;
            }
        }

        // Обработчик нажатия кнопки для вычисления площади
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedShapeName = ((ComboBoxItem)shapeComboBox.SelectedItem).Content.ToString();

            // Получение введенных значений
            double param1 = double.Parse(param1TextBox.Text);
            double param2 = param2TextBox.Visibility == Visibility.Visible ? double.Parse(param2TextBox.Text) : 0;

            // Создаем объект выбранной фигуры и вычисляем площадь
            switch (selectedShapeName)
            {
                case "Круг":
                    selectedShape = new Circle(param1);
                    break;
                case "Прямоугольник":
                    selectedShape = new MyRectangle(param1, param2);
                    break;
                case "Треугольник":
                    selectedShape = new Triangle(param1, param2);
                    break;
            }

            // Привязка делегата
            areaDelegate = new AreaDelegate(selectedShape.CalculateArea);

            // Вызываем делегат и показываем результат
            double area = areaDelegate.Invoke();
            resultTextBlock.Text = $"Площадь: {area}";
        }
    }
}


