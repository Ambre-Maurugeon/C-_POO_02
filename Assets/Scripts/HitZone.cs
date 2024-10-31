using UnityEngine;
using System.Collections;

public class HitZone : MonoBehaviour
{
    [SerializeField] Health _health;

    private bool inTrigger = false;
    private bool isTakingDmg = false;
    private bool JustTriggered=false;

    private Collider _enemyColl;

    void Update(){
        if(inTrigger){
            if(!isTakingDmg){
                if(JustTriggered){
                    _health.TakeDamage(20);
                    JustTriggered = false;
                }
                isTakingDmg = true;
                Invoke("TakeContinueDmg",0.4f);
            }
        }else if(!inTrigger || _enemyColl==null ){
            isTakingDmg = false;
            CancelInvoke("TakeContinueDmg");
        }
    }

    private void OnTriggerEnter(Collider other){
        JustTriggered = true;
        inTrigger = true;
        _enemyColl=other;
    }

    private void OnTriggerExit(Collider other)
    {
            inTrigger = false;
            _enemyColl=null;
        }


    private void TakeContinueDmg(){
        _health.TakeDamage(20);
        isTakingDmg = false;
    }

}
