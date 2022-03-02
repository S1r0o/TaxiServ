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

namespace TaxiServ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Путь к логу
            Logo_auth.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("../../Resources/Oe0jPt9jLVU.jpg")));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Авторизация
            if (!String.IsNullOrEmpty(LoginBox.Text))
            {
                if (!String.IsNullOrEmpty(PasswordBox.Password))
                {
                    IQueryable<User> login_list = DBEnt.GetContext().User.Where(p => p.login == LoginBox.Text && p.password == PasswordBox.Password);
                    if (login_list.Count() == 1)
                    {
                        //Успешная авторизация
                        MessageBox.Show("Приветствую," + login_list.First().name);
                        ViewWindow window = new ViewWindow(login_list.First(), this);
                        //Переход к основной форме
                        window.Owner = this;
                        window.Show();
                        this.Hide();
                    }
                }
                //Окно при неверных данных
                else MessageBox.Show("Incorrect login or password", "Exception");
                {
                    this.LoginBox.Text = "";
                    this.PasswordBox.Password = "";
                }
            }
        }
    } 
}
