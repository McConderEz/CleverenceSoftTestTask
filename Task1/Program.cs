using System.Text;

Console.WriteLine(Solution.Convert("aaabbcccdde"));
Console.WriteLine(Solution.Convert("aaaaaa"));
Console.WriteLine(Solution.Convert("aaabbbbb"));
Console.WriteLine(Solution.Convert("ab"));

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
                    result.Append(firstGroup + count.ToString());
                else
                    result.Append(firstGroup);

                firstGroup = item;
                count = 0;
            }
            
            count++;
        }
        
        return result.Append(firstGroup + (count != 1 ? count.ToString() : "")).ToString();
    }
}

