namespace MyeFusen
{
    partial class FontForm
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
            this.FontListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // FontListBox
            // 
            this.FontListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FontListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.FontListBox.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FontListBox.FormattingEnabled = true;
            this.FontListBox.IntegralHeight = false;
            this.FontListBox.ItemHeight = 20;
            this.FontListBox.Location = new System.Drawing.Point(0, 0);
            this.FontListBox.Margin = new System.Windows.Forms.Padding(0);
            this.FontListBox.Name = "FontListBox";
            this.FontListBox.Size = new System.Drawing.Size(250, 200);
            this.FontListBox.TabIndex = 0;
            this.FontListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.FontListBox_DrawItem);
            this.FontListBox.SelectedValueChanged += new System.EventHandler(this.FontListBox_SelectedValueChanged);
            // 
            // FontForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(250, 200);
            this.ControlBox = false;
            this.Controls.Add(this.FontListBox);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FontForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.FontForm_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox FontListBox;
    }
}