using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenager.Engines
{
    public static class GetDeviceType
    {
        public static Enums.DeviceType GetDeviceTypeMethod()
        {
            if(DeviceInfo.Current.Idiom == DeviceIdiom.Desktop)
            {
                return Enums.DeviceType.Desktop;
            }
            else if(DeviceInfo.Current.Idiom == DeviceIdiom.Phone)
            {
                return Enums.DeviceType.Mobile;
            }

            return Enums.DeviceType.Desktop;
        }
    }
}
