<div class="text" align="center">
    <h2>Онлайн магазин по продаже мебели</h2>
</div>
<h3>Краткое описание</h3>
<p><em>Онлайн магазин с возможностью просмотра имеющегося товара. Клиент может выбирать и просматривать будучи не авторизованным. Но , если он захочет что то купить, ему придется авторизоваться. Причем его выбор после авторизации, сохранится. </p>
<img src="https://github.com/user-attachments/assets/ca2907c0-4262-47ed-a176-837d4c91bd1c" />
    
<p><em>Есть возможность добавления в сравнение, избранное, корзина. </p>
<img src="https://github.com/user-attachments/assets/dd53183c-e0dc-4946-9eef-0264291cee39" />
    
<p><em>Есть возможность администрирования, добавления ролей, а также изменения статуса заказа, добавления отзыва по продукту. </p>
<p><em>Реализована работа с API через Swagger </p>
<img src="https://github.com/user-attachments/assets/fad00963-34be-44a1-b618-fa4d4bc4bbcb" />

<h2>Архитектурная часть</h2>
<img src="https://github.com/user-attachments/assets/a28a4009-ac47-4d9c-bfb2-3c2d3718afec" />
<h4>Технология ASP</h4>
<h4>Валидация данных</h4>
<p>Валидация на стороне клиента и на сервере</p>

    public class Authorization
    {
        [Required(ErrorMessage = "Укажите Ваш логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        public string Password { get; set; }
    }
    public class Registration
    {
        [Required(ErrorMessage = "Введите Ваш e-mail")]
        [EmailAddress(ErrorMessage = "Вы ввели неккоретный адрес почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [Phone(ErrorMessage = "Указан неккоректный номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [StringLength(15, MinimumLength = 11, ErrorMessage = "Длина пароля должна быть от 11 до 15 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
<h4>Использование токенов при авторизации и аутентификации </h4>

        public class JWTMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly IConfiguration _configuration;

        public JWTMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<User> userManager)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                await AttachAccountToContextAsync(context, token, userManager);
            }

            await _next(context);
        }

        private async Task AttachAccountToContextAsync(HttpContext context, string token, UserManager<User> userManager)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF32.GetBytes(_configuration["Jwt:Key"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidateIssuer = true,
                    ValidAudience = _configuration["Jwt:Audience"],
                    ValidateAudience = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userEmail = jwtToken.Claims.First(x => x.Type == "email").Value;
                var user = await userManager.FindByEmailAsync(userEmail);
                context.Items["User"] = user;
            }
            catch { }
        }
    }
   
<h4>Логирование данных</h4>
<img src="https://github.com/user-attachments/assets/72b86694-2285-49f9-8e88-62be0f0cc6e9" />

<h4>Работа с БД</h4>
<p>Использована БД MySQL в данном проекте. В данном проекте научился работать с миграциями, использовать Fluent API при организации работы с моделями</p>
<img src="https://github.com/user-attachments/assets/7cef0fec-1c57-47d0-86ba-c8a3b227cc12" />

    public void Configure(EntityTypeBuilder<Cart> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.CartId);

        entityTypeBuilder.Property(e => e.IsActive)
            .IsRequired();
    }

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

        public ProductBuilder WithGrade(double grade)
        {
            _product.Grade = grade;
            return this;
        }

        public Product Build()
        {
            return _product;
        }
    }

<h4>Работа с HTML, CSS, Bootstrap</h4>




<h2>Немного видео из игры</h2>

<a href="https://github.com/user-attachments/assets/d20e4a77-47db-4a6b-b80a-0049d21bfd77">Скачать видео</a>
 
<div class="text" align="center">
    <h1>Спасибо за внимание!</h2>
</div>
