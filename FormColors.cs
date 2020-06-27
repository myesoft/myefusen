using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Windows.Forms.ColorPicker;

namespace MyeFusen {
	/// <summary>
	/// Summary description for FormColors.
	/// </summary>
	public class FormColors : System.Windows.Forms.Form {

        public event ColorSelectedEventHandler ColorSelected;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormColors() {
			InitializeComponent();
            m_colorSelector.ColorSelected += new ColorSelectedEventHandler(this.OnColorSelected);
		}

        private System.Windows.Forms.Panel m_panelBorder;

        private System.Windows.Forms.ColorPicker.MultiTabColorPicker m_colorSelector;

        public Color Color {
            set {
                m_colorSelector.Color = value;
            }
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                m_colorSelector.ColorSelected -= new ColorSelectedEventHandler(this.OnColorSelected);
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        ///   Resizes the window to fit the ColorTabControl
        /// </summary>
        /// <param name="levent"></param>
        protected override void OnLayout(LayoutEventArgs levent) {
            base.OnLayout(levent);
            int dHeight = this.m_colorSelector.Height - m_panelBorder.ClientRectangle.Height;
            int dWidth = this.m_colorSelector.Width - m_panelBorder.ClientRectangle.Width;
            this.Height += dHeight;
            this.Width += dWidth;
        }

        /// <summary>
        ///   Window is closed automatically if it loses focus.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDeactivate(EventArgs e) {
            base.OnDeactivate(e);
            this.Hide();
        }

        /// <summary>
        ///   Hides the window when ESC key is pressed.
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData) {
            if (keyData == Keys.Escape) {
                this.Hide();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }


        /// <summary>
        ///   Closes window and forwards color selection event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnColorSelected(object sender, ColorSelectedEventArgs e) 
        {
            //this.Hide();
            if (ColorSelected != null)
                ColorSelected(sender, e);
        }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_colorSelector = new System.Windows.Forms.ColorPicker.MultiTabColorPicker();
            this.m_panelBorder = new System.Windows.Forms.Panel();
            this.m_panelBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_colorSelector
            // 
            this.m_colorSelector.Location = new System.Drawing.Point(0, 0);
            this.m_colorSelector.Name = "m_colorSelector";
            this.m_colorSelector.Size = new System.Drawing.Size(198, 183);
            this.m_colorSelector.TabIndex = 0;
            // 
            // m_panelBorder
            // 
            this.m_panelBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelBorder.Controls.Add(this.m_colorSelector);
            this.m_panelBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelBorder.Location = new System.Drawing.Point(0, 0);
            this.m_panelBorder.Name = "m_panelBorder";
            this.m_panelBorder.Size = new System.Drawing.Size(200, 200);
            this.m_panelBorder.TabIndex = 1;
            // 
            // FormColors
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(200, 200);
            this.Controls.Add(this.m_panelBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormColors";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Select a color";
            this.m_panelBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

	}
}