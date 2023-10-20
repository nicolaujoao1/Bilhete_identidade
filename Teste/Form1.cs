namespace Teste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bilhete = new BilheteService();
            bilhete.GetDadosPessoasPorBilhete(textBox1.Text, dataGridView1);
            
        }
    }
}