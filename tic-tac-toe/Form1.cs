using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        private int Player;
        private Button[] buttons; // Массив кнопок для удобства

        public Form1()
        {
            InitializeComponent();
            Create_Main_menu();
            Return_btn();
            Appearance();

            
            Player = 1;

            

            // Инициализируем массив кнопок
            buttons = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9,button10 };

            foreach (Button btn in buttons)
            {
                btn.Visible = false;
                
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button clickedBtn = sender as Button;

            if (clickedBtn != null)
            {
                // Определяем символ текущего игрока
                string symbol = (Player == 1) ? "X" : "O";
                clickedBtn.Text = symbol;

                // Меняем текст метки для следующего игрока
                label1.Text = $"Играют {(Player == 1 ? "O" : "X")}";

                // Меняем текущего игрока
                Player = 1 - Player; // краткая запись для переключения между 0 и 1

                clickedBtn.Enabled = false; // Блокируем кнопку

                winr(); // Проверяем на победу или ничью
            }
        }

        private void winr()
        {
            // Проверяем выигрышные комбинации с помощью if
            string winner = CheckForWinner();

            if (winner != null)
            {
                MessageBox.Show($"Победил {winner}!", "Конец игры");
                //блокируем кнопки
                foreach (Button btn in buttons.Take(9))
                {
                    btn.Enabled = false;
                }
                return;
            }

            // Проверяем на ничью
            else if (CheckForDraw())
            {
                MessageBox.Show("Ничья!", "Конец игры");
                //блокируем кнопки
                foreach (Button btn in buttons.Take(9))
                {
                    btn.Enabled = false;
                }
            }
        }

        private string CheckForWinner()
        {
            // Проверяем все возможные выигрышные комбинации с помощью if
            string winner = null;

            // Горизонтальные линии
            if (buttons[0].Text == buttons[1].Text && buttons[1].Text == buttons[2].Text && !string.IsNullOrEmpty(buttons[0].Text))
            {
                winner = buttons[0].Text;
            }
            if (buttons[3].Text == buttons[4].Text && buttons[4].Text == buttons[5].Text && !string.IsNullOrEmpty(buttons[3].Text))
            {
                winner = buttons[3].Text;
            }
            if (buttons[6].Text == buttons[7].Text && buttons[7].Text == buttons[8].Text && !string.IsNullOrEmpty(buttons[6].Text))
            {
                winner = buttons[6].Text;
            }

            // Вертикальные линии
            if (buttons[0].Text == buttons[3].Text && buttons[3].Text == buttons[6].Text && !string.IsNullOrEmpty(buttons[0].Text))
            {
                winner = buttons[0].Text;
            }
            if (buttons[1].Text == buttons[4].Text && buttons[4].Text == buttons[7].Text && !string.IsNullOrEmpty(buttons[1].Text))
            {
                winner = buttons[1].Text;
            }
            if (buttons[2].Text == buttons[5].Text && buttons[5].Text == buttons[8].Text && !string.IsNullOrEmpty(buttons[2].Text))
            {
                winner = buttons[2].Text;
            }

            // Диагонали
            if (buttons[0].Text == buttons[4].Text && buttons[4].Text == buttons[8].Text && !string.IsNullOrEmpty(buttons[0].Text))
            {
                winner = buttons[0].Text;
            }
            if (buttons[2].Text == buttons[4].Text && buttons[4].Text == buttons[6].Text && !string.IsNullOrEmpty(buttons[2].Text))
            {
                winner = buttons[2].Text;
            }

            return winner;
        }

        private bool CheckForDraw()
        {
          //проверка для ничьи
            return buttons.All(btn => !string.IsNullOrWhiteSpace(btn.Text));
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Сбрасываем состояние игры
            Player = 1; // Устанавливаем первого игрока (X)
            label1.Text = "Играют X"; // Обновляем текст метки

            // Очищаем текст всех кнопок и включаем их
            foreach (Button btn in buttons.Take(9))
            {
                btn.Text = ""; // Очищаем текст кнопки
                btn.Enabled = true; // Включаем кнопку
               
            }
        }
        //переменные с главным меню
        private Label label2;
        private Button Start;
        private Button Option;
        private Button Exit;

        private void Create_Main_menu()
        {
            //создание название
            label2 = new Label();
            //настройка
            label2.Text = "крестики и нолики";
            label2.Size = new Size(350, 300);
            label2.Location = new Point(260, 50);
            label2.Font = new Font("Sans",20);
            //иницилизация названия
            this.Controls.Add(label2);

            //создание кнопок в меню
            Start = new Button();
            Option = new Button();
            Exit = new Button();
            //Их настройка
            Start.Text = "Start";
            Option.Text = "Option";
            Exit.Text = "exit";

            Start.FlatAppearance.MouseOverBackColor = this.BackColor;
            Option.FlatAppearance.MouseDownBackColor = this.BackColor;
            Exit.FlatAppearance.MouseOverBackColor = this.BackColor;
            

            Start.Location = new Point(300, 150);
            Option.Location = new Point(300, 210);
            Exit.Location = new Point(300, 270);

            Start.Size = new Size(100, 50);
            Option.Size = new Size(100, 50);
            Exit.Size = new Size(100, 50);

            Start.Click += new EventHandler(Start_Click);
            Option.Click += new EventHandler(Option_Click);
            Exit.Click += new EventHandler(Exit_Click);

            //иницилизация кнопок
            this.Controls.Add(Start);
            this.Controls.Add(Option);
            this.Controls.Add(Exit);
            //делаем их перед обьектами
            Start.BringToFront();
            Option.BringToFront();
            Exit.BringToFront();
        }
        //переменная кнопки "назад"
        private Button Returg;

        private void Return_btn()
        {
            //создание кнопки "назад"
            Returg = new Button();
            //настройка "назад"
            Returg.Text = "Вернуться в меню";
            Returg.Location = new Point(600, 350);
            Returg.Size = new Size(100, 50);
            Returg.Visible = false;
            //делаем её по верх всех
            Returg.Click += new EventHandler(Returg_Click);
            //иницилизируем в программе
            this.Controls.Add(Returg);

            
        }

        private Button Aspect;
        private void Appearance()
        {
            Aspect = new Button();

            Aspect.Size = new Size(100, 50);
            Aspect.Visible = false;
            Aspect.Location = new Point(270, 140);
            Aspect.Text = "Внешний вид";

            Aspect.Click += new EventHandler(Aspect_Click);

            this.Controls.Add(Aspect);

            Aspect.BringToFront();
        }

        private void Start_Click (object sender, EventArgs e) 
        {
            //название и кто ходит делаем false и true 
            label2.Visible = false;
            label1.Visible = true;
            
            label1.Text = "Играют X";
            //убираем видимые кнопки из меню
            Start.Visible = false;
            Option.Visible = false;
            Exit.Visible = false;
            //показываем игровое поле
            foreach (Button btn in buttons)
            {
                btn.Visible = true;
            }
            //делаем кнопку "назад" видимым
            Returg.Visible = true;

        }

        private void Option_Click(object sender, EventArgs e)
        {
            Start.Visible = false;
            Option.Visible = false;
            Exit.Visible = false;
            Returg.Visible = true;

            Aspect.Visible = true;

            label2.Text = "Настройки";


        }
        private void Exit_Click(object sender, EventArgs e)
        {
            //закрываем программу
            this.Close();
        }

        private void Returg_Click(object sender, EventArgs e)
        {
            //выключаем игровые кнопки
            foreach (Button btn in buttons)
            {
                btn.Visible = false;
            }

            //кнопку "назад" делаем не видимым
            Returg.Visible = false;
            //названия и кто ходит делаем на true и false
            label2.Visible = true;
            label1.Visible = false;

            
            //делаем видимыми кнопки в меню
            Start.Visible = true;
            Option.Visible = true;
            Exit.Visible = true;
            if (Aspect.Visible == true)
            {
                Aspect.Visible = false;
                if (One_Variant != null) // Добавляем проверку на null
                {
                    One_Variant.Visible = false;
                }
            }
        }

        private ComboBox One_Variant;

        private void Aspect_Click(object sender, EventArgs e)
        {
            One_Variant = new ComboBox();

            One_Variant.Location = new Point(370, 170);
            One_Variant.Size = new Size(120, 30); // Установите размер комбобокса

            // Добавляем варианты внешнего вида
            One_Variant.Items.Add("Вариант 1 (Sans Serif)");
            One_Variant.Items.Add("Вариант 2 (Arial)");

            // Устанавливаем выбранный индекс по умолчанию
            One_Variant.SelectedIndex = 0;

            // Подписываемся на событие SelectedIndexChanged вместо Click
            One_Variant.SelectedIndexChanged += new EventHandler(OVar_SelectedIndexChanged);

            this.Controls.Add(One_Variant);

            One_Variant.BringToFront();
        }

        private void OVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox != null)
            {
                string selectedAppearance = comboBox.SelectedItem as string;

                if (selectedAppearance == "Вариант 2 (Arial)")
                {
                    foreach (Button btn in buttons)
                    {
                        btn.Font = new Font("arial", 20);
                        btn.BackColor = Color.LightBlue;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.MouseOverBackColor = Color.LightBlue;
                        btn.FlatAppearance.MouseDownBackColor = Color.LightBlue;
                    }
                }

                else if (selectedAppearance == "Вариант 1 (Sans Serif)")
                {
                    foreach (Button btn in buttons)
                    {
                        btn.Font = new Font("sans serif", 20); // Исправлено на lowercase 's'
                        btn.BackColor = Color.White;
                        btn.FlatStyle = FlatStyle.Standard;
                        btn.FlatAppearance.MouseOverBackColor = Color.White;
                        btn.FlatAppearance.MouseDownBackColor = Color.White;

                    }
                }
            }
        }





    }

}
