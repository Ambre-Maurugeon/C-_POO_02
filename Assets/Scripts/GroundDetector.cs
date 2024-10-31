using UnityEngine;

public class GroundDetector: MonoBehaviour
{
    [SerializeField] private Animator _anim;
    public bool Grounded { get; private set; } = false;
    bool inTrigger ;
    

    private void OnTriggerEnter(Collider other){
        Grounded = true;
        _anim.SetBool("grounded", true);
        Debug.Log("Sur le sol");
    }

    private void OnTriggerExit(Collider other){
        Grounded = false;
        _anim.SetBool("grounded", false);
    }

}

