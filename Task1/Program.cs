using System.Text;

Console.WriteLine(Solution.Convert("aaabbcccdde"));
Console.WriteLine(Solution.Deconvert("a3b2c3d2e"));
Console.WriteLine(Solution.Convert("aaaaaa"));
Console.WriteLine(Solution.Deconvert("a6"));
Console.WriteLine(Solution.Convert("aaabbbbb"));
Console.WriteLine(Solution.Deconvert("a3b5"));
Console.WriteLine(Solution.Convert("ab"));
Console.WriteLine(Solution.Deconvert("ab"));

public static class Solution
{
    public static string Convert(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;
        
        var result = new StringBuilder();
        var count = 0;
        var firstGroup = input[0];
        
        foreach (var item in input)
        {
            if (firstGroup != item)
            {
                if(count > 1)
                    result.Append(firstGroup).Append(count);
                else
                    result.Append(firstGroup);

                firstGroup = item;
                count = 0;
            }
            
            count++;
        }
        
        return result.Append(firstGroup).Append(count != 1 ? count.ToString() : "").ToString();
    }
    
    public static string Deconvert(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;
        
        var result = new StringBuilder();
        
        foreach (var item in input)
        {
            if(char.IsLetter(item))
                result.Append(item);
            else if(char.IsDigit(item))
                result.Append(new string(result[^1],int.Parse(item.ToString()) - 1));
        }

        return result.ToString();
    }
}

