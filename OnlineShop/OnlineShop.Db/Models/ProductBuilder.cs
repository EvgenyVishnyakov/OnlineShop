namespace OnlineShop.Db.Models
{
    public class ProductBuilder
    {
        private Product _product = new Product();

        public ProductBuilder WithId(Guid id)
        {
            _product.Id = id;
            return this;
        }

        public ProductBuilder WithName(string name)
        {
            _product.Name = name;
            return this;
        }

        public ProductBuilder WithCost(int cost)
        {
            _product.Cost = cost;
            return this;
        }

        public ProductBuilder WithDescription(string description)
        {
            _product.Description = description;
            return this;
        }

        public ProductBuilder AddImage(Image image)
        {
            _product.Images ??= [];
            _product.Images.Add(image);
            return this;
        }

        public ProductBuilder AddImages(List<Image> images)
        {
            _product.Images ??= [];
            _product.Images.AddRange(images);
            return this;
        }

        public ProductBuilder WithCategory(string category)
        {
            _product.Category = category;
            return this;
        }

        public ProductBuilder AddReview(List<Review> reviews)
        {
            _product.Reviews ??= [];
            _product.Reviews.AddRange(reviews);
            return this;
        }

        public Product Build()
        {
            return _product;
        }
    }
}
