
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
            this.Classes = new AI.Charts.Control.ChartVisual();
            this.plotSignal = new AI.Charts.Control.ChartVisual();
            this.scatter = new AI.Charts.Control.ChartVisual();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 356);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // fps
            // 
            this.fps.Enabled = true;
            this.fps.Interval = 50;
            this.fps.Tick += new System.EventHandler(this.fps_Tick);
            // 
            // Classes
            // 
            this.Classes.AutoScroll = true;
            this.Classes.BackColor = System.Drawing.Color.White;
            this.Classes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Classes.ChartName = "Активации";
            this.Classes.ForeColor = System.Drawing.Color.Black;
            this.Classes.IsContextMenu = true;
            this.Classes.IsLogScale = false;
            this.Classes.IsMoove = true;
            this.Classes.IsScale = true;
            this.Classes.IsShowXY = true;
            this.Classes.LabelX = "Компонента";
            this.Classes.LabelY = "Значение";
            this.Classes.Location = new System.Drawing.Point(333, 0);
            this.Classes.Name = "Classes";
            this.Classes.Size = new System.Drawing.Size(303, 383);
            this.Classes.TabIndex = 1;
            // 
            // plotSignal
            // 
            this.plotSignal.AutoScroll = true;
            this.plotSignal.BackColor = System.Drawing.Color.White;
            this.plotSignal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plotSignal.ChartName = "S(t)";
            this.plotSignal.ForeColor = System.Drawing.Color.Black;
            this.plotSignal.IsContextMenu = true;
            this.plotSignal.IsLogScale = false;
            this.plotSignal.IsMoove = true;
            this.plotSignal.IsScale = true;
            this.plotSignal.IsShowXY = true;
            this.plotSignal.LabelX = "Время(отсчеты)";
            this.plotSignal.LabelY = "Значение сигнала";
            this.plotSignal.Location = new System.Drawing.Point(12, 390);
            this.plotSignal.Name = "plotSignal";
            this.plotSignal.Size = new System.Drawing.Size(1087, 267);
            this.plotSignal.TabIndex = 2;
            // 
            // scatter
            // 
            this.scatter.AutoScroll = true;
            this.scatter.BackColor = System.Drawing.Color.White;
            this.scatter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scatter.ChartName = "Распределение";
            this.scatter.ForeColor = System.Drawing.Color.Black;
            this.scatter.IsContextMenu = true;
            this.scatter.IsLogScale = false;
            this.scatter.IsMoove = true;
            this.scatter.IsScale = true;
            this.scatter.IsShowXY = true;
            this.scatter.LabelX = "x";
            this.scatter.LabelY = "y";
            this.scatter.Location = new System.Drawing.Point(642, 0);
            this.scatter.Name = "scatter";
            this.scatter.Size = new System.Drawing.Size(457, 383);
            this.scatter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Flubber", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Погладь песика:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1111, 665);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scatter);
            this.Controls.Add(this.plotSignal);
            this.Controls.Add(this.Classes);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Flubber", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "VectorTest";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer fps;
        private AI.Charts.Control.ChartVisual Classes;
        private AI.Charts.Control.ChartVisual plotSignal;
        private AI.Charts.Control.ChartVisual scatter;
        private System.Windows.Forms.Label label1;
    }
}

