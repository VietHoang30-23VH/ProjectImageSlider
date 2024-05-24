namespace ImageSlider
{
    partial class Slider
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
            this.panel = new System.Windows.Forms.Panel();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.btnPreview = new Guna.UI2.WinForms.Guna2Button();
            this.btnSource = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.panelContainer);
            this.panel.Controls.Add(this.panel3);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1240, 785);
            this.panel.TabIndex = 1;
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 66);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1240, 719);
            this.panelContainer.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.guna2Button1);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnPreview);
            this.panel3.Controls.Add(this.btnSource);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1240, 66);
            this.panel3.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnExit.CheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.btnExit.CheckedState.CustomBorderColor = System.Drawing.Color.Red;
            this.btnExit.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnExit.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnExit.CustomBorderColor = System.Drawing.Color.White;
            this.btnExit.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.HoverState.CustomBorderColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(1015, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.PressedColor = System.Drawing.Color.White;
            this.btnExit.Size = new System.Drawing.Size(213, 60);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnPreview.CheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.btnPreview.CheckedState.CustomBorderColor = System.Drawing.Color.Red;
            this.btnPreview.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnPreview.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnPreview.CustomBorderColor = System.Drawing.Color.White;
            this.btnPreview.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnPreview.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPreview.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPreview.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPreview.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPreview.FillColor = System.Drawing.Color.White;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.Black;
            this.btnPreview.HoverState.CustomBorderColor = System.Drawing.Color.Red;
            this.btnPreview.Location = new System.Drawing.Point(12, 3);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.PressedColor = System.Drawing.Color.White;
            this.btnPreview.Size = new System.Drawing.Size(213, 60);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnSource
            // 
            this.btnSource.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSource.Checked = true;
            this.btnSource.CheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.btnSource.CheckedState.CustomBorderColor = System.Drawing.Color.Red;
            this.btnSource.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnSource.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnSource.CustomBorderColor = System.Drawing.Color.White;
            this.btnSource.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnSource.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSource.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSource.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSource.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSource.FillColor = System.Drawing.Color.White;
            this.btnSource.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSource.ForeColor = System.Drawing.Color.Black;
            this.btnSource.HoverState.CustomBorderColor = System.Drawing.Color.Red;
            this.btnSource.Location = new System.Drawing.Point(332, 3);
            this.btnSource.Name = "btnSource";
            this.btnSource.PressedColor = System.Drawing.Color.White;
            this.btnSource.Size = new System.Drawing.Size(213, 60);
            this.btnSource.TabIndex = 1;
            this.btnSource.Text = "Source";
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button1.CheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button1.CheckedState.CustomBorderColor = System.Drawing.Color.Red;
            this.guna2Button1.CheckedState.FillColor = System.Drawing.Color.White;
            this.guna2Button1.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.CustomBorderColor = System.Drawing.Color.White;
            this.guna2Button1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.HoverState.CustomBorderColor = System.Drawing.Color.Red;
            this.guna2Button1.Location = new System.Drawing.Point(722, 3);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.PressedColor = System.Drawing.Color.White;
            this.guna2Button1.Size = new System.Drawing.Size(213, 60);
            this.guna2Button1.TabIndex = 4;
            this.guna2Button1.Text = "ClientList";
            // 
            // Slider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 789);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Slider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Slider";
            this.panel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button btnSource;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2Button btnPreview;
        private System.Windows.Forms.Panel panelContainer;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}