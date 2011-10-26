using System;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Editor;
using System.Windows;

namespace DevErrorHandler
{
    internal sealed class ErrorMargin : Canvas, IWpfTextViewMargin
    {
        internal const string MarginName = "ErrorMargin";

        private readonly ITextView _textView;
        private readonly ErrorMarginControl _errorMarginControl;

        internal ErrorMargin(ITextView textView)
        {
            _textView = textView;
            _errorMarginControl = new ErrorMarginControl();
        }

        #region IWpfTextViewMargin

        FrameworkElement IWpfTextViewMargin.VisualElement
        {
            get { return _errorMarginControl; }
        }

        bool ITextViewMargin.Enabled
        {
            get { return true; }
        }

        ITextViewMargin ITextViewMargin.GetTextViewMargin(string marginName)
        {
            return marginName == MarginName ? this : null;
        }

        double ITextViewMargin.MarginSize
        {
            get { return 25; }
        }

        void IDisposable.Dispose()
        {
            
        }

        #endregion
    }
}