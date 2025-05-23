﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Bibliotopia.Data;
using Bibliotopia.Models;

public class ShoppingCart
{
    private readonly AppDbContext _context;
    public string ShoppingCartId { get; set; }
    public List<ShoppingCartItem> Items { get; set; }

    public ShoppingCart(AppDbContext context)
    {
        _context = context;
    }
    public static ShoppingCart GetShoppingCart(IServiceProvider services)
    {
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        var context = services.GetService<AppDbContext>();

        string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        session.SetString("CartId", cartId);

        return new ShoppingCart(context) { ShoppingCartId = cartId };
    }
    public void AddItemToCart(Book book)
    {
        
        var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Book.Id == book.Id && n.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem()
            {
                ShoppingCartId = ShoppingCartId,
                Book = book,
                Amount = 1
            };

            _context.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
        }
        _context.SaveChanges();
    }
    public void RemoveItemFromCart(Book book)
    {
        var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Book.Id == book.Id && n.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem != null)
        {
            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
            }
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }
            _context.SaveChanges();
        }
    }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        return Items ?? (Items = _context.ShoppingCartItems
            .Where(n => n.ShoppingCartId == ShoppingCartId)
            .Include(n => n.Book)
            .ToList());
    }

    public double GetShoppingCartTotal()
    {
        var total = _context.ShoppingCartItems
            .Where(n => n.ShoppingCartId == ShoppingCartId)
            .Select(n => n.Book.Price * n.Amount)
            .Sum();

        return total;
    }
    public async Task ClearShoppingCartAsync()
    {
        var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
        _context.ShoppingCartItems.RemoveRange(items);
        await _context.SaveChangesAsync();
        Items = new List<ShoppingCartItem>();
    }
}
