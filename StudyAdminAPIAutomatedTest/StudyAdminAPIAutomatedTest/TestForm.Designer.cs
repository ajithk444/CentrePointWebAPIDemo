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
            this.lblEndpoint = new System.Windows.Forms.Label();
            this.lblEndpointResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.txtBxRequest.Location = new System.Drawing.Point(184, 163);
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
            this.btnExecute.Location = new System.Drawing.Point(374, 287);
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
            // lblEndpoint
            // 
            this.lblEndpoint.AutoSize = true;
            this.lblEndpoint.Location = new System.Drawing.Point(17, 133);
            this.lblEndpoint.Name = "lblEndpoint";
            this.lblEndpoint.Size = new System.Drawing.Size(49, 13);
            this.lblEndpoint.TabIndex = 15;
            this.lblEndpoint.Text = "Endpoint";
            // 
            // lblEndpointResult
            // 
            this.lblEndpointResult.AutoSize = true;
            this.lblEndpointResult.Location = new System.Drawing.Point(117, 133);
            this.lblEndpointResult.Name = "lblEndpointResult";
            this.lblEndpointResult.Size = new System.Drawing.Size(0, 13);
            this.lblEndpointResult.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 17;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEndpointResult);
            this.Controls.Add(this.lblEndpoint);
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
            this.Text = "Study Admin API Automated Tests";
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
        private System.Windows.Forms.Label lblEndpoint;
        private System.Windows.Forms.Label lblEndpointResult;
        private System.Windows.Forms.Label label1;
    }
}

