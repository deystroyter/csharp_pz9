using System;
using System.Drawing;
using System.Threading;

namespace FedorovAD_Pz9
{
    class Circle
    {
        Graphics gr;
        Random rnd = new Random();
        int time;
        int x;
        int y;
        Pen pen, penW;
        int r = 0;
        /// <summary>
        /// Конструктор класса Окружность
        /// </summary>
        /// <param name="t">Время жизни</param>
        /// <param name="gr">Поле для рисования</param>
        /// <param name="maxX">Координата максимальной ширины центра</param>
        /// <param name="maxY">Координата максимольной высоты центра</param>
        public Circle(int t, Graphics gr, int maxX, int maxY)
        {
            this.time = t * 100;
            this.gr = gr;
            x = rnd.Next(20, maxX - 20);
            y = rnd.Next(20, maxY - 20);
            pen = new Pen(Color.FromArgb(255, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)), 1);
            penW = new Pen(Color.White, 1);
        }
        /// <summary>
        /// Отрисовка окружности
        /// </summary>
        public void Run()
        {
            Thread.Sleep(rnd.Next(20) * 100);
            for (int i = 0; i < time; i++)
            {
                gr.DrawEllipse(penW, x - r / 2, y - r / 2, r, r);
                r += 1;
                gr.DrawEllipse(pen, x - r / 2, y - r / 2, r, r);
                Thread.Sleep(30);
            }
            gr.DrawEllipse(penW, x - r / 2, y - r / 2, r, r);
            Interlocked.Decrement(ref MainForm.counter);
        }

    }
}
