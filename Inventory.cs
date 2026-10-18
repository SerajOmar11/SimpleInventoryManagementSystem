public class Inventory
{
    private List<Product> inventory=new List<Product>();

    public void AddProduct()
    {
        try{
            Product newProduct=new Product();
            newProduct.Name=PromptName();
            EnsureUniqueProductName(newProduct.Name);
            newProduct.Price=PromptPrice();
            newProduct.Quantity=PropmtQuantity();
            inventory.Add(newProduct);
            Console.WriteLine("new Product added successfully.\n");
        }catch(ArgumentException exception){
            Console.WriteLine(exception.Message);
        }
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
        Console.WriteLine();
    }

    public void EditProduct()
    {
        try{
            string input=PromptName();
            Product product=SearchProductByName(input);

            string newName=PromptName(1,product.Name);
            EnsureUniqueProductName(newName, product);
            decimal newPrice=PromptPrice(1,product.Price);
            int newQuantity=PropmtQuantity(1,product.Quantity);

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

    public void SearchProductName(){
        try
        {
            string name=PromptName();
            Product product=SearchProductByName(name);
            Console.WriteLine($"Name: {product.Name} | Price: {product.Price} | Quantity: {product.Quantity}\n");
        }
        catch(ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
    private string PromptName(int style=0,string? curr=null)
    {
        Console.WriteLine($"Enter {(style==1?"new ":"")}Product name{(curr is null ? "":$" (press Enter to keep '{curr}')")}: ");
        string? input=Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(input)){
            if(curr is not null){
                return curr;
            }
            throw new ArgumentException("Product name cannot be empty.\n");
        }
        return input;
    }

    private decimal PromptPrice(int style=0,decimal? curr=null)
    {
        Console.WriteLine($"Enter {(style==1?"new ":"")}Product price{(curr is null ? "":$" (press Enter to keep {curr})")}: ");
        string? input=Console.ReadLine()?.Trim();

        if(string.IsNullOrEmpty(input)&&curr is not null){
            return curr.Value;
        }
        if(!decimal.TryParse(input,out decimal price)||price<0)
        {
            throw new ArgumentException("Product price should be a non-negative number.\n");
        }
        return price;
    }

    private int PropmtQuantity(int style=0,int? curr=null)
    {
        Console.WriteLine($"Enter {(style==1?"new ":"")}Product quantity{(curr is null ? "":$" (press Enter to keep {curr})")}: ");
        string? input=Console.ReadLine()?.Trim();

        if(string.IsNullOrEmpty(input)&&curr is not null){
            return curr.Value;
        }
        if(!int.TryParse(input,out int quantity)||quantity<=0){
            throw new ArgumentException("Quantity should be a positive integer.\n");
        }
        return quantity;
    }

    private Product SearchProductByName(string name)
    {
        Product? product=inventory.Find(p=>p.Name==name);
        if(product==null){
            throw new ArgumentException("Product is not in the inventory.\n");
        }
        return product;
    }

    private void EnsureUniqueProductName(string name,Product? product=null)
    {
        if(inventory.Any(p =>p!=product && string.Equals(p.Name,name,StringComparison.OrdinalIgnoreCase)))
        {
            throw new ArgumentException("A product with this name already exists.\n");
        }
    }
}