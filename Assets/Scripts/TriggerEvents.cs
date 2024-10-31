using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    [SerializeField] UnityEvent _OnEnter;
    [SerializeField] UnityEvent _OnExit;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            _OnEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            _OnExit?.Invoke();
        }
    }
}
