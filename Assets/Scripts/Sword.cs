using UnityEngine;

public class Sword : Item
{
    protected  int  _remainingUses = 5;
    protected  int _attack = 20;

    public virtual int Attack => _attack;

    public override void Use()
    {
        if (Uses > 0)
        {
             _remainingUses--;
            Debug.Log("Remaining uses: " +  Uses);
        }
        else
        {
            Debug.Log("sword broken");
        }
    }
    
    public override int Uses => _remainingUses;
}
