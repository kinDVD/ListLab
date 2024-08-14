/*Dictionary<string, decimal>empty list of string (cart)loop-display menu (kvp)-ask for input-if item is in store, add to cart (.ContainsKey())-if not, don't add to cart-ask if they want to add more items (similar to if you want to continue loops)total = 0foreach the cart-display item name and price (dictionary[itemName])-add price onto the totaldisplay total*/


using System.Threading.Tasks;

Console.WriteLine("Welcome to Restricted Groceries!");

//menu/price dictionary
Dictionary<string, decimal> menu = new Dictionary<string, decimal>
{
    {"Vegan Butter", 3.49m },
    {"Oatmilk", 4.01m },
    {"Vegan Cheese", 3.49m },
    {"Bread", 2.99m },
    {"Tortilla Chips", 3.89m },
    {"Pico de Gallo", 4.49m },
    {"Vegan Ground Beef", 5.99m },
    {"Corn Tortillas", 2.49m },
    {"Onion", 0.99m },
    {"Garlic", 0.50m },
    {"Lettuce", 1.50m },
    {"Cilantro", 0.75m }
};

//Header for display table
Console.WriteLine("Item".PadRight(18) + "Price");
Console.WriteLine("=========================");

foreach (KeyValuePair<string, decimal> kvp in menu)
{
    Console.WriteLine($"{kvp.Key}".PadRight(18) + $" ${kvp.Value}");
}

//customer cart
List<string> cart = new List<string>();

bool runProgram = true;
while (runProgram)

{
    decimal total = 0;
    bool nae = true;

    while (nae)
    {
        Console.Write("Type an item to add to cart:");

        string cusSelect = Console.ReadLine();
        if (menu.ContainsKey(cusSelect))
        {
            cart.Insert(0, cusSelect);
            total+=menu[cusSelect];
            Console.WriteLine($"{cusSelect} was added to your cart, bringing your total to {total}");

        }
        else
        {
            Console.WriteLine("That item is not available.");
        }

        Console.WriteLine("Would you like to add another? Y/N");
        string cont = Console.ReadLine().ToLower();

        if (cont == "y")
        {
            foreach (KeyValuePair<string, decimal> kvp in menu)
            {
                Console.WriteLine($"{kvp.Key}".PadRight(18) + $" ${kvp.Value}");
            }
            continue;
        }
        else if (cont == "n")
        {
            Console.WriteLine("Sounds good.");
            nae = false;
        }
        else
        {
            Console.WriteLine("We're sorry, that item is not available.");
            break;
        }
    }
    Console.WriteLine("Your cart contains:");

    foreach (string n in cart)
    {
        if (menu.ContainsKey(n))
        {
            Console.WriteLine($"{n.PadRight(18)}" + $"{menu[n]}");
        }
    }

    Console.WriteLine($"Your total is: {total}");
    runProgram = false;

}