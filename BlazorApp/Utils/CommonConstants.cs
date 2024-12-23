using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BlazorApp.Utils.CommonConstants
{
    public class ShainKbn
    {
        public const string Regular = "0";
        public const string Commission = "1";
        public const string Partner = "3";

        public static string GetName(string kbn)
        {
            return kbn switch
            {
                Regular => "正社員",
                Commission => "嘱託",
                Partner => "協力会社",
                _ => "不明"
            };
        }

        public static List<string> GetAllShainKbn()
        {
            return new List<string> { Regular, Commission, Partner };
        }

        public static Dictionary<string, string> GetAllShainKbnSet()
        {
            return GetAllShainKbn().ToDictionary(kbn => kbn, GetName);
        }
    }

}
