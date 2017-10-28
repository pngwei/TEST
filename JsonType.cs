using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UT.Json
{

    /// <summary>
    /// Json类型转换
    /// </summary>
    public static class JsonCvt
    {
        /// <summary>
        /// json字符串转换为对象
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object DeserializeObject(string value, Type type)
        {
            object result = JsonConvert.DeserializeObject(value, type);

            return result;
        }

        /// <summary>
        /// 对象转换为json字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeObject(object value)
        {
            string result = JsonConvert.SerializeObject(value);

            return result;
        }


    }



}
