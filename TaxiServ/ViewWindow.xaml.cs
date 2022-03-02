using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace TaxiServ
{
    /// <summary>
    /// Логика взаимодействия для ViewWindow.xaml
    /// </summary>
    public partial class ViewWindow : Window
    {
        //Переменная для хранения пользователя
        User user;
        //Переменная для связи с окном авторизации 
        public MainWindow window;
        //Объявление перемемнной problemList для работы с элементом Листбокс
        IEnumerable<Problem> problemList;

        public ViewWindow(User user, MainWindow window)
        {
            InitializeComponent();
            Logo_auth.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("../../Resources/Oe0jPt9jLVU.jpg")));
            this.user = user;
            //Получение имени пользователя
            UserNameLabel.Content = user.name;
            //Выбор таблицы из БД для вывода
            DataContext = DBEnt.GetContext().Problem.ToList();
            //Вывод данных
            UpdateData();
        }
        //Метод для обновления элемента Листбокс и всех элементов внутри
        public void UpdateData()
        {
            //Выбор таблицы для фильтрации
            problemList = DBEnt.GetContext().Problem.ToList();
            //Поиск
            //Возвращение записей из бд согласно заданому условию
            problemList = problemList.Where(p => p.title_problem.Contains(SearchBox.Text) || p.description.Contains(SearchBox.Text)).ToList();
            //Отображение результата поиска
            listBox.ItemsSource = problemList;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Кнопка просмотра

            //Костыльное извлечение айдишника
            int id = (int)TypeDescriptor.GetProperties(listBox.SelectedItem)[1].GetValue(listBox.SelectedItem);
            Problem problemsListForView = DBEnt.GetContext().Problem.Where(p => p.ID == id).First();
            //Переход в окно просмотра
            ProblemViewWindow problemViewWindow = new ProblemViewWindow(problemsListForView, user, this);
            problemViewWindow.Owner = this;
            problemViewWindow.Show();
        }
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           //При выборе записи кнопка просмотра становиться активной
            ViewButton.IsEnabled = true;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Обновление элемента листбокс после ввода данных в строку поиска
            UpdateData();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //При закрытии открывается авторизация
            this.Owner.Show();
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            //Кнопка перехода в окно формирования отчёта
            ReportWindow reportWindow = new ReportWindow();
            reportWindow.Owner = this;
            reportWindow.Show();
        }
    }
}
