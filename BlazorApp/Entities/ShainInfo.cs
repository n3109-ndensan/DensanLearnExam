using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Entities;

public class ShainInfo(string shainName, DateTime nyushabi, string shainKbn, string biko) : IComparable<ShainInfo>
{
    [Required(ErrorMessage ="氏名を入力してください。")]
    public string ShainName { get; set; } = shainName;

    [Required(ErrorMessage = "入社日を入力してください。")]
    public DateTime Nyushabi { get; set; } = nyushabi;

    [Required(ErrorMessage = "雇用形態を入力してください。")]
    public string ShainKbn { get; set; } = shainKbn;

    public string Biko { get; set; } = biko;

    public int CompareTo(ShainInfo? other)
    {
        if (other == null) return 1;

        // まず雇用形態で昇順に並び替え
        int shainKbnComparison = ShainKbn.CompareTo(other.ShainKbn);
        // 雇用形態が同じ場合
        if (shainKbnComparison != 0)
        {
            return shainKbnComparison;
        }
        // 入社日で昇順に並び替え
        return Nyushabi.CompareTo(other.Nyushabi);
    }

}
