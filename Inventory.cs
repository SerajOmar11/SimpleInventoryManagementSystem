public class Inventory
{
    private List<Product> inventory=new List<Product>();

    public void AddProduct()
    {
        Product newProduct=new Product();
        try{
            newProduct.Name=PromptName();
            newProduct.Price=PromptPrice();
            newProduct.Quantity=PropmtQuantity();
        }catch(ArgumentException exception){
            Console.WriteLine(exception.Message);
            return;
        }
        inventory.Add(newProduct);
        Console.WriteLine("new Product added successfully.\n");
    }

    public void ViewAllProducts()
    {
        if(inventory.Count==0){
            Console.WriteLine("There are no products in the inventory.");
            return;
        }

        int num=1;
        foreach(var product in inventory)
        {
            Console.WriteLine($"{num++}- Name: {product.Name} | Price: {product.Price} | Quantity: {product.Quantity} ");
        }
    }
    private string PromptName()
    {
        Console.WriteLine("Enter Product name: ");
        string? input=Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(input)){
            throw new ArgumentException("Product name cannot be empty.\n");
        }
        return input;
    }

    private decimal PromptPrice()
    {
        Console.WriteLine("Enter Product price: ");
        string? input=Console.ReadLine()?.Trim();

        if(!decimal.TryParse(input,out decimal price)||price<0)
        {
            throw new ArgumentException("Product price should be a non-negative number.\n");
        }
        return price;
    }

    private int PropmtQuantity()
    {
        Console.WriteLine("Enter Product quantity: ");
        string? input=Console.ReadLine()?.Trim();

        if(!int.TryParse(input,out int quantity)||quantity<=0){
            throw new ArgumentException("Quantity should be a positive integer.\n");
        }
        return quantity;
    }
}