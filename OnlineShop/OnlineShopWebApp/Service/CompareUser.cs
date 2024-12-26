using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Service;

public static class CompareUser
{
    public static UserVM Compare(UserVM userDto, UserVM? user)
    {
        GetEmail(userDto, user);
        GetPhone(userDto, user);
        GetPassword(userDto, user);

        return user;
    }

    private static string GetPassword(UserVM userDto, UserVM? user)
    {
        if (user.Password != userDto.Password && userDto.Password != null) { user.Password = userDto.Password; }

        return user.Password;
    }

    private static string GetPhone(UserVM userDto, UserVM? user)
    {
        if (user.PhoneNumber != userDto.PhoneNumber && userDto.PhoneNumber != null) { user.PhoneNumber = userDto.PhoneNumber; }

        return user.PhoneNumber;
    }

    private static string GetEmail(UserVM userDto, UserVM? user)
    {
        if (user.Login != userDto.Login && userDto.Login != null) { user.Login = userDto.Login; }

        return user.Login;
    }
}
