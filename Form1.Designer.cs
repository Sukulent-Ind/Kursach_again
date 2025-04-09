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
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(66, 142);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Начать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 1;
            label1.Text = "Ширина поля";
            // 
            // field_width
            // 
            field_width.Location = new Point(153, 22);
            field_width.Name = "field_width";
            field_width.Size = new Size(50, 23);
            field_width.TabIndex = 2;
            // 
            // number_of_squares
            // 
            number_of_squares.Location = new Point(152, 66);
            number_of_squares.Name = "number_of_squares";
            number_of_squares.Size = new Size(50, 23);
            number_of_squares.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 69);
            label3.Name = "label3";
            label3.Size = new Size(130, 15);
            label3.TabIndex = 5;
            label3.Text = "Количество квадартов";
            // 
            // make_random
            // 
            make_random.AutoSize = true;
            make_random.Location = new Point(11, 107);
            make_random.Name = "make_random";
            make_random.Size = new Size(191, 19);
            make_random.TabIndex = 7;
            make_random.Text = "Случайный размер квадратов";
            make_random.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(222, 177);
            Controls.Add(make_random);
            Controls.Add(number_of_squares);
            Controls.Add(label3);
            Controls.Add(field_width);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
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
    }
}
