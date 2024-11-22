
namespace blockChain
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.MineButton = new System.Windows.Forms.Button();
            this.NodeBox = new System.Windows.Forms.TextBox();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.PortButton = new System.Windows.Forms.Button();
            this.ChainListBox = new System.Windows.Forms.ListBox();
            this.HashListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Node Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 2;
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(67, 39);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(40, 13);
            this.PortLabel.TabIndex = 3;
            this.PortLabel.Text = "no port";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(237, 9);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(65, 19);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // MineButton
            // 
            this.MineButton.Enabled = false;
            this.MineButton.Location = new System.Drawing.Point(308, 9);
            this.MineButton.Name = "MineButton";
            this.MineButton.Size = new System.Drawing.Size(68, 19);
            this.MineButton.TabIndex = 5;
            this.MineButton.Text = "Mine";
            this.MineButton.UseVisualStyleBackColor = true;
            this.MineButton.Click += new System.EventHandler(this.MineButton_Click);
            // 
            // NodeBox
            // 
            this.NodeBox.Location = new System.Drawing.Point(90, 9);
            this.NodeBox.Name = "NodeBox";
            this.NodeBox.Size = new System.Drawing.Size(141, 20);
            this.NodeBox.TabIndex = 6;
            // 
            // PortBox
            // 
            this.PortBox.Enabled = false;
            this.PortBox.Location = new System.Drawing.Point(475, 8);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(141, 20);
            this.PortBox.TabIndex = 7;
            // 
            // PortButton
            // 
            this.PortButton.Enabled = false;
            this.PortButton.Location = new System.Drawing.Point(652, 9);
            this.PortButton.Name = "PortButton";
            this.PortButton.Size = new System.Drawing.Size(103, 20);
            this.PortButton.TabIndex = 8;
            this.PortButton.Text = "Connect Port";
            this.PortButton.UseVisualStyleBackColor = true;
            this.PortButton.Click += new System.EventHandler(this.PortButton_Click);
            // 
            // ChainListBox
            // 
            this.ChainListBox.FormattingEnabled = true;
            this.ChainListBox.Location = new System.Drawing.Point(23, 79);
            this.ChainListBox.Name = "ChainListBox";
            this.ChainListBox.ScrollAlwaysVisible = true;
            this.ChainListBox.Size = new System.Drawing.Size(391, 368);
            this.ChainListBox.TabIndex = 9;
            // 
            // HashListBox
            // 
            this.HashListBox.FormattingEnabled = true;
            this.HashListBox.Location = new System.Drawing.Point(475, 79);
            this.HashListBox.Name = "HashListBox";
            this.HashListBox.ScrollAlwaysVisible = true;
            this.HashListBox.Size = new System.Drawing.Size(391, 368);
            this.HashListBox.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 485);
            this.Controls.Add(this.HashListBox);
            this.Controls.Add(this.ChainListBox);
            this.Controls.Add(this.PortButton);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.NodeBox);
            this.Controls.Add(this.MineButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button MineButton;
        private System.Windows.Forms.TextBox NodeBox;
        private System.Windows.Forms.TextBox PortBox;
        private System.Windows.Forms.Button PortButton;
        private System.Windows.Forms.ListBox ChainListBox;
        private System.Windows.Forms.ListBox HashListBox;
    }
}

