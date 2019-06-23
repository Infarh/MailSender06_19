using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Services;
using MailSender.lib.Services.Linq2SQL;


namespace MailSender.ViewModel
{
    /// <summary>Локатор моделей-представления</summary>
    public class ViewModelLocator
    {
        /// <summary>Конструктор локатора моделей представления. Здесь мы регистрируем все кирпичики нашего конструткора</summary>
        public ViewModelLocator()
        {
            // Регистрируем провайдера контекнера инверсии управления и внедрения зависимости
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #region Пример от разработчиков MVVM Light
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

            // Проверяем - зарегистрирован ли уже в контейнере сервис - "Контекст БД Linq2SQL"?
            if (!SimpleIoc.Default.IsRegistered<MailSenderDBContext>())      // Если нет, то регистрируем
                SimpleIoc.Default.Register(() => new MailSenderDBContext()); // Регистрируем контекст с помощью фабричного метода

            // Далее регистрируем наш первый сервис доступа к данным
            SimpleIoc.Default.Register<IRecipientsDataService, RecipientsDataServiceLinq2SQL>();
            // Сервис данных получателей почты требует для своей работы в конструкторе MailSenderDBContext! А он зарегистрирован у нас выше

            // Также регистрируем все используемые нами модели-представления. Их в приложении может быть одна, а может быть 1000. Количество не имеет значения.
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MainWindowViewModel>(); // MainWindowViewModel в конструкторе требует IRecipientsDataService, а он у нас зарегистрирован в контейнере.

            // Если мы забудем зарегистрировать одну из зависимостей у какого-то класса, то мы получим ошибку времени исполнения при попытке создать экземпляр этого класса!


            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // !!! Порядок регистрации сервисов здесь не важен !!!
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        /// <summary>Модель-представления главного окна</summary>
        public MainWindowViewModel MainWindowViewModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();

        /// <summary>Данный метод будет вызван перед штатным закрытием программы. Может быть использован для очистки мусора.</summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}