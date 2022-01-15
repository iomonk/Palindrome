using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Palindrome.Models;

namespace Palindrome.Controllers;

[ApiController]
[Route("[controller]")]
public class PalindromeStringController : ControllerBase
{
    private const string Pattern = @"[^A-Za-z0-9]+";
    private const string Yup = "Yup! you have a legit Palindrome";
    private const string Nope = "Nope! You had one job!";

    [HttpPost(Name = "PostUserInput")]
    public MPalindrome PostUserInput(string userInput)
    {
        var pm = new MPalindrome();
        var rg = new Regex(Pattern);
        
        pm.OriginalString = rg.Replace(userInput, string.Empty).ToLower();
        pm.ReversedString = rg.Replace(ReverseString(userInput), string.Empty).ToLower();

        if (pm.OriginalString == pm.ReversedString)
        {
            pm.IsPalindrome = true;
            pm.Message = Yup;
        }
        else
        {
            pm.IsPalindrome = false;
            pm.Message = Nope;
        }
        
        return pm;
    }

    private static string ReverseString(string userInput)
    {
        var reversedString = "";
        for (var i = userInput.Length - 1; i >= 0; i--)
        {
            reversedString += userInput[i];
        }
        return reversedString;
    }
}