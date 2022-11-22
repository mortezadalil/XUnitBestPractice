using Moq;
using TimeApp.Business;
using TimeApp.Business.Gateway;

namespace TimeApp.Test
{

    /// <summary>
    /// 1. Simplest Test without injection and Moq (Fact And Theory)
    /// </summary>
    public class ParollService_Class
    {
        PayRollService testCase;
        public ParollService_Class()
        {
            //Setup Test
            testCase = new PayRollService();
            #region For Fact (Theory doesn't need)
            testCase.Hours = 20;
            testCase.Hourly = 10;
            #endregion
        }

        public void Dispose()
        {
            //close down test
            //close db connection
        }

        [Fact]
        public void GrossPay_Is_Correct()
        {
            //Arrange
            Decimal expected = 200;
            //Act
            Decimal actual = testCase.GrossPay;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LocalTaxes_Is_Correct()
        {
            //Arrange
            Decimal taxRate = (Decimal)0.035;
            Decimal expected = 200 * (Decimal)0.035;
            //Act
            Decimal actual = testCase.LocalTaxes(taxRate);
            //Assert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(20,10,200)]
        [InlineData(50,10,550)]
        public void GrossPay_Is_Correct_Theory(decimal hours, decimal rate, decimal expected)
        {
            //Arrange
            testCase.Hours= hours;
            testCase.Hourly = rate;
            //Act
            Decimal actual = testCase.GrossPay;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(20, 10, 7)]
        [InlineData(50, 10, 19.25)]
        public void LocalTaxes_Is_Correct_Theory(decimal hours, decimal rate, decimal expected)
        {
            //Arrange
            Decimal taxRate = (Decimal)0.035;
            testCase.Hours = hours;
            testCase.Hourly = rate;
            //Act
            Decimal actual = testCase.LocalTaxes(taxRate);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
    
}