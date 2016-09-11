namespace DatabaseBasicTests
{
    partial class MainForm
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
            this.grpTestSelection = new System.Windows.Forms.GroupBox();
            this.cbbDatabaseCategory = new System.Windows.Forms.ComboBox();
            this.cbbDatabase = new System.Windows.Forms.ComboBox();
            this.lblDatabaseCategory = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblTestSet = new System.Windows.Forms.Label();
            this.cbbTestSet = new System.Windows.Forms.ComboBox();
            this.lblConnectionType = new System.Windows.Forms.Label();
            this.cbbConnectionType = new System.Windows.Forms.ComboBox();
            this.lblTest = new System.Windows.Forms.Label();
            this.cbbTest = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.grpTestSettings = new System.Windows.Forms.GroupBox();
            this.grpTestSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTestSelection
            // 
            this.grpTestSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpTestSelection.Controls.Add(this.btnTest);
            this.grpTestSelection.Controls.Add(this.lblTest);
            this.grpTestSelection.Controls.Add(this.cbbTest);
            this.grpTestSelection.Controls.Add(this.lblConnectionType);
            this.grpTestSelection.Controls.Add(this.cbbConnectionType);
            this.grpTestSelection.Controls.Add(this.lblTestSet);
            this.grpTestSelection.Controls.Add(this.cbbTestSet);
            this.grpTestSelection.Controls.Add(this.lblDatabase);
            this.grpTestSelection.Controls.Add(this.lblDatabaseCategory);
            this.grpTestSelection.Controls.Add(this.cbbDatabase);
            this.grpTestSelection.Controls.Add(this.cbbDatabaseCategory);
            this.grpTestSelection.Location = new System.Drawing.Point(12, 2);
            this.grpTestSelection.Name = "grpTestSelection";
            this.grpTestSelection.Size = new System.Drawing.Size(299, 640);
            this.grpTestSelection.TabIndex = 0;
            this.grpTestSelection.TabStop = false;
            this.grpTestSelection.Text = "Please Select a Test:";
            // 
            // cbbDatabaseCategory
            // 
            this.cbbDatabaseCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDatabaseCategory.FormattingEnabled = true;
            this.cbbDatabaseCategory.Location = new System.Drawing.Point(12, 38);
            this.cbbDatabaseCategory.Name = "cbbDatabaseCategory";
            this.cbbDatabaseCategory.Size = new System.Drawing.Size(281, 21);
            this.cbbDatabaseCategory.TabIndex = 0;
            this.cbbDatabaseCategory.SelectedIndexChanged += new System.EventHandler(this.cbbDatabaseCategory_SelectedIndexChanged);
            // 
            // cbbDatabase
            // 
            this.cbbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDatabase.FormattingEnabled = true;
            this.cbbDatabase.Location = new System.Drawing.Point(12, 92);
            this.cbbDatabase.Name = "cbbDatabase";
            this.cbbDatabase.Size = new System.Drawing.Size(281, 21);
            this.cbbDatabase.TabIndex = 1;
            this.cbbDatabase.SelectedIndexChanged += new System.EventHandler(this.cbbDatabase_SelectedIndexChanged);
            // 
            // lblDatabaseCategory
            // 
            this.lblDatabaseCategory.AutoSize = true;
            this.lblDatabaseCategory.Location = new System.Drawing.Point(9, 22);
            this.lblDatabaseCategory.Name = "lblDatabaseCategory";
            this.lblDatabaseCategory.Size = new System.Drawing.Size(101, 13);
            this.lblDatabaseCategory.TabIndex = 2;
            this.lblDatabaseCategory.Text = "Database Category:";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(9, 76);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(56, 13);
            this.lblDatabase.TabIndex = 3;
            this.lblDatabase.Text = "Database:";
            // 
            // lblTestSet
            // 
            this.lblTestSet.AutoSize = true;
            this.lblTestSet.Location = new System.Drawing.Point(9, 130);
            this.lblTestSet.Name = "lblTestSet";
            this.lblTestSet.Size = new System.Drawing.Size(50, 13);
            this.lblTestSet.TabIndex = 5;
            this.lblTestSet.Text = "Test Set:";
            // 
            // cbbTestSet
            // 
            this.cbbTestSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTestSet.FormattingEnabled = true;
            this.cbbTestSet.Location = new System.Drawing.Point(12, 146);
            this.cbbTestSet.Name = "cbbTestSet";
            this.cbbTestSet.Size = new System.Drawing.Size(281, 21);
            this.cbbTestSet.TabIndex = 4;
            this.cbbTestSet.SelectedIndexChanged += new System.EventHandler(this.cbbTestSet_SelectedIndexChanged);
            // 
            // lblConnectionType
            // 
            this.lblConnectionType.AutoSize = true;
            this.lblConnectionType.Location = new System.Drawing.Point(9, 184);
            this.lblConnectionType.Name = "lblConnectionType";
            this.lblConnectionType.Size = new System.Drawing.Size(91, 13);
            this.lblConnectionType.TabIndex = 7;
            this.lblConnectionType.Text = "Connection Type:";
            // 
            // cbbConnectionType
            // 
            this.cbbConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbConnectionType.FormattingEnabled = true;
            this.cbbConnectionType.Location = new System.Drawing.Point(12, 200);
            this.cbbConnectionType.Name = "cbbConnectionType";
            this.cbbConnectionType.Size = new System.Drawing.Size(281, 21);
            this.cbbConnectionType.TabIndex = 6;
            this.cbbConnectionType.SelectedIndexChanged += new System.EventHandler(this.cbbConnectionType_SelectedIndexChanged);
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(9, 238);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(31, 13);
            this.lblTest.TabIndex = 9;
            this.lblTest.Text = "Test:";
            // 
            // cbbTest
            // 
            this.cbbTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTest.FormattingEnabled = true;
            this.cbbTest.Location = new System.Drawing.Point(12, 254);
            this.cbbTest.Name = "cbbTest";
            this.cbbTest.Size = new System.Drawing.Size(281, 21);
            this.cbbTest.TabIndex = 8;
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.ForeColor = System.Drawing.Color.Maroon;
            this.btnTest.Location = new System.Drawing.Point(58, 347);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(184, 144);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // grpTestSettings
            // 
            this.grpTestSettings.Location = new System.Drawing.Point(328, 2);
            this.grpTestSettings.Name = "grpTestSettings";
            this.grpTestSettings.Size = new System.Drawing.Size(440, 249);
            this.grpTestSettings.TabIndex = 1;
            this.grpTestSettings.TabStop = false;
            this.grpTestSettings.Text = "Test Settings";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 654);
            this.Controls.Add(this.grpTestSettings);
            this.Controls.Add(this.grpTestSelection);
            this.Name = "MainForm";
            this.Text = "Database Basic Test";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpTestSelection.ResumeLayout(false);
            this.grpTestSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTestSelection;
        private System.Windows.Forms.ComboBox cbbDatabaseCategory;
        private System.Windows.Forms.ComboBox cbbDatabase;
        private System.Windows.Forms.Label lblDatabaseCategory;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblTestSet;
        private System.Windows.Forms.ComboBox cbbTestSet;
        private System.Windows.Forms.Label lblConnectionType;
        private System.Windows.Forms.ComboBox cbbConnectionType;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.ComboBox cbbTest;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox grpTestSettings;
    }
}

