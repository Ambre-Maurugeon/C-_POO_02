using UnityEngine;

public class SpecialSword : Sword
{
    public SpecialSword()
    {
        _remainingUses = 2; 
        _attack = 40;   
    }

    public override int Attack => _attack;
}
