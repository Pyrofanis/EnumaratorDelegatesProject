// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerControlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControlls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControlls"",
    ""maps"": [
        {
            ""name"": ""MainControlls"",
            ""id"": ""b1bb1b0a-4f59-4b18-9c36-132db1bf0090"",
            ""actions"": [
                {
                    ""name"": ""JumpAction"",
                    ""type"": ""Button"",
                    ""id"": ""8858be92-ee13-4b9f-8c69-aa439d2cf4d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""d34bc8c5-825e-4994-8d26-6f41e969831d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""9d5f4e7c-1ec4-4674-ae78-feddd7313ee8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Direction"",
                    ""type"": ""Button"",
                    ""id"": ""58b50e99-c8a2-460b-a3a4-68554738a1ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DirectionMouse"",
                    ""type"": ""Value"",
                    ""id"": ""3a316208-6213-4311-9cae-8a0a5e9f1f8c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UiButton"",
                    ""type"": ""Button"",
                    ""id"": ""ddc98936-2e69-43e0-afa0-b106adc04783"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape/ExtGame"",
                    ""type"": ""Button"",
                    ""id"": ""9c2a4f85-63dd-4c3b-8ac2-a25951bf2916"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5dfbb876-5dc4-4d51-bfd4-ffc261333703"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""JumpAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6507e0fd-238e-4d63-aa88-9e1e1302bb96"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""JumpAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d053747-30d5-4715-b61a-f735968a1e90"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf2f6135-5cef-40a3-9dc4-7f58b0936134"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7e97787-dc3b-444b-865c-21d5e85af48a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""JumpAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c8bbb6b-d777-4208-98f8-6a9071bb6b84"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""JumpAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d60573cc-527a-4e57-a54d-c4785256c29c"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fefcb1b4-5e92-46bd-8619-40d1ebbad5cd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac46c17a-7bfd-476f-94ae-3c64c2dfac65"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f346ec35-6d20-4f9c-bf7a-ff248b9c3eaf"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59600285-dfec-434c-bdd4-ab78e5ee885c"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D AxisPc1"",
                    ""id"": ""78de3626-de10-4b1b-9206-1039dba375ad"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""97d557cf-5f89-4d8c-b9f2-9bf953fdeae1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8f6ff306-3e51-44fe-bf8e-25c1172d7150"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D AxisPs4nXbox1"",
                    ""id"": ""4a826f94-d071-4793-8060-773b96e60599"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9f89a080-c2af-4ba2-9dc8-a3abb34ef5f7"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8c7f4d81-ac08-4333-b208-1ca173129aad"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D AxisPs4nXbox1"",
                    ""id"": ""8ccd6189-53f7-4e88-8575-7e77da77c8a0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""44fc619a-db33-453a-b3c4-d4a513430e2f"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ab99ee60-eac5-4387-90c5-279e03e290d9"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D AxisPc2"",
                    ""id"": ""9d726d92-b7e1-48fc-a7ee-1ff84eec431b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""39a5da29-0cf2-4b7e-9089-8b6692067583"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ad19b3f5-0518-4c54-bb13-0c63860d7d0b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D AxisGamePad"",
                    ""id"": ""580488eb-7eb0-41c7-9621-a1b6a5e071be"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""3ee0a798-5d0c-4e51-9c59-02eebde918f0"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""9ffae00e-6845-4f94-a0d2-0331c4a3feb3"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3e31aaf0-8dfe-474e-979d-6dabcd8c0bc5"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""DirectionMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ac6cec6-a6fb-4dd3-b89e-234649939582"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""UiButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1eb92f85-5d35-4933-a250-a0474dd02314"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""UiButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8017798-2c2f-43d9-aafd-6caad617298f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Escape/ExtGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f3cda0c-78cb-4c95-a9d9-4dc205dcafc0"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SchemeGeneral"",
                    ""action"": ""Escape/ExtGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""SchemeGeneral"",
            ""bindingGroup"": ""SchemeGeneral"",
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
                },
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // MainControlls
        m_MainControlls = asset.FindActionMap("MainControlls", throwIfNotFound: true);
        m_MainControlls_JumpAction = m_MainControlls.FindAction("JumpAction", throwIfNotFound: true);
        m_MainControlls_Attack = m_MainControlls.FindAction("Attack", throwIfNotFound: true);
        m_MainControlls_Move = m_MainControlls.FindAction("Move", throwIfNotFound: true);
        m_MainControlls_Direction = m_MainControlls.FindAction("Direction", throwIfNotFound: true);
        m_MainControlls_DirectionMouse = m_MainControlls.FindAction("DirectionMouse", throwIfNotFound: true);
        m_MainControlls_UiButton = m_MainControlls.FindAction("UiButton", throwIfNotFound: true);
        m_MainControlls_EscapeExtGame = m_MainControlls.FindAction("Escape/ExtGame", throwIfNotFound: true);
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

    // MainControlls
    private readonly InputActionMap m_MainControlls;
    private IMainControllsActions m_MainControllsActionsCallbackInterface;
    private readonly InputAction m_MainControlls_JumpAction;
    private readonly InputAction m_MainControlls_Attack;
    private readonly InputAction m_MainControlls_Move;
    private readonly InputAction m_MainControlls_Direction;
    private readonly InputAction m_MainControlls_DirectionMouse;
    private readonly InputAction m_MainControlls_UiButton;
    private readonly InputAction m_MainControlls_EscapeExtGame;
    public struct MainControllsActions
    {
        private @PlayerControlls m_Wrapper;
        public MainControllsActions(@PlayerControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @JumpAction => m_Wrapper.m_MainControlls_JumpAction;
        public InputAction @Attack => m_Wrapper.m_MainControlls_Attack;
        public InputAction @Move => m_Wrapper.m_MainControlls_Move;
        public InputAction @Direction => m_Wrapper.m_MainControlls_Direction;
        public InputAction @DirectionMouse => m_Wrapper.m_MainControlls_DirectionMouse;
        public InputAction @UiButton => m_Wrapper.m_MainControlls_UiButton;
        public InputAction @EscapeExtGame => m_Wrapper.m_MainControlls_EscapeExtGame;
        public InputActionMap Get() { return m_Wrapper.m_MainControlls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainControllsActions set) { return set.Get(); }
        public void SetCallbacks(IMainControllsActions instance)
        {
            if (m_Wrapper.m_MainControllsActionsCallbackInterface != null)
            {
                @JumpAction.started -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnJumpAction;
                @JumpAction.performed -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnJumpAction;
                @JumpAction.canceled -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnJumpAction;
                @Attack.started -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnAttack;
                @Move.started -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnMove;
                @Direction.started -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnDirection;
                @Direction.performed -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnDirection;
                @Direction.canceled -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnDirection;
                @DirectionMouse.started -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnDirectionMouse;
                @DirectionMouse.performed -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnDirectionMouse;
                @DirectionMouse.canceled -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnDirectionMouse;
                @UiButton.started -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnUiButton;
                @UiButton.performed -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnUiButton;
                @UiButton.canceled -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnUiButton;
                @EscapeExtGame.started -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnEscapeExtGame;
                @EscapeExtGame.performed -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnEscapeExtGame;
                @EscapeExtGame.canceled -= m_Wrapper.m_MainControllsActionsCallbackInterface.OnEscapeExtGame;
            }
            m_Wrapper.m_MainControllsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @JumpAction.started += instance.OnJumpAction;
                @JumpAction.performed += instance.OnJumpAction;
                @JumpAction.canceled += instance.OnJumpAction;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Direction.started += instance.OnDirection;
                @Direction.performed += instance.OnDirection;
                @Direction.canceled += instance.OnDirection;
                @DirectionMouse.started += instance.OnDirectionMouse;
                @DirectionMouse.performed += instance.OnDirectionMouse;
                @DirectionMouse.canceled += instance.OnDirectionMouse;
                @UiButton.started += instance.OnUiButton;
                @UiButton.performed += instance.OnUiButton;
                @UiButton.canceled += instance.OnUiButton;
                @EscapeExtGame.started += instance.OnEscapeExtGame;
                @EscapeExtGame.performed += instance.OnEscapeExtGame;
                @EscapeExtGame.canceled += instance.OnEscapeExtGame;
            }
        }
    }
    public MainControllsActions @MainControlls => new MainControllsActions(this);
    private int m_SchemeGeneralSchemeIndex = -1;
    public InputControlScheme SchemeGeneralScheme
    {
        get
        {
            if (m_SchemeGeneralSchemeIndex == -1) m_SchemeGeneralSchemeIndex = asset.FindControlSchemeIndex("SchemeGeneral");
            return asset.controlSchemes[m_SchemeGeneralSchemeIndex];
        }
    }
    public interface IMainControllsActions
    {
        void OnJumpAction(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnDirection(InputAction.CallbackContext context);
        void OnDirectionMouse(InputAction.CallbackContext context);
        void OnUiButton(InputAction.CallbackContext context);
        void OnEscapeExtGame(InputAction.CallbackContext context);
    }
}
