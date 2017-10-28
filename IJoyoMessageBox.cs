using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GX.Common
{
    public interface IJoyoMessageBox
    {
        DialogResult Show(string text);
        DialogResult Show(IWin32Window owner, string text);
        DialogResult Show(string text, string caption);
        DialogResult Show(IWin32Window owner, string text, string caption);
        DialogResult Show(string text, string caption, MessageBoxButtons buttons);
        DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons);
        DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
        DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
        DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton);
        DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton);
        //DialogResult Show(IWin32Window owner, string text, string caption, DialogResult[] buttons, Icon icon, int defaultButton, MessageBoxIcon messageBeepSound);

        //DialogResult Show(UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption);
        //DialogResult Show(UserLookAndFeel lookAndFeel, IWin32Window owner, string text);
        //DialogResult Show(UserLookAndFeel lookAndFeel, string text, string caption);
        //DialogResult Show(UserLookAndFeel lookAndFeel, string text, string caption, MessageBoxButtons buttons);
        //DialogResult Show(UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption, MessageBoxButtons buttons);
        //DialogResult Show(UserLookAndFeel lookAndFeel, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
        //DialogResult Show(UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
        //DialogResult Show(UserLookAndFeel lookAndFeel, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton);
        //DialogResult Show(UserLookAndFeel lookAndFeel, string text);
        //DialogResult Show(UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton);
        //DialogResult Show(UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption, DialogResult[] buttons, Icon icon, int defaultButton, MessageBoxIcon messageBeepSound);
    }

    public class WinFormMessageBox : IJoyoMessageBox
    {
        public DialogResult Show(string text)
        {
            return System.Windows.Forms.MessageBox.Show(text);
        }

        public DialogResult Show(IWin32Window owner, string text)
        {
            return MessageBox.Show(owner, text);
        }

        public DialogResult Show(string text, string caption)
        {
            return MessageBox.Show(text, caption);
        }

        public DialogResult Show(IWin32Window owner, string text, string caption)
        {
            return MessageBox.Show(owner, text, caption);
        }

        public DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
           return MessageBox.Show(text, caption, buttons);
        }

        public DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            return MessageBox.Show(owner, text, caption, buttons);
        }

        public DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }

        public DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(owner, text, caption, buttons, icon);
        }

        public DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(text, caption, buttons, icon, defaultButton);
        }

        public DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton);
        }

        //public DialogResult Show(IWin32Window owner, string text, string caption, DialogResult[] buttons, Icon icon, int defaultButton, MessageBoxIcon messageBeepSound)
        //{
        //    return System.Windows.Forms.MessageBox.Show(owner, text, caption, buttons, icon, defaultButton, messageBeepSound);
        //}

    }




}
