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
    public partial class CreateWindow : Window
    {
        ViewWindow viewWindow;
        User user;
        Problem problemForCreate;
        public CreateWindow(Problem problemForCreate, User user, ViewWindow viewWindow)
        {
            InitializeComponent();
            Logo_auth.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("../../Resources/Oe0jPt9jLVU.jpg")));
            //Присвоение данных переменным
            this.viewWindow = viewWindow;
            this.user = user;
            this.problemForCreate = problemForCreate;
            DataContext = problemForCreate;
            //Для вывода в label имени
            ApplicantLabel.Content = problemForCreate.Applicant1.name;
            TimeBox.Text = DateTime.Now.ToString();
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на заполнение всех полей
            StringBuilder errors = new StringBuilder();
            if (TimeBox.Text == null || TimeBox.Text == " ")
                errors.AppendLine("Укажите время");
            if (DescriptionBox.Text == null || DescriptionBox.Text == " ")
                errors.AppendLine("Укажите описание");
            if (StatusBox.Text == null || StatusBox.Text == " ")
                errors.AppendLine("Укажите статус обращения");
            if (ImpBox.Text == null || ImpBox.Text == " ")
                errors.AppendLine("Укажите важность обращения");
            if (TypeBox.Text == null || TypeBox.Text == " ")
                errors.AppendLine("Укажите тип проблемы:цифру от 1 до 5. 1 - Программная, 2 - Жалоба на водителя," +
                    " 3 - Жалоба на СП, 4 - Ложное обращение, 5 - Критическая ситуация");
            if (errors.Length > 0)
            {
                //Вывод ошибки
                MessageBox.Show(errors.ToString());
                return;
            }
            //Присвоение введённых данных к записи в бд
            try
            {
                DBEnt.GetContext().Appeal.Add(new Appeal()
                {
                    importance = ImpBox.Text,
                    status = StatusBox.Text,
                    description = DescriptionBox.Text,
                    time = TimeBox.Text,
                    type_problem = Int32.Parse(TypeBox.Text),
                    user = user.ID,
                    applicant = problemForCreate.applicant
                });

                //Сохранение изменений, удаление проблемы из бд и переход в окно вывода данных
                DBEnt.GetContext().Problem.Remove(problemForCreate);
                DBEnt.GetContext().SaveChanges();
                viewWindow.UpdateData();
                ((ProblemViewWindow)this.Owner).Close();
                MessageBox.Show("Обращение создано");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Укажите тип проблемы:цифру от 1 до 5. 1 - Программная, 2 - Жалоба на водителя," +
                    " 3 - Жалоба на СП, 4 - Ложное обращение, 5 - Критическая ситуация", "Неверно указан тип проблемы");
            }
            
           

        }
    }
}
