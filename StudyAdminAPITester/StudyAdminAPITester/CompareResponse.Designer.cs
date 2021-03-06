﻿namespace StudyAdminAPITester
{
    partial class CompareResponse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareResponse));
            this.txtResponseCompare = new System.Windows.Forms.TextBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.grpBoxCompare = new System.Windows.Forms.GroupBox();
            this.lblMatchStatus = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpBoxCompare.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResponseCompare
            // 
            this.txtResponseCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponseCompare.Location = new System.Drawing.Point(3, 17);
            this.txtResponseCompare.MaxLength = 200000;
            this.txtResponseCompare.Multiline = true;
            this.txtResponseCompare.Name = "txtResponseCompare";
            this.txtResponseCompare.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponseCompare.Size = new System.Drawing.Size(436, 153);
            this.txtResponseCompare.TabIndex = 0;
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCompare.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompare.Image = global::StudyAdminAPITester.Properties.Resources.compare;
            this.btnCompare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompare.Location = new System.Drawing.Point(56, 188);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(116, 31);
            this.btnCompare.TabIndex = 1;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            // 
            // grpBoxCompare
            // 
            this.grpBoxCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxCompare.Controls.Add(this.txtResponseCompare);
            this.grpBoxCompare.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxCompare.Location = new System.Drawing.Point(12, 12);
            this.grpBoxCompare.Name = "grpBoxCompare";
            this.grpBoxCompare.Size = new System.Drawing.Size(442, 173);
            this.grpBoxCompare.TabIndex = 2;
            this.grpBoxCompare.TabStop = false;
            this.grpBoxCompare.Text = "Compare Response With";
            // 
            // lblMatchStatus
            // 
            this.lblMatchStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMatchStatus.AutoSize = true;
            this.lblMatchStatus.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatchStatus.ForeColor = System.Drawing.Color.Red;
            this.lblMatchStatus.Image = global::StudyAdminAPITester.Properties.Resources.cancel_small;
            this.lblMatchStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMatchStatus.Location = new System.Drawing.Point(9, 224);
            this.lblMatchStatus.Name = "lblMatchStatus";
            this.lblMatchStatus.Size = new System.Drawing.Size(152, 14);
            this.lblMatchStatus.TabIndex = 4;
            this.lblMatchStatus.Text = "    Missing Compare Field";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::StudyAdminAPITester.Properties.Resources.cancel_black;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(280, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // CompareResponse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 247);
            this.Controls.Add(this.lblMatchStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpBoxCompare);
            this.Controls.Add(this.btnCompare);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(475, 286);
            this.Name = "CompareResponse";
            this.Text = "Compare Response";
            this.grpBoxCompare.ResumeLayout(false);
            this.grpBoxCompare.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResponseCompare;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.GroupBox grpBoxCompare;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMatchStatus;
    }
}