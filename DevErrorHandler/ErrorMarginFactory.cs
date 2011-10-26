using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace DevErrorHandler
{
    [Export(typeof(IWpfTextViewMarginProvider))]
    [Name(ErrorMargin.MarginName)]
    [MarginContainer(PredefinedMarginNames.Top)]
    [ContentType("text")]
    [TextViewRole(PredefinedTextViewRoles.Interactive)]
    internal sealed class ErrorMarginFactory : IWpfTextViewMarginProvider
    {
        IWpfTextViewMargin IWpfTextViewMarginProvider.CreateMargin(IWpfTextViewHost textViewHost, IWpfTextViewMargin containerMargin)
        {
            return new ErrorMargin(textViewHost.TextView);
        }
    }
}
