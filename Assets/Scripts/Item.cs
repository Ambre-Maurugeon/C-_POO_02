using UnityEngine;

public class Item
{
    
    public virtual int Uses => 0;

    public virtual void Use(){
    }

    public enum Types{
        Sword,
        SpecialSword,
        LegendarySword,
        Potion,
        None
    }
}


