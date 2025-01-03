﻿using OnlineShop.Db.Models;
using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Helpers;

public static class Mapping
{
    public static List<ProductViewModel> ToProductViewModels(List<Product> products)
    {
        var productsViewModels = new List<ProductViewModel>();
        foreach (var product in products)
        {
            productsViewModels.Add(ToProductViewModel(product));
        }
        return productsViewModels;
    }

    public static ProductViewModel ToProductViewModel(Product product)
    {
        return new ProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Cost = product.Cost,
            Description = product.Description,
            Images = product.Images,
            Category = product.Category
        };
    }

    public static EditProductViewModel ToEditProductViewModel(Product product)
    {
        return new EditProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Cost = product.Cost,
            Description = product.Description,
            Images = ToPaths(product.Images),
            Category = product.Category
        };
    }

    private static List<string> ToPaths(List<Image> imagePaths)
    {
        return imagePaths.Select(x => x.ImagesPath).ToList();
    }

    public static Product FromEditProductViewModel(EditProductViewModel productVM)
    {
        return new ProductBuilder()
            .WithId(productVM.Id)
            .WithName(productVM.Name)
            .WithCost(productVM.Cost)
            .WithDescription(productVM.Description)
            .WithCategory(productVM.Category)
            .AddImages(ToImage(productVM.Images))
            .Build();
    }

    public static CartViewModel? ToCartViewModel(Cart cart)
    {
        if (cart == null)
            return null;
        return new CartViewModel
        {
            CartId = cart.CartId,
            UserId = cart.UserId,
            Quantity = cart.Items.Count,
            Items = ToCartItemViewModels(cart.Items)
        };
    }

    private static List<CartItemViewModel> ToCartItemViewModels(List<CartItem> cartDbItems)
    {
        var cartItems = new List<CartItemViewModel>();
        foreach (var cartDbItem in cartDbItems)
        {
            var cartItem = new CartItemViewModel
            {
                Quantity = cartDbItem.Quantity,
                Product = ToProductViewModel(cartDbItem.Product)
            };
            cartItems.Add(cartItem);
        }
        return cartItems;
    }

    public static Product FromCreateProductViewModel(CreateProductViewModel modelVM, List<string> imagePaths)
    {
        var productDb = new ProductBuilder()
        .WithDescription(modelVM.Description)
        .WithCategory(modelVM.Category)
        .WithName(modelVM.Name)
        .WithCost(modelVM.Cost)
        .AddImages(ToImage(imagePaths))
        .Build();

        return productDb;
    }

    private static List<Image> ToImage(List<string> imagePaths)
    {
        return imagePaths.Select(x => new Image { ImagesPath = x }).ToList();
    }

    public static Product FromProductViewModel(ProductViewModel product)
    {
        var productDb = new ProductBuilder()
            .WithId(product.Id)
        .WithDescription(product.Description)
        .WithCategory(product.Category)
        .WithName(product.Name)
        .WithCost(product.Cost)
        .Build();

        return productDb;
    }

    public static Order FromOrderViewModel(OrderViewModel orderViewModel, Order order)
    {
        var orderDb = new OrderBuilder()
        .WithId(orderViewModel.OrderId)
        .WithName(orderViewModel.Name)
        .WithAddress(orderViewModel.Address)
        .WithPhone(orderViewModel.Phone)
        .WithEmail(orderViewModel.Email)
        .WithComment(orderViewModel.Comment)
        .AddItems(order.Items)
        .WithTotalCost(GetTotal(orderViewModel, order))
        .WithCreatedDateTime()
        .WithOrderNumber(orderViewModel.OrderNumber)
        .Build();

        return orderDb;
    }

    public static decimal GetTotal(OrderViewModel orderViewModel, Order order)
    {
        orderViewModel.Items = order.Items;
        return orderViewModel.Items?.Sum(i => i.UnitPrice) ?? 0;
    }

    public static OrderViewModel ToOrderViewModel(Order order)
    {
        if (order == null)
            return null;
        else
        {
            var orderVM =
                new OrderViewModel
                {
                    OrderId = order.OrderId,
                    Name = order.Name,
                    Address = order.Address,
                    Phone = order.Phone,
                    Email = order.Email,
                    Comment = order.Comment,
                    Items = order.Items,
                    TotalCost = order.TotalCost,
                    CreatedDateTime = order.CreatedDateTime,
                    OrderNumber = order.OrderNumber,
                    Status = order.Status
                };

            return orderVM;
        }
    }

    public static List<OrderViewModel> ToOrderViewModels(List<Order> orders)
    {
        var ordersViewModels = new List<OrderViewModel>();
        foreach (var order in orders)
        {
            ordersViewModels.Add(ToOrderViewModel(order));
        }

        return ordersViewModels;
    }

    public static FavouriteViewModel ToFavouriteViewModel(Favourite favourite)
    {
        if (favourite == null)
            return null;
        return new FavouriteViewModel
        {
            Id = favourite.Id,
            UserId = favourite.UserId,
            FavouriteProducts = ToProductViewModels(favourite.FavouriteProducts)
        };
    }

    public static ComparisonViewModel ToComparisonViewModel(Comparison comparison)
    {
        if (comparison == null)
            return null;
        return new ComparisonViewModel
        {
            Id = comparison.Id,
            UserId = comparison.UserId,
            ComparisonProducts = ToProductViewModels(comparison.ComparisonProducts)
        };
    }

    public static UserVM ToUserVM(User user)
    {
        return new UserVM
        {
            UserId = user.Id,
            Login = user.Email,
            PhoneNumber = user.PhoneNumber,
        };
    }

    public static UserWithOutPasswordVM ToUserWithOutPasswordVM(User user)
    {
        return new UserWithOutPasswordVM
        {
            UserId = user.Id,
            Login = user.Email,
            PhoneNumber = user.PhoneNumber
        };
    }

    public static UserChangePasswordVM ToUserChangePasswordVM(User user)
    {
        return new UserChangePasswordVM
        {
            UserId = user.Id,
            Email = user.Email
        };
    }

    public static User ToUserModel(User user, UserWithOutPasswordVM userWithOutPassword)
    {
        user.Email = userWithOutPassword.Login;
        user.PhoneNumber = userWithOutPassword.PhoneNumber;

        return user;
    }

    public static AccountViewModel ToAccountVM(User user)
    {
        return new AccountViewModel
        {
            UserId = user.Id,
            Login = user.Email,
            PhoneNumber = user.PhoneNumber,
            ProfileImage = user.ProfileImage
        };
    }

    public static EditProfileViewModel ToAccountEditProfile(User user)
    {
        return new EditProfileViewModel
        {
            Login = user.Email,
            ImageProfile = user.ProfileImage
        };
    }

    public static User FromAccountEditProfile(User user, EditProfileViewModel accountEditProfile)
    {
        user.Email = accountEditProfile.Login;
        user.ProfileImage = accountEditProfile.ImageProfile;

        return user;
    }

    public static AccountOrderViewModel ToAccountOrderViewModel(Order order)
    {
        if (order == null)
            return null;
        else
        {
            var orderVM =
                new AccountOrderViewModel
                {
                    Comment = order.Comment,
                    Items = order.Items,
                    TotalCost = order.TotalCost,
                    CreatedDateTime = order.CreatedDateTime,
                    OrderNumber = order.OrderNumber,
                    Status = order.Status
                };

            return orderVM;
        }
    }

    public static List<AccountOrderViewModel> ToAccountOrdersViewModel(List<Order> ordersListByUser)
    {
        var accountOrdersViewModel = new List<AccountOrderViewModel>();
        foreach (var order in ordersListByUser)
        {
            accountOrdersViewModel.Add(ToAccountOrderViewModel(order));
        }

        return accountOrdersViewModel;
    }
}
