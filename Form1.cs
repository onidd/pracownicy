using System.Data;
using System.Numerics;
using System.Windows.Forms.Design;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace pracownicy
{
    public partial class Form1 : Form
    {
        private int currentID = 1;
        public string imie;
        public string nazwisko;
        public int wiek;
        public string stanowisko;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Imiê", "Imiê");
            dataGridView1.Columns.Add("Nazwisko", "Nazwisko");
            dataGridView1.Columns.Add("Wiek", "Wiek");
            dataGridView1.Columns.Add("Stanowisko", "Stanowisko");
            dataGridView1.ReadOnly = true;
            Controls.Add(dataGridView1);
        }
        public void adduser()
        {
            dataGridView1.Rows.Add(new object[] { currentID, imie, nazwisko, wiek, stanowisko });
            currentID++;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            savetocsv();
        }

        private void savetocsv()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    DefaultExt = "csv",
                    FileName = "pracownicy.csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        var columnNames = dataGridView1.Columns.Cast<DataGridViewColumn>()
                                            .Select(column => column.HeaderText)
                                            .ToArray();
                        writer.WriteLine(string.Join(",", columnNames));
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                var cellValues = row.Cells.Cast<DataGridViewCell>()
                                                       .Select(cell => cell.Value.ToString())
                                                       .ToArray();
                                writer.WriteLine(string.Join(",", cellValues));
                            }
                        }
                    }
                    MessageBox.Show("Dane zosta³y zapisane.", "Zapisano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d: " + ex.Message, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newform = new Form2(this);
            newform.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            removeUser();
        }

        private void removeUser()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Wybierz wiersz do usuniêcia!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            readfromcsv();
        }

        private void readfromcsv()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    DefaultExt = "csv"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        string line;
                        bool firstLine = true;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (firstLine)
                            {
                                firstLine = false;
                                continue;
                            }
                            var values = line.Split(',');
                            dataGridView1.Rows.Add(values);
                        }
                    }

                    MessageBox.Show("Dane zosta³y za³adowane.", "Wczytano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d: " + ex.Message, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveToJson();
        }

        private void SaveToJson()
        {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "JSON files (*.json)|*.json",
                    DefaultExt = "json",
                    FileName = "pracownicy.json"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var employees = new List<Employee>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        employees.Add(new Employee
                        {
                            Id = Convert.ToInt32(row.Cells["ID"].Value),
                            Name = row.Cells["Imiê"].Value.ToString(),
                            Surname = row.Cells["Nazwisko"].Value.ToString(),
                            Wiek = Convert.ToInt32(row.Cells["Wiek"].Value),
                            Position = row.Cells["Stanowisko"].Value.ToString()
                        });
                    }
                }
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string json = JsonSerializer.Serialize(employees, options); 
                    File.WriteAllText(saveFileDialog.FileName, json);
                   //MessageBox.Show("Dane Zosta³y Zapisane", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }


        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Wiek { get; set; }
            public string Position { get; set; }
        }
    }
}
