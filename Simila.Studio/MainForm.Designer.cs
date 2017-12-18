namespace Simila.Studio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPageProfile = new System.Windows.Forms.TabPage();
            this.groupBoxDirtyWords = new System.Windows.Forms.GroupBox();
            this.textBoxDirtyWords = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tabControlProfile = new System.Windows.Forms.TabControl();
            this.tabPageFindSimilars = new System.Windows.Forms.TabPage();
            this.progressBarCalcStatus = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.similarityResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.otherSimilarsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.timerProgressUpdater = new System.Windows.Forms.Timer(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.newToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.similarTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.similarityRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Original = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.similarTextDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.similarityRateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxCommonCharMistakes = new System.Windows.Forms.GroupBox();
            this.dataGridViewCharMistakeInstance = new System.Windows.Forms.DataGridView();
            this.charMistakeInstanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.leftDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.similarityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxCommonWordMistakes = new System.Windows.Forms.GroupBox();
            this.dataGridViewWordMistakeInstance = new System.Windows.Forms.DataGridView();
            this.wordMistakeInstanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.leftDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.similarityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabPageProfile.SuspendLayout();
            this.groupBoxDirtyWords.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControlProfile.SuspendLayout();
            this.tabPageFindSimilars.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.similarityResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherSimilarsBindingSource)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.groupBoxCommonCharMistakes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCharMistakeInstance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charMistakeInstanceBindingSource)).BeginInit();
            this.groupBoxCommonWordMistakes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWordMistakeInstance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordMistakeInstanceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPageProfile
            // 
            this.tabPageProfile.Controls.Add(this.groupBoxCommonWordMistakes);
            this.tabPageProfile.Controls.Add(this.groupBoxCommonCharMistakes);
            this.tabPageProfile.Controls.Add(this.groupBoxDirtyWords);
            this.tabPageProfile.Controls.Add(this.toolStrip1);
            this.tabPageProfile.Location = new System.Drawing.Point(4, 22);
            this.tabPageProfile.Name = "tabPageProfile";
            this.tabPageProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProfile.Size = new System.Drawing.Size(1055, 731);
            this.tabPageProfile.TabIndex = 1;
            this.tabPageProfile.Text = "Profile";
            this.tabPageProfile.UseVisualStyleBackColor = true;
            // 
            // groupBoxDirtyWords
            // 
            this.groupBoxDirtyWords.Controls.Add(this.textBoxDirtyWords);
            this.groupBoxDirtyWords.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxDirtyWords.Location = new System.Drawing.Point(3, 28);
            this.groupBoxDirtyWords.Name = "groupBoxDirtyWords";
            this.groupBoxDirtyWords.Size = new System.Drawing.Size(147, 700);
            this.groupBoxDirtyWords.TabIndex = 2;
            this.groupBoxDirtyWords.TabStop = false;
            this.groupBoxDirtyWords.Text = "Dirty words to clear first:";
            // 
            // textBoxDirtyWords
            // 
            this.textBoxDirtyWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDirtyWords.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxDirtyWords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDirtyWords.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDirtyWords.Location = new System.Drawing.Point(8, 19);
            this.textBoxDirtyWords.Name = "textBoxDirtyWords";
            this.textBoxDirtyWords.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxDirtyWords.Size = new System.Drawing.Size(133, 675);
            this.textBoxDirtyWords.TabIndex = 0;
            this.textBoxDirtyWords.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton1,
            this.openToolStripButton1,
            this.saveToolStripButton1,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1049, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tabControlProfile
            // 
            this.tabControlProfile.Controls.Add(this.tabPageProfile);
            this.tabControlProfile.Controls.Add(this.tabPageFindSimilars);
            this.tabControlProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlProfile.Location = new System.Drawing.Point(0, 0);
            this.tabControlProfile.Name = "tabControlProfile";
            this.tabControlProfile.SelectedIndex = 0;
            this.tabControlProfile.Size = new System.Drawing.Size(1063, 757);
            this.tabControlProfile.TabIndex = 2;
            // 
            // tabPageFindSimilars
            // 
            this.tabPageFindSimilars.Controls.Add(this.progressBarCalcStatus);
            this.tabPageFindSimilars.Controls.Add(this.toolStrip2);
            this.tabPageFindSimilars.Controls.Add(this.panel2);
            this.tabPageFindSimilars.Location = new System.Drawing.Point(4, 22);
            this.tabPageFindSimilars.Name = "tabPageFindSimilars";
            this.tabPageFindSimilars.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFindSimilars.Size = new System.Drawing.Size(1055, 731);
            this.tabPageFindSimilars.TabIndex = 0;
            this.tabPageFindSimilars.Text = "Find Similars";
            this.tabPageFindSimilars.UseVisualStyleBackColor = true;
            // 
            // progressBarCalcStatus
            // 
            this.progressBarCalcStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBarCalcStatus.Location = new System.Drawing.Point(3, 28);
            this.progressBarCalcStatus.Name = "progressBarCalcStatus";
            this.progressBarCalcStatus.Size = new System.Drawing.Size(1049, 23);
            this.progressBarCalcStatus.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel2.Size = new System.Drawing.Size(1046, 673);
            this.panel2.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(1046, 673);
            this.splitContainer1.SplitterDistance = 712;
            this.splitContainer1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.similarTextDataGridViewTextBoxColumn,
            this.similarityRateDataGridViewTextBoxColumn,
            this.Original,
            this.Column1});
            this.dataGridView1.DataSource = this.similarityResultBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(712, 673);
            this.dataGridView1.TabIndex = 2;
            // 
            // similarityResultBindingSource
            // 
            this.similarityResultBindingSource.DataSource = typeof(SimilarityResult);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.similarTextDataGridViewTextBoxColumn1,
            this.similarityRateDataGridViewTextBoxColumn1});
            this.dataGridView2.DataSource = this.otherSimilarsBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView2.Size = new System.Drawing.Size(330, 673);
            this.dataGridView2.TabIndex = 0;
            // 
            // otherSimilarsBindingSource
            // 
            this.otherSimilarsBindingSource.DataMember = "OtherSimilars";
            this.otherSimilarsBindingSource.DataSource = this.similarityResultBindingSource;
            // 
            // listBoxLog
            // 
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(1063, 0);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(218, 757);
            this.listBoxLog.TabIndex = 0;
            // 
            // timerProgressUpdater
            // 
            this.timerProgressUpdater.Enabled = true;
            this.timerProgressUpdater.Interval = 2000;
            this.timerProgressUpdater.Tick += new System.EventHandler(this.timerProgressUpdater_Tick);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1049, 25);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // newToolStripButton1
            // 
            this.newToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton1.Image")));
            this.newToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton1.Name = "newToolStripButton1";
            this.newToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton1.Text = "&New";
            // 
            // openToolStripButton1
            // 
            this.openToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton1.Image")));
            this.openToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton1.Name = "openToolStripButton1";
            this.openToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton1.Text = "&Open";
            this.openToolStripButton1.Click += new System.EventHandler(this.toolStripButtonLoad_Click);
            // 
            // saveToolStripButton1
            // 
            this.saveToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton1.Image")));
            this.saveToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton1.Name = "saveToolStripButton1";
            this.saveToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton1.Text = "&Save";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "OriginalText";
            this.Column2.HeaderText = "Original Text";
            this.Column2.Name = "Column2";
            this.Column2.Width = 350;
            // 
            // similarTextDataGridViewTextBoxColumn
            // 
            this.similarTextDataGridViewTextBoxColumn.DataPropertyName = "SimilarText";
            this.similarTextDataGridViewTextBoxColumn.HeaderText = "Similar Text";
            this.similarTextDataGridViewTextBoxColumn.Name = "similarTextDataGridViewTextBoxColumn";
            this.similarTextDataGridViewTextBoxColumn.Width = 350;
            // 
            // similarityRateDataGridViewTextBoxColumn
            // 
            this.similarityRateDataGridViewTextBoxColumn.DataPropertyName = "SimilarityRate";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.similarityRateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.similarityRateDataGridViewTextBoxColumn.HeaderText = "SimilarityRate";
            this.similarityRateDataGridViewTextBoxColumn.Name = "similarityRateDataGridViewTextBoxColumn";
            // 
            // Original
            // 
            this.Original.DataPropertyName = "OriginalCleared";
            this.Original.HeaderText = "Original Cleared";
            this.Original.Name = "Original";
            this.Original.Width = 200;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "SimilarCleared";
            this.Column1.HeaderText = "Similar Cleared";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // similarTextDataGridViewTextBoxColumn1
            // 
            this.similarTextDataGridViewTextBoxColumn1.DataPropertyName = "SimilarText";
            this.similarTextDataGridViewTextBoxColumn1.HeaderText = "SimilarText";
            this.similarTextDataGridViewTextBoxColumn1.Name = "similarTextDataGridViewTextBoxColumn1";
            this.similarTextDataGridViewTextBoxColumn1.Width = 350;
            // 
            // similarityRateDataGridViewTextBoxColumn1
            // 
            this.similarityRateDataGridViewTextBoxColumn1.DataPropertyName = "SimilarityRate";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.similarityRateDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.similarityRateDataGridViewTextBoxColumn1.HeaderText = "Similarity";
            this.similarityRateDataGridViewTextBoxColumn1.Name = "similarityRateDataGridViewTextBoxColumn1";
            this.similarityRateDataGridViewTextBoxColumn1.Width = 70;
            // 
            // groupBoxCommonCharMistakes
            // 
            this.groupBoxCommonCharMistakes.Controls.Add(this.dataGridViewCharMistakeInstance);
            this.groupBoxCommonCharMistakes.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxCommonCharMistakes.Location = new System.Drawing.Point(150, 28);
            this.groupBoxCommonCharMistakes.Name = "groupBoxCommonCharMistakes";
            this.groupBoxCommonCharMistakes.Size = new System.Drawing.Size(340, 700);
            this.groupBoxCommonCharMistakes.TabIndex = 3;
            this.groupBoxCommonCharMistakes.TabStop = false;
            this.groupBoxCommonCharMistakes.Text = "Common Character Mistakes";
            this.groupBoxCommonCharMistakes.Visible = false;
            // 
            // dataGridViewCharMistakeInstance
            // 
            this.dataGridViewCharMistakeInstance.AutoGenerateColumns = false;
            this.dataGridViewCharMistakeInstance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCharMistakeInstance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.leftDataGridViewTextBoxColumn,
            this.rightDataGridViewTextBoxColumn,
            this.similarityDataGridViewTextBoxColumn});
            this.dataGridViewCharMistakeInstance.DataSource = this.charMistakeInstanceBindingSource;
            this.dataGridViewCharMistakeInstance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCharMistakeInstance.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewCharMistakeInstance.Name = "dataGridViewCharMistakeInstance";
            this.dataGridViewCharMistakeInstance.Size = new System.Drawing.Size(334, 680);
            this.dataGridViewCharMistakeInstance.TabIndex = 0;
            // 
            // charMistakeInstanceBindingSource
            // 
            this.charMistakeInstanceBindingSource.DataSource = typeof(MistakeInstance);
            // 
            // leftDataGridViewTextBoxColumn
            // 
            this.leftDataGridViewTextBoxColumn.DataPropertyName = "Left";
            this.leftDataGridViewTextBoxColumn.HeaderText = "Left";
            this.leftDataGridViewTextBoxColumn.Name = "leftDataGridViewTextBoxColumn";
            // 
            // rightDataGridViewTextBoxColumn
            // 
            this.rightDataGridViewTextBoxColumn.DataPropertyName = "Right";
            this.rightDataGridViewTextBoxColumn.HeaderText = "Right";
            this.rightDataGridViewTextBoxColumn.Name = "rightDataGridViewTextBoxColumn";
            // 
            // similarityDataGridViewTextBoxColumn
            // 
            this.similarityDataGridViewTextBoxColumn.DataPropertyName = "Similarity";
            this.similarityDataGridViewTextBoxColumn.HeaderText = "Similarity";
            this.similarityDataGridViewTextBoxColumn.Name = "similarityDataGridViewTextBoxColumn";
            // 
            // groupBoxCommonWordMistakes
            // 
            this.groupBoxCommonWordMistakes.Controls.Add(this.dataGridViewWordMistakeInstance);
            this.groupBoxCommonWordMistakes.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxCommonWordMistakes.Location = new System.Drawing.Point(490, 28);
            this.groupBoxCommonWordMistakes.Name = "groupBoxCommonWordMistakes";
            this.groupBoxCommonWordMistakes.Size = new System.Drawing.Size(333, 700);
            this.groupBoxCommonWordMistakes.TabIndex = 4;
            this.groupBoxCommonWordMistakes.TabStop = false;
            this.groupBoxCommonWordMistakes.Text = "Common Word Mistakes";
            this.groupBoxCommonWordMistakes.Visible = false;
            // 
            // dataGridViewWordMistakeInstance
            // 
            this.dataGridViewWordMistakeInstance.AutoGenerateColumns = false;
            this.dataGridViewWordMistakeInstance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWordMistakeInstance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.leftDataGridViewTextBoxColumn1,
            this.rightDataGridViewTextBoxColumn1,
            this.similarityDataGridViewTextBoxColumn1});
            this.dataGridViewWordMistakeInstance.DataSource = this.wordMistakeInstanceBindingSource;
            this.dataGridViewWordMistakeInstance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWordMistakeInstance.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewWordMistakeInstance.Name = "dataGridViewWordMistakeInstance";
            this.dataGridViewWordMistakeInstance.Size = new System.Drawing.Size(327, 680);
            this.dataGridViewWordMistakeInstance.TabIndex = 0;
            // 
            // wordMistakeInstanceBindingSource
            // 
            this.wordMistakeInstanceBindingSource.DataSource = typeof(MistakeInstance);
            // 
            // leftDataGridViewTextBoxColumn1
            // 
            this.leftDataGridViewTextBoxColumn1.DataPropertyName = "Left";
            this.leftDataGridViewTextBoxColumn1.HeaderText = "Left";
            this.leftDataGridViewTextBoxColumn1.Name = "leftDataGridViewTextBoxColumn1";
            // 
            // rightDataGridViewTextBoxColumn1
            // 
            this.rightDataGridViewTextBoxColumn1.DataPropertyName = "Right";
            this.rightDataGridViewTextBoxColumn1.HeaderText = "Right";
            this.rightDataGridViewTextBoxColumn1.Name = "rightDataGridViewTextBoxColumn1";
            // 
            // similarityDataGridViewTextBoxColumn1
            // 
            this.similarityDataGridViewTextBoxColumn1.DataPropertyName = "Similarity";
            this.similarityDataGridViewTextBoxColumn1.HeaderText = "Similarity";
            this.similarityDataGridViewTextBoxColumn1.Name = "similarityDataGridViewTextBoxColumn1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 757);
            this.Controls.Add(this.tabControlProfile);
            this.Controls.Add(this.listBoxLog);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "Simila Studio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabPageProfile.ResumeLayout(false);
            this.tabPageProfile.PerformLayout();
            this.groupBoxDirtyWords.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControlProfile.ResumeLayout(false);
            this.tabPageFindSimilars.ResumeLayout(false);
            this.tabPageFindSimilars.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.similarityResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherSimilarsBindingSource)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBoxCommonCharMistakes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCharMistakeInstance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charMistakeInstanceBindingSource)).EndInit();
            this.groupBoxCommonWordMistakes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWordMistakeInstance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordMistakeInstanceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageProfile;
        private System.Windows.Forms.RichTextBox textBoxDirtyWords;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tabControlProfile;
        private System.Windows.Forms.TabPage tabPageFindSimilars;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource similarityResultBindingSource;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.GroupBox groupBoxDirtyWords;
        private System.Windows.Forms.BindingSource otherSimilarsBindingSource;
        private System.Windows.Forms.ProgressBar progressBarCalcStatus;
        private System.Windows.Forms.Timer timerProgressUpdater;
        private System.Windows.Forms.ToolStripButton newToolStripButton1;
        private System.Windows.Forms.ToolStripButton openToolStripButton1;
        private System.Windows.Forms.ToolStripButton saveToolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn similarTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn similarityRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Original;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn similarTextDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn similarityRateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.GroupBox groupBoxCommonCharMistakes;
        private System.Windows.Forms.DataGridView dataGridViewCharMistakeInstance;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn similarityDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource charMistakeInstanceBindingSource;
        private System.Windows.Forms.GroupBox groupBoxCommonWordMistakes;
        private System.Windows.Forms.DataGridView dataGridViewWordMistakeInstance;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn similarityDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource wordMistakeInstanceBindingSource;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

