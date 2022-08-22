using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections;

namespace The3BlackBro.WebQueue.Infra.CrossCutting.Utils
{
    public static class ConverterProvider
    {
        public static ValueConverter<bool, BitArray> GetBoolToBitArrayConverter()
        {
            return new ValueConverter<bool, BitArray>(
                value => new BitArray(new[] { value }),
                value => value.Get(0));
        }
    }
}
