namespace Final_Year_Project_Application
{
    partial class StartMenu
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
            this.btnLab1Timetable = new System.Windows.Forms.Button();
            this.btnLab2Timetable = new System.Windows.Forms.Button();
            this.btnLabClassesGen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLab1Timetable
            // 
            this.btnLab1Timetable.Location = new System.Drawing.Point(30, 11);
            this.btnLab1Timetable.Margin = new System.Windows.Forms.Padding(2);
            this.btnLab1Timetable.Name = "btnLab1Timetable";
            this.btnLab1Timetable.Size = new System.Drawing.Size(191, 110);
            this.btnLab1Timetable.TabIndex = 0;
            this.btnLab1Timetable.Text = "Lab 1 Timetable";
            this.btnLab1Timetable.UseVisualStyleBackColor = true;
            this.btnLab1Timetable.Click += new System.EventHandler(this.btnLab1Timetable_Click);
            // 
            // btnLab2Timetable
            // 
            this.btnLab2Timetable.Location = new System.Drawing.Point(254, 11);
            this.btnLab2Timetable.Margin = new System.Windows.Forms.Padding(2);
            this.btnLab2Timetable.Name = "btnLab2Timetable";
            this.btnLab2Timetable.Size = new System.Drawing.Size(191, 110);
            this.btnLab2Timetable.TabIndex = 1;
            this.btnLab2Timetable.Text = "Lab 2 Timetable";
            this.btnLab2Timetable.UseVisualStyleBackColor = true;
            this.btnLab2Timetable.Click += new System.EventHandler(this.btnLab2Timetable_Click);
            // 
            // btnLabClassesGen
            // 
            this.btnLabClassesGen.Location = new System.Drawing.Point(478, 11);
            this.btnLabClassesGen.Name = "btnLabClassesGen";
            this.btnLabClassesGen.Size = new System.Drawing.Size(191, 110);
            this.btnLabClassesGen.TabIndex = 2;
            this.btnLabClassesGen.Text = "Lab Classes Generation";
            this.btnLabClassesGen.UseVisualStyleBackColor = true;
            this.btnLabClassesGen.Click += new System.EventHandler(this.btnLabClassesGen_Click);
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 142);
            this.Controls.Add(this.btnLabClassesGen);
            this.Controls.Add(this.btnLab2Timetable);
            this.Controls.Add(this.btnLab1Timetable);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StartMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartMenu_FormClosing);
            this.Load += new System.EventHandler(this.StartMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLab1Timetable;
        private System.Windows.Forms.Button btnLab2Timetable;
        private System.Windows.Forms.Button btnLabClassesGen;
    }
}

