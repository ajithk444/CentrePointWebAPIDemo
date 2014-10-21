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
            this.cBBuiltInTests = new System.Windows.Forms.ComboBox();
            this.lblTest = new System.Windows.Forms.Label();
            this.txtBxRequest = new System.Windows.Forms.TextBox();
            this.lblRequest = new System.Windows.Forms.Label();
            this.lblAccessKey = new System.Windows.Forms.Label();
            this.txtBxAccessKey = new System.Windows.Forms.TextBox();
            this.txtBxResponse = new System.Windows.Forms.TextBox();
            this.lblResponse = new System.Windows.Forms.Label();
            this.lblBaseURI = new System.Windows.Forms.Label();
            this.cbBaseURI = new System.Windows.Forms.ComboBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblPrivateKey = new System.Windows.Forms.Label();
            this.txtBxSecretKey = new System.Windows.Forms.TextBox();
            this.lblBaseURIRequired = new System.Windows.Forms.Label();
            this.lblAccessKeyRequired = new System.Windows.Forms.Label();
            this.lblSecretKeyRequired = new System.Windows.Forms.Label();
            this.lblRequestRequired = new System.Windows.Forms.Label();
            this.lblResponseRequired = new System.Windows.Forms.Label();
            this.lblTestRequired = new System.Windows.Forms.Label();
            this.lblValidationError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cBBuiltInTests
            // 
            this.cBBuiltInTests.FormattingEnabled = true;
            this.cBBuiltInTests.Location = new System.Drawing.Point(117, 99);
            this.cBBuiltInTests.Name = "cBBuiltInTests";
            this.cBBuiltInTests.Size = new System.Drawing.Size(274, 21);
            this.cBBuiltInTests.TabIndex = 0;
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(17, 99);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(68, 13);
            this.lblTest.TabIndex = 1;
            this.lblTest.Text = "Built-In Tests";
            // 
            // txtBxRequest
            // 
            this.txtBxRequest.Location = new System.Drawing.Point(184, 160);
            this.txtBxRequest.Multiline = true;
            this.txtBxRequest.Name = "txtBxRequest";
            this.txtBxRequest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBxRequest.Size = new System.Drawing.Size(535, 102);
            this.txtBxRequest.TabIndex = 2;
            // 
            // lblRequest
            // 
            this.lblRequest.AutoSize = true;
            this.lblRequest.Location = new System.Drawing.Point(17, 163);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(147, 13);
            this.lblRequest.TabIndex = 4;
            this.lblRequest.Text = "Request (to Study Admin API)";
            // 
            // lblAccessKey
            // 
            this.lblAccessKey.AutoSize = true;
            this.lblAccessKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccessKey.Location = new System.Drawing.Point(17, 56);
            this.lblAccessKey.Name = "lblAccessKey";
            this.lblAccessKey.Size = new System.Drawing.Size(63, 13);
            this.lblAccessKey.TabIndex = 5;
            this.lblAccessKey.Text = "Access Key";
            // 
            // txtBxAccessKey
            // 
            this.txtBxAccessKey.Location = new System.Drawing.Point(117, 56);
            this.txtBxAccessKey.Name = "txtBxAccessKey";
            this.txtBxAccessKey.Size = new System.Drawing.Size(208, 20);
            this.txtBxAccessKey.TabIndex = 6;
            // 
            // txtBxResponse
            // 
            this.txtBxResponse.Location = new System.Drawing.Point(184, 372);
            this.txtBxResponse.Multiline = true;
            this.txtBxResponse.Name = "txtBxResponse";
            this.txtBxResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBxResponse.Size = new System.Drawing.Size(535, 126);
            this.txtBxResponse.TabIndex = 7;
            // 
            // lblResponse
            // 
            this.lblResponse.AutoSize = true;
            this.lblResponse.Location = new System.Drawing.Point(12, 372);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(166, 13);
            this.lblResponse.TabIndex = 8;
            this.lblResponse.Text = "Resposne (from Study Admin API)";
            // 
            // lblBaseURI
            // 
            this.lblBaseURI.AutoSize = true;
            this.lblBaseURI.Location = new System.Drawing.Point(17, 22);
            this.lblBaseURI.Name = "lblBaseURI";
            this.lblBaseURI.Size = new System.Drawing.Size(50, 13);
            this.lblBaseURI.TabIndex = 9;
            this.lblBaseURI.Text = "BaseURI";
            // 
            // cbBaseURI
            // 
            this.cbBaseURI.FormattingEnabled = true;
            this.cbBaseURI.Location = new System.Drawing.Point(117, 22);
            this.cbBaseURI.Name = "cbBaseURI";
            this.cbBaseURI.Size = new System.Drawing.Size(446, 21);
            this.cbBaseURI.TabIndex = 11;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(184, 300);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(112, 23);
            this.btnExecute.TabIndex = 12;
            this.btnExecute.Text = "Execute Test";
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // lblPrivateKey
            // 
            this.lblPrivateKey.AutoSize = true;
            this.lblPrivateKey.Location = new System.Drawing.Point(356, 59);
            this.lblPrivateKey.Name = "lblPrivateKey";
            this.lblPrivateKey.Size = new System.Drawing.Size(59, 13);
            this.lblPrivateKey.TabIndex = 13;
            this.lblPrivateKey.Text = "Secret Key";
            // 
            // txtBxSecretKey
            // 
            this.txtBxSecretKey.Location = new System.Drawing.Point(421, 56);
            this.txtBxSecretKey.Name = "txtBxSecretKey";
            this.txtBxSecretKey.Size = new System.Drawing.Size(298, 20);
            this.txtBxSecretKey.TabIndex = 14;
            // 
            // lblBaseURIRequired
            // 
            this.lblBaseURIRequired.AutoSize = true;
            this.lblBaseURIRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseURIRequired.ForeColor = System.Drawing.Color.Red;
            this.lblBaseURIRequired.Location = new System.Drawing.Point(570, 29);
            this.lblBaseURIRequired.Name = "lblBaseURIRequired";
            this.lblBaseURIRequired.Size = new System.Drawing.Size(0, 25);
            this.lblBaseURIRequired.TabIndex = 18;
            // 
            // lblAccessKeyRequired
            // 
            this.lblAccessKeyRequired.AutoSize = true;
            this.lblAccessKeyRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccessKeyRequired.ForeColor = System.Drawing.Color.Red;
            this.lblAccessKeyRequired.Location = new System.Drawing.Point(331, 59);
            this.lblAccessKeyRequired.Name = "lblAccessKeyRequired";
            this.lblAccessKeyRequired.Size = new System.Drawing.Size(0, 25);
            this.lblAccessKeyRequired.TabIndex = 19;
            // 
            // lblSecretKeyRequired
            // 
            this.lblSecretKeyRequired.AutoSize = true;
            this.lblSecretKeyRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecretKeyRequired.ForeColor = System.Drawing.Color.Red;
            this.lblSecretKeyRequired.Location = new System.Drawing.Point(726, 56);
            this.lblSecretKeyRequired.Name = "lblSecretKeyRequired";
            this.lblSecretKeyRequired.Size = new System.Drawing.Size(0, 25);
            this.lblSecretKeyRequired.TabIndex = 20;
            // 
            // lblRequestRequired
            // 
            this.lblRequestRequired.AutoSize = true;
            this.lblRequestRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestRequired.ForeColor = System.Drawing.Color.Red;
            this.lblRequestRequired.Location = new System.Drawing.Point(729, 163);
            this.lblRequestRequired.Name = "lblRequestRequired";
            this.lblRequestRequired.Size = new System.Drawing.Size(0, 25);
            this.lblRequestRequired.TabIndex = 21;
            // 
            // lblResponseRequired
            // 
            this.lblResponseRequired.AutoSize = true;
            this.lblResponseRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResponseRequired.ForeColor = System.Drawing.Color.Red;
            this.lblResponseRequired.Location = new System.Drawing.Point(732, 372);
            this.lblResponseRequired.Name = "lblResponseRequired";
            this.lblResponseRequired.Size = new System.Drawing.Size(0, 25);
            this.lblResponseRequired.TabIndex = 22;
            // 
            // lblTestRequired
            // 
            this.lblTestRequired.AutoSize = true;
            this.lblTestRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestRequired.ForeColor = System.Drawing.Color.Red;
            this.lblTestRequired.Location = new System.Drawing.Point(398, 99);
            this.lblTestRequired.Name = "lblTestRequired";
            this.lblTestRequired.Size = new System.Drawing.Size(0, 25);
            this.lblTestRequired.TabIndex = 23;
            // 
            // lblValidationError
            // 
            this.lblValidationError.AutoSize = true;
            this.lblValidationError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidationError.ForeColor = System.Drawing.Color.Red;
            this.lblValidationError.Location = new System.Drawing.Point(184, 281);
            this.lblValidationError.Name = "lblValidationError";
            this.lblValidationError.Size = new System.Drawing.Size(0, 17);
            this.lblValidationError.TabIndex = 24;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 561);
            this.Controls.Add(this.lblValidationError);
            this.Controls.Add(this.lblTestRequired);
            this.Controls.Add(this.lblResponseRequired);
            this.Controls.Add(this.lblRequestRequired);
            this.Controls.Add(this.lblSecretKeyRequired);
            this.Controls.Add(this.lblAccessKeyRequired);
            this.Controls.Add(this.lblBaseURIRequired);
            this.Controls.Add(this.txtBxSecretKey);
            this.Controls.Add(this.lblPrivateKey);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.cbBaseURI);
            this.Controls.Add(this.lblBaseURI);
            this.Controls.Add(this.lblResponse);
            this.Controls.Add(this.txtBxResponse);
            this.Controls.Add(this.txtBxAccessKey);
            this.Controls.Add(this.lblAccessKey);
            this.Controls.Add(this.lblRequest);
            this.Controls.Add(this.txtBxRequest);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.cBBuiltInTests);
            this.Name = "TestForm";
            this.Text = "Study Admin API Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBBuiltInTests;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.TextBox txtBxRequest;
        private System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.Label lblAccessKey;
        private System.Windows.Forms.TextBox txtBxAccessKey;
        private System.Windows.Forms.TextBox txtBxResponse;
        private System.Windows.Forms.Label lblResponse;
        private System.Windows.Forms.Label lblBaseURI;
        private System.Windows.Forms.ComboBox cbBaseURI;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label lblPrivateKey;
        private System.Windows.Forms.TextBox txtBxSecretKey;
        private System.Windows.Forms.Label lblBaseURIRequired;
        private System.Windows.Forms.Label lblAccessKeyRequired;
        private System.Windows.Forms.Label lblSecretKeyRequired;
        private System.Windows.Forms.Label lblRequestRequired;
        private System.Windows.Forms.Label lblResponseRequired;
        private System.Windows.Forms.Label lblTestRequired;
        private System.Windows.Forms.Label lblValidationError;
    }
}

