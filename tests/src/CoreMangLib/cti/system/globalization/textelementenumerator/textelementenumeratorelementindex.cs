using System;
using System.Globalization;
/// <summary>
///ElementIndex
/// </summary>
public class TextElementEnumeratorElementIndex
{
    public static int Main()
    {
        TextElementEnumeratorElementIndex TextElementEnumeratorElementIndex = new TextElementEnumeratorElementIndex();
        TestLibrary.TestFramework.BeginTestCase("TextElementEnumeratorElementIndex");
        if (TextElementEnumeratorElementIndex.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    public bool RunTests()
    {
        bool retVal = true;
        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        TestLibrary.TestFramework.LogInformation("[Negitive]");
        retVal = NegTest1() && retVal;
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong

    public bool PosTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest1: Calling Current Property.");
        try
        {
            // Creates and initializes a String containing the following:
            //   - a surrogate pair (high surrogate U+D800 and low surrogate U+DC00)
            //   - a combining character sequence (the Latin small letter "a" followed by the combining grave accent)
            //   - a base character (the ligature "")
            String myString = "\uD800\uDC00\u0061\u0300\u00C6";
            int [] expectValue = new int[3];
            expectValue[0] = 0;
            expectValue[1] = 2;
            expectValue[2] = 4;
            // Creates and initializes a TextElementEnumerator for myString.
            TextElementEnumerator myTEE = StringInfo.GetTextElementEnumerator(myString);
            myTEE.Reset();
            int i = 0;
            while (myTEE.MoveNext())
            {
                if (expectValue[i] != myTEE.ElementIndex)
                {
                    TestLibrary.TestFramework.LogError("001." + (i + 1).ToString(), " Calling ElementIndex property should return " + expectValue[i]);
                    retVal = false;
                 }
                i++;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("001.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong

    public bool NegTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("NegTest1: The enumerator is positioned before the first text element of the string.");
        try
        {
            String myString = "\uD800\uDC00\u0061\u0300\u00C6";
            // Creates and initializes a TextElementEnumerator for myString.
            TextElementEnumerator myTEE = StringInfo.GetTextElementEnumerator(myString);
            myTEE.Reset();
            int actualValue=myTEE.ElementIndex;
            TestLibrary.TestFramework.LogError("101.1", " InvalidOperationException should be caught.");
            retVal = false;
        }
        catch (InvalidOperationException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("101.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

   
}

