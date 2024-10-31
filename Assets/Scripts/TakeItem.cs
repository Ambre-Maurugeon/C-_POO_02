using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TakeItem : MonoBehaviour
{
    [SerializeField] Item.Types _item;
    [SerializeField, Tooltip("GameObject that will be destroyed when interaction takes place")] GameObject _entity;

    [SerializeField] UnityEvent _onTakeItem;

    [Header("Input")]
    [SerializeField] InputActionReference _interactInput;

    private bool inTrigger = false;


    void Start()
    {
        _interactInput.action.started += Interact;
    }


    private void Interact(InputAction.CallbackContext obj){
        if(inTrigger)
        {
            if ((_item == Item.Types.Sword && Inventory.instance.ContainsExactly<Sword>()) ||
            (_item == Item.Types.SpecialSword && Inventory.instance.ContainsExactly<SpecialSword>()) ||
            (_item == Item.Types.LegendarySword && Inventory.instance.ContainsExactly<LegendarySword>()))
        {
            return; // no two same swords
        }
        
        Item myItem = GetMyItemType();
        if (myItem != null)
        {
            _onTakeItem?.Invoke();
            Inventory.instance.Add(myItem);
            Destroy(_entity, 0.25f);
        }
        }
    }

    private Item GetMyItemType(){
        switch(_item){
            case Item.Types.Sword :
                return new Sword();
            case Item.Types.SpecialSword :
                return new SpecialSword();
            case Item.Types.LegendarySword :
                return new LegendarySword();
            // case Item.Types.Potion :
            //     return new Potion();
            default:
             return null;
        }
    }

//Trigger
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            inTrigger = false;
        }
    }

    
}
