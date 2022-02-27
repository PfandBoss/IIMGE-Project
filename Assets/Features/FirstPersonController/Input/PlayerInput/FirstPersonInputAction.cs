//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Features/FirstPersonController/Input/PlayerInput/FirstPersonInputAction.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @FirstPersonInputAction : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @FirstPersonInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FirstPersonInputAction"",
    ""maps"": [
        {
            ""name"": ""Char"",
            ""id"": ""bfebbd8c-1f88-45a0-a6b9-42bb46aed872"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ae23877f-d83d-42e6-94f7-4b742233ec02"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""b300a078-a80e-4578-9886-4e011d719fe9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""9031b224-4493-44e7-bc08-d44ba395809e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""f20860c5-e412-46cb-ba6b-f921ded581b3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""67d311c6-a450-4dab-8ec1-605421d2b4b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftPunch"",
                    ""type"": ""Button"",
                    ""id"": ""84ffba20-e2f5-428d-b5f3-5ee97c432d4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightPunch"",
                    ""type"": ""Button"",
                    ""id"": ""d7923325-3b80-45a7-9511-9cecfd94077a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WasdKeys"",
                    ""id"": ""7c2c68cd-7bfe-49d8-bcc9-5e9d3bdfc018"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""56de4af6-977d-43e0-b1ea-feed56b99b47"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""9ab85f51-ca4a-4ec3-8663-9bf26b36d6e9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""008ce090-e6e3-4ca0-84df-1c13f11f3912"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""49ed26f0-7d38-4a1b-ad35-3a09bc520abe"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c561e8e1-da09-49bf-8110-833883fdc931"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4a692e9-a75d-4872-babd-6741d2cece10"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""DivideVector2ByDeltaTime,ScaleVector2(x=0.1,y=0.1)"",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cf2cbdc-31cd-4be7-8c38-18c498bc55fd"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c51267fe-52c0-498f-b7ab-08a350d23cc9"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46114c3b-b847-4275-8f2c-cb5183b07cd7"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5c98014-5d1f-442e-9409-dee912518d6a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ae6e5d3-b49b-4319-824a-4b00cfb6ec5e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7681c87a-3d42-4505-80aa-c7bdc74fb38c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4db9e712-ae36-4da9-9948-01294b64ed55"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88748218-5074-4f1b-867f-580cace3ab33"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""LeftPunch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd8139bf-5ee8-4ac8-874c-53569579a056"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LeftPunch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ff7d4e2-5a44-4005-8043-a303ea57f4d9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""RightPunch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0afd9a75-b76b-4c9f-a70a-222fed3e527d"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RightPunch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Char
        m_Char = asset.FindActionMap("Char", throwIfNotFound: true);
        m_Char_Move = m_Char.FindAction("Move", throwIfNotFound: true);
        m_Char_Look = m_Char.FindAction("Look", throwIfNotFound: true);
        m_Char_Sprint = m_Char.FindAction("Sprint", throwIfNotFound: true);
        m_Char_Jump = m_Char.FindAction("Jump", throwIfNotFound: true);
        m_Char_Pause = m_Char.FindAction("Pause", throwIfNotFound: true);
        m_Char_LeftPunch = m_Char.FindAction("LeftPunch", throwIfNotFound: true);
        m_Char_RightPunch = m_Char.FindAction("RightPunch", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Char
    private readonly InputActionMap m_Char;
    private ICharActions m_CharActionsCallbackInterface;
    private readonly InputAction m_Char_Move;
    private readonly InputAction m_Char_Look;
    private readonly InputAction m_Char_Sprint;
    private readonly InputAction m_Char_Jump;
    private readonly InputAction m_Char_Pause;
    private readonly InputAction m_Char_LeftPunch;
    private readonly InputAction m_Char_RightPunch;
    public struct CharActions
    {
        private @FirstPersonInputAction m_Wrapper;
        public CharActions(@FirstPersonInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Char_Move;
        public InputAction @Look => m_Wrapper.m_Char_Look;
        public InputAction @Sprint => m_Wrapper.m_Char_Sprint;
        public InputAction @Jump => m_Wrapper.m_Char_Jump;
        public InputAction @Pause => m_Wrapper.m_Char_Pause;
        public InputAction @LeftPunch => m_Wrapper.m_Char_LeftPunch;
        public InputAction @RightPunch => m_Wrapper.m_Char_RightPunch;
        public InputActionMap Get() { return m_Wrapper.m_Char; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharActions set) { return set.Get(); }
        public void SetCallbacks(ICharActions instance)
        {
            if (m_Wrapper.m_CharActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CharActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CharActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CharActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_CharActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_CharActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_CharActionsCallbackInterface.OnLook;
                @Sprint.started -= m_Wrapper.m_CharActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_CharActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_CharActionsCallbackInterface.OnSprint;
                @Jump.started -= m_Wrapper.m_CharActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharActionsCallbackInterface.OnJump;
                @Pause.started -= m_Wrapper.m_CharActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_CharActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_CharActionsCallbackInterface.OnPause;
                @LeftPunch.started -= m_Wrapper.m_CharActionsCallbackInterface.OnLeftPunch;
                @LeftPunch.performed -= m_Wrapper.m_CharActionsCallbackInterface.OnLeftPunch;
                @LeftPunch.canceled -= m_Wrapper.m_CharActionsCallbackInterface.OnLeftPunch;
                @RightPunch.started -= m_Wrapper.m_CharActionsCallbackInterface.OnRightPunch;
                @RightPunch.performed -= m_Wrapper.m_CharActionsCallbackInterface.OnRightPunch;
                @RightPunch.canceled -= m_Wrapper.m_CharActionsCallbackInterface.OnRightPunch;
            }
            m_Wrapper.m_CharActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @LeftPunch.started += instance.OnLeftPunch;
                @LeftPunch.performed += instance.OnLeftPunch;
                @LeftPunch.canceled += instance.OnLeftPunch;
                @RightPunch.started += instance.OnRightPunch;
                @RightPunch.performed += instance.OnRightPunch;
                @RightPunch.canceled += instance.OnRightPunch;
            }
        }
    }
    public CharActions @Char => new CharActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface ICharActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnLeftPunch(InputAction.CallbackContext context);
        void OnRightPunch(InputAction.CallbackContext context);
    }
}
