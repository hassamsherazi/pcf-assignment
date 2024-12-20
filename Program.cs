// See https://aka.ms/new-console-template for more information
using System.Net;
using Microsoft.VisualBasic;


List<string> data = await GetInput();

Console.WriteLine("Task 1 Resule is:  " + Task1(data));


Console.WriteLine("Task 2 Result: " + Task2(data));

Console.ReadKey();

int Task1(List<string> inputLines){
    int finalSum = 0;
    foreach (string line in inputLines)
        {
            string digits = string.Empty;
            foreach (char c in line)
            {
                if (char.IsDigit(c))
                {
                    digits += c;
                }
            }

            // Combine first and last digits to form a two-digit number
            if (digits.Length >= 2)
            {
                int firstDigit = digits[0] - '0';
                int lastDigit = digits[^1] - '0';
                int twoDigitNumber = firstDigit * 10 + lastDigit;

                // Add to the final sum
                finalSum += twoDigitNumber;
            }
        }
        return finalSum;
}

int Task2(List<string> inputLines){
Dictionary<string, int> wordToNumber = new Dictionary<string, int>
        {
            { "one", 1 }, { "two", 2 }, { "three", 3 },
            { "four", 4 }, { "five", 5 }, { "six", 6 },
            { "seven", 7 }, { "eight", 8 }, { "nine", 9 }
        };

        int finalSum = 0;

        foreach (string line in inputLines)
        {
            string digits = string.Empty;
            int lineSum = 0;

            for (int i = 0; i < line.Length; i++)
            {
                foreach (var word in wordToNumber.Keys)
                {
                    if (line.Substring(i).StartsWith(word))
                    {
                        lineSum += wordToNumber[word];
                        i += word.Length - 1; 
                        break;
                    }
                }

                if (char.IsDigit(line[i]))
                {
                    digits += line[i];
                }
            }

            if (digits.Length >= 2)
            {
                int firstDigit = digits[0] - '0';
                int lastDigit = digits[^1] - '0';
                lineSum += firstDigit * 10 + lastDigit;
            }

            finalSum += lineSum;
        }
        return finalSum;
}



async Task<List<string>> GetInput(){
    using(HttpClient client = new()){
        var taskResponse = await client.GetAsync(new System.Uri("https://dart.delivery/interview/27c5964a-f96b-48b3-9465-72e244800701/input.txt"));
        
        var content = await taskResponse.Content.ReadAsStringAsync();
        List<string> data = new List<string>(content.Replace("\n","").Split(new[] { '\r' }, StringSplitOptions.RemoveEmptyEntries));
    
    return data;
    }
}  