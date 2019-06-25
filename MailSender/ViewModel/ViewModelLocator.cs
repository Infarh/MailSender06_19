using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Services;
using MailSender.lib.Services.Linq2SQL;
using MailSender.lib.Services.InMemory;


namespace MailSender.ViewModel
{
    /// <summary>������� �������-�������������</summary>
    public class ViewModelLocator
    {
        /// <summary>����������� �������� ������� �������������. ����� �� ������������ ��� ��������� ������ ������������</summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #region ������ �� ������������� MVVM Light
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////} 
            #endregion

            if (!SimpleIoc.Default.IsRegistered<MailSenderDBContext>())
                SimpleIoc.Default.Register(() => new MailSenderDBContext());

            //SimpleIoc.Default.Register<IRecipientsDataService, RecipientsDataServiceLinq2SQL>();
            SimpleIoc.Default.Register<IRecipientsDataService, RecipientsDataServiceInMemory>();

            SimpleIoc.Default.Register<MainWindowViewModel>();
        }

        /// <summary>������-������������� �������� ����</summary>
        public MainWindowViewModel MainWindowViewModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();

        /// <summary>������ ����� ����� ������ ����� ������� ��������� ���������. ����� ���� ����������� ��� ������� ������.</summary>
        public static void Cleanup() { }
    }
}