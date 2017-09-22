namespace Final_Year_Project_Application
{
    partial class ModuleTimetableGeneration
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
            this.components = new System.ComponentModel.Container();
            this.tblmodulesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fypdatabaseDataSet = new Final_Year_Project_Application.fypdatabaseDataSet();
            this.tblmodulesTableAdapter = new Final_Year_Project_Application.fypdatabaseDataSetTableAdapters.tblmodulesTableAdapter();
            this.tableAdapterManager = new Final_Year_Project_Application.fypdatabaseDataSetTableAdapters.TableAdapterManager();
            this.tblbookingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblbookingsTableAdapter = new Final_Year_Project_Application.fypdatabaseDataSetTableAdapters.tblbookingsTableAdapter();
            this.tblcomputersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblcomputersTableAdapter = new Final_Year_Project_Application.fypdatabaseDataSetTableAdapters.tblcomputersTableAdapter();
            this.tbllabsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbllabsTableAdapter = new Final_Year_Project_Application.fypdatabaseDataSetTableAdapters.tbllabsTableAdapter();
            this.tbltimeslotsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbltimeslotsTableAdapter = new Final_Year_Project_Application.fypdatabaseDataSetTableAdapters.tbltimeslotsTableAdapter();
            this.dsavage11DataSet = new Final_Year_Project_Application.dsavage11DataSet();
            this.tblbookingsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tblbookingsTableAdapter1 = new Final_Year_Project_Application.dsavage11DataSetTableAdapters.tblbookingsTableAdapter();
            this.tableAdapterManager1 = new Final_Year_Project_Application.dsavage11DataSetTableAdapters.TableAdapterManager();
            this.tblcomputersTableAdapter1 = new Final_Year_Project_Application.dsavage11DataSetTableAdapters.tblcomputersTableAdapter();
            this.tblmodulesTableAdapter1 = new Final_Year_Project_Application.dsavage11DataSetTableAdapters.tblmodulesTableAdapter();
            this.tbltimeslotsTableAdapter1 = new Final_Year_Project_Application.dsavage11DataSetTableAdapters.tbltimeslotsTableAdapter();
            this.tblcomputersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tblmodulesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tbltimeslotsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnRunCode = new System.Windows.Forms.Button();
            this.btnResetTheBookingTable = new System.Windows.Forms.Button();
            this.btnResetAndRunCode = new System.Windows.Forms.Button();
            this.btnBackToMenu = new System.Windows.Forms.Button();
            this.btnProgressTheWeek = new System.Windows.Forms.Button();
            this.txtModuleToDelete = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteModule = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCourseLevelToAdd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCourseCodeToAdd = new System.Windows.Forms.TextBox();
            this.btnAddModule = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStudentsToAdd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModuleToAdd = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFindClasses = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtModuleToFind = new System.Windows.Forms.TextBox();
            this.dgvModules = new System.Windows.Forms.DataGridView();
            this.idModulesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modulesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfStudentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblmodulesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fypdatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblbookingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcomputersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbllabsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbltimeslotsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsavage11DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblbookingsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcomputersBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblmodulesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbltimeslotsBindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModules)).BeginInit();
            this.SuspendLayout();
            // 
            // tblmodulesBindingSource
            // 
            this.tblmodulesBindingSource.DataMember = "tblmodules";
            this.tblmodulesBindingSource.DataSource = this.fypdatabaseDataSet;
            // 
            // fypdatabaseDataSet
            // 
            this.fypdatabaseDataSet.DataSetName = "fypdatabaseDataSet";
            this.fypdatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblmodulesTableAdapter
            // 
            this.tblmodulesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tblbookingsTableAdapter = null;
            this.tableAdapterManager.tblcomputersTableAdapter = null;
            this.tableAdapterManager.tbllabsTableAdapter = null;
            this.tableAdapterManager.tblmodulesTableAdapter = this.tblmodulesTableAdapter;
            this.tableAdapterManager.tbltimeslotsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Final_Year_Project_Application.fypdatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tblbookingsBindingSource
            // 
            this.tblbookingsBindingSource.DataMember = "tblbookings";
            this.tblbookingsBindingSource.DataSource = this.fypdatabaseDataSet;
            // 
            // tblbookingsTableAdapter
            // 
            this.tblbookingsTableAdapter.ClearBeforeFill = true;
            // 
            // tblcomputersBindingSource
            // 
            this.tblcomputersBindingSource.DataMember = "tblcomputers";
            this.tblcomputersBindingSource.DataSource = this.fypdatabaseDataSet;
            // 
            // tblcomputersTableAdapter
            // 
            this.tblcomputersTableAdapter.ClearBeforeFill = true;
            // 
            // tbllabsBindingSource
            // 
            this.tbllabsBindingSource.DataMember = "tbllabs";
            this.tbllabsBindingSource.DataSource = this.fypdatabaseDataSet;
            // 
            // tbllabsTableAdapter
            // 
            this.tbllabsTableAdapter.ClearBeforeFill = true;
            // 
            // tbltimeslotsBindingSource
            // 
            this.tbltimeslotsBindingSource.DataMember = "tbltimeslots";
            this.tbltimeslotsBindingSource.DataSource = this.fypdatabaseDataSet;
            // 
            // tbltimeslotsTableAdapter
            // 
            this.tbltimeslotsTableAdapter.ClearBeforeFill = true;
            // 
            // dsavage11DataSet
            // 
            this.dsavage11DataSet.DataSetName = "dsavage11DataSet";
            this.dsavage11DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblbookingsBindingSource1
            // 
            this.tblbookingsBindingSource1.DataMember = "tblbookings";
            this.tblbookingsBindingSource1.DataSource = this.dsavage11DataSet;
            // 
            // tblbookingsTableAdapter1
            // 
            this.tblbookingsTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.tblbookingsTableAdapter = this.tblbookingsTableAdapter1;
            this.tableAdapterManager1.tblcomputersTableAdapter = this.tblcomputersTableAdapter1;
            this.tableAdapterManager1.tbllabsTableAdapter = null;
            this.tableAdapterManager1.tblmodulesTableAdapter = this.tblmodulesTableAdapter1;
            this.tableAdapterManager1.tbltimeslotsTableAdapter = this.tbltimeslotsTableAdapter1;
            this.tableAdapterManager1.UpdateOrder = Final_Year_Project_Application.dsavage11DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tblcomputersTableAdapter1
            // 
            this.tblcomputersTableAdapter1.ClearBeforeFill = true;
            // 
            // tblmodulesTableAdapter1
            // 
            this.tblmodulesTableAdapter1.ClearBeforeFill = true;
            // 
            // tbltimeslotsTableAdapter1
            // 
            this.tbltimeslotsTableAdapter1.ClearBeforeFill = true;
            // 
            // tblcomputersBindingSource1
            // 
            this.tblcomputersBindingSource1.DataMember = "tblcomputers";
            this.tblcomputersBindingSource1.DataSource = this.dsavage11DataSet;
            // 
            // tblmodulesBindingSource1
            // 
            this.tblmodulesBindingSource1.DataMember = "tblmodules";
            this.tblmodulesBindingSource1.DataSource = this.dsavage11DataSet;
            // 
            // tbltimeslotsBindingSource1
            // 
            this.tbltimeslotsBindingSource1.DataMember = "tbltimeslots";
            this.tbltimeslotsBindingSource1.DataSource = this.dsavage11DataSet;
            // 
            // btnRunCode
            // 
            this.btnRunCode.Location = new System.Drawing.Point(62, 34);
            this.btnRunCode.Name = "btnRunCode";
            this.btnRunCode.Size = new System.Drawing.Size(151, 57);
            this.btnRunCode.TabIndex = 4;
            this.btnRunCode.Text = "Run The Code";
            this.btnRunCode.UseVisualStyleBackColor = true;
            this.btnRunCode.Click += new System.EventHandler(this.btnRunCode_Click);
            // 
            // btnResetTheBookingTable
            // 
            this.btnResetTheBookingTable.Location = new System.Drawing.Point(219, 34);
            this.btnResetTheBookingTable.Name = "btnResetTheBookingTable";
            this.btnResetTheBookingTable.Size = new System.Drawing.Size(177, 57);
            this.btnResetTheBookingTable.TabIndex = 5;
            this.btnResetTheBookingTable.Text = "Reset The Booking Table";
            this.btnResetTheBookingTable.UseVisualStyleBackColor = true;
            this.btnResetTheBookingTable.Click += new System.EventHandler(this.btnResetTheBookingTable_Click);
            // 
            // btnResetAndRunCode
            // 
            this.btnResetAndRunCode.Location = new System.Drawing.Point(62, 97);
            this.btnResetAndRunCode.Name = "btnResetAndRunCode";
            this.btnResetAndRunCode.Size = new System.Drawing.Size(151, 56);
            this.btnResetAndRunCode.TabIndex = 6;
            this.btnResetAndRunCode.Text = "Clear the Booking Table of classes and generate new classes";
            this.btnResetAndRunCode.UseVisualStyleBackColor = true;
            this.btnResetAndRunCode.Click += new System.EventHandler(this.btnResetAndRun_Click);
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.Location = new System.Drawing.Point(705, 484);
            this.btnBackToMenu.Name = "btnBackToMenu";
            this.btnBackToMenu.Size = new System.Drawing.Size(119, 53);
            this.btnBackToMenu.TabIndex = 7;
            this.btnBackToMenu.Text = "Back to Menu";
            this.btnBackToMenu.UseVisualStyleBackColor = true;
            this.btnBackToMenu.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnProgressTheWeek
            // 
            this.btnProgressTheWeek.Location = new System.Drawing.Point(219, 100);
            this.btnProgressTheWeek.Name = "btnProgressTheWeek";
            this.btnProgressTheWeek.Size = new System.Drawing.Size(177, 53);
            this.btnProgressTheWeek.TabIndex = 8;
            this.btnProgressTheWeek.Text = "Progress the week";
            this.btnProgressTheWeek.UseVisualStyleBackColor = true;
            this.btnProgressTheWeek.Click += new System.EventHandler(this.btnProgressTheWeek_Click);
            // 
            // txtModuleToDelete
            // 
            this.txtModuleToDelete.Location = new System.Drawing.Point(143, 27);
            this.txtModuleToDelete.Name = "txtModuleToDelete";
            this.txtModuleToDelete.Size = new System.Drawing.Size(154, 20);
            this.txtModuleToDelete.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Name of module to delete:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteModule);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtModuleToDelete);
            this.groupBox1.Location = new System.Drawing.Point(62, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 91);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delete A Module";
            // 
            // btnDeleteModule
            // 
            this.btnDeleteModule.Location = new System.Drawing.Point(157, 53);
            this.btnDeleteModule.Name = "btnDeleteModule";
            this.btnDeleteModule.Size = new System.Drawing.Size(119, 27);
            this.btnDeleteModule.TabIndex = 14;
            this.btnDeleteModule.Text = "Delete Module";
            this.btnDeleteModule.UseVisualStyleBackColor = true;
            this.btnDeleteModule.Click += new System.EventHandler(this.btnDeleteModule_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCourseLevelToAdd);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtCourseCodeToAdd);
            this.groupBox2.Controls.Add(this.btnAddModule);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtStudentsToAdd);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtModuleToAdd);
            this.groupBox2.Location = new System.Drawing.Point(62, 448);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(623, 118);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add New Module";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Course Level:";
            // 
            // txtCourseLevelToAdd
            // 
            this.txtCourseLevelToAdd.Location = new System.Drawing.Point(444, 53);
            this.txtCourseLevelToAdd.Name = "txtCourseLevelToAdd";
            this.txtCourseLevelToAdd.Size = new System.Drawing.Size(154, 20);
            this.txtCourseLevelToAdd.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(307, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Course code:";
            // 
            // txtCourseCodeToAdd
            // 
            this.txtCourseCodeToAdd.Location = new System.Drawing.Point(444, 27);
            this.txtCourseCodeToAdd.Name = "txtCourseCodeToAdd";
            this.txtCourseCodeToAdd.Size = new System.Drawing.Size(154, 20);
            this.txtCourseCodeToAdd.TabIndex = 16;
            // 
            // btnAddModule
            // 
            this.btnAddModule.Location = new System.Drawing.Point(249, 79);
            this.btnAddModule.Name = "btnAddModule";
            this.btnAddModule.Size = new System.Drawing.Size(119, 27);
            this.btnAddModule.TabIndex = 15;
            this.btnAddModule.Text = "Add Module";
            this.btnAddModule.UseVisualStyleBackColor = true;
            this.btnAddModule.Click += new System.EventHandler(this.btnAddModule_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Number of students:";
            // 
            // txtStudentsToAdd
            // 
            this.txtStudentsToAdd.Location = new System.Drawing.Point(143, 53);
            this.txtStudentsToAdd.Name = "txtStudentsToAdd";
            this.txtStudentsToAdd.Size = new System.Drawing.Size(154, 20);
            this.txtStudentsToAdd.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Name of module to add:";
            // 
            // txtModuleToAdd
            // 
            this.txtModuleToAdd.Location = new System.Drawing.Point(143, 27);
            this.txtModuleToAdd.Name = "txtModuleToAdd";
            this.txtModuleToAdd.Size = new System.Drawing.Size(154, 20);
            this.txtModuleToAdd.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFindClasses);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtModuleToFind);
            this.groupBox3.Location = new System.Drawing.Point(62, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(334, 91);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Find A Modules Classes";
            // 
            // btnFindClasses
            // 
            this.btnFindClasses.Location = new System.Drawing.Point(157, 53);
            this.btnFindClasses.Name = "btnFindClasses";
            this.btnFindClasses.Size = new System.Drawing.Size(119, 27);
            this.btnFindClasses.TabIndex = 14;
            this.btnFindClasses.Text = "Find Classes";
            this.btnFindClasses.UseVisualStyleBackColor = true;
            this.btnFindClasses.Click += new System.EventHandler(this.btnFindClasses_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Name of module to find:";
            // 
            // txtModuleToFind
            // 
            this.txtModuleToFind.Location = new System.Drawing.Point(143, 27);
            this.txtModuleToFind.Name = "txtModuleToFind";
            this.txtModuleToFind.Size = new System.Drawing.Size(154, 20);
            this.txtModuleToFind.TabIndex = 10;
            // 
            // dgvModules
            // 
            this.dgvModules.AllowUserToAddRows = false;
            this.dgvModules.AllowUserToDeleteRows = false;
            this.dgvModules.AutoGenerateColumns = false;
            this.dgvModules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idModulesDataGridViewTextBoxColumn,
            this.modulesDataGridViewTextBoxColumn,
            this.numberOfStudentsDataGridViewTextBoxColumn,
            this.levelDataGridViewTextBoxColumn});
            this.dgvModules.DataSource = this.tblmodulesBindingSource1;
            this.dgvModules.Location = new System.Drawing.Point(411, 34);
            this.dgvModules.Name = "dgvModules";
            this.dgvModules.ReadOnly = true;
            this.dgvModules.Size = new System.Drawing.Size(586, 408);
            this.dgvModules.TabIndex = 17;
            // 
            // idModulesDataGridViewTextBoxColumn
            // 
            this.idModulesDataGridViewTextBoxColumn.DataPropertyName = "idModules";
            this.idModulesDataGridViewTextBoxColumn.HeaderText = "idModules";
            this.idModulesDataGridViewTextBoxColumn.Name = "idModulesDataGridViewTextBoxColumn";
            this.idModulesDataGridViewTextBoxColumn.ReadOnly = true;
            this.idModulesDataGridViewTextBoxColumn.Width = 80;
            // 
            // modulesDataGridViewTextBoxColumn
            // 
            this.modulesDataGridViewTextBoxColumn.DataPropertyName = "Modules";
            this.modulesDataGridViewTextBoxColumn.HeaderText = "Modules";
            this.modulesDataGridViewTextBoxColumn.Name = "modulesDataGridViewTextBoxColumn";
            this.modulesDataGridViewTextBoxColumn.ReadOnly = true;
            this.modulesDataGridViewTextBoxColumn.Width = 300;
            // 
            // numberOfStudentsDataGridViewTextBoxColumn
            // 
            this.numberOfStudentsDataGridViewTextBoxColumn.DataPropertyName = "Number of Students";
            this.numberOfStudentsDataGridViewTextBoxColumn.HeaderText = "Number of Students";
            this.numberOfStudentsDataGridViewTextBoxColumn.Name = "numberOfStudentsDataGridViewTextBoxColumn";
            this.numberOfStudentsDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberOfStudentsDataGridViewTextBoxColumn.Width = 70;
            // 
            // levelDataGridViewTextBoxColumn
            // 
            this.levelDataGridViewTextBoxColumn.DataPropertyName = "Level";
            this.levelDataGridViewTextBoxColumn.HeaderText = "Level";
            this.levelDataGridViewTextBoxColumn.Name = "levelDataGridViewTextBoxColumn";
            this.levelDataGridViewTextBoxColumn.ReadOnly = true;
            this.levelDataGridViewTextBoxColumn.Width = 50;
            // 
            // ModuleTimetableGeneration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 578);
            this.Controls.Add(this.dgvModules);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnProgressTheWeek);
            this.Controls.Add(this.btnBackToMenu);
            this.Controls.Add(this.btnResetAndRunCode);
            this.Controls.Add(this.btnResetTheBookingTable);
            this.Controls.Add(this.btnRunCode);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ModuleTimetableGeneration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModuleTimetableGeneration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModuleTimetableGeneration_FormClosing);
            this.Load += new System.EventHandler(this.ModuleTimetableGeneration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblmodulesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fypdatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblbookingsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcomputersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbllabsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbltimeslotsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsavage11DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblbookingsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcomputersBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblmodulesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbltimeslotsBindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private fypdatabaseDataSet fypdatabaseDataSet;
        private System.Windows.Forms.BindingSource tblmodulesBindingSource;
        private fypdatabaseDataSetTableAdapters.tblmodulesTableAdapter tblmodulesTableAdapter;
        private fypdatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource tblbookingsBindingSource;
        private fypdatabaseDataSetTableAdapters.tblbookingsTableAdapter tblbookingsTableAdapter;
        private System.Windows.Forms.BindingSource tblcomputersBindingSource;
        private fypdatabaseDataSetTableAdapters.tblcomputersTableAdapter tblcomputersTableAdapter;
        private System.Windows.Forms.BindingSource tbllabsBindingSource;
        private fypdatabaseDataSetTableAdapters.tbllabsTableAdapter tbllabsTableAdapter;
        private System.Windows.Forms.BindingSource tbltimeslotsBindingSource;
        private fypdatabaseDataSetTableAdapters.tbltimeslotsTableAdapter tbltimeslotsTableAdapter;
        private dsavage11DataSet dsavage11DataSet;
        private System.Windows.Forms.BindingSource tblbookingsBindingSource1;
        private dsavage11DataSetTableAdapters.tblbookingsTableAdapter tblbookingsTableAdapter1;
        private dsavage11DataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private dsavage11DataSetTableAdapters.tblcomputersTableAdapter tblcomputersTableAdapter1;
        private System.Windows.Forms.BindingSource tblcomputersBindingSource1;
        private dsavage11DataSetTableAdapters.tblmodulesTableAdapter tblmodulesTableAdapter1;
        private System.Windows.Forms.BindingSource tblmodulesBindingSource1;
        private dsavage11DataSetTableAdapters.tbltimeslotsTableAdapter tbltimeslotsTableAdapter1;
        private System.Windows.Forms.BindingSource tbltimeslotsBindingSource1;
        private System.Windows.Forms.Button btnRunCode;
        private System.Windows.Forms.Button btnResetTheBookingTable;
        private System.Windows.Forms.Button btnResetAndRunCode;
        private System.Windows.Forms.Button btnBackToMenu;
        private System.Windows.Forms.Button btnProgressTheWeek;
        private System.Windows.Forms.TextBox txtModuleToDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteModule;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddModule;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStudentsToAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtModuleToAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCourseLevelToAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCourseCodeToAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFindClasses;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtModuleToFind;
        private System.Windows.Forms.DataGridView dgvModules;
        private System.Windows.Forms.DataGridViewTextBoxColumn idModulesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfStudentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
    }
}