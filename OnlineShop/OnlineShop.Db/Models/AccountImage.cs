﻿namespace OnlineShop.Db.Models;

public class AccountImage
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public string ImagePath { get; set; }
}