using Core;

namespace LetMeKnow.Biz
{
    public class BizCostcoDiscount
    {
        public List<CostcoProduct> GetCostcoDiscountInfo()
        {
            CostcoClient costcoClient = new();
            return costcoClient.GetCostcoDiscount().Result;
        }
    }
}
