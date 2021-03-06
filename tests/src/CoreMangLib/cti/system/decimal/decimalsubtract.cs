using System;
/// <summary>
/// Subtract(System.Decimal,System.Decimal)
/// </summary>
public class DecimalSubtract
{
    #region Public Methods
    public bool RunTests()
    {
        bool retVal = true;

        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        TestLibrary.TestFramework.LogInformation("[Negtive]");
        retVal = NegTest1() && retVal;
        retVal = NegTest2() && retVal;
        return retVal;
    }

    #region Positive Test Cases
    public bool PosTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest1: Calling Subtract method.");

        try
        {
            Decimal m1 = 1.45m;
            Decimal expectValue = 1.4m;
            Decimal m2 = m1 - expectValue;
            Decimal actualValue = Decimal.Subtract(m1,m2);
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.1", "Subtract should  return " + expectValue);
                retVal = false;
            }

        
            m1 = 123.456789m;
            expectValue = 123.4568m;
            m2 = m1 - expectValue;
            actualValue = Decimal.Subtract(m1, m2);
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.2", "Subtract should  return " + expectValue);
                retVal = false;
            }


            m1 = 123.456789m;
            expectValue = 0m;
            actualValue = Decimal.Subtract(m1, m1);
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.3", "Subtract should  return " + expectValue);
                retVal = false;
            }


            m1 = 123.456789m;
            expectValue = 123.456789m;
            actualValue = Decimal.Subtract(m1, 0);
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.4", "Subtract should  return " + expectValue);
                retVal = false;
            }


            m1 = -123.456m;
            expectValue = -123;
            m2 = -0.456m;
            actualValue = Decimal.Subtract(m1, m2);
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.5", "Subtract should  return " + expectValue);
                retVal = false;
            }

           

            m1 = -9999999999.9999999999m;
            expectValue = -10000000000.000000000m;
            m2 = 0.0000000001m;
            actualValue = Decimal.Subtract(m1, m2);
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.6", "Subtract should  return " + expectValue);
                retVal = false;
            }
            m1 = Decimal.MaxValue;
            expectValue = 0;
            actualValue = Decimal.Subtract(m1, m1);
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.7", "Subtract should  return " + expectValue);
                retVal = false;
            }

            m1 = Decimal.MinValue;
            expectValue = 0;
            actualValue = Decimal.Subtract(m1, m1);
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.8", "Subtract should  return " + expectValue);
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("001.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    #endregion
    #region NegiTive Test
    public bool NegTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest1: The return value is  greater than MaxValue.");

        try
        {
            Decimal m1 = Decimal.MaxValue;
            Decimal m2 = Decimal.MinValue;
            Decimal actualValue = Decimal.Subtract(m1, m2);
            TestLibrary.TestFramework.LogError("101.1", "OverflowException should be caught.");
            retVal = false;
        }
        catch (OverflowException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("101.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool NegTest2()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest2: The return value is less than MinValue .");

        try
        {
            Decimal m1 = Decimal.MinValue;
            Decimal m2 = Decimal.MaxValue;
            Decimal actualValue = Decimal.Subtract(m1, m2);
            TestLibrary.TestFramework.LogError("102.1", "OverflowException should be caught.");
            retVal = false;
        }
        catch (OverflowException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("101.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    #endregion
    #endregion

    public static int Main()
    {
        DecimalSubtract test = new DecimalSubtract();

        TestLibrary.TestFramework.BeginTestCase("DecimalSubtract");

        if (test.RunTests())
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
    #region private method
    public TypeCode GetExpectValue(Decimal myValue)
    {
        return TypeCode.Decimal;
    }
    #endregion
}
