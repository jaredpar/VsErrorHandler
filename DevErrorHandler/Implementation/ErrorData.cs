using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Text;
using System.ComponentModel.Composition;

namespace DevErrorHandler.Implementation
{
    [Export(typeof(IExtensionErrorHandler))]
    [Export(typeof(IErrorData))]
    internal sealed class ErrorData : IExtensionErrorHandler, IErrorData
    {
        private bool _ignoreAll;
        private event EventHandler<ExceptionEventArgs> _errorThrownEvent;
        private event EventHandler _errorIgnoredEvent;

        #region IExtensionErrorHandler

        void IExtensionErrorHandler.HandleError(object sender, Exception exception)
        {
            if (_ignoreAll)
            {
                return;
            }

            if (_errorThrownEvent != null)
            {
                var args = new ExceptionEventArgs(exception);
                _errorThrownEvent(this, args);
            }
        }

        #endregion

        #region IErrorData

        bool IErrorData.IgnoreAll
        {
            get { return _ignoreAll; }
            set { _ignoreAll = value; }
        }

        void IErrorData.IgnoreLastError()
        {
            if (_errorIgnoredEvent != null)
            {
                _errorIgnoredEvent(this, EventArgs.Empty);
            }
        }

        event EventHandler<ExceptionEventArgs> IErrorData.ErrorThrown
        {
            add { _errorThrownEvent += value; }
            remove { _errorThrownEvent -= value; }
        }

        event EventHandler IErrorData.ErrorIgnored
        {
            add { _errorIgnoredEvent += value; }
            remove { _errorIgnoredEvent -= value; }
        }

        #endregion
    }
}
