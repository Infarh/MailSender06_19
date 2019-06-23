using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.MVVM
{
    /// <summary>Модель-представления</summary>
    public abstract class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие возникает при изменении одного из свойств модели-представления.
        /// В параметре события передаётся имя изменившегося свойства</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Метод генерирования события изменения свойства</summary>
        /// <param name="PropertyName">
        /// Имя изменившегося свойства.
        /// Если не указано, то используется имя метода/свойства из которого вызыван данный метод.
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        /// <summary>Метод установки значения поля свойства, позволяющий автоматизировать генерацию события изменения свойства</summary>
        /// <typeparam name="T">Тип данных поля/свойства</typeparam>
        /// <param name="field">Ссылка на поле, в котором свойство хранит свои данные</param>
        /// <param name="value">Значение, которое требуется установить для свойства</param>
        /// <param name="PropertyName">Имя свойства, которое нужно изменить. По умолчанию указывать его не надо.</param>
        /// <returns>Истина, если значение свойства было изменено</returns>
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
