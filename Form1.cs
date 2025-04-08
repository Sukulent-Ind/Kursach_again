using System.Drawing.Drawing2D;

namespace Kursach_again
{
    public partial class Form1 : Form
    {
        Form field = new Form();
        List<int[]> field_matrix = new List<int[]>();
        List<Button> button_list = new List<Button>();
        List<int[]> variants = new List<int[]>();
        List<int[]> copy_field_matrix = new List<int[]>();
        List<int[]> coords = new List<int[]>();
        int prev_square_size = 0;


        public Form1()
        {
            InitializeComponent();
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

        private int find_touching_sum(int x, int y, int size)
        {
            int touch_sum = -1;

            for (int i = 0; i < size; i++)
            {
                if (field_matrix[y + i][x] == 1 || field_matrix[y + i][x] == 2) touch_sum++;

                if (field_matrix[y][x + i] == 1 || field_matrix[y][x + i] == 2) touch_sum++;

            }

            return touch_sum;
        }

        private bool check_crosses(int x, int y, int size)
        {
            copy_field_matrix.Clear();
            field_matrix.ForEach((item) => { copy_field_matrix.Add((int[])item.Clone()); });

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 0 || j == 0 || i == size - 1 || j == size - 1) copy_field_matrix[y + i][x + j] += 1;
                    else copy_field_matrix[y + i][x + j] += 2;

                    if (copy_field_matrix[y + i][x + j] > 2) return true;
                }
            }

            return false;
        }

        private void find_optimal_square()
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

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 0 || j == 0 || i == size - 1 || j == size - 1) field_matrix[y + i][x + j] += 1;
                    else field_matrix[y + i][x + j] += 2;
                }
            }

            field_matrix[y + size - 1][x] = 1;
            field_matrix[y][x + size - 1] = 1;
            field_matrix[y + size - 1][x + size - 1] = 1;

            //btn.Location = new Point(x, y);
            //btn.Size = new Size(btn.Width * scale, btn.Height * scale);
            //field.Controls.Add(btn);

            coords.Add([x, y, size]);
            //prev_square_size = size;

        }

        private void add_height(int height, int width)
        {
            for (int i = 0; i <= height; i++)
            {
                int[] new_line = new int[width];

                for (int j = 0; j < width; j++) new_line[j] = 0;
                new_line[0] = 1;
                new_line[width - 1] = 1;

                field_matrix.Add(new_line);
            }
        }

        private void make_matrix(int width, int height)
        {
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

        private void make_buttons(int amount, int size)
        {
            for (int i = 0; i < amount; i++)
            {
                Button button = new Button();
                button.Width = size;
                button.Height = size;
                button.Text = size.ToString();

                button_list.Add(button);
            }
        }

        private void place_buttons(int width, int height)
        {
            make_matrix(width, height);
            coords.Clear();
            prev_square_size = 0;

            foreach (Button button in button_list)
            {
                variants.Clear();

                for (int y = 0; y < field_matrix.Count; y++)
                {
                    if (field_matrix[y].Sum() == 2) break;

                    for (int x = 0; x < width; x++)
                    {
                        if (field_matrix[y][x] == 1)
                        {
                            if (x + button.Width > width)
                            {
                                prev_square_size = 0;
                                break;
                            }

                            if (y + button.Height > field_matrix.Count) add_height(button.Height, width);

                            if (check_crosses(x, y, button.Width)) break;

                            variants.Add([find_touching_sum(x, y, button.Width), x, y, button.Width]);

                        }
                    }
                }

                find_optimal_square();

            }

            build_buttons();
        }

        private void build_buttons()
        {
            for (int i = 0;  i < button_list.Count; i++)
            {
                Button button = button_list[i];

                button.Location = new Point(coords[i][0], coords[i][1]);
                button.Size = new Size(coords[i][2], coords[i][2]);

                field.Controls.Add(button);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
            {
                MessageBox.Show("NaN");
                return;
            }


            int squares_count = int.Parse(number_of_squares.Text);
            int scale = 8;
            int width = int.Parse(field_width.Text) + 1;
            int height = squares_count * width / 4;

            //if (squares_count >= 30 || width >= 30) scale = 2;
            //else if (squares_count >= 25 || width >= 25) scale = 4;
            //else if (squares_count >= 20 || width >= 20) scale = 6;

            field.Size = new Size(width * scale, height * scale);

            make_buttons(squares_count, width / 4 * scale);
            
            place_buttons(width * scale, height * scale);

            
            field.Show();
            button1.Enabled = false;
        }
    }
}
