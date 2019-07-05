using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MailSender.WPFTest
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = (Button)sender;

            var thread_id1 = Thread.CurrentThread.ManagedThreadId;

            var result = await Task.Run(() => LongCompution("Hello Wold!")).ConfigureAwait(true);

            var thread_id2 = Thread.CurrentThread.ManagedThreadId;

            DataResult.Text = result.ToString();
        }

        private async Task<int> LongCompution(string str)
        {
            var thread_id1 = Thread.CurrentThread.ManagedThreadId;

            await Task.Delay(1500);

            var thread_id2 = Thread.CurrentThread.ManagedThreadId;
            return str.Length;
        }
    }
}
