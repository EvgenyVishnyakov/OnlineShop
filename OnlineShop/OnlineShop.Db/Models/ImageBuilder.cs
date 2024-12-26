namespace OnlineShop.Db.Models
{
    public class ImageBuilder
    {
        private Image _image = new Image();

        public ImageBuilder WithId(Guid id)
        {
            _image.ImageId = id;
            return this;
        }

        public ImageBuilder WithProductId(Guid productId)
        {
            _image.ProductId = productId;
            return this;
        }

        public ImageBuilder WithImagePath(string imagePath)
        {
            _image.ImagesPath = imagePath;
            return this;
        }

        public Image Build()
        {
            return _image;
        }
    }
}
