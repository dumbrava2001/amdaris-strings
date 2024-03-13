using System;
using System.Linq;
using System.Text;

internal static class Program
{
    public static void Main()
    {
        const string text =
            "In object-oriented programming, encapsulation is a fundamental principle that involves bundling data and methods that operate on that data within a single unit or class. This concept allows for the hiding of implementation details from the outside world and exposing only the necessary interfaces for interacting with the object. By encapsulating data and methods together, we promote code reusability, maintainability, and flexibility.One of the key benefits of encapsulation is the ability to enforce access control on the members of a class. This means we can specify which parts of the class are accessible to the outside world and which are not. By using access modifiers such as public, private, and protected, we can control the visibility of members, ensuring that they are only accessed in appropriate ways. For example, we may have a class representing a bank account with properties such as balance and methods for depositing and withdrawing funds. By making the balance property private and providing public methods for depositing and withdrawing funds, we encapsulate the internal state of the account and ensure that it can only be modified in a controlled manner. Encapsulation also allows us to enforce data validation and maintain invariants within our classes. By providing controlled access to data through methods, we can ensure that it is always in a valid state. For instance, when setting the balance of a bank account, we can check that the new balance is not negative before updating the internal state of the object. Overall, encapsulation is a powerful concept in object-oriented programming that promotes modularity, reusability, and maintainability. By bundling data and methods together within a class and controlling access to them, we can create more robust and flexible software systems.";

        //TODO- Display the word count of this string
        // Console.WriteLine($"Words count: {GetWordsCount(text)}");

        //TODO- Display the sentence count of this string
        // Console.WriteLine($"\nSentence count: {GetSentencesCount(text)}");

        //TODO- Display how often the word "encapsulation" appears in this string
        // const string wordToSearch = "encapsulation";
        // Console.WriteLine($"\nWord {wordToSearch} appears: {GetWordOccurrenceCount(text, wordToSearch)}");

        //TODO- Display this string in reverse, without using any C# language feature. (Create your own algorithm)
        // Console.WriteLine($"\nText in reverse order where last sentence is first: \n {ReverseText(text)}");
        
        //Respecting words order
        // Console.WriteLine($"\nReversed text:\n{ReverseTextWithWordOrder(text)}");
        
        //Enhanced method with words order
        // Console.WriteLine($"\nReversed text:\n{ReverseTextWithWordOrderEnhanced(text)}");

        //TODO- In the given string, replace all occurrences of "object-oriented programming" with "OOP" and display the new string
        // const string stringToReplace = "object-oriented programming";
        // const string replacer = "OOP";
        // Console.WriteLine(
        //     $"\nText where {stringToReplace} is replaced with {replacer}\n {ReplaceAllOccurrences(text: text, toReplace: stringToReplace, replacer: replacer)}");
    }
    
    private static int GetWordsCount(string text) => text.Split(' ').Length;

    private static int GetSentencesCount(string text) => text.Split('.').Count(sentence => sentence.Trim().Length > 0);

    private static int GetWordOccurrenceCount(string text, string word) =>
        text.Split(' ').Count(w => w.Trim().Equals(word));

    private static string ReverseText(string text)
    {
        var builder = new StringBuilder();
        for (var i = text.Length - 1; i >= 0; i--)
        {
            builder.Append(text[i]);
        }

        return builder.ToString();
    }

    private static string ReverseTextWithWordOrder(string text)
    {
        var wordCount = 0;
        foreach (var element in text)
        {
            if (element.Equals(' '))
            {
                wordCount++;
            }
        }

        var wordsArray = new string[wordCount];
        var wordsArrayIndex = 0;
        var wordBuilder = new StringBuilder();
        foreach (var element in text)
        {
            if (element.Equals(' '))
            {
                wordsArray[wordsArrayIndex] = wordBuilder.ToString();
                wordsArrayIndex++;
                wordBuilder = new StringBuilder();
            }
            else
            {
                wordBuilder.Append(element);
            }
        }

        for (var index = 0; index < wordsArray.Length; index++)
        {
            var reversedWordBuilder = new StringBuilder();
            var word = wordsArray[index];
            var punctuation = '*';
            for (var i = word.Length - 1; i >= 0; i--)
            {
                if (word[i].Equals(',') || word[i].Equals('.') || word[i].Equals(';'))
                {
                    punctuation = word[i];
                }
                else
                {
                    reversedWordBuilder.Append(word[i]);
                }

                if (i == 0 && punctuation != '*')
                {
                    reversedWordBuilder.Append(punctuation);
                }
            }

            wordsArray[index] = reversedWordBuilder.ToString();
        }

        var reversedTextBuilder = new StringBuilder();
        for (var index = 0; index < wordsArray.Length; index++)
        {
            if (index != 0)
            {
                reversedTextBuilder.Append(' ');
            }

            reversedTextBuilder.Append(wordsArray[index]);
        }

        return reversedTextBuilder.ToString();
    }

    private static string ReverseTextWithWordOrderEnhanced(string text)
    {
        var wordStartIndex = 0;
        var reversedText = new StringBuilder();
        for (var index = 0; index < text.Length; index++)
        {
            if (text[index] != ' ') continue;
            var punctuation = '*';
            for (var wordIndex = index - 1; wordIndex >= wordStartIndex; wordIndex--)
            {
                if (text[wordIndex] == ',' || text[wordIndex] == '.' || text[wordIndex] == ';')
                {
                    punctuation = text[wordIndex];
                }
                else
                {
                    reversedText.Append(text[wordIndex]);
                }
            }

            if (punctuation != '*')
            {
                reversedText.Append(punctuation);
            }

            wordStartIndex = index + 1;
            reversedText.Append(' ');
        }

        return reversedText.ToString();
    }

    private static string ReplaceAllOccurrences(string text, string toReplace, string replacer) =>
        text.Replace(toReplace, replacer);

}