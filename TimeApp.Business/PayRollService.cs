using TimeApp.Business.Gateway;

namespace TimeApp.Business
{
    public interface IPayRollService
    {
        decimal LocalTaxes(Decimal taxRate);
    }

    public class PayRollService : IPayRollService
    {
        public Decimal Hourly;
        public Decimal Hours;
        private Decimal _grossPay;
        public decimal GrossPay
        {
            get
            {
                if (Hours <= 40)
                {
                    _grossPay = Hours * Hourly;
                }else if (Hours > 40)
                {
                    _grossPay= Hourly * 40 + Hourly * (Hours - 40) * (Decimal)1.5;
                }
                return _grossPay;
            }
            set { _grossPay = value; }
        }
        public PayRollService(decimal grossPay,decimal hourly,decimal hours)
        {
            GrossPay= grossPay;
            hourly = hourly;
            Hours= hours;
        }

        public PayRollService()
        {

        }

        public decimal LocalTaxes(Decimal taxRate)
        {
            return GrossPay * taxRate;
        }

        
    }
}