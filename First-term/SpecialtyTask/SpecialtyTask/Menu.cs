using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace SQLTask
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        List<string> Specialties;
        public static List<RuntimeData> RuntimeData;
        public static int DialogSelectedRow;

        Button SoftwareEngineeringButton;
        Button EconomicInformaticsButton;
        Button ECommerceButton;
        Button EcologyButton;

        string SelectedSpecialty_DB;
        int Variant_DB;
        string FilePath_DB;

        string SelectedSpecialty;
        int Variant;
        string PrinterFileName;

        private void Menu_Load(object sender, EventArgs e)
        {
            QueryManager.SetupDB();

            RuntimeData = QueryManager.GetRuntimeData();
            dataGridView1.DataSource = RuntimeData;

            Specialties = new List<string>();

            tableLayoutPanel1.Controls.Add(SoftwareEngineeringButton = new Button()
            {
                Text = "Софтуерно инженерство",
                Width = 150,
                TextAlign = ContentAlignment.MiddleCenter
            });

            tableLayoutPanel1.Controls.Add(EconomicInformaticsButton = new Button()
            {
                Text = "Икономическа информатика",
                Width = 165,
                TextAlign = ContentAlignment.MiddleCenter
            });

            tableLayoutPanel1.Controls.Add(ECommerceButton = new Button()
            {
                Text = "Електронна търговия",
                Width = 125,
                TextAlign = ContentAlignment.MiddleCenter
            });

            tableLayoutPanel1.Controls.Add(EcologyButton = new Button()
            {
                Text = "Екология",
                Width = 100,
                TextAlign = ContentAlignment.MiddleCenter
            });

            SoftwareEngineeringButton.Click += SpecialtyButton_Click;
            EconomicInformaticsButton.Click += SpecialtyButton_Click;
            ECommerceButton.Click += SpecialtyButton_Click;
            EcologyButton.Click += SpecialtyButton_Click;

            foreach (Button button in tableLayoutPanel1.Controls)
            {
                Specialties.Add(button.Text);
            }

            comboBox1.DataSource = Specialties;
            comboBox1.Invalidate();
        }

        private void SpecialtyButton_Click(object sender, EventArgs e)
        {
            SelectedSpecialty = ((Button)sender).Text;
            panel1.Visible = true;
            Variant = 0;
            variantLabel.Text = $"Вариант [?]";
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            QueryManager.StopConnection();
        }

        private void FileSelectButton_Click(object sender, EventArgs e)
        {
            fileSelector = new OpenFileDialog()
            {
                Filter = "Текстови документи (*.txt)|*.txt",
            };
            
            if (fileSelector.ShowDialog() == DialogResult.OK)
            {
                fileSelector.OpenFile();
                textBox1.Text = fileSelector.FileName;
            }
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Изберете специалност.");
                return;
            }

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Изберете файл.");
                return;
            }

            SelectedSpecialty_DB = comboBox1.SelectedItem.ToString();
            Variant_DB = (int)numericUpDown1.Value;
            FilePath_DB = textBox1.Text;

            QueryManager.InsertData(SelectedSpecialty_DB, Variant_DB, FilePath_DB);
            RuntimeData = QueryManager.GetRuntimeData();
            
            dataGridView1.DataSource = RuntimeData;
        }

        private void RandomNumberButton_Click(object sender, EventArgs e)
        {
            string[] possibleVariants = QueryManager.ReadDataAsString($"SELECT DISTINCT Variant FROM Exam_Container WHERE Specialty = N'{SelectedSpecialty}'").Trim().Split(new[] { '|', '\n', '\r' }).Where(x => !String.IsNullOrEmpty(x)).ToArray();

            if (possibleVariants.Any())
            {
                int randomIndex = new Random().Next(0, possibleVariants.Length);
                Variant = int.Parse(possibleVariants[randomIndex]);
                variantLabel.Text = $"Вариант [{Variant}]";
                return;
            }

            MessageBox.Show("Базата данни няма резултати за този предмет или е станала грешка!");
        }

        private void ShowTextButton_Click(object sender, EventArgs e)
        {
            var totalSpecialtyVariantDuplicates = RuntimeData.Where(x => x.Specialty == SelectedSpecialty && x.Variant == Variant)
                                          .Select(x => x.Variant == Variant)
                                          .Count();

            if (totalSpecialtyVariantDuplicates > 1)
            {
                DialogWindow dw = new DialogWindow(RuntimeData, SelectedSpecialty, Variant);
                dw.ShowDialog();

                while (!DialogWindow.HasExited) { Thread.Sleep(50); }

                RuntimeData dataRecordAt = RuntimeData.Where(x => x.Specialty == SelectedSpecialty && x.Variant == Variant)
                                                      .OrderBy(x => x.ID)
                                                      .ElementAt(DialogSelectedRow);

                richTextBox1.Text = File.ReadAllText(dataRecordAt.FileLocation);
                PrinterFileName = dataRecordAt.FileLocation;

                return;
            }

            RuntimeData dataRecordSingle = RuntimeData.FirstOrDefault(x => x.Specialty == SelectedSpecialty && x.Variant == Variant);
            if (dataRecordSingle == null)
                return;

            richTextBox1.Text = File.ReadAllText(dataRecordSingle.FileLocation);
            PrinterFileName = dataRecordSingle.FileLocation;
        }

        private void DropTableButton_Click(object sender, EventArgs e)
        {
            QueryManager.DropTable();
            RuntimeData.Clear();
            dataGridView1.DataSource = null;
        }
    }
}
