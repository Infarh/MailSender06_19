using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MailSender.lib.MVVM;
using Microsoft.Win32;

namespace MailSender.WPFTest
{
    class Window2ViewModel : ViewModel
    {
        public ICommand OpenFileCommand { get; }

        public Window2ViewModel()
        {
            OpenFileCommand = new LamdaCommand(OnOpenFileCommandExecuted);
        }

        private async void OnOpenFileCommandExecuted(object Obj)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Выбор файла для анализа",
                Filter = "Текстовые файлы (*.txt)|*.txt|Архивы (*.zip)|*.zip|Все файлы (*.*)|*.*"
            };

            if (dialog.ShowDialog() != true) return;

            var file_name = dialog.FileName;

            switch (Path.GetExtension(file_name).ToLower())
            {
                case ".zip":
                    break;
                case ".txt":
                    break;
            }
        }

        private async Task ParseZip(string FileName)
        {
            var result = new List<Dictionary<string, int>>();
            using (var file = File.OpenRead(FileName))
            using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
            {
                foreach (var zip_archive_entry in zip.Entries)
                {
                    var dict = await ParseZipEntry(zip_archive_entry);
                    result.Add(dict);
                }
            }
        }

        private async Task<Dictionary<string, int>> ParseZipEntry(ZipArchiveEntry entry)
        {
            var result = new Dictionary<string, int>();
            using (var data_stream = entry.Open())
            using (var reader = new StreamReader(data_stream))
                while (!reader.EndOfStream)
                {
                    var str = await reader.ReadLineAsync().ConfigureAwait(false);
                    var words = str.Split(' ');
                    foreach (var word in words)
                    {
                        result[word.Trim(',', '!', '.', '?').ToLower()]++;
                    }
                }

            return result;
        }
    }
}
