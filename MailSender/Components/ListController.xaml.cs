using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender.Components
{
    public partial class ListController : UserControl/*, INotifyPropertyChanged*/
    {
        #region Обычное объявление свойства

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        //}

        //private string _PanelName = "Тестовая панель";

        //public string PanelName
        //{
        //    get => _PanelName;
        //    set
        //    {
        //        _PanelName = value;
        //        OnPropertyChanged();
        //    }
        //} 

        #endregion

        #region PanelName : string - Название панели

        /// <summary>Название панели</summary>
        public static readonly DependencyProperty PanelNameProperty =
            DependencyProperty.Register(
                nameof(PanelName),
                typeof(string),
                typeof(ListController),
                new PropertyMetadata("Панель"));

        /// <summary>Название панели</summary>
        public string PanelName
        {
            get => (string) GetValue(PanelNameProperty);
            set => SetValue(PanelNameProperty, value);
        }

        #endregion

        #region ItemSource : IEnumerable - Управляемый список

        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register(
                "ItemSource",
                typeof(IEnumerable),
                typeof(ListController),
                new PropertyMetadata(default(IEnumerable)));

        public IEnumerable ItemSource
        {
            get => (IEnumerable) GetValue(ItemSourceProperty);
            set => SetValue(ItemSourceProperty, value);
        }

        #endregion

        #region SelectedItem : object - Выбранный элемент

        /// <summary>Выбранный элемент</summary>
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                nameof(SelectedItem),
                typeof(object),
                typeof(ListController),
                new PropertyMetadata(default(object)));

        /// <summary>Выбранный элемент</summary>
        public object SelectedItem
        {
            get => (object) GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        #endregion

        #region CreateCommand : ICommand - Команда - Создать новый элемент

        /// <summary>Команда - Создать новый элемент</summary>
        public static readonly DependencyProperty CreateCommandProperty =
            DependencyProperty.Register(
                nameof(CreateCommand),
                typeof(ICommand),
                typeof(ListController),
                new PropertyMetadata(default(ICommand)));

        /// <summary>Команда - Создать новый элемент</summary>
        public ICommand CreateCommand
        {
            get => (ICommand) GetValue(CreateCommandProperty);
            set => SetValue(CreateCommandProperty, value);
        }

        #endregion

        #region EditCommand : ICommand - Команда - редактировать выбранный элемент

        /// <summary>Команда - редактировать выбранный элемент</summary>
        public static readonly DependencyProperty EditCommandProperty =
            DependencyProperty.Register(
                nameof(EditCommand),
                typeof(ICommand),
                typeof(ListController),
                new PropertyMetadata(default(ICommand)));

        /// <summary>Команда - редактировать выбранный элемент</summary>
        public ICommand EditCommand
        {
            get => (ICommand) GetValue(EditCommandProperty);
            set => SetValue(EditCommandProperty, value);
        }

        #endregion

        #region RemoveCommand : ICommand - Удалить выбранный элемент

        /// <summary>Удалить выбранный элемент</summary>
        public static readonly DependencyProperty RemoveCommandProperty =
            DependencyProperty.Register(
                nameof(RemoveCommand),
                typeof(ICommand),
                typeof(ListController),
                new PropertyMetadata(default(ICommand)));

        /// <summary>Удалить выбранный элемент</summary>
        public ICommand RemoveCommand
        {
            get => (ICommand) GetValue(RemoveCommandProperty);
            set => SetValue(RemoveCommandProperty, value);
        }

        #endregion

        #region SelectedIndex : int - Номер выбранного элемента

        /// <summary>Номер выбранного элемента</summary>
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register(
                nameof(SelectedIndex),
                typeof(int),
                typeof(ListController),
                new PropertyMetadata(default(int)));

        /// <summary>Номер выбранного элемента</summary>
        public int SelectedIndex
        {
            get => (int) GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }

        #endregion

        #region ItemTemplate : DataTemplate - Шаблон визуализации элемента списка

        /// <summary>Шаблон визуализации элемента списка</summary>
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register(
                nameof(ItemTemplate),
                typeof(DataTemplate),
                typeof(ListController),
                new PropertyMetadata(default(DataTemplate)));

        /// <summary>Шаблон визуализации элемента списка</summary>
        public DataTemplate ItemTemplate
        {
            get => (DataTemplate) GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        #endregion

        public ListController()
        {
            InitializeComponent();
        }
    }
}
