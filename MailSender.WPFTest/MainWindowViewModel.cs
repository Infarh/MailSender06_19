using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using MailSender.lib.MVVM;

namespace MailSender.WPFTest
{
    /// <summary>Пример собственной подели представления</summary>
    class MainWindowViewModel : ViewModel
    {
        /// <summary>Поле для хранения данных заголовка</summary>
        private string _Title = "Test Application";

        /// <summary>Заголовок</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        /// <summary>Поле для хранения данных положения</summary>
        private double _Position;

        /// <summary>Положение</summary>
        public double Position
        {
            get => _Position;
            set => Set(ref _Position, value);
        }

        /// <summary>Поле для хранения данных угла</summary>
        private double _Angle;

        /// <summary>Угол</summary>
        public double Angle
        {
            get => _Angle;
            set => Set(ref _Angle, value);
        }

        /// <summary>Поле для хранени яданных времени</summary>
        private DateTime _Time = DateTime.Now;

        /// <summary>Время</summary>
        public DateTime Time
        {
            get => _Time;
            private set => Set(ref _Time, value);
        }

        /// <summary>Таймер обновления времени</summary>
        private readonly DispatcherTimer _Timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(1),
            IsEnabled = true
        };

        /// <summary>Новая модель-представления главного окна</summary>
        public MainWindowViewModel() => _Timer.Tick += (s, e) => Time = DateTime.Now;
    }
}
