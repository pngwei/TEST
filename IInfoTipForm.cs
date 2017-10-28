using System;
using System.Collections.Generic;
using System.Text;


namespace GX.Common
{
    public interface IInfoTipForm 
    {
        bool IsDisposed
        {
            get;
        }
        bool Visible
        {
            get;
        }
        void CloseForm();
        void HideInfoTipForm();
        void ShowInfo(string infoText, PopupMessageType infoMessageType);
        void ShowInfoTipForm();
        void ShowInfoTipForm(PopupMessageType showTab);
        void ShowInfoTipFormInner();
    }
}
