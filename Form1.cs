namespace Kursach_again
{
    public partial class Form1 : Form
    {
        Form field = new Form(); //Форма для расположения квадратов
        Form position_matrix_form = new Form(); //Форма для демонстрации матрицы квадратов
        List<int[]> field_matrix = new List<int[]>(); //Матрица квадратов
        List<Button> button_list = new List<Button>(); //Список кнопок
        List<int[]> variants = new List<int[]>(); //Список возможных вариантов расположения
        List<int[]> coords = new List<int[]>(); //Список координат
        List<int[]> tests = new List<int[]>(); //Список тестов
        bool test_mode = false; //Активен ли тестовый режим



        public Form1()
        {
            InitializeComponent();
            field.FormClosed += field_closed;
            field.Text = "Поле";
            choose_scale.DataSource = new List<int>() { 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 35, 40, 50 };
            position_matrix_form.FormClosing += matrix_form_closing;
            field.FormClosing += field_closing;

            //------------------------тесты-----------------------------------
            tests.Add([4, 3, 1, 1, 3, 3, 2, 1, 1, 3, 2, 2, 1, 1, 2, 3, 2, 7]);
            tests.Add([1, 2, 3, 1, 1, 2, 1, 1, 2, 1, 3, 1, 3, 3, 1, 1, 1, 1, 2, 1, 2, 6, 1, 1, 2, 6]);
            tests.Add([5, 6, 3, 2, 1, 2, 3, 1, 1, 4, 1, 1, 1, 1, 2, 3, 2, 3, 2, 1, 1, 3, 2, 2, 5, 2, 1, 1, 2, 1, 11]);
            tests.Add([8, 4, 3, 1, 1, 2, 2, 6, 2, 1, 1, 1, 1, 1, 2, 3, 1, 1, 1, 2, 2, 2, 4, 1, 1, 3, 3, 13]);
            tests.Add([2, 3, 1, 3, 2, 1, 1, 3, 2, 1, 1, 1, 1, 1, 1, 1, 3, 3, 8]);
            tests.Add([3, 2, 2, 2, 3, 1, 1, 3, 1, 2, 2, 5]);
            tests.Add([2, 3, 5, 2, 2, 5, 4, 2, 1, 1, 1, 1, 1, 3, 3, 5, 4, 4, 2, 2, 2, 3, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 2, 2, 2, 12]);
            tests.Add([5, 4, 2, 1, 3, 2, 2, 6, 5, 1, 2, 2, 1, 1, 2, 1, 1, 2, 3, 3, 2, 1, 1, 13]);
            tests.Add([1, 2, 4, 3, 2, 1, 1, 1, 1, 1, 5, 2, 2, 5, 1, 1, 1, 2, 2, 2, 7]);
            tests.Add([1, 1, 1, 1, 1, 2, 1, 2, 3, 2, 2, 2, 3, 4, 1, 2, 3, 4, 2, 1, 3, 2, 2, 3, 2, 2, 1,   1, 3, 1, 3, 2, 3, 50]);
            tests.Add([1, 1, 1, 1, 1, 2, 1, 2, 3, 2, 2, 2, 3, 4, 1, 2, 3, 4, 2, 1, 3, 50]);
            //----------------------------------------------------------------

            test_number.Maximum = tests.Count();
        }


        //-----------------Создание списка кнопок-----------------------------
        private void make_buttons(int amount, int width, bool random)
        {
            int sz = 1;
           
            if (test_mode) amount = tests[(int)test_number.Value - 1].Count() - 1;

            for (int i = 0; i < amount; i++)
            {
                if (random) //Если выбран случайный размер квадратов
                {
                    Random rnd = new Random();
                    sz = rnd.Next(1, width);
                }

                if (test_mode) sz = tests[(int)test_number.Value - 1][i];

                Button button = new Button();
                button.Size = new Size(sz, sz);
                button.Text = sz.ToString();
                button.MouseDown += square_Click;

                button_list.Add(button);
            }
        }

        //-----------------Создание матрицы поля------------------------------
        private void make_matrix(int width, int height)
        {
            field_matrix.Clear();

            for (int i = 0; i < height; i++)
            {
                int[] line = new int[width];

                if (i == 0) for (int j = 0; j < width; j++) line[j] = 1;
                else
                {
                    for (int j = 0; j < width; j++) line[j] = 0;
                    line[0] = 1;

                }

                field_matrix.Add(line);
            }
        }

        //-------Проверка пересечения нового квадрата с уже установленными----
        private bool check_crosses(int x, int y, int size)
        {
            //Создание копии матрицы
            List<int[]> copy_field_matrix = new List<int[]>();

            for (int i = 0; i <= size; i++) copy_field_matrix.Add((int[])field_matrix[y + i].Clone());

            for (int i = 0; i <= size; i++)
            {
                for (int j = 0; j <= size; j++)
                {
                    if (i == 0 || j == 0 || i == size || j == size) copy_field_matrix[i][x + j] += 1;
                    else copy_field_matrix[i][x + j] += 2;

                    if (copy_field_matrix[i][x + j] > 2) return true; //Число больше 3 - пересечение
                }
            }

            return false;
        }

        //--------Найти площадь соприкаснавения с другими квадратами----------
        private int find_touching_sum(int x, int y, int size)
        {
            int touch_sum = 0;
            int prev = 1;

            for (int i = 1; i <= size; i++)
            {
                //Позволяет правильно вычислять касание правой стороны, в случае если есть пролёты 
                if (prev == 1) if (field_matrix[y + i][x] == 1) touch_sum++;
                prev = field_matrix[y + i][x];

                //Для корректного вычисления касания верхней стороны
                if (y > 0 && x + i > 0) 
                    if (field_matrix[y][x + i] == 1 && (field_matrix[y - 1][x + i - 1] != 2 && field_matrix[y - 1][x + i] != 2)) 
                        continue;

                if (field_matrix[y][x + i] == 1) touch_sum++;

            }

            return touch_sum;
        }

        //-Выбирает положение с наибольшей площадью касания и устанавливает квадрат-
        private void find_and_build_optimal_square()
        {
            //Выбор варианта с наибольшей площадбю касания
            int id = 0, max_sum = 0;

            for (int i = 0; i < variants.Count; i++)
            {
                if (variants[i][0] > max_sum)
                {
                    max_sum = variants[i][0];
                    id = i;
                }
            }

            int x = variants[id][1], y = variants[id][2], size = variants[id][3];

            int l_prev = 0;
            int r_prev = 0;

            for (int i = 0; i <= size; i++)
            {

                for (int j = 0; j <= size; j++)
                {
                    if (i == 0 || j == 0 || i == size || j == size) field_matrix[y + i][x + j] += 1;
                    else field_matrix[y + i][x + j] = 2;

                    if (i == 0 && y > 0) // Коррекция пересечения правой и верхней граней
                    {
                        if (field_matrix[y - 1][x + j] == 1 && field_matrix[y][x + j] == 2)
                            field_matrix[y][x + j] = 1;
                    }

                    if (j == 0) // Коррекция пересечения левой и нижней граней
                    {
                        if (l_prev == 2 && field_matrix[y + i][x] == 1)
                            field_matrix[y + i - 1][x] = 1;

                        l_prev = field_matrix[y + i][x];

                        if (x > 0)
                            if (field_matrix[y + i][x - 1] == 1) field_matrix[y + i][x] = 1;
                    }

                    if (j == size) //Коррекция пересечения правой и нижней граней
                    {
                        if (r_prev == 2 && field_matrix[y + i][x + size] == 1)
                            field_matrix[y + i - 1][x + size] = 1;

                        r_prev = field_matrix[y + i][x + size];
                    }

                    if (i == size) //Коррекция пересечения нижней и верхней граней
                        if (y + i < field_matrix.Count() - 1)
                            if (field_matrix[y + i + 1][x + j] == 1)
                                field_matrix[y + i][x + j] = 1;
                }

            }

            field_matrix[y + size][x] = 1; //Корркция левого нижнего угла

            if (x + size < field_matrix[0].Count() - 1) //Корркция правого верхнего угла
                if (field_matrix[y][x + size + 1] == 2 & field_matrix[y][x + size - 1] != 1)
                field_matrix[y][x + size] = 2;

            else field_matrix[y][x + size] = 1;

            field_matrix[y + size][x + size] = 1; //Корркция правого нижнего угла

            int[] res = new int[3] { x, y, size };

            coords.Add(res);
        }

        //--------------Добавляет строки в список, когда надо-----------------
        private int add_height(int height, int width)
        {
            for (int i = 0; i <= height + 1; i++)
            {
                int[] line = new int[width];

                for (int j = 0; j < width; j++) line[j] = 0;
                line[0] = 1;


                field_matrix.Add(line);
            }
            return field_matrix.Count;
        }

        //--------Возвращение кнопкам неотмасштабированного значения----------
        private void button_size_rollback()
        {
            for (int i = 0; i < button_list.Count; i++)
            {
                Button button = button_list[i];

                button.Size = new Size(coords[i][2], coords[i][2]);
            }
        }

        //------------------Построение кнопок на форме------------------------
        private void build_buttons()
        {
            field.Controls.Clear();

            int scale = int.Parse(choose_scale.Text);

            for (int i = 0; i < button_list.Count; i++)
            {
                Button button = button_list[i];

                button.Text = coords[i][2] + " (" + (i + 1) + ")";
                button.Location = new Point(coords[i][0] * scale, coords[i][1] * scale);
                button.Size = new Size(coords[i][2] * scale, coords[i][2] * scale);

                field.Controls.Add(button);
            }
        }

        //------------------------Главная функция-----------------------------
        private void place_buttons(int width, int height)
        {
            make_matrix(width, height);
            coords.Clear();
            //int cnt = 1;
            //bool yes = false;

            foreach (Button button in button_list)
            {
                variants.Clear();

                for (int y = 0; y < height; y++)
                {
                    if (field_matrix[y].Sum() == 1) break;
                    if (field_matrix[y].Min() == 2) continue;

                    for (int x = 0; x < width; x++)
                    {


                        if (field_matrix[y][x] == 1) //Левый верхний угол квадрата может быть расположен только в единицу
                        {
                            if (x + button.Width > width - 1) break; //Переход на след. строку, если ширина недостаточна
                            if (y + button.Height >= field_matrix.Count() - 1) 
                                height = add_height(button.Height, width);
                                

                            int t_sum = 0;
                            for (int i = 1; i <= button.Height; i++) t_sum += field_matrix[y + i][x];
                            if (t_sum == 0) break;

                            if (check_crosses(x, y, button.Width)) continue; //Вариант пропускаетя при пересечении с другими квадратами                      

                            

                            int[] res = new int[4] { find_touching_sum(x, y, button.Width), x, y, button.Width };

                            variants.Add(res); //Вариант расположения имеет: сумму касания, координаты, размер кнопки

                        }
                    }
                }             

                find_and_build_optimal_square(); //Располагаем квадрат на матрице

                //if (cnt == 21) //Для дебага :)
                //    yes = true;
                //cnt++;
            }

            build_buttons(); //Располагаем кнопки на форме
            update_grid(); //Обновляем матрицу для демонстрации
        }

        //----Обновление формы, на которой можно увидеть матрицу квадратов----
        private void update_grid()
        {
            position_matrix_form.Controls.Clear();
            string s = "";

            for (int i = 0; i < field_matrix.Count; i++)
            {
                for (int j = 0; j < field_matrix[i].Count(); j++) s += field_matrix[i][j] + " ";

                s += "\r\n";

                if (field_matrix[i].Sum() == 2) break;
            }

            TextBox textbox = new TextBox();
            textbox.Text = s;
            textbox.Multiline = true;
            textbox.ReadOnly = true;
            textbox.Size = new Size(field_matrix[0].Count() * 15, field_matrix[0].Count() * 15);
            textbox.Font = new Font("Lucida Console", 9);

            position_matrix_form.Size = textbox.Size;
            position_matrix_form.Controls.Add(textbox);
        }

        //----------------Изменение размера квадратов-------------------------
        private void square_Click(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            button_size_rollback();

            if (e.Button == MouseButtons.Left && (button.Width + 1) < field_matrix[0].Count())
            {
                button.Size = new Size(button.Width + 1, button.Height + 1);
            }

            if (e.Button == MouseButtons.Right && (button.Width - 1) > 0)
            {
                button.Size = new Size(button.Width - 1, button.Height - 1);
            }

            place_buttons(field_matrix[0].Count(), field_matrix.Count());

        }

        //------------------Обработка кнопки Начать---------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            field.Hide();
            field_matrix.Clear();
            button_list.Clear();

            int squares_count = (int)number_of_squares.Value;
            int width = (int)field_width.Value;
            int height = 5 * width + 1;

            field.MinimumSize = new Size(10, 10);
            field.AutoSize = true;
            field.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            make_buttons(squares_count, width + 1, make_random.Checked);

            place_buttons(width + 1, height);

            button1.Text = "Перестроить поле";
            show_matrix.Enabled = true;
            field.Show();
        }

        private void field_closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void matrix_closing(object sender, EventArgs e)
        {
            position_matrix_form.Hide();
        }

        private void choose_scale_TextChanged(object sender, EventArgs e)
        {
            if (button1.Text == "Начать" && !test_mode) return;

            button_size_rollback();
            build_buttons();
        }

        private void matrix_form_closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                position_matrix_form.Hide();
            }
        }

        private void field_closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                field.Hide();
            }
        }

        private void show_matrix_Click(object sender, EventArgs e)
        {
            position_matrix_form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Активировать")
            {
                field.Hide();
                test_mode = true;
                button2.Text = "Отключить";
                field_width.Enabled = false;
                number_of_squares.Enabled = false;
                make_random.Enabled = false;
                button1.Enabled = false;
                button3.Enabled = true;
                test_number.Enabled = true;

            }
            else
            {
                field.Hide();
                test_mode = false;
                button2.Text = "Активировать";
                field_width.Enabled = true;
                number_of_squares.Enabled = true;
                make_random.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = false;
                test_number.Enabled= false;

            }
        }

        //---------------------Обработка кнопки Тест---------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            field.Hide();
            field_matrix.Clear();
            button_list.Clear();

            int n = (int)test_number.Value - 1;

            int squares_count = tests[n].Count() - 1;
            int width = tests[n][tests[n].Count() - 1];
            int height = 5 * width + 1;

            field.AutoSize = true;
            field.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            make_buttons(squares_count, width + 1, make_random.Checked);

            place_buttons(width + 1, height);

            show_matrix.Enabled = true;
            field.Show();
        }
    }
}
