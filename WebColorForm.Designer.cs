namespace MyeFusen
{
    partial class WebColorForm
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
            this.WebColorListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // WebColorListBox
            // 
            this.WebColorListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebColorListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.WebColorListBox.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.WebColorListBox.FormattingEnabled = true;
            this.WebColorListBox.ItemHeight = 20;
            this.WebColorListBox.Location = new System.Drawing.Point(0, 0);
            this.WebColorListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WebColorListBox.Name = "WebColorListBox";
            this.WebColorListBox.Size = new System.Drawing.Size(233, 250);
            this.WebColorListBox.TabIndex = 0;
            this.WebColorListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.WebColorListBox_DrawItem);
            this.WebColorListBox.SelectedValueChanged += new System.EventHandler(this.WebColorListBox_SelectedValueChanged);
            // 
            // WebColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 250);
            this.Controls.Add(this.WebColorListBox);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WebColorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WebColorForm";
            this.TopMost = true;
            this.VisibleChanged += new System.EventHandler(this.WebColorForm_VisibleChanged);
            this.MouseLeave += new System.EventHandler(this.WebColorForm_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox WebColorListBox;
    }
}