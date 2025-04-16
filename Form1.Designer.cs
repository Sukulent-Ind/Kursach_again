namespace Kursach_again
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            field_width = new TextBox();
            number_of_squares = new TextBox();
            label3 = new Label();
            make_random = new CheckBox();
            groupBox1 = new GroupBox();
            show_matrix = new Button();
            label4 = new Label();
            choose_scale = new ComboBox();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(32, 142);
            button1.Name = "button1";
            button1.Size = new Size(191, 23);
            button1.TabIndex = 0;
            button1.Text = "Начать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 25);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 1;
            label1.Text = "Ширина поля";
            // 
            // field_width
            // 
            field_width.Location = new Point(174, 22);
            field_width.Name = "field_width";
            field_width.Size = new Size(50, 23);
            field_width.TabIndex = 2;
            // 
            // number_of_squares
            // 
            number_of_squares.Location = new Point(173, 66);
            number_of_squares.Name = "number_of_squares";
            number_of_squares.Size = new Size(50, 23);
            number_of_squares.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 69);
            label3.Name = "label3";
            label3.Size = new Size(130, 15);
            label3.TabIndex = 5;
            label3.Text = "Количество квадартов";
            // 
            // make_random
            // 
            make_random.AutoSize = true;
            make_random.Location = new Point(32, 107);
            make_random.Name = "make_random";
            make_random.Size = new Size(191, 19);
            make_random.TabIndex = 7;
            make_random.Text = "Случайный размер квадратов";
            make_random.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(show_matrix);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(choose_scale);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(248, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(155, 153);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Доп. опции";
            // 
            // show_matrix
            // 
            show_matrix.Enabled = false;
            show_matrix.Location = new Point(11, 99);
            show_matrix.Name = "show_matrix";
            show_matrix.Size = new Size(87, 23);
            show_matrix.TabIndex = 3;
            show_matrix.Text = "Показать";
            show_matrix.UseVisualStyleBackColor = true;
            show_matrix.Click += show_matrix_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 81);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 2;
            label4.Text = "Матрица";
            // 
            // choose_scale
            // 
            choose_scale.FormattingEnabled = true;
            choose_scale.Location = new Point(11, 42);
            choose_scale.Name = "choose_scale";
            choose_scale.Size = new Size(121, 23);
            choose_scale.TabIndex = 1;
            choose_scale.TextChanged += choose_scale_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 24);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 0;
            label2.Text = "Масштаб";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 177);
            Controls.Add(groupBox1);
            Controls.Add(make_random);
            Controls.Add(number_of_squares);
            Controls.Add(label3);
            Controls.Add(field_width);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Расстановка квадратов";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox field_width;
        private TextBox number_of_squares;
        private Label label3;
        private CheckBox make_random;
        private GroupBox groupBox1;
        private Label label2;
        private Button show_matrix;
        private Label label4;
        private ComboBox choose_scale;
    }
}
