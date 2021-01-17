
namespace Hardware___Intermetiary
{
    partial class PortForm
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
            this.lbxPorts = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetPort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxPorts
            // 
            this.lbxPorts.FormattingEnabled = true;
            this.lbxPorts.ItemHeight = 20;
            this.lbxPorts.Location = new System.Drawing.Point(87, 64);
            this.lbxPorts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbxPorts.Name = "lbxPorts";
            this.lbxPorts.Size = new System.Drawing.Size(173, 164);
            this.lbxPorts.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the car port below:";
            // 
            // btnSetPort
            // 
            this.btnSetPort.Location = new System.Drawing.Point(126, 237);
            this.btnSetPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetPort.Name = "btnSetPort";
            this.btnSetPort.Size = new System.Drawing.Size(105, 31);
            this.btnSetPort.TabIndex = 2;
            this.btnSetPort.Text = "Select Port";
            this.btnSetPort.UseVisualStyleBackColor = true;
            this.btnSetPort.Click += new System.EventHandler(this.btnSetPort_Click);
            // 
            // PortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 291);
            this.Controls.Add(this.btnSetPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxPorts);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PortForm";
            this.Text = "PortForm";
            this.Load += new System.EventHandler(this.PortForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetPort;
    }
}