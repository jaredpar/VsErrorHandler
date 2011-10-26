using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace TestErrorMargin
{
    #region TestErrorMargin Factory
    /// <summary>
    /// Export a <see cref="IWpfTextViewMarginProvider"/>, which returns an instance of the margin for the editor
    /// to use.
    /// </summary>
    [Export(typeof(IWpfTextViewMarginProvider))]
    [Name(TestErrorMargin.MarginName)]
    [Order(After = PredefinedMarginNames.HorizontalScrollBar)] //Ensure that the margin occurs below the horizontal scrollbar
    [MarginContainer(PredefinedMarginNames.Bottom)] //Set the container to the bottom of the editor window
    [ContentType("text")] //Show this margin for all text-based types
    [TextViewRole(PredefinedTextViewRoles.Interactive)]
    internal sealed class MarginFactory : IWpfTextViewMarginProvider
    {
        public IWpfTextViewMargin CreateMargin(IWpfTextViewHost textViewHost, IWpfTextViewMargin containerMargin)
        {
            return new TestErrorMargin(textViewHost.TextView);
        }
    }
    #endregion
}
