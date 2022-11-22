using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadacha2
{
    public partial class Task : Form
    {
        public Task()
        {
            InitializeComponent();
        }
        private void Click1(object sender, EventArgs e)
        {
            time.Text = " ";
            timemin.Text = " ";
            string path = @"D:\Projects\zadacha2\hod.txt";
            decimal a, b, c, d, f, t = 3600;
            if (Convert.ToDecimal(distance.Text) == 0 | Convert.ToDecimal(speed.Text) == 0)
            {
                time.Text = "Ошибка!";
                timemin.Text = "Ошибка!";
                using (FileStream file = new FileStream(path, FileMode.Append))
                using (StreamWriter stream = new StreamWriter(file))
                    stream.WriteLine($"{distance.Text} км : {speed.Text} км/ч = Ошибка!");
                return;
            }
            else
                a = Convert.ToDecimal(distance.Text) * 1000;
                b = Convert.ToDecimal(speed.Text) * 5;
                f = a * 18 / b / t;
                c = (decimal)Math.Floor(a * 18 / b / t);
                d = f - c;
                d = (decimal)Math.Round(d * 60);
                time.Text = Convert.ToString(c);
                timemin.Text = Convert.ToString(d);
                using (FileStream file = new FileStream(path, FileMode.Append))
                    using (StreamWriter stream = new StreamWriter(file))
                {
                    if (c < 1)
                        stream.WriteLine($"{distance.Text} км : {speed.Text} км/ч = {time.Text} часов и {timemin.Text} минут");
                    else if (c == 1)
                        stream.WriteLine($"{distance.Text} км : {speed.Text} км/ч = {time.Text} час и {timemin.Text} минут");
                    else if (c > 5)
                        stream.WriteLine($"{distance.Text} км : {speed.Text} км/ч = {time.Text} часов и {timemin.Text} минут");
                    else
                        stream.WriteLine($"{distance.Text} км : {speed.Text} км/ч = {time.Text} часа и {timemin.Text} минут");
                return;
            }

        }
        private void Clickauth(object sender, EventArgs e)
        {
            MessageBox.Show("Студент Дианов Никита,\nгруппа ИСП-320А.", "Автор", MessageBoxButtons.OK);         
        }

        private void clickwhy(object sender, EventArgs e)
        {
            MessageBox.Show("Нужно заполнить поля скорости и расстояния,\nдалее нажать на кнопку рассчитать и\nвам выведеться результат.\nОставлять путые поля нельзя, если пишите десятичные,\nписать нужно  через запятую!", "Как работать", MessageBoxButtons.OK);
        }
    }
}
