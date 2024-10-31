using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] InputActionReference _moveInput;
    [SerializeField] InputActionReference _jumpInput;
    [SerializeField] Rigidbody _rb;

    [Header("Feedbacks")]
    [SerializeField] Camera _cam;
    [SerializeField] Animator _anim;

    [Space(20)]
    [Header("Values")]
    [SerializeField] float _speed;
    [SerializeField] float _jumpAltitude =20 ;

    [Header("Scripts")]
    [SerializeField] GroundDetector _groundDetector;

    Coroutine _movementRoutine;


    void Start()
    {
        //Horizontal Input
        _moveInput.action.started += MoveStarted;
        //_moveInput.action.performed += MoveUpdated;
        _moveInput.action.canceled += MoveCanceled;

        //Jump
        _jumpInput.action.started += JumpStarted;
    }

    private void OnDestroy(){
        //Horizontal Input
        _moveInput.action.started -= MoveStarted;
        //_moveInput.action.performed += MoveUpdated;
        _moveInput.action.canceled -= MoveCanceled;

        //Jump
        _jumpInput.action.started -= JumpStarted;
    }


    private void MoveStarted(InputAction.CallbackContext obj){
        _anim.SetBool("moving",true);

        _movementRoutine = StartCoroutine(Move());
        IEnumerator Move()
        {
            while (true)
            {
                var joystickDir = obj.ReadValue<Vector2>();

                Vector3 realDirection = new Vector3(joystickDir.x,0, joystickDir.y).normalized;
                

                //Move perso
                _rb.linearVelocity = new Vector3(realDirection.x * _speed, _rb.linearVelocity.y, realDirection.z * _speed);
                
                Cursor.lockState = CursorLockMode.Locked;
                transform.LookAt(transform.position + realDirection);

                _anim.SetBool("isJumping", !_groundDetector.Grounded);

                yield return new WaitForFixedUpdate();
            }   
        }
    }


    private void MoveCanceled(InputAction.CallbackContext obj){
        StopCoroutine(_movementRoutine);
        _anim.SetBool("moving",false);
    }

    private void JumpStarted(InputAction.CallbackContext obj){
        if(_groundDetector.Grounded){
            _anim.SetBool("isJumping",true);

            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x,_jumpAltitude, _rb.linearVelocity.z);
        }
    }


}
