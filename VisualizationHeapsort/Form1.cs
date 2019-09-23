using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace VisualizationHeapsort
{
    public partial class Form1 : Form
    {
        List<Line> lines = new List<Line>();
        int count;

        public Form1()
        {
            InitializeComponent();            
            HeapSort.Draw += Draw;
        }

        void Draw(List<Line> lines, Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Blue);
            pen.Width = 2;
            for (int i = 0; i < lines.Count; ++i)
                g.DrawLine(pen, lines[i].Position, 55, lines[i].Vertex.X, lines[i].Vertex.Y);
            pictureBox1.Image = bmp;
        }

        private void Sort_Click(object sender, EventArgs e)
        {
            if (lines.Count != 0)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                for (int i = lines.Count / 2 - 1; i >= 0; i--)
                    HeapSort.Heapsort(lines, lines.Count, i);
                count = lines.Count - 1;
                Draw(lines, bmp);
                timer1.Enabled = true;
            }
            else
                MessageBox.Show("Створіть лінії для візуалізації сортування!");
        }

        private void Random_Click(object sender, EventArgs e)
        {
            int numberSegments;
            string errorMessage = "Введіть число від 2 до 60 включно!";
            try { numberSegments = int.Parse(textBox1.Text); }
            catch
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (numberSegments <= 60 && numberSegments >= 2)
            {
                textBox2.Text = "";
                Random rnd = new Random();
                for (int i = 0; i < numberSegments; i++)
                    textBox2.Text += rnd.Next(0, 180) + " ";
            }
            else
                MessageBox.Show(errorMessage);
        }

        private void Create_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            lines.Clear();
            string errorMessage = "Введіть не мнше двох чисел в діапазоні від 0 до 180 включно!";
            int[] angle;
            try
            {
                angle = textBox2.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();
            }
            catch
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (angle.Length >= 2)
            {
                for (int i = 0; i < angle.Length; ++i)
                    lines.Add(new Line(50 + i * 10, angle[i]));
                Draw(lines, bmp);
            }
            else
                MessageBox.Show(errorMessage);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            if (count >= 0)
            {
                HeapSort.Sort(lines, count, bmp);
                --count;
            }
            else
            {
                timer1.Enabled = false;
                MessageBox.Show("Готово");
            }
        }
    }
}