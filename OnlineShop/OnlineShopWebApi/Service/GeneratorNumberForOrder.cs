using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Service;

public static class GeneratorNumberForOrder
{
    public static string GetOrderNumber(Order order, Guid orderId)
    {
        var firstPartOrderCounter = GetFirstPartOrderCounter(orderId);

        var yearPartInSecondPart = GetYear();

        var mounthPartInThirdPart = GetMounth();

        var dayInForthPart = GetDay();

        var ordercounter = GetFinalPart(order, dayInForthPart);

        return $"{firstPartOrderCounter}-{yearPartInSecondPart}-{mounthPartInThirdPart}-{dayInForthPart}-{ordercounter:00}";
    }
    private static int GetFinalPart(Order order, string dayInForthPart)
    {
        if (order != null)
        {
            var lastSeparateIndex = order.OrderNumber.LastIndexOf("-");
            var lastOrderCounter = int.Parse(order.OrderNumber.Substring(lastSeparateIndex + 1));
            var controlDay = order.OrderNumber.Substring(lastSeparateIndex - 2, 2);

            if (controlDay == dayInForthPart)
                return ++lastOrderCounter;
            else
                return 1;
        }
        return 1;
    }

    private static string GetDay()
    {
        return DateTime.Now.Day.ToString("00");
    }

    private static string GetMounth()
    {
        return DateTime.Now.Month.ToString("00");
    }

    private static string GetYear()
    {
        return DateTime.Now.Year.ToString("0000");
    }

    private static string GetFirstPartOrderCounter(Guid orderId)
    {
        var lastId = orderId.ToString();
        var separateId = lastId.IndexOf("-");
        return lastId.Substring(0, separateId);
    }
}
