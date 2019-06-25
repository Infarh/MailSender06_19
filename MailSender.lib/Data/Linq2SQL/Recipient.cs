using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.Linq2SQL
{
    public partial class Recipient : IDataErrorInfo
    {
        partial void OnNameChanging(string value)
        {
            if(value is null)
                throw new ArgumentNullException(nameof(value), "Передана пустая ссылка на строку имени");

            //if(value.Length < 3)
            //    throw new InvalidOperationException("Строка имени должна быть больше 3 символов");
        }

        string IDataErrorInfo.Error => "";


        string IDataErrorInfo.this[string PropertyName]
        {
            get
            {
                switch (PropertyName)
                {
                    case nameof(Name):
                        if (Name is null) return "Пустая ссылка на строк с именем";
                        if (Name.Length < 4) return "Длина строки имени должна быть больше 4 символов";
                        if (!char.IsUpper(Name[0])) return "Имя должно начинаться с заглавной буквы";
                        break;
                }

                return "";
            }
        }
    }
}
