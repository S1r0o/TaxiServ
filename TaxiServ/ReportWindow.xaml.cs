using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaxiServ
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
            chart1.Titles.Add("Данные об обращениях");
            chart1.ChartAreas.Add(new ChartArea("Default"));
            chart1.Series.Add(new Series("Тип обращения")
            {
                ChartType = SeriesChartType.Column
            });
            //Присвоение данных заголовкам и осям
            List<String> descrip_Appeal = new List<string>();
            List<int> appeal_Type = new List<int>();
            foreach (Appeal ap in DBEnt.GetContext().Appeal)
            {
                descrip_Appeal.Add(ap.description);
                appeal_Type.Add(Convert.ToInt32(ap.type_problem));
            }
            chart1.Series["Тип обращения"].Points.DataBindXY(descrip_Appeal, appeal_Type);
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word document(*.docx) | *.docx";
            object oMissing = System.Reflection.Missing.Value;
            //Документ
            Microsoft.Office.Interop.Word.Application word_app = new Microsoft.Office.Interop.Word.Application();
            word_app.Visible = true;
            Microsoft.Office.Interop.Word.Document doc = word_app.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            //Заголовки
            Microsoft.Office.Interop.Word.Paragraph par_zag = doc.Content.Paragraphs.Add(ref oMissing);
            par_zag.Range.Text = "Отчёт по обработке обращений";
            par_zag.Range.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorBlack;
            par_zag.Range.Font.Bold = 1;
            par_zag.Range.Font.Size = 14f;
            par_zag.Range.Font.Name = "Times New Roman";
            par_zag.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            par_zag.Range.InsertParagraphAfter();
            //Таблица
            Microsoft.Office.Interop.Word.Paragraph table_par = doc.Content.Paragraphs.Add(ref oMissing);
            Microsoft.Office.Interop.Word.Table table = doc.Content.Tables.Add(table_par.Range, DBEnt.GetContext().Appeal.Count() + 1, 5, ref oMissing, ref oMissing);
            table.Range.Font.Size = 11f;
            table.Range.Font.Bold = 0;
            table.Rows[1].Range.Font.Bold = 1;
            table.Cell(1, 1).Range.Text = "Описание";
            table.Cell(1, 2).Range.Text = "Статус";
            table.Cell(1, 3).Range.Text = "Тип";
            table.Cell(1, 4).Range.Text = "Важность";
            table.Cell(1, 5).Range.Text = "Составитель";
            table.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            table.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            var join_massive = from appeal in DBEnt.GetContext().Appeal
                               join users in DBEnt.GetContext().User on appeal.user equals users.ID
                               select new
                               {
                                   appeal.description,
                                   appeal.status,
                                   appeal.type_problem,
                                   appeal.importance,
                                   users.name
                               };

            //Заполнение таблицы данными из БД
            for (int i = 0; i < DBEnt.GetContext().Appeal.Count(); i++)
            {
                for (int j = 1; j <= table.Columns.Count; j++)
                {
                    switch (j)
                    {
                        case 1:
                            table.Cell(i + 2, j).Range.Text = join_massive.ToList()[i].description;
                            break;
                        case 2:
                            table.Cell(i + 2, j).Range.Text = join_massive.ToList()[i].status;
                            break;
                        case 3:
                            table.Cell(i + 2, j).Range.Text = join_massive.ToList()[i].type_problem.ToString();
                            break;
                        case 4:
                            table.Cell(i + 2, j).Range.Text = join_massive.ToList()[i].importance;
                            break;
                        case 5:
                            table.Cell(i + 2, j).Range.Text = join_massive.ToList()[i].name;
                            break;
                    }
                }
            }
            doc.SaveAs2(saveFileDialog.FileName = "Appeal report", ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        }
    }
}
