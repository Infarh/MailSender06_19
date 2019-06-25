using System.Windows;
using System.Windows.Controls;

namespace MailSender.View
{
    /// <summary>Представление редактора данных получателя почты</summary>
    public partial class RecipientInfoEditor
    {
        public RecipientInfoEditor() => InitializeComponent();

        private void OnDataValidationError(object Sender, ValidationErrorEventArgs E)
        {
            var error_control = (Control)E.OriginalSource;
            if (E.Action == ValidationErrorEventAction.Added)
            {
                error_control.ToolTip = E.Error.ErrorContent.ToString();
            }
            else
            {
                error_control.ToolTip = DependencyProperty.UnsetValue;
            }
        }
    }
}
