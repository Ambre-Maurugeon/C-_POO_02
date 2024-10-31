using UnityEngine;
using NaughtyAttributes;
using System;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField, ValidateInput("IsPositive", "myInteger must be greater than zero")]
    int _maxLife;
    public int currentHealth {get; private set;}

    [Header("Animation")]
    [SerializeField] Animator _anim;

    [Space(20)]
    [Header("Feedbacks")]

    [Header("Die Events")]
    [SerializeField] UnityEvent _onDie;

    [SerializeField] bool _CamShakerOnDie = false;
    [SerializeField, ShowIf("_CamShakerOnDie")] UnityEvent _onDestroy;

    [Header("Dmg Events")]
    [SerializeField] bool _DmgEvents = false;
    [SerializeField, ShowIf("_DmgEvents")] UnityEvent _onTakeDamage;

    [Button]
    void TestTakeDmg(){
        TakeDamage(10);
    }
    
    [Button]
    void TestHeal(){
        Heal(10);
    }

    public event Action<int> OnTakeDamage;
    public event Action<int> OnHeal;


    //private void TakeDamage(int parameter = 5) { }

    public bool IsDead => currentHealth <=0 ;
    

    private bool IsPositive(int value)
    {
        return value > 0;
    }

    void Reset(){
        _maxLife = 100;
    }

    void Awake(){   
        currentHealth = _maxLife;
    }


    // [Button]
    // void TestErrorTakeDmg(){
    //     TakeDamage(-10);
    // }

    public void TakeDamage(int dmg){
        if(dmg <=0){
            Debug.LogError("damage must be positive");
            return;
        }

        currentHealth = Mathf.Clamp( currentHealth - dmg,0,_maxLife);

        OnTakeDamage?.Invoke(12);

        //Feedback
        DmgEvents();

        if(_anim != null){ 
            _anim.SetTrigger("hit");
        }

        //Mort
        if(IsDead){
            Die();
        }
    }

    public void Heal(int heal){
        currentHealth = Mathf.Clamp( currentHealth + heal,0,_maxLife);
        OnHeal?.Invoke(12);
    }

    public void OneShot(){
        Die();
    }

    void DmgEvents(){
        _onTakeDamage?.Invoke();
    }

    void Die(){
        _onDie.Invoke();
        
        Destroy(gameObject,0.35f); //Destroy(this) = composant
    }

    void OnDestroy(){
        _onDestroy.Invoke();
    }

    //new wait for seconds : prends en compte le time scale (expl ralenti au time scale 0.5)
    //new WaitForSecondsRealTime
}
