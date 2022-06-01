using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTesting.Application.Utils
{
    public static class ColorMark
    {
        public static (int, int, int) ToColorRgb(int mark)
        {
            switch (mark)
            {
                case 5:
                    return (0x00, 0xd0, 0x02);
                case 4:
                    return (0xa0, 0xba, 0x08); // #a0ba08
                case 3:
                    return (0xd1, 0xd5, 0x00); // #d1d500
                case 2:
                    return (0xaf, 0x00, 0x00); // #af0000
                default:
                    return (0xFF, 0xFF, 0xFF);
            }
        }
    }
}
