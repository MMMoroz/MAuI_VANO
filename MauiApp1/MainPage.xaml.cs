namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        double x = 0;
        char operation = ' ';
        double y = 0;

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (double.TryParse(button.Text, out double chifkif))
            {
                if (Vvod.Text == "0")
                {
                    Vvod.Text = button.Text;
                }
                else
                {
                    Vvod.Text += button.Text;
                }
            }
        }

        private void ClickResult(object sender, EventArgs e)
        {
            if (double.TryParse(Vvod.Text, out y)) 
            {
                double result = 0;
                switch (operation)
                {
                    case '+':
                        result = x + y;
                        break;
                    case '-':
                        result = x - y;
                        break;
                    case '*':
                        result = x * y;
                        break;
                    case '/':
                        if (y != 0)
                        {
                            result = x / y; 
                        }
                        else
                        {
                            Vvod.Text = "Ошибка"; 
                            return;
                        }
                        break;
                    default:
                        return; 
                }
                Vvod.Text = result.ToString();
                ClearValues(); 
            }
        }

        private void Button_Clicked_CE(object sender, EventArgs e)
        {
            Vvod.Text = "0";
        }

        private void Button_Clicked_Del(object sender, EventArgs e)
        {
            if (Vvod.Text.Length > 1)
            {
                Vvod.Text = Vvod.Text.Substring(0, Vvod.Text.Length - 1); 
            }
            else
            {
                Vvod.Text = "0"; 
            }
        }


        private void Button_Clicked_C(object sender, EventArgs e)
        {
            
            ClearValues();
            Vvod.Text = "0";
        }

        private void Button_Clicked_Symbols(object sender, EventArgs e)
        {
            Button button = sender as Button;
            operation = button.Text[0];
            if (double.TryParse(Vvod.Text, out x)) 
            {
                History.Text = Vvod.Text + " " + operation;
                Vvod.Text = "0"; 
            }
        }

        private void Button_Percent_Clicked(object sender, EventArgs e)
        {
            if (double.TryParse(Vvod.Text, out x))
            {
                double result = x * 0.01; // Вычисляем процент
                Vvod.Text = result.ToString(); // Выводим результат в поле ввода
            }
        }


        private void Button_Coren_Clicked(object sender, EventArgs e)
        {
            if (double.TryParse(Vvod.Text, out x)) // Пробуем преобразовать текст в double
            {
                if (x >= 0) // Проверяем, что число неотрицательно
                {
                    double result = Math.Sqrt(x); // Вычисляем квадратный корень
                    Vvod.Text = result.ToString();
                    History.Text = x.ToString();
                }
                else
                {
                    Vvod.Text = "Ошибка"; // Если число отрицательное, показываем ошибку
                }
            }
        }

        private void ClearValues()
        {
            x = 0;
            y = 0;
            operation = ' ';
        }

        
    }
}