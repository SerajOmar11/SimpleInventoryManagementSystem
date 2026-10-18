Inventory inventory=new Inventory();

while(true){
    Console.WriteLine("====== Inventory Management System ======");
    Console.WriteLine("1- Add product.");
    Console.WriteLine("2- View all products.");
    Console.WriteLine("3- Edit product.");
    Console.WriteLine("4- Delete product.");
    Console.WriteLine("5- Search product.");
    Console.WriteLine("6- Exit.\n");

    Console.WriteLine("Enter your choice:");
    string? input=Console.ReadLine()?.Trim();
    if(!int.TryParse(input,out int choice)||choice<1||choice>6){
        Console.WriteLine("Invalid choice (choice should be an integer in [1,6])");
        continue;
    }
    if(choice==6){
        break;
    }
    Console.WriteLine();
    
    switch(choice){
        case 1:
            inventory.AddProduct();
            break;
        case 2:
            inventory.ViewAllProducts();
            break;
        case 3:
            inventory.EditProduct();
            break;
        case 4:
            inventory.DeleteProduct();
            break;
        case 5:
            inventory.SearchProductName();
            break;
    }
}