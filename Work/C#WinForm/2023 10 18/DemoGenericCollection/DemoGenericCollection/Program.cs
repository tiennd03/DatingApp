using System;
using System.Collections.Generic;

namespace DemoGenericCollection
{
    internal class Program
    {
        static FunctResult<int> Add(int a, int b)
        {
            FunctResult<int> rs = new FunctResult<int>();
            try
            {
                int c = a + b;
                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Thuc hien phep tinh thanh cong";
                rs.Data = c;
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Fail;
                rs.ErrDesc = "Thuc hien phep tinh that bai. Chi tiet loi: " + ex.ToString();                
            }

            return rs;
        }

        static FunctResult<float> Sub(float a, float b)
        {
            FunctResult<float> rs = new FunctResult<float>();
            try
            {
                float c = a - b;
                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Thuc hien phep tinh thanh cong";
                rs.Data = c;
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Fail;
                rs.ErrDesc = "Thuc hien phep tinh that bai. Chi tiet loi: " + ex.ToString();
            }

            return rs;
        }
        static void Main(string[] args)
        {
            //gọi hàm
            var rs = Add(1, 2);
            //switch(rs.ErrCode)
            //{
            //    case "Success":
            //        Console.WriteLine("Ket qua thuc hien phep tinh: " + rs.Data);
            //        break;
            //    case "Fail":
            //        Console.WriteLine(rs.ErrDesc);
            //        break;
            //}

            switch (rs.ErrCode)
            {
                case EnumErrCode.Fail:
                    Console.WriteLine(rs.ErrDesc);
                    break;
                case EnumErrCode.Success:
                    Console.WriteLine("Ket qua thuc hien phep tinh: " + rs.Data);
                    break;
                case EnumErrCode.Error:
                    break;
                default:
                    break;
            }

        }
    }
}
