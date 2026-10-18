public class Inventory
{
    private List<Product> inventory=new List<Product>();

    public void AddProduct()
    {
        Product newProduct=new Product();
        try{
            Product newProduct=new Product();
            newProduct.Name=PromptName();
            newProduct.Price=PromptPrice();
            newProduct.Quantity=PropmtQuantity();
            inventory.Add(newProduct);
            Console.WriteLine("new Product added successfully.\n");
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

    public void EditProduct()
    {
        try{
            string input=PromptName();
            Product product=SearchProduct(input);

            string newName=PromptName(1);
            decimal newPrice=PromptPrice(1);
            int newQuantity=PropmtQuantity(1);

            product.Name=newName;
            product.Price=newPrice;
            product.Quantity=newQuantity;
            Console.WriteLine("Product edited Successfully.\n");
        }catch(ArgumentException exception){
            Console.WriteLine(exception.Message);
        }
    }

    public void DeleteProduct()
    {
        try
        {
            string name=PromptName();
            Product product=SearchProductByName(name);
            inventory.Remove(product);
            Console.WriteLine("Product Deleted successfully");
        }catch(ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
    private string PromptName(int style=0)
    {
        Console.WriteLine($"Enter {(style==1?"new ":"")}Product name: ");
        string? input=Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(input)){
            throw new ArgumentException("Product name cannot be empty.\n");
        }
        return input;
    }

    private decimal PromptPrice(int style=0)
    {
        Console.WriteLine($"Enter {(style==1?"new ":"")}Product price: ");
        string? input=Console.ReadLine()?.Trim();

        if(!decimal.TryParse(input,out decimal price)||price<0)
        {
            throw new ArgumentException("Product price should be a non-negative number.\n");
        }
        return price;
    }

    private int PropmtQuantity(int style=0)
    {
        Console.WriteLine($"Enter {(style==1?"new ":"")}Product quantity: ");
        string? input=Console.ReadLine()?.Trim();

        if(!int.TryParse(input,out int quantity)||quantity<=0){
            throw new ArgumentException("Quantity should be a positive integer.\n");
        }
        return quantity;
    }

    private Product SearchProduct(string name)
    {
        Product? product=inventory.Find(p=>p.Name==name);
        if(product==null){
            throw new ArgumentException("Product is not in the inventory.\n");
        }
        return product;
    }
}