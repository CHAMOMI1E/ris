using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        TcpClient tcp_client = new TcpClient("localhost", 5555);
        Encoding utf8 = new UTF8Encoding();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void Perform_Click(object sender, EventArgs e)
        {
            if (radioView.Checked == true)
            {
                NetworkStream ns = tcp_client.GetStream();
                String command = "view";
                String res = command + "|";
                byte[] sent = utf8.GetBytes(res);
                // Отправляем запрос на сервер
                await ns.WriteAsync(sent, 0, sent.Length);

                byte[] received = new byte[256];
                int bytesRead = await ns.ReadAsync(received, 0, received.Length);

                // Проверяем, что получены данные
                if (bytesRead > 0)
                {
                    //richTextBox1.Text.Remove(0);
                    // Отображаем полученный результат в клиентском RichTextBox
                    richTextBox1.Text = utf8.GetString(received, 0, bytesRead);
                    String status = "=>Command sent:view data";
                    // Отображаем служебную информацию в клиентском ListBox
                    listBox1.Items.Add(status);
                }
            }
            if (radioAdd.Checked == true)
            {
                NetworkStream ns = tcp_client.GetStream();
                string command = "add";
                string name = textBoxName.Text;
                int quantity = int.Parse(textBoxQuantity.Text);
                double price = double.Parse(textBoxPrice.Text.Replace('.', ','));
                string addCommand = $"{command}|{name}|{quantity}|{price}";

                byte[] sent = utf8.GetBytes(addCommand);
                // Отправляем запрос на сервер
                await ns.WriteAsync(sent, 0, sent.Length);

                byte[] received = new byte[256];
                int bytesRead = await ns.ReadAsync(received, 0, received.Length);

                // Проверяем, что получены данные
                if (bytesRead > 0)
                {
                    // Отображаем полученный результат в клиентском RichTextBox
                    listBox1.Items.Add(utf8.GetString(received, 0, bytesRead));
                }
            }
            if (radioDelete.Checked == true)
            {
                NetworkStream ns = tcp_client.GetStream();
                string command = "delete";
                string name = textBoxName.Text;
                string addCommand = $"{command}|{name}";

                byte[] sent = utf8.GetBytes(addCommand);
                // Отправляем запрос на сервер
                await ns.WriteAsync(sent, 0, sent.Length);

                byte[] received = new byte[256];
                int bytesRead = await ns.ReadAsync(received, 0, received.Length);

                // Проверяем, что получены данные
                if (bytesRead > 0)
                {
                    listBox1.Items.Add(utf8.GetString(received, 0, bytesRead));
                }
            }
            if (radioEdit.Checked == true)
            {
                NetworkStream ns = tcp_client.GetStream();
                string command = "edit";
                string name = textBoxName.Text;
                int quantity = int.Parse(textBoxQuantity.Text);
                double price = double.Parse(textBoxPrice.Text.Replace('.', ','));
                string addCommand = $"{command}|{name}|{quantity}|{price}";

                byte[] sent = utf8.GetBytes(addCommand);
                // Отправляем запрос на сервер
                await ns.WriteAsync(sent, 0, sent.Length);

                byte[] received = new byte[256];
                int bytesRead = await ns.ReadAsync(received, 0, received.Length);

                // Проверяем, что получены данные
                if (bytesRead > 0)
                {
                    // Отображаем полученный результат в клиентском RichTextBox
                    listBox1.Items.Add(utf8.GetString(received, 0, bytesRead));
                }
            }
        }

        private void radioAdd_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}