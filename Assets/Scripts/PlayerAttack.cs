using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] InputActionReference _attackInput;
    [SerializeField] Animator _anim;

    [SerializeField] UnityEvent _onAttack;
    [SerializeField] UnityEvent _onSpecialAttack;
    [SerializeField] UnityEvent _onLegendaryAttack;

    private Health _OpposantHealth;
    
    private bool inTrigger = false;
    
    void Start()
    {
        _attackInput.action.started += Attack;
    }


    private void OnTriggerEnter(Collider other){
        if(other.TryGetComponent<Health>(out Health health)){
            _OpposantHealth = health;
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other){
         if (other.TryGetComponent<Health>(out Health health) && health == _OpposantHealth)
        {
            inTrigger = false;
            _OpposantHealth = null;
        }
    }

    private void Attack(InputAction.CallbackContext obj){
        bool HasSword = Inventory.instance.Contains<Sword>();

        
        if(HasSword){
            _anim.SetTrigger("attack");
        } else{
            return;
        }

        bool HasSimpleSword = Inventory.instance.ContainsExactly<Sword>();
        bool HasSpecialSword = Inventory.instance.ContainsExactly<SpecialSword>();
        bool HasLegendarySword = Inventory.instance.ContainsExactly<LegendarySword>();


        if(HasLegendarySword){
            _onLegendaryAttack.Invoke();
        }
        else if(HasSpecialSword)
        {
            _onSpecialAttack.Invoke();
        } else if(HasSimpleSword){
            _onAttack.Invoke();
        }


        if (inTrigger && _OpposantHealth != null)
        {
            if(HasLegendarySword){
                Inventory.instance.UseItemOfType<LegendarySword>();
                _OpposantHealth.OneShot();
            }
            else if(HasSpecialSword){
                Inventory.instance.UseItemOfType<SpecialSword>();
                _OpposantHealth.TakeDamage(40);
            }
            else if(HasSimpleSword){
                Inventory.instance.UseItemOfType<Sword>();
                _OpposantHealth.TakeDamage(20);
            }
        }

    }

    
}
