using System;
using System.Collections.Generic;

namespace ServerInfoSample.Helpers
{
    public static class EnumExtensions
    {
        public static List<EnumValue> GetValues<T>()
        {
            List<EnumValue> values = new List<EnumValue>();
            foreach (var itemType in Enum.GetValues(typeof(T)))
            {
                values.Add(new EnumValue()
                {
                    Id = (int)itemType,
                    Name = Enum.GetName(typeof(T), itemType)
                    
                });
            }
            return values;
        }
    }
}
