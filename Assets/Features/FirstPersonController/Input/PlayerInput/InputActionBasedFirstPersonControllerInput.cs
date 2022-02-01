using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;


public class InputActionBasedFirstPersonControllerInput : FirstPersonControllerInput
{
    private FirstPersonInputAction _firstPersonInputAction;


    private IObservable<Vector2> _move;
    private IObservable<Vector2> _look;
    private ReadOnlyReactiveProperty<bool> _sprint;
    private ReadOnlyReactiveProperty<bool> _pause;
    private Subject<Unit> _jump;



    private const float LookSmoothingFactor = 50f;

    public override IObservable<Vector2> Move
    {
        get { return _move; }
    }
    public override IObservable<Unit> Jump
    {
        get { return _jump; }
    }
    public override ReadOnlyReactiveProperty<bool> Run
    {
        get { return _sprint; }
    }
    public override IObservable<Vector2> Look
    {
        get { return _look; }
    }
    
    public override ReadOnlyReactiveProperty<bool> Pause
    {
        get { return _pause; }
    }

    


    private void Awake()
    {
        _firstPersonInputAction = new FirstPersonInputAction();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        _move = this.UpdateAsObservable()
            .Select(_ => _firstPersonInputAction.Char.Move.ReadValue<Vector2>());

        var smoothLookValue = new Vector2(0, 0);
        _look = this.UpdateAsObservable()
            .Select(_ =>
            {
                var rawLookValue = _firstPersonInputAction.Char.Look.ReadValue<Vector2>();

                smoothLookValue = new Vector2(
                    Mathf.Lerp(smoothLookValue.x, rawLookValue.x, LookSmoothingFactor * Time.deltaTime),
                    Mathf.Lerp(smoothLookValue.y, rawLookValue.y, LookSmoothingFactor * Time.deltaTime)
                );

                return smoothLookValue;
            });


        _sprint = this.UpdateAsObservable().Select(_=> _firstPersonInputAction.Char.Sprint.ReadValueAsObject() != null).ToReadOnlyReactiveProperty();


        _jump = new Subject<Unit>().AddTo(this);
        _firstPersonInputAction.Char.Jump.performed += _ => _jump.OnNext(Unit.Default);

        _pause = this.UpdateAsObservable().Select(_ => _firstPersonInputAction.Char.Pause.ReadValueAsObject() != null)
            .ToReadOnlyReactiveProperty();

    }

    private void OnEnable()
    {
        _firstPersonInputAction.Enable();
    }

    private void OnDisable()
    {
        _firstPersonInputAction.Disable();
    }
    
    
}