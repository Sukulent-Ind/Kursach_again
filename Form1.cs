namespace Kursach_again
{
    public partial class Form1 : Form
    {
        Form field = new Form();
        Form position_matrix = new Form();
        List<int[]> field_matrix = new List<int[]>();
        List<Button> button_list = new List<Button>();
        List<int[]> variants = new List<int[]>();
        List<int[]> coords = new List<int[]>();


        public Form1()
        {
            InitializeComponent();
            field.FormClosed += field_closed;
            field.Text = "Поле";
            choose_scale.DataSource = new List<int>() { 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 35, 40, 50 };
            position_matrix.FormClosing += matrix_closing;
        }

        private bool ValidateFields()
        {

            bool isValid = true;

            if (!(int.TryParse(field_width.Text, out int val)))
            {
                isValid = false;
            }

            if (!(int.TryParse(number_of_squares.Text, out int val2)))
            {
                isValid = false;
            }


            return isValid;
        }

        private void make_buttons(int amount, int width, bool random)
        {
            int sz = 1;

            for (int i = 0; i < amount; i++)
            {
                if (random)
                {
                    Random rnd = new Random();
                    sz = rnd.Next(2, width);
                }

                Button button = new Button();
                button.Size = new Size(sz, sz);
                button.Text = sz.ToString();
                button.MouseDown += square_Click;

                button_list.Add(button);
            }
        }

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
                    line[width - 1] = 1;
                }

                field_matrix.Add(line);
            }
        }

        private bool check_crosses(int x, int y, int size)
        {
            List<int[]> copy_field_matrix = new List<int[]>();
            field_matrix.ForEach((item) => { copy_field_matrix.Add((int[])item.Clone()); });

            for (int i = 0; i <= size; i++)
            {
                for (int j = 0; j <= size; j++)
                {
                    if (i == 0 || j == 0 || i == size || j == size) copy_field_matrix[y + i][x + j] += 1;
                    else copy_field_matrix[y + i][x + j] += 2;

                    //if (j == size) copy_field_matrix[y + i][x + j] = 2;

                    if (copy_field_matrix[y + i][x + j] > 2) return true;
                }
            }

            return false;
        }

        private int find_touching_sum(int x, int y, int size)
        {
            int touch_sum = -2;

            for (int i = 0; i <= size; i++)
            {
                if (field_matrix[y + i][x] == 1) touch_sum++;

                //if (field_matrix[y][x + i] == 1) touch_sum++;

                if (y > 0 && x + i > 0) //  && x + i != field_matrix[0].Count() - 1
                {
                    if (field_matrix[y][x + i] == 1 && (field_matrix[y - 1][x + i - 1] != 2 && field_matrix[y - 1][x + i] != 2)) continue;
                    
                }
                
                if (field_matrix[y][x + i] == 1) touch_sum++;

            }

            return touch_sum;
        }

        private void find_and_build_optimal_square()
        {
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
                    else field_matrix[y + i][x + j] += 2;

                    if (i == 0 && y > 0) // Коррекция пересечения правой и верхней граней
                    {
                        if (field_matrix[y - 1][x + j] == 1 && field_matrix[y][x + j] == 2)
                            field_matrix[y][x + j] = 1;
                    }
                    
                    if (j == 0) // Коррекция пересечения нижней и левой граней
                    {
                        if (l_prev == 2 && field_matrix[y + i][x] == 1)
                            field_matrix[y + i - 1][x] = 1;

                        l_prev = field_matrix[y + i][x];
                    }

                    if (j == size) //Коррекция пересечения правой и нижней граней
                    {
                        if (r_prev == 2 && field_matrix[y + i][x + size] == 1)
                            field_matrix[y + i - 1][x + size] = 1;

                        r_prev = field_matrix[y + i][x + size];
                    } 


                        
                }

            }

            field_matrix[y + size][x] = 1;
            //if (y + size == field_matrix.Count() - 1)
            //    field_matrix[y + size][x] = 2;

            //else if (field_matrix[y + size + 1][x] == 2)
            //    field_matrix[y + size][x] = 2;

            //else
            //    field_matrix[y + size][x] = 1;


            //field_matrix[y][x + size] = 1;
            if (x + size < field_matrix[0].Count() - 1 && field_matrix[y][x + size + 1] == 2) // || x + size == field_matrix[0].Count() - 1
                field_matrix[y][x + size] = 2;

            else field_matrix[y][x + size] = 1;


            field_matrix[y + size][x + size] = 1;
            //if (y + size == field_matrix.Count() - 1)
            //    field_matrix[y + size][x + size] = 2;

            //else if (field_matrix[y + size + 1][x + size] == 2)
            //    field_matrix[y + size][x + size] = 2;

            //else
            //    field_matrix[y + size][x + size] = 1;




            coords.Add([x, y, size]);
        }

        private void button_size_rollback()
        {
            for (int i = 0; i < button_list.Count; i++)
            {
                Button button = button_list[i];

                button.Size = new Size(coords[i][2], coords[i][2]);
            }
        }

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

        private void place_buttons(int width, int height)
        {
            make_matrix(width, height);
            coords.Clear();
            int cnt = 1;
            bool yes = false;

            foreach (Button button in button_list)
            {
                variants.Clear();

                if (cnt == 19 && button.Width == 2)
                    yes = true;

                for (int y = 0; y < height; y++)
                {
                    if (field_matrix[y].Sum() == 2) break;

                    for (int x = 0; x < width; x++)
                    {
                        if (yes && y == 7)
                            cnt += 0;

                        if (field_matrix[y][x] == 1)
                        {
                            if (x + button.Width > width - 1) break;

                            //if (y + button.Height > field_matrix.Count) add_height(button.Height, width); //Если высота сразу максимальна, то это не нужно

                            if (check_crosses(x, y, button.Width)) continue;

                            variants.Add([find_touching_sum(x, y, button.Width), x, y, button.Width]);

                        }
                    }
                }

                int a = 0;
                if (button.Width == 3)
                    a = 1;

                find_and_build_optimal_square();

                cnt++;
            }

            build_buttons();
            update_grid();
        }

        private void update_grid()
        {
            position_matrix.Controls.Clear();
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

            position_matrix.Size = textbox.Size;
            position_matrix.Controls.Add(textbox);
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            field.Hide();
            field_matrix.Clear();
            button_list.Clear();


            if (!ValidateFields())
            {
                MessageBox.Show("Одно или несколько введённых вами значений не являются числами.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int squares_count = int.Parse(number_of_squares.Text);

            if (squares_count <= 0)
            {
                MessageBox.Show("Должен быть как минимум один квадрат!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int width = int.Parse(field_width.Text);

            if (width < 2)
            {
                MessageBox.Show("Ширина поля должна быть как минимум 2!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int height = squares_count * width + 1; //Максимально возможная высота


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
            position_matrix.Hide();
        }

        private void choose_scale_TextChanged(object sender, EventArgs e)
        {
            if (button1.Text == "Начать") return;

            button_size_rollback();
            build_buttons();
        }

        private void matrix_closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                position_matrix.Hide();
            }
        }

        private void show_matrix_Click(object sender, EventArgs e)
        {
            position_matrix.Show();
        }
    }
}
