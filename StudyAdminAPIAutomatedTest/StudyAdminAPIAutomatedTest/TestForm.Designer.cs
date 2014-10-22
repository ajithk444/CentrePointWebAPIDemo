namespace StudyAdminAPIAutomatedTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.cBBuiltInTests = new System.Windows.Forms.ComboBox();
            this.txtBxRequest = new System.Windows.Forms.TextBox();
            this.txtBxAccessKey = new System.Windows.Forms.TextBox();
            this.txtBxResponse = new System.Windows.Forms.TextBox();
            this.lblBaseURI = new System.Windows.Forms.Label();
            this.cbBaseURI = new System.Windows.Forms.ComboBox();
            this.txtBxSecretKey = new System.Windows.Forms.TextBox();
            this.lblBaseURIRequired = new System.Windows.Forms.Label();
            this.lblAccessKeyRequired = new System.Windows.Forms.Label();
            this.lblSecretKeyRequired = new System.Windows.Forms.Label();
            this.lblRequestRequired = new System.Windows.Forms.Label();
            this.lblResponseRequired = new System.Windows.Forms.Label();
            this.lblTestRequired = new System.Windows.Forms.Label();
            this.lblValidationError = new System.Windows.Forms.Label();
            this.grpBxBuiltInTests = new System.Windows.Forms.GroupBox();
            this.grpBxAccessKey = new System.Windows.Forms.GroupBox();
            this.grpBxSecretKey = new System.Windows.Forms.GroupBox();
            this.grpBxBaseURI = new System.Windows.Forms.GroupBox();
            this.lblStatusCode = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCompareResponse = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.grpBxRequest = new System.Windows.Forms.GroupBox();
            this.grpBxResponse = new System.Windows.Forms.GroupBox();
            this.grpBxBuiltInTests.SuspendLayout();
            this.grpBxAccessKey.SuspendLayout();
            this.grpBxSecretKey.SuspendLayout();
            this.grpBxBaseURI.SuspendLayout();
            this.grpBxRequest.SuspendLayout();
            this.grpBxResponse.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBBuiltInTests
            // 
            this.cBBuiltInTests.FormattingEnabled = true;
            this.cBBuiltInTests.Location = new System.Drawing.Point(96, 15);
            this.cBBuiltInTests.Name = "cBBuiltInTests";
            this.cBBuiltInTests.Size = new System.Drawing.Size(319, 22);
            this.cBBuiltInTests.TabIndex = 0;
            // 
            // txtBxRequest
            // 
            this.txtBxRequest.Location = new System.Drawing.Point(183, 17);
            this.txtBxRequest.Multiline = true;
            this.txtBxRequest.Name = "txtBxRequest";
            this.txtBxRequest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBxRequest.Size = new System.Drawing.Size(623, 79);
            this.txtBxRequest.TabIndex = 2;
            // 
            // txtBxAccessKey
            // 
            this.txtBxAccessKey.Location = new System.Drawing.Point(96, 14);
            this.txtBxAccessKey.Name = "txtBxAccessKey";
            this.txtBxAccessKey.Size = new System.Drawing.Size(269, 21);
            this.txtBxAccessKey.TabIndex = 6;
            // 
            // txtBxResponse
            // 
            this.txtBxResponse.Location = new System.Drawing.Point(183, 20);
            this.txtBxResponse.Multiline = true;
            this.txtBxResponse.Name = "txtBxResponse";
            this.txtBxResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBxResponse.Size = new System.Drawing.Size(623, 111);
            this.txtBxResponse.TabIndex = 7;
            // 
            // lblBaseURI
            // 
            this.lblBaseURI.AutoSize = true;
            this.lblBaseURI.Location = new System.Drawing.Point(20, 27);
            this.lblBaseURI.Name = "lblBaseURI";
            this.lblBaseURI.Size = new System.Drawing.Size(51, 14);
            this.lblBaseURI.TabIndex = 9;
            this.lblBaseURI.Text = "BaseURI";
            // 
            // cbBaseURI
            // 
            this.cbBaseURI.FormattingEnabled = true;
            this.cbBaseURI.Location = new System.Drawing.Point(92, 11);
            this.cbBaseURI.Name = "cbBaseURI";
            this.cbBaseURI.Size = new System.Drawing.Size(682, 22);
            this.cbBaseURI.TabIndex = 11;
            // 
            // txtBxSecretKey
            // 
            this.txtBxSecretKey.Location = new System.Drawing.Point(75, 17);
            this.txtBxSecretKey.Name = "txtBxSecretKey";
            this.txtBxSecretKey.Size = new System.Drawing.Size(307, 21);
            this.txtBxSecretKey.TabIndex = 14;
            // 
            // lblBaseURIRequired
            // 
            this.lblBaseURIRequired.AutoSize = true;
            this.lblBaseURIRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseURIRequired.ForeColor = System.Drawing.Color.Red;
            this.lblBaseURIRequired.Location = new System.Drawing.Point(782, 12);
            this.lblBaseURIRequired.Name = "lblBaseURIRequired";
            this.lblBaseURIRequired.Size = new System.Drawing.Size(0, 25);
            this.lblBaseURIRequired.TabIndex = 18;
            // 
            // lblAccessKeyRequired
            // 
            this.lblAccessKeyRequired.AutoSize = true;
            this.lblAccessKeyRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccessKeyRequired.ForeColor = System.Drawing.Color.Red;
            this.lblAccessKeyRequired.Location = new System.Drawing.Point(372, 14);
            this.lblAccessKeyRequired.Name = "lblAccessKeyRequired";
            this.lblAccessKeyRequired.Size = new System.Drawing.Size(0, 25);
            this.lblAccessKeyRequired.TabIndex = 19;
            // 
            // lblSecretKeyRequired
            // 
            this.lblSecretKeyRequired.AutoSize = true;
            this.lblSecretKeyRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecretKeyRequired.ForeColor = System.Drawing.Color.Red;
            this.lblSecretKeyRequired.Location = new System.Drawing.Point(390, 11);
            this.lblSecretKeyRequired.Name = "lblSecretKeyRequired";
            this.lblSecretKeyRequired.Size = new System.Drawing.Size(0, 25);
            this.lblSecretKeyRequired.TabIndex = 20;
            // 
            // lblRequestRequired
            // 
            this.lblRequestRequired.AutoSize = true;
            this.lblRequestRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestRequired.ForeColor = System.Drawing.Color.Red;
            this.lblRequestRequired.Location = new System.Drawing.Point(821, 17);
            this.lblRequestRequired.Name = "lblRequestRequired";
            this.lblRequestRequired.Size = new System.Drawing.Size(0, 25);
            this.lblRequestRequired.TabIndex = 21;
            // 
            // lblResponseRequired
            // 
            this.lblResponseRequired.AutoSize = true;
            this.lblResponseRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResponseRequired.ForeColor = System.Drawing.Color.Red;
            this.lblResponseRequired.Location = new System.Drawing.Point(821, 20);
            this.lblResponseRequired.Name = "lblResponseRequired";
            this.lblResponseRequired.Size = new System.Drawing.Size(0, 25);
            this.lblResponseRequired.TabIndex = 22;
            // 
            // lblTestRequired
            // 
            this.lblTestRequired.AutoSize = true;
            this.lblTestRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestRequired.ForeColor = System.Drawing.Color.Red;
            this.lblTestRequired.Location = new System.Drawing.Point(465, 130);
            this.lblTestRequired.Name = "lblTestRequired";
            this.lblTestRequired.Size = new System.Drawing.Size(0, 25);
            this.lblTestRequired.TabIndex = 23;
            // 
            // lblValidationError
            // 
            this.lblValidationError.AutoSize = true;
            this.lblValidationError.Font = new System.Drawing.Font("Meiryo UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidationError.ForeColor = System.Drawing.Color.Red;
            this.lblValidationError.Location = new System.Drawing.Point(192, 340);
            this.lblValidationError.Name = "lblValidationError";
            this.lblValidationError.Size = new System.Drawing.Size(0, 18);
            this.lblValidationError.TabIndex = 24;
            // 
            // grpBxBuiltInTests
            // 
            this.grpBxBuiltInTests.Controls.Add(this.cBBuiltInTests);
            this.grpBxBuiltInTests.Location = new System.Drawing.Point(14, 122);
            this.grpBxBuiltInTests.Name = "grpBxBuiltInTests";
            this.grpBxBuiltInTests.Size = new System.Drawing.Size(444, 44);
            this.grpBxBuiltInTests.TabIndex = 25;
            this.grpBxBuiltInTests.TabStop = false;
            this.grpBxBuiltInTests.Text = "Built-In Tests";
            // 
            // grpBxAccessKey
            // 
            this.grpBxAccessKey.Controls.Add(this.txtBxAccessKey);
            this.grpBxAccessKey.Controls.Add(this.lblAccessKeyRequired);
            this.grpBxAccessKey.Location = new System.Drawing.Point(14, 64);
            this.grpBxAccessKey.Name = "grpBxAccessKey";
            this.grpBxAccessKey.Size = new System.Drawing.Size(385, 42);
            this.grpBxAccessKey.TabIndex = 26;
            this.grpBxAccessKey.TabStop = false;
            this.grpBxAccessKey.Text = "Access Key";
            // 
            // grpBxSecretKey
            // 
            this.grpBxSecretKey.Controls.Add(this.txtBxSecretKey);
            this.grpBxSecretKey.Controls.Add(this.lblSecretKeyRequired);
            this.grpBxSecretKey.Location = new System.Drawing.Point(406, 64);
            this.grpBxSecretKey.Name = "grpBxSecretKey";
            this.grpBxSecretKey.Size = new System.Drawing.Size(465, 42);
            this.grpBxSecretKey.TabIndex = 27;
            this.grpBxSecretKey.TabStop = false;
            this.grpBxSecretKey.Text = "Secret Key";
            // 
            // grpBxBaseURI
            // 
            this.grpBxBaseURI.Controls.Add(this.cbBaseURI);
            this.grpBxBaseURI.Controls.Add(this.lblBaseURIRequired);
            this.grpBxBaseURI.Location = new System.Drawing.Point(14, 15);
            this.grpBxBaseURI.Name = "grpBxBaseURI";
            this.grpBxBaseURI.Size = new System.Drawing.Size(854, 45);
            this.grpBxBaseURI.TabIndex = 28;
            this.grpBxBaseURI.TabStop = false;
            this.grpBxBaseURI.Text = "Base URI";
            // 
            // lblStatusCode
            // 
            this.lblStatusCode.AutoSize = true;
            this.lblStatusCode.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusCode.Location = new System.Drawing.Point(192, 379);
            this.lblStatusCode.Name = "lblStatusCode";
            this.lblStatusCode.Size = new System.Drawing.Size(0, 14);
            this.lblStatusCode.TabIndex = 29;
            // 
            // btnReset
            // 
            this.btnReset.Image = global::StudyAdminAPITester.Properties.Resources.edit_clear;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnReset.Location = new System.Drawing.Point(536, 102);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(149, 32);
            this.btnReset.TabIndex = 31;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnCompareResponse
            // 
            this.btnCompareResponse.Enabled = false;
            this.btnCompareResponse.Image = global::StudyAdminAPITester.Properties.Resources.check;
            this.btnCompareResponse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompareResponse.Location = new System.Drawing.Point(705, 594);
            this.btnCompareResponse.Name = "btnCompareResponse";
            this.btnCompareResponse.Size = new System.Drawing.Size(149, 32);
            this.btnCompareResponse.TabIndex = 30;
            this.btnCompareResponse.Text = "Compare";
            this.btnCompareResponse.UseVisualStyleBackColor = true;
            // 
            // btnExecute
            // 
            this.btnExecute.Image = global::StudyAdminAPITester.Properties.Resources.mail;
            this.btnExecute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecute.Location = new System.Drawing.Point(268, 102);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(149, 32);
            this.btnExecute.TabIndex = 12;
            this.btnExecute.Text = "   Send Request";
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // grpBxRequest
            // 
            this.grpBxRequest.Controls.Add(this.btnReset);
            this.grpBxRequest.Controls.Add(this.txtBxRequest);
            this.grpBxRequest.Controls.Add(this.btnExecute);
            this.grpBxRequest.Controls.Add(this.lblRequestRequired);
            this.grpBxRequest.Location = new System.Drawing.Point(12, 176);
            this.grpBxRequest.Name = "grpBxRequest";
            this.grpBxRequest.Size = new System.Drawing.Size(856, 149);
            this.grpBxRequest.TabIndex = 32;
            this.grpBxRequest.TabStop = false;
            this.grpBxRequest.Text = "Request (to Study Admin API)";
            // 
            // grpBxResponse
            // 
            this.grpBxResponse.Controls.Add(this.txtBxResponse);
            this.grpBxResponse.Controls.Add(this.lblResponseRequired);
            this.grpBxResponse.Location = new System.Drawing.Point(12, 418);
            this.grpBxResponse.Name = "grpBxResponse";
            this.grpBxResponse.Size = new System.Drawing.Size(856, 154);
            this.grpBxResponse.TabIndex = 33;
            this.grpBxResponse.TabStop = false;
            this.grpBxResponse.Text = "Resposne (from Study Admin API)";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 658);
            this.Controls.Add(this.grpBxResponse);
            this.Controls.Add(this.grpBxRequest);
            this.Controls.Add(this.btnCompareResponse);
            this.Controls.Add(this.lblStatusCode);
            this.Controls.Add(this.grpBxBaseURI);
            this.Controls.Add(this.grpBxSecretKey);
            this.Controls.Add(this.grpBxAccessKey);
            this.Controls.Add(this.grpBxBuiltInTests);
            this.Controls.Add(this.lblValidationError);
            this.Controls.Add(this.lblTestRequired);
            this.Controls.Add(this.lblBaseURI);
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestForm";
            this.Text = "Study Admin API Tester";
            this.grpBxBuiltInTests.ResumeLayout(false);
            this.grpBxAccessKey.ResumeLayout(false);
            this.grpBxAccessKey.PerformLayout();
            this.grpBxSecretKey.ResumeLayout(false);
            this.grpBxSecretKey.PerformLayout();
            this.grpBxBaseURI.ResumeLayout(false);
            this.grpBxBaseURI.PerformLayout();
            this.grpBxRequest.ResumeLayout(false);
            this.grpBxRequest.PerformLayout();
            this.grpBxResponse.ResumeLayout(false);
            this.grpBxResponse.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBBuiltInTests;
        private System.Windows.Forms.TextBox txtBxRequest;
        private System.Windows.Forms.TextBox txtBxAccessKey;
        private System.Windows.Forms.TextBox txtBxResponse;
        private System.Windows.Forms.Label lblBaseURI;
        private System.Windows.Forms.ComboBox cbBaseURI;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox txtBxSecretKey;
        private System.Windows.Forms.Label lblBaseURIRequired;
        private System.Windows.Forms.Label lblAccessKeyRequired;
        private System.Windows.Forms.Label lblSecretKeyRequired;
        private System.Windows.Forms.Label lblRequestRequired;
        private System.Windows.Forms.Label lblResponseRequired;
        private System.Windows.Forms.Label lblTestRequired;
        private System.Windows.Forms.Label lblValidationError;
        private System.Windows.Forms.GroupBox grpBxBuiltInTests;
        private System.Windows.Forms.GroupBox grpBxAccessKey;
        private System.Windows.Forms.GroupBox grpBxSecretKey;
        private System.Windows.Forms.GroupBox grpBxBaseURI;
        private System.Windows.Forms.Label lblStatusCode;
        private System.Windows.Forms.Button btnCompareResponse;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grpBxRequest;
        private System.Windows.Forms.GroupBox grpBxResponse;
    }
}

