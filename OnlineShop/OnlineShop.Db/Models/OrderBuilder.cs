namespace OnlineShop.Db.Models
{
    public class OrderBuilder
    {
        private Order _order = new Order();

        public OrderBuilder WithId(Guid id)
        {
            _order.OrderId = id;
            return this;
        }

        public OrderBuilder WithName(string name)
        {
            _order.Name = name;
            return this;
        }

        public OrderBuilder WithAddress(string address)
        {
            _order.Address = address;
            return this;
        }

        public OrderBuilder WithPhone(string phone)
        {
            _order.Phone = phone;
            return this;
        }

        public OrderBuilder WithEmail(string email)
        {
            _order.Email = email;
            return this;
        }

        public OrderBuilder WithTotalCost(decimal totalCost)
        {
            _order.TotalCost = totalCost;
            return this;
        }

        public OrderBuilder WithOrderNumber(string orderNumber)
        {
            _order.OrderNumber = orderNumber;
            return this;
        }

        public OrderBuilder AddItem(CartItem item)
        {
            _order.Items ??= [];
            _order.Items.Add(item);
            return this;
        }

        public OrderBuilder AddItems(List<CartItem> items)
        {
            _order.Items ??= [];
            _order.Items.AddRange(items);
            return this;
        }

        public OrderBuilder WithStatus(OrderStatus status)
        {
            _order.Status = status;
            return this;
        }

        public OrderBuilder WithComment(string comment)
        {
            _order.Comment = comment;
            return this;
        }

        public OrderBuilder WithCreatedDateTime()
        {
            _order.CreatedDateTime = DateTime.Now;
            return this;
        }

        public Order Build()
        {
            return _order;
        }
    }
}
