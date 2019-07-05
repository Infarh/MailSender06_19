using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Data;
using MailSender.lib.Data.BaseEntityes;
using MailSender.lib.Services;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRecipientsDataService _RecipientsDataService;
        private readonly ISendersDataService _SendersDataService;
        private readonly IServerDataService _ServerDataService;
        private readonly IMailMessageDataService _MailMessagesDataService;

        private readonly IMailSenderService _MailSenderService;

        private string _Title = "Рассыльщик почты";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private string _Status = "Готов!";

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        private ObservableCollection<Recipient> _Recipients;

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            private set => Set(ref _Recipients, value);
        }

        private Recipient _CurrentRecipient;

        public Recipient CurrentRecipient
        {
            get => _CurrentRecipient;
            set => Set(ref _CurrentRecipient, value);
        }

        public ObservableCollection<Server> Servers { get; } = new ObservableCollection<Server>();

        public ObservableCollection<Sender> Senders { get; } = new ObservableCollection<Sender>();

        public ObservableCollection<MailMessage> MailMessages { get; } = new ObservableCollection<MailMessage>();

        public ICommand UpdateDataCommand { get; }

        public ICommand CreateRecipientCommand { get; }

        public ICommand SaveRecipientCommand { get; }

        public ICommand ApplicationExitCommand { get; }

        public MainWindowViewModel(
            IRecipientsDataService RecipientsDataService,
            ISendersDataService SendersDataService,
            IServerDataService ServerDataService,
            IMailMessageDataService MailMessagesDataService,
            IMailSenderService MailSenderService
            )
        {
            _RecipientsDataService = RecipientsDataService;
            _SendersDataService = SendersDataService;
            _ServerDataService = ServerDataService;
            _MailMessagesDataService = MailMessagesDataService;

            _MailSenderService = MailSenderService;

            UpdateDataCommand = new RelayCommand(OnUpdateDataCommandExecuted, CanUpdateDataCommandExecute);
            CreateRecipientCommand = new RelayCommand(OnCreateRecipientCommandExecuted, CanCreateRecipientCommandExecute);
            SaveRecipientCommand = new RelayCommand<Recipient>(OnSaveRecipientCommandExecuted, CanSaveRecipientCommandExecuted);

            ApplicationExitCommand = new RelayCommand(OnApplicationExitCommanExecuted, () => true, true);

            //UpdateData();
        }

        private static void OnApplicationExitCommanExecuted()
        {
            Application.Current.Shutdown();
        }

        private bool CanSaveRecipientCommandExecuted(Recipient recipient) => recipient != null && recipient.Name.Length > 3;

        private void OnSaveRecipientCommandExecuted(Recipient recipient)
        {
            _RecipientsDataService.Edit(recipient.Id, recipient);
        }

        private bool CanCreateRecipientCommandExecute() => true;

        private void OnCreateRecipientCommandExecuted()
        {
            var new_recipient = new Recipient
            {
                Name = "New recpient",
                Address = "recipient@server.com"
            };
            _RecipientsDataService.Add(new_recipient);
            _Recipients.Add(new_recipient);
            CurrentRecipient = new_recipient;
        }

        private bool CanUpdateDataCommandExecute() => true;

        private void OnUpdateDataCommandExecuted()
        {
            UpdateData();
        }

        public void UpdateData()
        {
            Recipients = new ObservableCollection<Recipient>(_RecipientsDataService.GetAll());

            void UpdateData<T>(IDataService<T> Service, ObservableCollection<T> Collection)
                where T : Entity
            {
                Collection.Clear();
                foreach (var entity in Service.GetAll())
                    Collection.Add(entity);
            }

            UpdateData(_ServerDataService, Servers);
            UpdateData(_SendersDataService, Senders);
            UpdateData(_MailMessagesDataService, MailMessages);
        }
    }
}
