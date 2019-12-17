namespace scanner
{
    partial class Output
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
            this.btn_back = new System.Windows.Forms.Button();
            this.groupBox_processDetail = new System.Windows.Forms.Panel();
            this.lbl_priority_r = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_p1 = new System.Windows.Forms.Label();
            this.lbl_burst_l = new System.Windows.Forms.Label();
            this.lbl_arrival_l = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_processDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Transparent;
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.btn_back.Location = new System.Drawing.Point(694, 400);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(85, 38);
            this.btn_back.TabIndex = 58;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.Btn_back_Click);
            // 
            // groupBox_processDetail
            // 
            this.groupBox_processDetail.AutoScroll = true;
            this.groupBox_processDetail.AutoScrollMargin = new System.Drawing.Size(0, 50);
            this.groupBox_processDetail.BackColor = System.Drawing.Color.White;
            this.groupBox_processDetail.Controls.Add(this.label2);
            this.groupBox_processDetail.Controls.Add(this.lbl_priority_r);
            this.groupBox_processDetail.Controls.Add(this.label1);
            this.groupBox_processDetail.Controls.Add(this.lbl_p1);
            this.groupBox_processDetail.Controls.Add(this.lbl_burst_l);
            this.groupBox_processDetail.Controls.Add(this.lbl_arrival_l);
            this.groupBox_processDetail.Location = new System.Drawing.Point(100, 12);
            this.groupBox_processDetail.Name = "groupBox_processDetail";
            this.groupBox_processDetail.Size = new System.Drawing.Size(590, 382);
            this.groupBox_processDetail.TabIndex = 59;
            // 
            // lbl_priority_r
            // 
            this.lbl_priority_r.AutoSize = true;
            this.lbl_priority_r.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_priority_r.ForeColor = System.Drawing.Color.Gray;
            this.lbl_priority_r.Location = new System.Drawing.Point(177, 39);
            this.lbl_priority_r.Name = "lbl_priority_r";
            this.lbl_priority_r.Size = new System.Drawing.Size(246, 21);
            this.lbl_priority_r.TabIndex = 53;
            this.lbl_priority_r.Text = "This output represent tiny scanner";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Goudy Old Style", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(194, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 39);
            this.label1.TabIndex = 52;
            this.label1.Text = "Code Tokens";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // lbl_p1
            // 
            this.lbl_p1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lbl_p1.ForeColor = System.Drawing.Color.Black;
            this.lbl_p1.Location = new System.Drawing.Point(156, 104);
            this.lbl_p1.Name = "lbl_p1";
            this.lbl_p1.Size = new System.Drawing.Size(125, 35);
            this.lbl_p1.TabIndex = 43;
            this.lbl_p1.Text = "Hole 1";
            this.lbl_p1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_p1.Visible = false;
            // 
            // lbl_burst_l
            // 
            this.lbl_burst_l.AutoSize = true;
            this.lbl_burst_l.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_burst_l.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_burst_l.Location = new System.Drawing.Point(364, 79);
            this.lbl_burst_l.Name = "lbl_burst_l";
            this.lbl_burst_l.Size = new System.Drawing.Size(59, 25);
            this.lbl_burst_l.TabIndex = 12;
            this.lbl_burst_l.Text = "Value";
            // 
            // lbl_arrival_l
            // 
            this.lbl_arrival_l.AutoSize = true;
            this.lbl_arrival_l.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_arrival_l.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_arrival_l.Location = new System.Drawing.Point(186, 79);
            this.lbl_arrival_l.Name = "lbl_arrival_l";
            this.lbl_arrival_l.Size = new System.Drawing.Size(61, 25);
            this.lbl_arrival_l.TabIndex = 24;
            this.lbl_arrival_l.Text = "Token";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(324, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 35);
            this.label2.TabIndex = 54;
            this.label2.Text = "Hole 1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::scanner.Properties.Resources.BG_Blur;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox_processDetail);
            this.Controls.Add(this.btn_back);
            this.Name = "Output";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Output";
            this.groupBox_processDetail.ResumeLayout(false);
            this.groupBox_processDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Panel groupBox_processDetail;
        private System.Windows.Forms.Label lbl_priority_r;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_p1;
        private System.Windows.Forms.Label lbl_burst_l;
        private System.Windows.Forms.Label lbl_arrival_l;
        private System.Windows.Forms.Label label2;
    }
}