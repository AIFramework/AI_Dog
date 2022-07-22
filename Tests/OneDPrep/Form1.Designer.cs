
namespace OneDPrep
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fps = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.heatMapControl1 = new AI.Charts.Control.HeatMapControl();
            this.scatter = new AI.Charts.Control.ChartVisual();
            this.Classes = new AI.Charts.Control.ChartVisual();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 257);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // fps
            // 
            this.fps.Enabled = true;
            this.fps.Interval = 30;
            this.fps.Tick += new System.EventHandler(this.fps_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(0, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Погладь песика";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(390, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Матрица смежности";
            // 
            // heatMapControl1
            // 
            this.heatMapControl1.Location = new System.Drawing.Point(310, 286);
            this.heatMapControl1.Name = "heatMapControl1";
            this.heatMapControl1.Size = new System.Drawing.Size(382, 285);
            this.heatMapControl1.TabIndex = 6;
            // 
            // scatter
            // 
            this.scatter.AutoScroll = true;
            this.scatter.BackColor = System.Drawing.Color.White;
            this.scatter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scatter.ChartName = "Семантический образ";
            this.scatter.ForeColor = System.Drawing.Color.Black;
            this.scatter.IsContextMenu = true;
            this.scatter.IsLogScale = false;
            this.scatter.IsMoove = true;
            this.scatter.IsScale = true;
            this.scatter.IsShowXY = true;
            this.scatter.LabelX = "x";
            this.scatter.LabelY = "y";
            this.scatter.Location = new System.Drawing.Point(5, 286);
            this.scatter.Name = "scatter";
            this.scatter.Size = new System.Drawing.Size(299, 285);
            this.scatter.TabIndex = 3;
            // 
            // Classes
            // 
            this.Classes.AutoScroll = true;
            this.Classes.BackColor = System.Drawing.Color.White;
            this.Classes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Classes.ChartName = "Сенсорный образ";
            this.Classes.ForeColor = System.Drawing.Color.Black;
            this.Classes.IsContextMenu = true;
            this.Classes.IsLogScale = false;
            this.Classes.IsMoove = true;
            this.Classes.IsScale = true;
            this.Classes.IsShowXY = true;
            this.Classes.LabelX = "Компонента";
            this.Classes.LabelY = "Значение";
            this.Classes.Location = new System.Drawing.Point(260, 23);
            this.Classes.Name = "Classes";
            this.Classes.Size = new System.Drawing.Size(435, 257);
            this.Classes.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 574);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Точность: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(211, 629);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Слово:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(694, 667);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.heatMapControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scatter);
            this.Controls.Add(this.Classes);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "AI Dog Main test";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer fps;
        private AI.Charts.Control.ChartVisual Classes;
        private System.Windows.Forms.Label label1;
        private AI.Charts.Control.HeatMapControl heatMapControl1;
        private AI.Charts.Control.ChartVisual scatter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

