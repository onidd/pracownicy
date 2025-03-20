using System.Data;
using System.Windows.Forms.Design;

namespace pracownicy
{
    public partial class Form1 : Form
    {
        public string imie;
        public string nazwisko;
        public string wiek;
        public string stanowisko;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Column1", "Column1");
            dataGridView1.Columns.Add("Column2", "Column2");
            dataGridView1.Columns.Add("Column3", "Column3");
            dataGridView1.Columns.Add("Column4", "Column4");
            Controls.Add(dataGridView1);
        }

        public void adduser() { 
            dataGridView1.Rows.Add(new object[] { imie, nazwisko, wiek, stanowisko } );
        }
        private void button3_Click(object sender, EventArgs e)
        {

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

      
    }
}
