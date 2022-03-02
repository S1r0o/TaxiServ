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
using System.Windows.Shapes;

namespace TaxiServ
{
    public partial class ProblemViewWindow : Window
    {
        //Хранение главного окна
        ViewWindow viewWindow;
        //хранение пользователя
        User user;
        //хранение проблемы
        Problem problemForCreate;
        public ProblemViewWindow(Problem problemsListForView, User user, ViewWindow viewWindow)
        {
            InitializeComponent();
            Logo_auth.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("../../Resources/Oe0jPt9jLVU.jpg")));
            this.viewWindow = viewWindow;
            this.user = user;
            DataContext = problemsListForView;
            problemForCreate = problemsListForView;
            Applicant.ItemsSource = DBEnt.GetContext().Applicant.ToList();
        }
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            //Обработка неверного заполнения полей
            StringBuilder errors = new StringBuilder();
            if (TimeBox.Text == null || TimeBox.Text == " ")
                errors.AppendLine("Укажите время");
            if (DescriptionBox.Text == null || DescriptionBox.Text == " ")
                errors.AppendLine("Укажите описание");
            if (TitleBox.Text == null || TitleBox.Text == " ")
                errors.AppendLine("Укажите заголовок проблемы");
            if (VersionBox.Text == null || VersionBox.Text == " ")
                errors.AppendLine("Укажите версию приложения либо поставьте '-'");
            if (DeviceBox.Text == null || DeviceBox.Text == " ")
                errors.AppendLine("Укажите версию устройства");
            if (Applicant.SelectedItem == null)
                errors.AppendLine("Укажите заявителя");
            if (errors.Length > 0)
            {
                //Вывод ошибки
                MessageBox.Show(errors.ToString());
                return;

            }
            else
            {
                //Сохранение изменений
                DBEnt.GetContext().SaveChanges();
                ((ViewWindow)this.Owner).UpdateData();
                this.Close();
            }
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow createWindow = new CreateWindow(problemForCreate, user, viewWindow);
            createWindow.Owner = this;
            createWindow.Show();
        }
    }
}
