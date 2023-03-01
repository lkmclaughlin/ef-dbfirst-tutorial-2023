
using ef_dbfirst_tutorial_2023.Controllers;
using ef_dbfirst_tutorial_2023.Models;
using Microsoft.EntityFrameworkCore;



//** Cannot get this to work! **  Or maybe it does??(3/1/23
var ordCtrl = new OrdersController();

var ord = await ordCtrl.GetByIdAsync(1);

Console.WriteLine(ord);

var orderTotal = ord.OrderLines.Sum(x => x.Price * x.Quantity);

Console.WriteLine($"Order total is {orderTotal:C}");




/*
var ordCtrl = new OrdersController();

var orders = await ordCtrl.GetAllAsync();

orders.ForEach(ord => Console.WriteLine(ord));
*/

/*
var ordCtrl = new OrdersController();

var ord = await ordCtrl.GetByIdAsync(1);
Console.WriteLine(ord);
*/

///****** I do not know what went on here *******
/*
var ordlCtrl = new OrderLinesController();

var order = await ordlCtrl.GetByIdAsync(82);

ordLine.OrdersId = 2;

await ordlCtrl.UpdateAsnc(ordLine);
*/


////////All from Feb 22 original: 
/*
var ordCtrl = new OrdersController();

var orders = await ordlCtrl.GetByIdAsync(1);

Console.WriteLine(ord);

var orderTotal = ord.Orderlines.Sum(x => x.Price * x.Quantity);

Console.WriteLine($")
*/

/*var ordCtrl = new OrdersController();

var orders = await ordlCtrl.GetAllAsync();

Console.WriteLine(ord);
*/

/*var ordCtrl = new OrdersController();
var orders = await ordlCtrl.GetAllAsync();
orders.ForEach(orders => Console.WriteLine(ordCtrl));
*/
/*
var ordCtrl = new OrdersController();

var ord = await ordlCtrl.GetByIdAsync(1);

Console.WriteLine(ord);
*/
//only when reading the order will you get the information.

/*
var ordCtrl = new OrdersController();

var ordLine = await ordlCtrl.GetByIdAsync(82);

ordLine.OrdersId = 2;

await ordlCtrl.UpdateAsync(ordLine);



/*

var ordCtrl = new OrdersController();

var ordLine = new OrderLine()
{
    Id = 0,
    OrdersId = 1,
    Product = "Echo",
    Description = "Amazon Echo",
    Quantity = 3,
    Price = 50
};

await ordlCtrl.InsertAsync(ordLine);

*/
/*
var ordLine = new OrderLine()
{
    Id = 0,
    OrdersId = 1,
    Product = "Echo",
    Description = "Amazon Echo",
    Quantity = 3,
    Price = 50
};

var ordLines = await ordlCtrl.GetAllAsync();

ordLines.ForEach(ord => Console.WriteLine(ordLine));

*/

/////***ALL BELOW THIS LINE IS CHECKING OrdCntrl 

//and let's get rid of it after all
/*
var ordctrl = new OrdersController();

bool success = await ordctrl.DeleteAsync(27);
Console.WriteLine(success ? "Your order has been deleted." : "Uh-oh, error!");
//checked database: line 27 is gone.
*/

//do the update: 
/*
var ordCtrl = new OrdersController();

var order = await ordCtrl.GetByIdAsync(27);

order.Description = " by LM.";

bool success = await ordCtrl.UpdateAsync(order);

Console.WriteLine(success ? "Update Complete." : "Error!");

//Azure DS shows updated with " by LM"

*/
//let's do an Add:
/*
var ordCtrl = new OrdersController();

var order = new Order()
{
    Id = 0,
    Date = new DateTime(2023, 2, 23),
    Description = "New Kroger Order",
    CustomerId = 1
};
bool success = await ordCtrl.InsertAsync(order);
Console.WriteLine(success ? "Order Added" : "Error!");

//order 27 added
*/


//checking GetById
/*
var ordCtrl = new OrdersController();

var order = await ordCtrl.GetByIdAsync(1);
Console.WriteLine(order);
*/

