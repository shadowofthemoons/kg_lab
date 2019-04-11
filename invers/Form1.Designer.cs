namespace invers
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.download = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.grayscale = new System.Windows.Forms.Button();
            this.return2 = new System.Windows.Forms.Button();
            this.average_binarization = new System.Windows.Forms.Button();
            this.Bradley_Roth_algorithm = new System.Windows.Forms.Button();
            this.med = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grayscale_noise = new System.Windows.Forms.Button();
            this.Sobel = new System.Windows.Forms.Button();
            this.Sobel_color = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // download
            // 
            this.download.Location = new System.Drawing.Point(1298, 12);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(118, 41);
            this.download.TabIndex = 0;
            this.download.Text = "Загрузить";
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.download_click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1298, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 41);
            this.button2.TabIndex = 1;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.save_click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1298, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 41);
            this.button3.TabIndex = 2;
            this.button3.Text = "Инвертировать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.inversion_click);
            // 
            // grayscale
            // 
            this.grayscale.Location = new System.Drawing.Point(1298, 153);
            this.grayscale.Name = "grayscale";
            this.grayscale.Size = new System.Drawing.Size(118, 41);
            this.grayscale.TabIndex = 4;
            this.grayscale.Text = "Перевести в оттенки серого";
            this.grayscale.UseVisualStyleBackColor = true;
            this.grayscale.Click += new System.EventHandler(this.grayscale_Click);
            // 
            // return2
            // 
            this.return2.Location = new System.Drawing.Point(1298, 200);
            this.return2.Name = "return2";
            this.return2.Size = new System.Drawing.Size(118, 41);
            this.return2.TabIndex = 5;
            this.return2.Text = "Вернуть начальное изображение ";
            this.return2.UseVisualStyleBackColor = true;
            this.return2.Click += new System.EventHandler(this.return_Click);
            // 
            // average_binarization
            // 
            this.average_binarization.Location = new System.Drawing.Point(1298, 247);
            this.average_binarization.Name = "average_binarization";
            this.average_binarization.Size = new System.Drawing.Size(118, 41);
            this.average_binarization.TabIndex = 6;
            this.average_binarization.Text = " ч/б по среднему";
            this.average_binarization.UseVisualStyleBackColor = true;
            this.average_binarization.Click += new System.EventHandler(this.average_binarization_Click);
            // 
            // Bradley_Roth_algorithm
            // 
            this.Bradley_Roth_algorithm.Location = new System.Drawing.Point(1298, 294);
            this.Bradley_Roth_algorithm.Name = "Bradley_Roth_algorithm";
            this.Bradley_Roth_algorithm.Size = new System.Drawing.Size(118, 41);
            this.Bradley_Roth_algorithm.TabIndex = 7;
            this.Bradley_Roth_algorithm.Text = "ч/б алгоритм Брэдли-Рота";
            this.Bradley_Roth_algorithm.UseVisualStyleBackColor = true;
            this.Bradley_Roth_algorithm.Click += new System.EventHandler(this.Bradley_Roth_algorithm_Click);
            // 
            // med
            // 
            this.med.Location = new System.Drawing.Point(1298, 341);
            this.med.Name = "med";
            this.med.Size = new System.Drawing.Size(118, 41);
            this.med.TabIndex = 8;
            this.med.Text = "Медианный фильтр";
            this.med.UseVisualStyleBackColor = true;
            this.med.Click += new System.EventHandler(this.med_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1280, 720);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // grayscale_noise
            // 
            this.grayscale_noise.Location = new System.Drawing.Point(1298, 388);
            this.grayscale_noise.Name = "grayscale_noise";
            this.grayscale_noise.Size = new System.Drawing.Size(118, 41);
            this.grayscale_noise.TabIndex = 9;
            this.grayscale_noise.Text = "Медианный фильттр чб";
            this.grayscale_noise.UseVisualStyleBackColor = true;
            this.grayscale_noise.Click += new System.EventHandler(this.grayscale_noise_Click);
            // 
            // Sobel
            // 
            this.Sobel.Location = new System.Drawing.Point(1298, 435);
            this.Sobel.Name = "Sobel";
            this.Sobel.Size = new System.Drawing.Size(118, 41);
            this.Sobel.TabIndex = 10;
            this.Sobel.Text = "Алгоритм Собеля";
            this.Sobel.UseVisualStyleBackColor = true;
            this.Sobel.Click += new System.EventHandler(this.Sobel_Click);
            // 
            // Sobel_color
            // 
            this.Sobel_color.Location = new System.Drawing.Point(1298, 482);
            this.Sobel_color.Name = "Sobel_color";
            this.Sobel_color.Size = new System.Drawing.Size(118, 41);
            this.Sobel_color.TabIndex = 11;
            this.Sobel_color.Text = "Алгоритм Собеля цвет\r\n";
            this.Sobel_color.UseVisualStyleBackColor = true;
            this.Sobel_color.Click += new System.EventHandler(this.Sobel_color_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 767);
            this.Controls.Add(this.Sobel_color);
            this.Controls.Add(this.Sobel);
            this.Controls.Add(this.grayscale_noise);
            this.Controls.Add(this.med);
            this.Controls.Add(this.Bradley_Roth_algorithm);
            this.Controls.Add(this.average_binarization);
            this.Controls.Add(this.return2);
            this.Controls.Add(this.grayscale);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.download);
            this.Name = "Form1";
            this.Text = "Инвертирование изображения";
            
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button download;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button grayscale;
        private System.Windows.Forms.Button return2;
        private System.Windows.Forms.Button average_binarization;
        private System.Windows.Forms.Button Bradley_Roth_algorithm;
        private System.Windows.Forms.Button med;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button grayscale_noise;
        private System.Windows.Forms.Button Sobel;
        private System.Windows.Forms.Button Sobel_color;
    }
}

