public class Product{

    private string name;
    public string Name{
        get{return name;}
        set{
            if(string.IsNullOrWhiteSpace(value)){
                throw new ArgumentException("Name cannot be empty.");
            }
            name=value;
            
        }
    }
    
    private decimal price;
    public decimal Price{
        get{return price;}
        set{
            if(value<0){
                throw new ArgumentException("Price cannot be negative.");
            }
            price=value;
        }
    }

    private int quantity;
    public int Quantity{
        get{return quantity;}
        set{
            if(value<=0){
                throw new ArgumentException("Quantity should be a positive integer");
            }
            quantity=value;
        }
    }
}