using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Entities;

public class MyTask(string taskName, DateTime limit, string status, string content) 
{
    [Required(ErrorMessage ="タスク名を入力してください。")]
    public string TaskName { get; set; } = taskName;

    [Required(ErrorMessage = "期日を入力してください。")]
    public DateTime Limit { get; set; } = limit;

    [Required(ErrorMessage = "状態を入力してください。")]
    public string Status { get; set; } = status;

    public string Content { get; set; } = content;

    public class SortComparer : IComparer<MyTask>
    {
        public int Compare(MyTask? x, MyTask? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            //期限＞状態＞タスク名の順でソート
            int limitComparison = x.Limit.CompareTo(y.Limit);
            if (limitComparison != 0) return limitComparison;
            int statusComparison = int.Parse(x.Status).CompareTo(int.Parse(y.Status));
            if (statusComparison != 0) return statusComparison;
            return x.TaskName.CompareTo(y.TaskName);
        }
    }

}
