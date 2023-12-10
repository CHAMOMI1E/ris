namespace Client
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
            radioAdd = new RadioButton();
            radioDelete = new RadioButton();
            radioView = new RadioButton();
            listBox1 = new ListBox();
            textBoxName = new TextBox();
            textBoxPrice = new TextBox();
            textBoxQuantity = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Perform = new Button();
            richTextBox1 = new RichTextBox();
            radioEdit = new RadioButton();
            SuspendLayout();
            // 
            // radioAdd
            // 
            radioAdd.AutoSize = true;
            radioAdd.Location = new Point(243, 15);
            radioAdd.Name = "radioAdd";
            radioAdd.Size = new Size(77, 19);
            radioAdd.TabIndex = 0;
            radioAdd.TabStop = true;
            radioAdd.Text = "Добавить";
            radioAdd.UseVisualStyleBackColor = true;
            radioAdd.CheckedChanged += radioAdd_CheckedChanged;
            // 
            // radioDelete
            // 
            radioDelete.AutoSize = true;
            radioDelete.Location = new Point(243, 48);
            radioDelete.Name = "radioDelete";
            radioDelete.Size = new Size(69, 19);
            radioDelete.TabIndex = 1;
            radioDelete.TabStop = true;
            radioDelete.Text = "Удалить";
            radioDelete.UseVisualStyleBackColor = true;
            // 
            // radioView
            // 
            radioView.AutoSize = true;
            radioView.Location = new Point(243, 82);
            radioView.Name = "radioView";
            radioView.Size = new Size(92, 19);
            radioView.TabIndex = 2;
            radioView.TabStop = true;
            radioView.Text = "Посмотреть";
            radioView.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Items.AddRange(new object[] { "" });
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(208, 124);
            listBox1.TabIndex = 3;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(473, 11);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(192, 23);
            textBoxName.TabIndex = 4;
            textBoxName.TextChanged += textBox1_TextChanged;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(473, 83);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(192, 23);
            textBoxPrice.TabIndex = 5;
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(473, 44);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(192, 23);
            textBoxQuantity.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(377, 19);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 7;
            label1.Text = "Наименование";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(377, 50);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 8;
            label2.Text = "Количество";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(377, 86);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 9;
            label3.Text = "Цена";
            // 
            // Perform
            // 
            Perform.Location = new Point(325, 191);
            Perform.Name = "Perform";
            Perform.Size = new Size(124, 49);
            Perform.TabIndex = 10;
            Perform.Text = "Выполнить";
            Perform.UseVisualStyleBackColor = true;
            Perform.Click += Perform_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.ScrollBar;
            richTextBox1.Location = new Point(473, 144);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(192, 144);
            richTextBox1.TabIndex = 11;
            richTextBox1.Text = "";
            // 
            // radioEdit
            // 
            radioEdit.AutoSize = true;
            radioEdit.Location = new Point(243, 118);
            radioEdit.Name = "radioEdit";
            radioEdit.Size = new Size(79, 19);
            radioEdit.TabIndex = 12;
            radioEdit.TabStop = true;
            radioEdit.Text = "Изменить";
            radioEdit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 310);
            Controls.Add(radioEdit);
            Controls.Add(richTextBox1);
            Controls.Add(Perform);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxQuantity);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxName);
            Controls.Add(listBox1);
            Controls.Add(radioView);
            Controls.Add(radioDelete);
            Controls.Add(radioAdd);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radioAdd;
        private RadioButton radioDelete;
        private RadioButton radioView;
        private ListBox listBox1;
        private TextBox textBoxName;
        private TextBox textBoxPrice;
        private TextBox textBoxQuantity;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button Perform;
        private RichTextBox richTextBox1;
        private RadioButton radioEdit;
    }
}