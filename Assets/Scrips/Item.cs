
public enum Type { Health, Weapon, Puzzle };

public class Item {

   
    private string name;
    private Type type;
    private int quantity;

    public Item(string Name, Type type)
    {
        name = Name;
        this.type = type;
        quantity = 1;
    }

    public void incQuantity()
    {
        quantity++;
    }

    public string getItem()
    {
        return name + "," + type.ToString() + "," + quantity;
    }
}
