namespace StudyAdminAPITester
{
    partial class TestForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
			this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
			this.grpBxBuiltInTests = new System.Windows.Forms.GroupBox();
			this.btnPopualte = new System.Windows.Forms.Button();
			this.cBBuiltInTests = new System.Windows.Forms.ComboBox();
			this.grpBxAccessKey = new System.Windows.Forms.GroupBox();
			this.txtBxAccessKey = new System.Windows.Forms.TextBox();
			this.lblAccessKeyRequired = new System.Windows.Forms.Label();
			this.grpBxSecretKey = new System.Windows.Forms.GroupBox();
			this.txtBxSecretKey = new System.Windows.Forms.TextBox();
			this.lblSecretKeyRequired = new System.Windows.Forms.Label();
			this.grpBxBaseURI = new System.Windows.Forms.GroupBox();
			this.lblBaseURIRequired = new System.Windows.Forms.Label();
			this.txtBaseURI = new System.Windows.Forms.TextBox();
			this.lblStatusCode = new System.Windows.Forms.Label();
			this.grpBxRequest = new System.Windows.Forms.GroupBox();
			this.pnlActivityFile = new System.Windows.Forms.Panel();
			this.chkBxUseFile = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmBxFileType = new System.Windows.Forms.ComboBox();
			this.btnSelectActivityFile = new System.Windows.Forms.Button();
			this.cbHttpMethod = new System.Windows.Forms.ComboBox();
			this.txtBxURI = new System.Windows.Forms.TextBox();
			this.txtBxRequest = new System.Windows.Forms.TextBox();
			this.grpBxResponse = new System.Windows.Forms.GroupBox();
			this.txtBxResponse = new System.Windows.Forms.TextBox();
			this.contextMenuStripResponse = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItemClearLog = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemSaveLog = new System.Windows.Forms.ToolStripMenuItem();
			this.lblResponseRequired = new System.Windows.Forms.Label();
			this.linkLabelHelp = new System.Windows.Forms.LinkLabel();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageSingleTest = new System.Windows.Forms.TabPage();
			this.splitContainerRequest = new System.Windows.Forms.SplitContainer();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtBxRequestCount = new System.Windows.Forms.TextBox();
			this.lblRequestCount = new System.Windows.Forms.Label();
			this.lblMultipleRequests = new System.Windows.Forms.Label();
			this.rdBtnPerformMultipleReqFalse = new System.Windows.Forms.RadioButton();
			this.rdBtnPerformMultipleReqTrue = new System.Windows.Forms.RadioButton();
			this.btnSendRequest = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lblError = new System.Windows.Forms.Label();
			this.btnCompareResponse = new System.Windows.Forms.Button();
			this.tabPageBatchForm = new System.Windows.Forms.TabPage();
			this.lblImportedTestCount = new System.Windows.Forms.Label();
			this.lnkClearImport = new System.Windows.Forms.LinkLabel();
			this.lblImportedXMLConfig = new System.Windows.Forms.Label();
			this.lblBatchStatus = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lstBxBatchResults = new System.Windows.Forms.ListBox();
			this.contextMenuStripBatchResults = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItemClearBatch = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lstBxImportTests = new System.Windows.Forms.ListBox();
			this.grpResults = new System.Windows.Forms.GroupBox();
			this.lblTestsPassed = new System.Windows.Forms.Label();
			this.lblTestsFailed = new System.Windows.Forms.Label();
			this.lblTotalTests = new System.Windows.Forms.Label();
			this.btnViewLog = new System.Windows.Forms.Button();
			this.lnkSampeXML = new System.Windows.Forms.LinkLabel();
			this.btnRunBatch = new System.Windows.Forms.Button();
			this.lnkSchema = new System.Windows.Forms.LinkLabel();
			this.btnImportBatchConfig = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lblBatchInstructions = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.grpBxBuiltInTests.SuspendLayout();
			this.grpBxAccessKey.SuspendLayout();
			this.grpBxSecretKey.SuspendLayout();
			this.grpBxBaseURI.SuspendLayout();
			this.grpBxRequest.SuspendLayout();
			this.pnlActivityFile.SuspendLayout();
			this.grpBxResponse.SuspendLayout();
			this.contextMenuStripResponse.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPageSingleTest.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerRequest)).BeginInit();
			this.splitContainerRequest.Panel1.SuspendLayout();
			this.splitContainerRequest.Panel2.SuspendLayout();
			this.splitContainerRequest.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabPageBatchForm.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.contextMenuStripBatchResults.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grpResults.SuspendLayout();
			this.SuspendLayout();
			// 
			// BottomToolStripPanel
			// 
			this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.BottomToolStripPanel.Name = "BottomToolStripPanel";
			this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// TopToolStripPanel
			// 
			this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.TopToolStripPanel.Name = "TopToolStripPanel";
			this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// RightToolStripPanel
			// 
			this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.RightToolStripPanel.Name = "RightToolStripPanel";
			this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// LeftToolStripPanel
			// 
			this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.LeftToolStripPanel.Name = "LeftToolStripPanel";
			this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// ContentPanel
			// 
			this.ContentPanel.AutoScroll = true;
			this.ContentPanel.Size = new System.Drawing.Size(915, 633);
			// 
			// grpBxBuiltInTests
			// 
			this.grpBxBuiltInTests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.grpBxBuiltInTests.Controls.Add(this.btnPopualte);
			this.grpBxBuiltInTests.Controls.Add(this.cBBuiltInTests);
			this.grpBxBuiltInTests.Location = new System.Drawing.Point(424, 13);
			this.grpBxBuiltInTests.Name = "grpBxBuiltInTests";
			this.grpBxBuiltInTests.Size = new System.Drawing.Size(467, 44);
			this.grpBxBuiltInTests.TabIndex = 25;
			this.grpBxBuiltInTests.TabStop = false;
			this.grpBxBuiltInTests.Text = "Built-In Tests";
			// 
			// btnPopualte
			// 
			this.btnPopualte.Image = global::StudyAdminAPITester.Properties.Resources.wand;
			this.btnPopualte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPopualte.Location = new System.Drawing.Point(348, 14);
			this.btnPopualte.Name = "btnPopualte";
			this.btnPopualte.Size = new System.Drawing.Size(93, 23);
			this.btnPopualte.TabIndex = 1;
			this.btnPopualte.Text = "  Populate";
			this.btnPopualte.UseVisualStyleBackColor = true;
			// 
			// cBBuiltInTests
			// 
			this.cBBuiltInTests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cBBuiltInTests.FormattingEnabled = true;
			this.cBBuiltInTests.Location = new System.Drawing.Point(85, 15);
			this.cBBuiltInTests.Name = "cBBuiltInTests";
			this.cBBuiltInTests.Size = new System.Drawing.Size(257, 21);
			this.cBBuiltInTests.TabIndex = 0;
			// 
			// grpBxAccessKey
			// 
			this.grpBxAccessKey.Controls.Add(this.txtBxAccessKey);
			this.grpBxAccessKey.Controls.Add(this.lblAccessKeyRequired);
			this.grpBxAccessKey.Location = new System.Drawing.Point(9, 57);
			this.grpBxAccessKey.Name = "grpBxAccessKey";
			this.grpBxAccessKey.Size = new System.Drawing.Size(422, 41);
			this.grpBxAccessKey.TabIndex = 26;
			this.grpBxAccessKey.TabStop = false;
			this.grpBxAccessKey.Text = "Access Key";
			// 
			// txtBxAccessKey
			// 
			this.txtBxAccessKey.Location = new System.Drawing.Point(78, 15);
			this.txtBxAccessKey.Name = "txtBxAccessKey";
			this.txtBxAccessKey.Size = new System.Drawing.Size(312, 20);
			this.txtBxAccessKey.TabIndex = 6;
			// 
			// lblAccessKeyRequired
			// 
			this.lblAccessKeyRequired.AutoSize = true;
			this.lblAccessKeyRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAccessKeyRequired.ForeColor = System.Drawing.Color.Red;
			this.lblAccessKeyRequired.Location = new System.Drawing.Point(396, 15);
			this.lblAccessKeyRequired.Name = "lblAccessKeyRequired";
			this.lblAccessKeyRequired.Size = new System.Drawing.Size(20, 25);
			this.lblAccessKeyRequired.TabIndex = 19;
			this.lblAccessKeyRequired.Text = "*";
			// 
			// grpBxSecretKey
			// 
			this.grpBxSecretKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.grpBxSecretKey.Controls.Add(this.txtBxSecretKey);
			this.grpBxSecretKey.Controls.Add(this.lblSecretKeyRequired);
			this.grpBxSecretKey.Location = new System.Drawing.Point(424, 57);
			this.grpBxSecretKey.Name = "grpBxSecretKey";
			this.grpBxSecretKey.Size = new System.Drawing.Size(467, 41);
			this.grpBxSecretKey.TabIndex = 27;
			this.grpBxSecretKey.TabStop = false;
			this.grpBxSecretKey.Text = "Secret Key";
			// 
			// txtBxSecretKey
			// 
			this.txtBxSecretKey.Location = new System.Drawing.Point(85, 13);
			this.txtBxSecretKey.Name = "txtBxSecretKey";
			this.txtBxSecretKey.Size = new System.Drawing.Size(356, 20);
			this.txtBxSecretKey.TabIndex = 14;
			// 
			// lblSecretKeyRequired
			// 
			this.lblSecretKeyRequired.AutoSize = true;
			this.lblSecretKeyRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSecretKeyRequired.ForeColor = System.Drawing.Color.Red;
			this.lblSecretKeyRequired.Location = new System.Drawing.Point(443, 13);
			this.lblSecretKeyRequired.Name = "lblSecretKeyRequired";
			this.lblSecretKeyRequired.Size = new System.Drawing.Size(20, 25);
			this.lblSecretKeyRequired.TabIndex = 20;
			this.lblSecretKeyRequired.Text = "*";
			// 
			// grpBxBaseURI
			// 
			this.grpBxBaseURI.Controls.Add(this.lblBaseURIRequired);
			this.grpBxBaseURI.Controls.Add(this.txtBaseURI);
			this.grpBxBaseURI.Location = new System.Drawing.Point(9, 12);
			this.grpBxBaseURI.Name = "grpBxBaseURI";
			this.grpBxBaseURI.Size = new System.Drawing.Size(422, 45);
			this.grpBxBaseURI.TabIndex = 28;
			this.grpBxBaseURI.TabStop = false;
			this.grpBxBaseURI.Text = "Base URI";
			// 
			// lblBaseURIRequired
			// 
			this.lblBaseURIRequired.AutoSize = true;
			this.lblBaseURIRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBaseURIRequired.ForeColor = System.Drawing.Color.Red;
			this.lblBaseURIRequired.Location = new System.Drawing.Point(396, 16);
			this.lblBaseURIRequired.Name = "lblBaseURIRequired";
			this.lblBaseURIRequired.Size = new System.Drawing.Size(20, 25);
			this.lblBaseURIRequired.TabIndex = 20;
			this.lblBaseURIRequired.Text = "*";
			// 
			// txtBaseURI
			// 
			this.txtBaseURI.Location = new System.Drawing.Point(78, 16);
			this.txtBaseURI.Name = "txtBaseURI";
			this.txtBaseURI.Size = new System.Drawing.Size(312, 20);
			this.txtBaseURI.TabIndex = 12;
			// 
			// lblStatusCode
			// 
			this.lblStatusCode.AutoSize = true;
			this.lblStatusCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatusCode.ForeColor = System.Drawing.Color.Green;
			this.lblStatusCode.Image = global::StudyAdminAPITester.Properties.Resources.check_smaller;
			this.lblStatusCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStatusCode.Location = new System.Drawing.Point(14, 9);
			this.lblStatusCode.MaximumSize = new System.Drawing.Size(0, 15);
			this.lblStatusCode.Name = "lblStatusCode";
			this.lblStatusCode.Size = new System.Drawing.Size(179, 13);
			this.lblStatusCode.TabIndex = 29;
			this.lblStatusCode.Text = "     HTTP Status Code 200 OK";
			// 
			// grpBxRequest
			// 
			this.grpBxRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpBxRequest.Controls.Add(this.pnlActivityFile);
			this.grpBxRequest.Controls.Add(this.cbHttpMethod);
			this.grpBxRequest.Controls.Add(this.txtBxURI);
			this.grpBxRequest.Location = new System.Drawing.Point(9, 99);
			this.grpBxRequest.Name = "grpBxRequest";
			this.grpBxRequest.Size = new System.Drawing.Size(882, 47);
			this.grpBxRequest.TabIndex = 32;
			this.grpBxRequest.TabStop = false;
			this.grpBxRequest.Text = "Request (to Study Admin API)";
			// 
			// pnlActivityFile
			// 
			this.pnlActivityFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlActivityFile.Controls.Add(this.chkBxUseFile);
			this.pnlActivityFile.Controls.Add(this.label2);
			this.pnlActivityFile.Controls.Add(this.cmBxFileType);
			this.pnlActivityFile.Controls.Add(this.btnSelectActivityFile);
			this.pnlActivityFile.Enabled = false;
			this.pnlActivityFile.Location = new System.Drawing.Point(617, 12);
			this.pnlActivityFile.Name = "pnlActivityFile";
			this.pnlActivityFile.Size = new System.Drawing.Size(261, 29);
			this.pnlActivityFile.TabIndex = 38;
			// 
			// chkBxUseFile
			// 
			this.chkBxUseFile.AutoSize = true;
			this.chkBxUseFile.Location = new System.Drawing.Point(11, 6);
			this.chkBxUseFile.Name = "chkBxUseFile";
			this.chkBxUseFile.Size = new System.Drawing.Size(64, 17);
			this.chkBxUseFile.TabIndex = 42;
			this.chkBxUseFile.Text = "Use File";
			this.chkBxUseFile.UseVisualStyleBackColor = true;
			this.chkBxUseFile.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Enabled = false;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(81, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 41;
			this.label2.Text = "Type/Format";
			// 
			// cmBxFileType
			// 
			this.cmBxFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmBxFileType.Enabled = false;
			this.cmBxFileType.FormattingEnabled = true;
			this.cmBxFileType.Location = new System.Drawing.Point(147, 3);
			this.cmBxFileType.Name = "cmBxFileType";
			this.cmBxFileType.Size = new System.Drawing.Size(61, 21);
			this.cmBxFileType.TabIndex = 40;
			// 
			// btnSelectActivityFile
			// 
			this.btnSelectActivityFile.Enabled = false;
			this.btnSelectActivityFile.Location = new System.Drawing.Point(212, 3);
			this.btnSelectActivityFile.Name = "btnSelectActivityFile";
			this.btnSelectActivityFile.Size = new System.Drawing.Size(45, 22);
			this.btnSelectActivityFile.TabIndex = 37;
			this.btnSelectActivityFile.Text = "Select File";
			this.btnSelectActivityFile.UseVisualStyleBackColor = true;
			// 
			// cbHttpMethod
			// 
			this.cbHttpMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbHttpMethod.FormattingEnabled = true;
			this.cbHttpMethod.Location = new System.Drawing.Point(6, 16);
			this.cbHttpMethod.Name = "cbHttpMethod";
			this.cbHttpMethod.Size = new System.Drawing.Size(80, 21);
			this.cbHttpMethod.TabIndex = 36;
			// 
			// txtBxURI
			// 
			this.txtBxURI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtBxURI.Location = new System.Drawing.Point(92, 17);
			this.txtBxURI.Name = "txtBxURI";
			this.txtBxURI.Size = new System.Drawing.Size(524, 20);
			this.txtBxURI.TabIndex = 33;
			// 
			// txtBxRequest
			// 
			this.txtBxRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBxRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBxRequest.Location = new System.Drawing.Point(6, 13);
			this.txtBxRequest.Multiline = true;
			this.txtBxRequest.Name = "txtBxRequest";
			this.txtBxRequest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBxRequest.Size = new System.Drawing.Size(871, 90);
			this.txtBxRequest.TabIndex = 3;
			// 
			// grpBxResponse
			// 
			this.grpBxResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpBxResponse.Controls.Add(this.txtBxResponse);
			this.grpBxResponse.Controls.Add(this.lblResponseRequired);
			this.grpBxResponse.Location = new System.Drawing.Point(9, 25);
			this.grpBxResponse.Name = "grpBxResponse";
			this.grpBxResponse.Size = new System.Drawing.Size(882, 118);
			this.grpBxResponse.TabIndex = 33;
			this.grpBxResponse.TabStop = false;
			this.grpBxResponse.Text = "Response (from Study Admin API)";
			// 
			// txtBxResponse
			// 
			this.txtBxResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBxResponse.BackColor = System.Drawing.SystemColors.Window;
			this.txtBxResponse.ContextMenuStrip = this.contextMenuStripResponse;
			this.txtBxResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBxResponse.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtBxResponse.Location = new System.Drawing.Point(2, 19);
			this.txtBxResponse.Multiline = true;
			this.txtBxResponse.Name = "txtBxResponse";
			this.txtBxResponse.ReadOnly = true;
			this.txtBxResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBxResponse.Size = new System.Drawing.Size(874, 88);
			this.txtBxResponse.TabIndex = 7;
			// 
			// contextMenuStripResponse
			// 
			this.contextMenuStripResponse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemClearLog,
            this.toolStripMenuItemSaveLog});
			this.contextMenuStripResponse.Name = "contextMenuStrip1";
			this.contextMenuStripResponse.Size = new System.Drawing.Size(125, 48);
			// 
			// toolStripMenuItemClearLog
			// 
			this.toolStripMenuItemClearLog.Image = global::StudyAdminAPITester.Properties.Resources.cell_clear;
			this.toolStripMenuItemClearLog.Name = "toolStripMenuItemClearLog";
			this.toolStripMenuItemClearLog.Size = new System.Drawing.Size(124, 22);
			this.toolStripMenuItemClearLog.Text = "Clear Log";
			// 
			// toolStripMenuItemSaveLog
			// 
			this.toolStripMenuItemSaveLog.Image = global::StudyAdminAPITester.Properties.Resources.table_save;
			this.toolStripMenuItemSaveLog.Name = "toolStripMenuItemSaveLog";
			this.toolStripMenuItemSaveLog.Size = new System.Drawing.Size(124, 22);
			this.toolStripMenuItemSaveLog.Text = "Save Log";
			// 
			// lblResponseRequired
			// 
			this.lblResponseRequired.AutoSize = true;
			this.lblResponseRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblResponseRequired.ForeColor = System.Drawing.Color.Red;
			this.lblResponseRequired.Location = new System.Drawing.Point(888, 20);
			this.lblResponseRequired.Name = "lblResponseRequired";
			this.lblResponseRequired.Size = new System.Drawing.Size(0, 25);
			this.lblResponseRequired.TabIndex = 22;
			// 
			// linkLabelHelp
			// 
			this.linkLabelHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabelHelp.Location = new System.Drawing.Point(782, 2);
			this.linkLabelHelp.Name = "linkLabelHelp";
			this.linkLabelHelp.Size = new System.Drawing.Size(112, 14);
			this.linkLabelHelp.TabIndex = 34;
			this.linkLabelHelp.TabStop = true;
			this.linkLabelHelp.Text = "API Documentation";
			// 
			// toolStripContainer1
			// 
			this.toolStripContainer1.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.AutoScroll = true;
			this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl1);
			this.toolStripContainer1.ContentPanel.ForeColor = System.Drawing.Color.Black;
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(915, 526);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new System.Drawing.Size(915, 526);
			this.toolStripContainer1.TabIndex = 36;
			this.toolStripContainer1.Text = "toolStripContainer1";
			this.toolStripContainer1.TopToolStripPanelVisible = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPageSingleTest);
			this.tabControl1.Controls.Add(this.tabPageBatchForm);
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(912, 523);
			this.tabControl1.TabIndex = 39;
			// 
			// tabPageSingleTest
			// 
			this.tabPageSingleTest.Controls.Add(this.splitContainerRequest);
			this.tabPageSingleTest.Location = new System.Drawing.Point(4, 22);
			this.tabPageSingleTest.Name = "tabPageSingleTest";
			this.tabPageSingleTest.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSingleTest.Size = new System.Drawing.Size(904, 497);
			this.tabPageSingleTest.TabIndex = 0;
			this.tabPageSingleTest.Text = "Single Endpoint";
			this.tabPageSingleTest.UseVisualStyleBackColor = true;
			// 
			// splitContainerRequest
			// 
			this.splitContainerRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainerRequest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerRequest.Location = new System.Drawing.Point(3, 3);
			this.splitContainerRequest.Name = "splitContainerRequest";
			this.splitContainerRequest.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerRequest.Panel1
			// 
			this.splitContainerRequest.Panel1.Controls.Add(this.groupBox3);
			this.splitContainerRequest.Panel1.Controls.Add(this.txtBxRequestCount);
			this.splitContainerRequest.Panel1.Controls.Add(this.lblRequestCount);
			this.splitContainerRequest.Panel1.Controls.Add(this.lblMultipleRequests);
			this.splitContainerRequest.Panel1.Controls.Add(this.rdBtnPerformMultipleReqFalse);
			this.splitContainerRequest.Panel1.Controls.Add(this.rdBtnPerformMultipleReqTrue);
			this.splitContainerRequest.Panel1.Controls.Add(this.grpBxBaseURI);
			this.splitContainerRequest.Panel1.Controls.Add(this.btnSendRequest);
			this.splitContainerRequest.Panel1.Controls.Add(this.lblStatus);
			this.splitContainerRequest.Panel1.Controls.Add(this.linkLabelHelp);
			this.splitContainerRequest.Panel1.Controls.Add(this.grpBxAccessKey);
			this.splitContainerRequest.Panel1.Controls.Add(this.grpBxBuiltInTests);
			this.splitContainerRequest.Panel1.Controls.Add(this.grpBxSecretKey);
			this.splitContainerRequest.Panel1.Controls.Add(this.grpBxRequest);
			// 
			// splitContainerRequest.Panel2
			// 
			this.splitContainerRequest.Panel2.Controls.Add(this.grpBxResponse);
			this.splitContainerRequest.Panel2.Controls.Add(this.lblError);
			this.splitContainerRequest.Panel2.Controls.Add(this.btnCompareResponse);
			this.splitContainerRequest.Panel2.Controls.Add(this.lblStatusCode);
			this.splitContainerRequest.Size = new System.Drawing.Size(898, 491);
			this.splitContainerRequest.SplitterDistance = 294;
			this.splitContainerRequest.TabIndex = 39;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.txtBxRequest);
			this.groupBox3.Location = new System.Drawing.Point(9, 149);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(883, 109);
			this.groupBox3.TabIndex = 39;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Content";
			// 
			// txtBxRequestCount
			// 
			this.txtBxRequestCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.txtBxRequestCount.Location = new System.Drawing.Point(295, 263);
			this.txtBxRequestCount.MaxLength = 5;
			this.txtBxRequestCount.Name = "txtBxRequestCount";
			this.txtBxRequestCount.Size = new System.Drawing.Size(50, 20);
			this.txtBxRequestCount.TabIndex = 43;
			// 
			// lblRequestCount
			// 
			this.lblRequestCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.lblRequestCount.AutoSize = true;
			this.lblRequestCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRequestCount.Location = new System.Drawing.Point(199, 267);
			this.lblRequestCount.Name = "lblRequestCount";
			this.lblRequestCount.Size = new System.Drawing.Size(89, 13);
			this.lblRequestCount.TabIndex = 42;
			this.lblRequestCount.Text = "Repeat Count:";
			// 
			// lblMultipleRequests
			// 
			this.lblMultipleRequests.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.lblMultipleRequests.AutoSize = true;
			this.lblMultipleRequests.Location = new System.Drawing.Point(8, 265);
			this.lblMultipleRequests.Name = "lblMultipleRequests";
			this.lblMultipleRequests.Size = new System.Drawing.Size(85, 13);
			this.lblMultipleRequests.TabIndex = 37;
			this.lblMultipleRequests.Text = "Repeat Request";
			// 
			// rdBtnPerformMultipleReqFalse
			// 
			this.rdBtnPerformMultipleReqFalse.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.rdBtnPerformMultipleReqFalse.AutoSize = true;
			this.rdBtnPerformMultipleReqFalse.Checked = true;
			this.rdBtnPerformMultipleReqFalse.Location = new System.Drawing.Point(152, 264);
			this.rdBtnPerformMultipleReqFalse.Name = "rdBtnPerformMultipleReqFalse";
			this.rdBtnPerformMultipleReqFalse.Size = new System.Drawing.Size(39, 17);
			this.rdBtnPerformMultipleReqFalse.TabIndex = 41;
			this.rdBtnPerformMultipleReqFalse.TabStop = true;
			this.rdBtnPerformMultipleReqFalse.Text = "No";
			this.rdBtnPerformMultipleReqFalse.UseVisualStyleBackColor = true;
			// 
			// rdBtnPerformMultipleReqTrue
			// 
			this.rdBtnPerformMultipleReqTrue.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.rdBtnPerformMultipleReqTrue.AutoSize = true;
			this.rdBtnPerformMultipleReqTrue.Location = new System.Drawing.Point(104, 264);
			this.rdBtnPerformMultipleReqTrue.Name = "rdBtnPerformMultipleReqTrue";
			this.rdBtnPerformMultipleReqTrue.Size = new System.Drawing.Size(43, 17);
			this.rdBtnPerformMultipleReqTrue.TabIndex = 40;
			this.rdBtnPerformMultipleReqTrue.Text = "Yes";
			this.rdBtnPerformMultipleReqTrue.UseVisualStyleBackColor = true;
			// 
			// btnSendRequest
			// 
			this.btnSendRequest.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnSendRequest.Image = global::StudyAdminAPITester.Properties.Resources.mail;
			this.btnSendRequest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSendRequest.Location = new System.Drawing.Point(381, 261);
			this.btnSendRequest.Name = "btnSendRequest";
			this.btnSendRequest.Size = new System.Drawing.Size(156, 23);
			this.btnSendRequest.TabIndex = 12;
			this.btnSendRequest.Text = "   Send Request";
			this.btnSendRequest.UseVisualStyleBackColor = true;
			// 
			// lblStatus
			// 
			this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(543, 267);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(121, 13);
			this.lblStatus.TabIndex = 38;
			this.lblStatus.Text = "Waiting For Response...";
			this.lblStatus.Visible = false;
			// 
			// lblError
			// 
			this.lblError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblError.AutoSize = true;
			this.lblError.ForeColor = System.Drawing.Color.Red;
			this.lblError.Location = new System.Drawing.Point(14, 146);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(118, 13);
			this.lblError.TabIndex = 37;
			this.lblError.Text = "Required Fields Missing";
			// 
			// btnCompareResponse
			// 
			this.btnCompareResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCompareResponse.Enabled = false;
			this.btnCompareResponse.Image = global::StudyAdminAPITester.Properties.Resources.compare_smaller;
			this.btnCompareResponse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCompareResponse.Location = new System.Drawing.Point(738, 146);
			this.btnCompareResponse.Name = "btnCompareResponse";
			this.btnCompareResponse.Size = new System.Drawing.Size(149, 27);
			this.btnCompareResponse.TabIndex = 30;
			this.btnCompareResponse.Text = "Compare";
			this.btnCompareResponse.UseVisualStyleBackColor = true;
			// 
			// tabPageBatchForm
			// 
			this.tabPageBatchForm.Controls.Add(this.lblImportedTestCount);
			this.tabPageBatchForm.Controls.Add(this.lnkClearImport);
			this.tabPageBatchForm.Controls.Add(this.lblImportedXMLConfig);
			this.tabPageBatchForm.Controls.Add(this.lblBatchStatus);
			this.tabPageBatchForm.Controls.Add(this.groupBox2);
			this.tabPageBatchForm.Controls.Add(this.groupBox1);
			this.tabPageBatchForm.Controls.Add(this.grpResults);
			this.tabPageBatchForm.Controls.Add(this.btnViewLog);
			this.tabPageBatchForm.Controls.Add(this.lnkSampeXML);
			this.tabPageBatchForm.Controls.Add(this.btnRunBatch);
			this.tabPageBatchForm.Controls.Add(this.lnkSchema);
			this.tabPageBatchForm.Controls.Add(this.btnImportBatchConfig);
			this.tabPageBatchForm.Controls.Add(this.label1);
			this.tabPageBatchForm.Controls.Add(this.lblBatchInstructions);
			this.tabPageBatchForm.Location = new System.Drawing.Point(4, 22);
			this.tabPageBatchForm.Name = "tabPageBatchForm";
			this.tabPageBatchForm.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageBatchForm.Size = new System.Drawing.Size(904, 497);
			this.tabPageBatchForm.TabIndex = 1;
			this.tabPageBatchForm.Text = "Batch Mode";
			this.tabPageBatchForm.UseVisualStyleBackColor = true;
			// 
			// lblImportedTestCount
			// 
			this.lblImportedTestCount.AutoSize = true;
			this.lblImportedTestCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblImportedTestCount.Location = new System.Drawing.Point(132, 98);
			this.lblImportedTestCount.Name = "lblImportedTestCount";
			this.lblImportedTestCount.Size = new System.Drawing.Size(77, 13);
			this.lblImportedTestCount.TabIndex = 33;
			this.lblImportedTestCount.Text = "Test Count: ";
			this.lblImportedTestCount.Visible = false;
			// 
			// lnkClearImport
			// 
			this.lnkClearImport.AutoSize = true;
			this.lnkClearImport.Location = new System.Drawing.Point(132, 111);
			this.lnkClearImport.Name = "lnkClearImport";
			this.lnkClearImport.Size = new System.Drawing.Size(63, 13);
			this.lnkClearImport.TabIndex = 32;
			this.lnkClearImport.TabStop = true;
			this.lnkClearImport.Text = "Clear Import";
			this.lnkClearImport.Visible = false;
			this.lnkClearImport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClearImport_LinkClicked);
			// 
			// lblImportedXMLConfig
			// 
			this.lblImportedXMLConfig.AutoSize = true;
			this.lblImportedXMLConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblImportedXMLConfig.Location = new System.Drawing.Point(132, 84);
			this.lblImportedXMLConfig.Name = "lblImportedXMLConfig";
			this.lblImportedXMLConfig.Size = new System.Drawing.Size(84, 13);
			this.lblImportedXMLConfig.TabIndex = 31;
			this.lblImportedXMLConfig.Text = "Imported File:";
			this.lblImportedXMLConfig.Visible = false;
			// 
			// lblBatchStatus
			// 
			this.lblBatchStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblBatchStatus.AutoSize = true;
			this.lblBatchStatus.Location = new System.Drawing.Point(488, 257);
			this.lblBatchStatus.Name = "lblBatchStatus";
			this.lblBatchStatus.Size = new System.Drawing.Size(85, 13);
			this.lblBatchStatus.TabIndex = 30;
			this.lblBatchStatus.Text = "Running Tests...";
			this.lblBatchStatus.Visible = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.lstBxBatchResults);
			this.groupBox2.Location = new System.Drawing.Point(21, 276);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(875, 136);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Results";
			// 
			// lstBxBatchResults
			// 
			this.lstBxBatchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstBxBatchResults.ContextMenuStrip = this.contextMenuStripBatchResults;
			this.lstBxBatchResults.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.lstBxBatchResults.FormattingEnabled = true;
			this.lstBxBatchResults.HorizontalScrollbar = true;
			this.lstBxBatchResults.ItemHeight = 14;
			this.lstBxBatchResults.Location = new System.Drawing.Point(6, 20);
			this.lstBxBatchResults.Name = "lstBxBatchResults";
			this.lstBxBatchResults.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstBxBatchResults.ScrollAlwaysVisible = true;
			this.lstBxBatchResults.Size = new System.Drawing.Size(863, 60);
			this.lstBxBatchResults.TabIndex = 4;
			this.lstBxBatchResults.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstBxBatchResults_DrawItem);
			// 
			// contextMenuStripBatchResults
			// 
			this.contextMenuStripBatchResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemClearBatch});
			this.contextMenuStripBatchResults.Name = "contextMenuStripBatchResults";
			this.contextMenuStripBatchResults.Size = new System.Drawing.Size(125, 26);
			// 
			// toolStripMenuItemClearBatch
			// 
			this.toolStripMenuItemClearBatch.Image = global::StudyAdminAPITester.Properties.Resources.cell_clear;
			this.toolStripMenuItemClearBatch.Name = "toolStripMenuItemClearBatch";
			this.toolStripMenuItemClearBatch.Size = new System.Drawing.Size(124, 22);
			this.toolStripMenuItemClearBatch.Text = "Clear Log";
			this.toolStripMenuItemClearBatch.Click += new System.EventHandler(this.toolStripMenuItemClearBatchLog);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.lstBxImportTests);
			this.groupBox1.Location = new System.Drawing.Point(21, 128);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(875, 117);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Imported Tests";
			// 
			// lstBxImportTests
			// 
			this.lstBxImportTests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstBxImportTests.FormattingEnabled = true;
			this.lstBxImportTests.HorizontalScrollbar = true;
			this.lstBxImportTests.Location = new System.Drawing.Point(6, 20);
			this.lstBxImportTests.Name = "lstBxImportTests";
			this.lstBxImportTests.ScrollAlwaysVisible = true;
			this.lstBxImportTests.Size = new System.Drawing.Size(863, 82);
			this.lstBxImportTests.TabIndex = 3;
			// 
			// grpResults
			// 
			this.grpResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.grpResults.Controls.Add(this.lblTestsPassed);
			this.grpResults.Controls.Add(this.lblTestsFailed);
			this.grpResults.Controls.Add(this.lblTotalTests);
			this.grpResults.Location = new System.Drawing.Point(692, 413);
			this.grpResults.Name = "grpResults";
			this.grpResults.Size = new System.Drawing.Size(123, 61);
			this.grpResults.TabIndex = 13;
			this.grpResults.TabStop = false;
			this.grpResults.Text = "Results";
			this.grpResults.Visible = false;
			// 
			// lblTestsPassed
			// 
			this.lblTestsPassed.AutoSize = true;
			this.lblTestsPassed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTestsPassed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.lblTestsPassed.Location = new System.Drawing.Point(15, 17);
			this.lblTestsPassed.Name = "lblTestsPassed";
			this.lblTestsPassed.Size = new System.Drawing.Size(98, 13);
			this.lblTestsPassed.TabIndex = 7;
			this.lblTestsPassed.Text = "Tests Passed: 0";
			// 
			// lblTestsFailed
			// 
			this.lblTestsFailed.AutoSize = true;
			this.lblTestsFailed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTestsFailed.ForeColor = System.Drawing.Color.Red;
			this.lblTestsFailed.Location = new System.Drawing.Point(16, 31);
			this.lblTestsFailed.Name = "lblTestsFailed";
			this.lblTestsFailed.Size = new System.Drawing.Size(91, 13);
			this.lblTestsFailed.TabIndex = 8;
			this.lblTestsFailed.Text = "Tests Failed: 0";
			// 
			// lblTotalTests
			// 
			this.lblTotalTests.AutoSize = true;
			this.lblTotalTests.Location = new System.Drawing.Point(16, 45);
			this.lblTotalTests.Name = "lblTotalTests";
			this.lblTotalTests.Size = new System.Drawing.Size(72, 13);
			this.lblTotalTests.TabIndex = 9;
			this.lblTotalTests.Text = "Total Tests: 0";
			// 
			// btnViewLog
			// 
			this.btnViewLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnViewLog.Enabled = false;
			this.btnViewLog.Location = new System.Drawing.Point(821, 437);
			this.btnViewLog.Name = "btnViewLog";
			this.btnViewLog.Size = new System.Drawing.Size(75, 23);
			this.btnViewLog.TabIndex = 12;
			this.btnViewLog.Text = "View Log";
			this.btnViewLog.UseVisualStyleBackColor = true;
			this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
			// 
			// lnkSampeXML
			// 
			this.lnkSampeXML.AutoSize = true;
			this.lnkSampeXML.Location = new System.Drawing.Point(119, 55);
			this.lnkSampeXML.Name = "lnkSampeXML";
			this.lnkSampeXML.Size = new System.Drawing.Size(93, 13);
			this.lnkSampeXML.TabIndex = 6;
			this.lnkSampeXML.TabStop = true;
			this.lnkSampeXML.Text = "View Sample XML";
			this.lnkSampeXML.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSampeXML_LinkClicked);
			// 
			// btnRunBatch
			// 
			this.btnRunBatch.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnRunBatch.Enabled = false;
			this.btnRunBatch.Location = new System.Drawing.Point(406, 251);
			this.btnRunBatch.Name = "btnRunBatch";
			this.btnRunBatch.Size = new System.Drawing.Size(69, 26);
			this.btnRunBatch.TabIndex = 5;
			this.btnRunBatch.Text = "Run";
			this.btnRunBatch.UseVisualStyleBackColor = true;
			this.btnRunBatch.Click += new System.EventHandler(this.btnRunBatch_Click);
			// 
			// lnkSchema
			// 
			this.lnkSchema.AutoSize = true;
			this.lnkSchema.Location = new System.Drawing.Point(18, 55);
			this.lnkSchema.Name = "lnkSchema";
			this.lnkSchema.Size = new System.Drawing.Size(72, 13);
			this.lnkSchema.TabIndex = 2;
			this.lnkSchema.TabStop = true;
			this.lnkSchema.Text = "View Schema";
			this.lnkSchema.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkXmlSchema_Click);
			// 
			// btnImportBatchConfig
			// 
			this.btnImportBatchConfig.Location = new System.Drawing.Point(21, 93);
			this.btnImportBatchConfig.Name = "btnImportBatchConfig";
			this.btnImportBatchConfig.Size = new System.Drawing.Size(105, 24);
			this.btnImportBatchConfig.TabIndex = 1;
			this.btnImportBatchConfig.Text = "Import";
			this.btnImportBatchConfig.UseVisualStyleBackColor = true;
			this.btnImportBatchConfig.Click += new System.EventHandler(this.btnImportConfig_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(18, 13);
			this.label1.MaximumSize = new System.Drawing.Size(855, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(854, 39);
			this.label1.TabIndex = 0;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// lblBatchInstructions
			// 
			this.lblBatchInstructions.AutoSize = true;
			this.lblBatchInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBatchInstructions.Location = new System.Drawing.Point(18, 13);
			this.lblBatchInstructions.MaximumSize = new System.Drawing.Size(855, 0);
			this.lblBatchInstructions.Name = "lblBatchInstructions";
			this.lblBatchInstructions.Size = new System.Drawing.Size(852, 39);
			this.lblBatchInstructions.TabIndex = 0;
			this.lblBatchInstructions.Text = resources.GetString("lblBatchInstructions.Text");
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(915, 526);
			this.Controls.Add(this.toolStripContainer1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(931, 565);
			this.Name = "TestForm";
			this.Text = "CentrePoint Web API Tester";
			this.grpBxBuiltInTests.ResumeLayout(false);
			this.grpBxAccessKey.ResumeLayout(false);
			this.grpBxAccessKey.PerformLayout();
			this.grpBxSecretKey.ResumeLayout(false);
			this.grpBxSecretKey.PerformLayout();
			this.grpBxBaseURI.ResumeLayout(false);
			this.grpBxBaseURI.PerformLayout();
			this.grpBxRequest.ResumeLayout(false);
			this.grpBxRequest.PerformLayout();
			this.pnlActivityFile.ResumeLayout(false);
			this.pnlActivityFile.PerformLayout();
			this.grpBxResponse.ResumeLayout(false);
			this.grpBxResponse.PerformLayout();
			this.contextMenuStripResponse.ResumeLayout(false);
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPageSingleTest.ResumeLayout(false);
			this.splitContainerRequest.Panel1.ResumeLayout(false);
			this.splitContainerRequest.Panel1.PerformLayout();
			this.splitContainerRequest.Panel2.ResumeLayout(false);
			this.splitContainerRequest.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerRequest)).EndInit();
			this.splitContainerRequest.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabPageBatchForm.ResumeLayout(false);
			this.tabPageBatchForm.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.contextMenuStripBatchResults.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.grpResults.ResumeLayout(false);
			this.grpResults.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBxBuiltInTests;
        private System.Windows.Forms.ComboBox cBBuiltInTests;
        private System.Windows.Forms.GroupBox grpBxAccessKey;
        private System.Windows.Forms.TextBox txtBxAccessKey;
        private System.Windows.Forms.Label lblAccessKeyRequired;
        private System.Windows.Forms.GroupBox grpBxSecretKey;
        private System.Windows.Forms.TextBox txtBxSecretKey;
        private System.Windows.Forms.Label lblSecretKeyRequired;
        private System.Windows.Forms.GroupBox grpBxBaseURI;
        private System.Windows.Forms.Label lblStatusCode;
        private System.Windows.Forms.Button btnCompareResponse;
        private System.Windows.Forms.GroupBox grpBxRequest;
		private System.Windows.Forms.TextBox txtBxURI;
        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.GroupBox grpBxResponse;
        private System.Windows.Forms.TextBox txtBxResponse;
        private System.Windows.Forms.Label lblResponseRequired;
        private System.Windows.Forms.LinkLabel linkLabelHelp;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripResponse;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClearLog;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveLog;
        private System.Windows.Forms.Button btnPopualte;
        private System.Windows.Forms.ComboBox cbHttpMethod;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.SplitContainer splitContainerRequest;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSingleTest;
        private System.Windows.Forms.TabPage tabPageBatchForm;
        private System.Windows.Forms.Label lblBatchInstructions;
        private System.Windows.Forms.Button btnImportBatchConfig;
        private System.Windows.Forms.LinkLabel lnkSchema;
        private System.Windows.Forms.Button btnRunBatch;
        private System.Windows.Forms.ListBox lstBxBatchResults;
        private System.Windows.Forms.ListBox lstBxImportTests;
        private System.Windows.Forms.LinkLabel lnkSampeXML;
        private System.Windows.Forms.Label lblTestsPassed;
        private System.Windows.Forms.Label lblTestsFailed;
        private System.Windows.Forms.Label lblTotalTests;
        private System.Windows.Forms.Button btnViewLog;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblBatchStatus;
        private System.Windows.Forms.Label lblImportedXMLConfig;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripBatchResults;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClearBatch;
        private System.Windows.Forms.LinkLabel lnkClearImport;
        private System.Windows.Forms.TextBox txtBaseURI;
        private System.Windows.Forms.Label lblBaseURIRequired;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblImportedTestCount;
		private System.Windows.Forms.RadioButton rdBtnPerformMultipleReqTrue;
		private System.Windows.Forms.RadioButton rdBtnPerformMultipleReqFalse;
		private System.Windows.Forms.Label lblMultipleRequests;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Label lblRequestCount;
		private System.Windows.Forms.TextBox txtBxRequestCount;
		private System.Windows.Forms.TextBox txtBxRequest;
		private System.Windows.Forms.Panel pnlActivityFile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmBxFileType;
		private System.Windows.Forms.Button btnSelectActivityFile;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox chkBxUseFile;
        //private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClearBatchLog;

        

    }
}

