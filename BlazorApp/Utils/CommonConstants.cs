using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BlazorApp.Utils
{
    public class CommonConstants
    {

        public class TaskStatus
        {
            public const string Pending = "0";
            public const string InProgress = "1";
            public const string Completed = "2";
            public const string Ignored = "9";

            public static string GetName(string status)
            {
                return status switch
                {
                    Pending => "未着手",
                    InProgress => "仕掛中",
                    Completed => "完了",
                    Ignored => "無視",
                    _ => "不明"
                };
            }

            public static List<string> GetAllStatuses()
            {
                return new List<string> { Pending, InProgress, Completed, Ignored };
            }

            public static Dictionary<string, string> GetAllStatusSet()
            {
                return GetAllStatuses().ToDictionary(status => status, GetName);
            }
        }
    }
}
