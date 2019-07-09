using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Service
{
    public static class ObjectCopyer
    {
        public static void CopyTo(this object Source, object Destionation)
        {
            if(Source is null) throw new ArgumentNullException(nameof(Source));
            if(Destionation is null) throw new ArgumentNullException(nameof(Destionation));

            var source_type = Source.GetType();
            var destination_type = Destionation.GetType();

            var destination_properties = destination_type.GetProperties()
               .Where(p => p.CanWrite)
               .ToDictionary(p => p.Name);

            foreach (var source_property in source_type.GetProperties().Where(p => p.CanRead))
            {
                if(source_property.Name == "Id") continue;
                if(!destination_properties.TryGetValue(source_property.Name, out var destination_property))
                    continue;

                if(!destination_property.PropertyType.IsAssignableFrom(source_property.PropertyType))
                    continue;

                var source_property_value = source_property.GetValue(Source);
                destination_property.SetValue(Destionation, source_property_value);
            }
        }
    }
}
