using ef_dbfirst_tutorial_2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ef_dbfirst_tutorial_2023.Controllers;

public class OrderlinesController
{
    private readonly SalesDbContext _context;

    public OrderlinesController()
    {
        _context = new SalesDbContext();
    }

    public async Task<List<OrderLine>> GetAllAsync()
    {
        return await _context.OrderLines.ToListAsync();
    }

    public async Task<OrderLine?> GetByIdAsync(int id)
    {
        return await _context.OrderLines.FindAsync(id);
    }

    public async Task<bool> InsertAsync(OrderLine orderLine)
    {
        _context.OrderLines.Add(orderLine);
        return await SaveDb();
    }

    public async Task<bool> UpdateAsync(OrderLine orderLine)
    {
        var ordLine = await GetByIdAsync(orderLine.Id);
        if (ordLine == null)
        {
            return false;
        }
        _context.OrderLines.Entry(orderLine).State = EntityState.Modified;
        return await SaveDb();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ordLine = await GetByIdAsync(id);
        if (ordLine == null)
        {
            return false;
        }
        _context.OrderLines.Remove(ordLine);
        return await SaveDb();
    }

    //ADDING new method to reduce duplicate coding
    private async Task<bool> SaveDb()
    {
        var changes = await _context.SaveChangesAsync();
        return (changes == 1) ? true : false;
    }

}
