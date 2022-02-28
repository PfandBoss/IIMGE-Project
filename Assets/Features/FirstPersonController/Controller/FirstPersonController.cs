using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;


/// <summary>
///     Controller that handles the character controls and camera controls of the first person player.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private FirstPersonControllerInput firstPersonControllerInput;
    private CharacterController _characterController;
    private Camera _camera;

    [SerializeField]private float walkingSpeed;
    private float velocity;
    [SerializeField] private float sprintingSpeed;
    [SerializeField] private float maxViewAngle;
    [SerializeField] private float minViewAngle;
    [SerializeField] private float jumpSpeed;

    [SerializeField]private GameObject _pauseMenu;
    [SerializeField] private PlayerStats stats;
    
    private float stickToGroundForceMagnitude = 5.0f;


    private void Awake() {
        _characterController = GetComponent<CharacterController>();
        _camera = GetComponentInChildren<Camera>();
        velocity = walkingSpeed;
    }

    private void Start()
    {
        stats.getSpeedMultiplier().Subscribe(f => changeSpeed(f)).AddTo(this);
        
        _characterController.Move(-stickToGroundForceMagnitude * transform.up);
        
        var jumpLatch = LatchObservables.Latch(this.UpdateAsObservable(), firstPersonControllerInput.Jump, false);
        
        firstPersonControllerInput.Move.Zip(jumpLatch,(mo,ju) => new MoveInputData(mo,ju) ).Subscribe(input =>
        {
            var wasGrounded = _characterController.isGrounded;
            var verticalVelocity = 0f;
            if (input.jump && wasGrounded)
            {
        // We're on the ground and want to jump.
                verticalVelocity = jumpSpeed;
                
            }
            else if (!wasGrounded)
            {
        // We're in the air: apply gravity.
                verticalVelocity = _characterController.velocity.y +
                                   (Physics.gravity.y * Time.deltaTime * 3.0f);
            }
            else
            {
        // We're on the ground: push us down a little.
        // (Required for character.isGrounded to work.)
                verticalVelocity = -Mathf.Abs(stickToGroundForceMagnitude);
            }

            

            var horVelocity = input.move * walkingSpeed;

            var charVelocity = transform.TransformVector(new Vector3(horVelocity.x, verticalVelocity, horVelocity.y));
 
            var distance = charVelocity * Time.deltaTime;

            _characterController.Move(distance);
        }).AddTo(this);

        firstPersonControllerInput.Look.Where(vec => vec != Vector2.zero).Subscribe(input =>
        {
            var horLook = input.x * Vector3.up * Time.deltaTime;
            
            transform.localRotation *= Quaternion.Euler(horLook);


            var vertLook = input.y * Vector3.left * Time.deltaTime ;


            var newQ = _camera.transform.localRotation * Quaternion.Euler(vertLook);


            _camera.transform.localRotation = RotationTools.ClampRotationAroundXAxis(newQ, -maxViewAngle, -minViewAngle);
        }).AddTo(this);


        firstPersonControllerInput.Run.Subscribe(input =>
        {
            if (input)
            {
                walkingSpeed = sprintingSpeed;
            }
            else
            {
                walkingSpeed = velocity;
            }

        });

        firstPersonControllerInput.Pause.Subscribe(input =>
        {
            if (input)
            {
                _pauseMenu.GetComponent<PauseMenu>().EnterMenu();
            }
        }).AddTo(this);

    }

    private void changeSpeed(float speedMultiplier)
    {
        walkingSpeed *= speedMultiplier;
    }

    public struct MoveInputData
    {
        public readonly Vector2 move;
        public readonly bool jump;
        public MoveInputData(Vector2 move, bool jump) {
            this.move = move;
            this.jump = jump;
        }

    }

}
