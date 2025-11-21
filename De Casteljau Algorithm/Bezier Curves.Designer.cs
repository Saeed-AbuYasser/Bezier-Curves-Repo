namespace Graphic
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlDrawSquar = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnSetPoints = new System.Windows.Forms.Button();
            this.lblPoints = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDrawSquar
            // 
            this.pnlDrawSquar.AutoScroll = true;
            this.pnlDrawSquar.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlDrawSquar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDrawSquar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDrawSquar.Location = new System.Drawing.Point(0, 0);
            this.pnlDrawSquar.Name = "pnlDrawSquar";
            this.pnlDrawSquar.Size = new System.Drawing.Size(1069, 624);
            this.pnlDrawSquar.TabIndex = 0;
            this.pnlDrawSquar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlDrawSquar_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnDraw);
            this.groupBox1.Controls.Add(this.btnSetPoints);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 624);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Script MT Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(62, 231);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(133, 63);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDraw
            // 
            this.btnDraw.Font = new System.Drawing.Font("Script MT Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDraw.Location = new System.Drawing.Point(44, 138);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(171, 63);
            this.btnDraw.TabIndex = 1;
            this.btnDraw.Text = "De Casteljau";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnSetPoints
            // 
            this.btnSetPoints.Font = new System.Drawing.Font("Script MT Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetPoints.Location = new System.Drawing.Point(62, 45);
            this.btnSetPoints.Name = "btnSetPoints";
            this.btnSetPoints.Size = new System.Drawing.Size(133, 63);
            this.btnSetPoints.TabIndex = 0;
            this.btnSetPoints.Text = "Set Points";
            this.btnSetPoints.UseVisualStyleBackColor = true;
            this.btnSetPoints.Click += new System.EventHandler(this.btnSetPoints_Click);
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Location = new System.Drawing.Point(426, 69);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(13, 13);
            this.lblPoints.TabIndex = 0;
            this.lblPoints.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 624);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlDrawSquar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Bezier Curves";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDrawSquar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnSetPoints;
        private System.Windows.Forms.Label lblPoints;
    }
}

