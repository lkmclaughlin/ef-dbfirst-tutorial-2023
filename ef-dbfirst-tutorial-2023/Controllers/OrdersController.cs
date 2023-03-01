using ef_dbfirst_tutorial_2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ef_dbfirst_tutorial_2023.Controllers;

public class OrdersController
{
    private readonly SalesDbContext _context;

    public OrdersController()
    {
        _context = new SalesDbContext();
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders
                                .Include(x => x.Customer)
                                .Include(x => x.OrderLines)
                                .ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _context.Orders
                                .Include(x => x.Customer)
                                .SingleOrDefaultAsync(x => x.Id == id);
                                //.FindAsync(id);
    }

    public async Task<bool> InsertAsync(Order order)
    {
        _context.Orders.Add(order);
        return await SaveDb();
    }

    public async Task<bool> UpdateAsync(Order order)
    {
        var ord = await GetByIdAsync(order.Id);
        if (ord == null)
        {
            return false;
        }
        _context.Orders.Entry(order).State = EntityState.Modified;
        return await SaveDb();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ord = await GetByIdAsync(id);
        if (ord == null)
        {
            return false;
        }
        _context.Orders.Remove(ord);
        return await SaveDb();
    }

    //ADDING new method to reduce duplicate coding
    private async Task<bool> SaveDb()
    {
        var changes = await _context.SaveChangesAsync();
        return (changes == 1) ? true : false;
    } 

}


