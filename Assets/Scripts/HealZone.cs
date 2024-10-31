using UnityEngine;

public class HealZone : MonoBehaviour
{
    [SerializeField] private Health _health;
    private bool inTrigger;

    // Update is called once per frame
    void Update()
    {
        if(inTrigger){
            GetProgressiveHeal();
        }
    }

     private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            inTrigger = true;
        }

    }

    private void OnTriggerExit(Collider other){
        inTrigger = false;
    }

    private void GetProgressiveHeal(){
        if(_health.currentHealth <100)
        {
            _health.Heal(1);
        }
    }
}
