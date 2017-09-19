﻿using DarkUI.Config;
using DarkUI.Docking;
using DarkUI.Forms;
using System.Drawing;
using System.Windows.Forms;

namespace Example
{
    public partial class DockDocument : DarkDocument
    {
        #region Constructor Region

        public DockDocument()
        {
            InitializeComponent();

            // Workaround to stop the textbox from highlight all text.
            txtDocument.SelectionStart = txtDocument.Text.Length;
        }

        public DockDocument(string text, Image icon)
            : this()
        {
            DockText = text;
            Icon = icon;
        }

        #endregion

        #region Event Handler Region

        public override void Close()
        {
            var result = DarkMessageBox.ShowWarning(@"You will lose any unsaved changes. Continue?", @"Close document", DarkDialogButton.YesNo);
            if (result == DialogResult.No)
                return;

            base.Close();
        }

        #endregion

        private void txtDocument_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