//checking GetAll
/*
var ordCtrl = new OrdersController();

var orders = await ordCtrl.GetAllAsync();
orders.ForEach(x => Console.WriteLine(x.Description));
*/
/*
 ///alternate way shown:
var _context = new SalesDbContext();

var orders = await _context.Orders.ToListAsync();
orders.ForEach(x => Console.WriteLine(x.Description));

*/

/*
var _context = new SalesDbContext();
var startingNumber = 100;

var sum = await SumNumber1to10();

var total = sum + startingNumber;

Console.WriteLine("Done");

async Task<int> SumNumber1to10()
{
    await _context.Customers.ToListAsync();
    int sum = 0;
    sum += 1;
    sum += 2;
    sum += 3;
    sum += 4;
    sum += 5;
    sum += 6;
    sum += 7;
    sum += 8;
    sum += 9;
    sum += 10;
    return sum;
}
*/


///**EVERYTHING BELOW FROM 2/22/23
/*
//Time to Delete aka Remove
var custCtrl = new CustomersController();

var success = await custCtrl.DeleteAsync(36);

Console.WriteLine(success ? "Ok" : "Failed!");

//check database: aw, all gone!
*/

/*
//let's do the Update:

var custCtrl = new CustomersController();

var bootcamp = await custCtrl.GetByIdAsync(36);

bootcamp.Sales = 5000;

var success = await custCtrl.UpdateAsync(bootcamp);

Console.WriteLine(success ? "Ok" : "Failed!");

//checked database: yes, sales is $5000
*/

/*
//let's do an Add!
var custCtrl = new CustomersController();
var cust = new Customer()
{
    Id = 0,
    Name = "Bootcamp",
    City = "Blue Ash",
    State = "OH",
    Sales = 0,
    Active = true
};

var success = await custCtrl.InsertAsync(cust); 
Console.WriteLine(success ? "Ok" : "Failed!");

//checked database: yes, it's added!

*/

/*
var custCtrl = new CustomersController();
var cust = await custCtrl.GetByIdAsync(1);
Console.WriteLine(cust.Name);
*/

/*
//not needed after adding "public async Task<Customer> GetByIdAsync(int id)" in CustCntrlr class
foreach(var cust in await custCtrl.GetAllAsync())
{
    Console.WriteLine(cust.Name);
}
*/



/*
var dbc = new SalesDbContext();


////// calling something asynchronously 

//var customer = await GetById(1);

var customers = await GetAll();

foreach(var cust in customers)
{
    Console.WriteLine(cust.Name);
}



async Task<Customer> GetById(int id)
{
    return await dbc.Customers.FindAsync(id) ?? new Customer();
                    //added the "?? new CUstomer()" after break, and it removed green squiggle warning
}

async Task<List<Customer>> GetAll()
{
    return await dbc.Customers.ToListAsync();
}
*/


///// synchronous   
/*
var customer = GetById(1);

Console.WriteLine(customer.Name);


Customer GetById(int id)
{
    return dbc.Customers.Find(id);
}
*/


/*
//just put here to show an example
var newCust = new Customer();
dbc.Customers.Add(newCust);
dbc.SaveChanges();
*/

////////
/*
var orderWithCustomers = from o in dbc.Orders
                         join c in dbc.Customers
                            on o.CustomerId equals c.Id
                         orderby c.Name
                         select new
                         {
                             Id = o.Id, Desc = o.Description, Customer = c.Name
                         };

foreach(var oc in orderWithCustomers)
{
    Console.WriteLine($"{oc.Id,2} | {oc.Desc,-15} | {oc.Customer,-15}");
}
*/

////////////////////////
/*
var orders = from o in dbc.Orders
             select o;
foreach(var order in orders)
{
    Console.WriteLine(order.Description);
}

var customers = dbc.Customers
                        .Where(x => x.City == "Cincinnati")
                        .OrderByDescending(x => x.Sales)
                        .ToList();
foreach(var customer in customers)
{
    Console.WriteLine(customer.Name);
}*/