using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventorySystem : MonoBehaviour {
    public struct items
    {
        public Item item { get; set; }
        public int quantity { get; set; }
        
    }
    private Dictionary<Type, items> inventory;
    private string s = "";

    [SerializeField] private Text healthCountTF;
    [SerializeField] private Text puzzleCountTF;
    [SerializeField] private GameObject inventoryUI;

    // Use this for initialization
    void Start () {
        inventory = new Dictionary<Type, items>();
        healthCountTF.text = "0x";
        puzzleCountTF.text = "0x";
        inventoryUI.SetActive(false);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        
    }


    public void addItem(string name, Type type)
    {
        

        // check to see if the inventory has the item
        items itemTemp;
        if (inventory.TryGetValue(type, out itemTemp))
        {
            itemTemp.quantity++;
            inventory[type] = itemTemp;
            if (type == Type.Health)
            {
                healthCountTF.text = itemTemp.quantity + "x";
            }
            if (type == Type.Puzzle)
            {
                puzzleCountTF.text = itemTemp.quantity + "x";
            }
        }
        else
        {
            Item temp = new Item(name, type);
            items i = new items();
            i.item = temp;
            i.quantity = 1;
            inventory.Add(type, i);
            if (type == Type.Health)
            {
                healthCountTF.text = i.quantity + "x";
            }
            if (type == Type.Puzzle)
            {
                puzzleCountTF.text = i.quantity + "x";
            }
        }

        
    }

    public string displayAll()
    {
        
        if (inventory.ContainsKey(Type.Health))
        {
            s += "Health: " + inventory[Type.Health].quantity + ",\n";
        }
        if (inventory.ContainsKey(Type.Puzzle))
        {
            s += "Puzzle: " + inventory[Type.Puzzle].quantity + ",\n";
        }
        if (inventory.ContainsKey(Type.Weapon))
        {
            s += "Weapon: " + inventory[Type.Weapon].quantity + ",\n";
        }
        return s;
    }


}
