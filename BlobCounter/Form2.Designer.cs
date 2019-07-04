using System.Windows.Forms;

namespace BlobCounter
{
    partial class Form2
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
            this.doneLabel = new System.Windows.Forms.Label();
            this.processPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // doneLabel
            // 
            this.doneLabel.AutoSize = true;
            this.doneLabel.Location = new System.Drawing.Point(94, 422);
            this.doneLabel.Name = "doneLabel";
            this.doneLabel.Size = new System.Drawing.Size(41, 13);
            this.doneLabel.TabIndex = 2;
            this.doneLabel.Text = "DONE!";
            this.doneLabel.Visible = false;
            // 
            // processPanel
            // 
            this.processPanel.AutoScroll = true;
            this.processPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.processPanel.Location = new System.Drawing.Point(13, 22);
            this.processPanel.Name = "processPanel";
            this.processPanel.Size = new System.Drawing.Size(980, 372);
            this.processPanel.TabIndex = 3;
            this.processPanel.WrapContents = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 450);
            this.Controls.Add(this.processPanel);
            this.Controls.Add(this.doneLabel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel progressTable = new TableLayoutPanel();
        private Label doneLabel;
        private FlowLayoutPanel processPanel;
    }
}