using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace FedorovAD_Pz9
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        int time;
        public static int cnt;
        public static int counter = 0;
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Генерация потоков для отрисовки кругов
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {

            if (counter < cnt)
            {
                counter++;
                Thread t = new Thread(new ThreadStart(new Circle(time, drawArea.CreateGraphics(), drawArea.Width, drawArea.Height).Run));
                t.Start();
            }
        }
        /// <summary>
        /// Обработчик кнопки Начать
        /// </summary>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            cnt = (int)numericUpDown1.Value;
            time = (int)numericUpDown2.Value;
            timer.Start();
            timer.Interval = 200;
            timer.Tick += new EventHandler(timer_Tick);
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;

            
        }
        /// <summary>
        /// Обработчик кнопки Стоп
        /// </summary>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
        }
    }
}
