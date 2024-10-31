using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private List<Item> _Inventory = new List<Item>();
    
    [SerializeField] GameObject _swordModel;

    [Header("UI Stuff")]
    [SerializeField] Image _legImg;
    [SerializeField] Image _speImg;
    [SerializeField] Image _classicImg;

    void Awake(){
         instance = this;
        _swordModel?.SetActive(false);
    }

    //Add
    public void Add(Item i){
        _Inventory.Add(i);
        if(i is Sword){
            _swordModel?.SetActive(true);
        }
        Debug.Log("type de mon item : " + i.GetType());
    }

    // public void AddItemOfType<Type>() where Type : Item, new(){ 
    //     Type item = new Type();
    // }

    //Contains
    // public bool Contains(Item i){
    //     if( _Inventory.Contains(i)){
    //         return true;
    //     }
    //     return false;
    // }

    public bool Contains<Type>() where Type : Item{ // contains any inherited class of Item
        foreach(var item in _Inventory){
            if(item is Type){                      // contains any types of sword
                return true;
            }
        }
        return false;
    }

    public bool ContainsExactly<Type>() where Type : Item{ // contains any inherited class of Item
        foreach(var item in _Inventory){
            if(item.GetType() == typeof(Type)){                      // Sword and inherited class of Sword (typeof(), GetType => exact type)
                return true;
            }
        }
        return false;
    }

    //Get
    // public Item GetItemOfType<Type>() where Type : Item{
    //      foreach(var item in _Inventory){
    //         if(item.GetType() == typeof(Type)){                     
    //             return item;
    //         }
    //     }
    //     return null;
    // }

    [Button]
    private void PrintInventory(){
        foreach(var item in _Inventory){
            Debug.Log(item.GetType() + "type");
        }
    }

    //Use
    public void UseItemOfType<Type>() where Type : Item
    {

        for (int i = 0; i < _Inventory.Count; i++)
        {
            var item = _Inventory[i];
            if (item.GetType() == typeof(Type)) // Utilise le 1er item de type Type
            {
                item.Use();
                if (item.Uses == 0)
                {
                    Debug.Log("là");
                    _Inventory.RemoveAt(i); 
                    if (item is Sword)
                    {
                        if (!Contains<Sword>())
                        {
                            _swordModel.SetActive(false);
                        }
                    }
                }
                return; // Quitte après avoir utilisé le premier item
            }
        }
    }

    // public void UseItem(Item i)
    // {
    //     i.Use();
    //     if(i.Uses == 0)
    //     {
    //         _Inventory.Remove(i);
    //         if(i is Sword)
    //         {               // if remove a sword + inventory doesn't contains any swords => desactivate sword model
    //             if(!Contains<Sword>())
    //             {
    //                 _swordModel.SetActive(false);
    //             }
    //         }
    //     }
    // }
}

