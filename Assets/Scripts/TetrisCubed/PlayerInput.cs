// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/TetrisCubed/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Menu Controls"",
            ""id"": ""81bb984b-bcf6-48bd-9bcd-d76df991a092"",
            ""actions"": [
                {
                    ""name"": ""NavUp"",
                    ""type"": ""Button"",
                    ""id"": ""80285a17-7b5e-4c35-a5c0-07ddcadc20d2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavDown"",
                    ""type"": ""Button"",
                    ""id"": ""bf2d2fbc-e867-4b58-91c7-677bda3c6749"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""65f4894c-db76-475c-b80e-3eeb419abf34"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GoTo4x4"",
                    ""type"": ""Button"",
                    ""id"": ""1a2c4b57-66b8-455f-8d6f-2f5e8947c4aa"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""38f94a22-ef9a-4cf0-98cd-ed7b6ce256b1"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23790f22-dbd2-4241-a048-580b32e3c619"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea220be1-b3c4-42fd-8e34-75d8e96e17f1"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""472d30d6-7349-4c31-9e0a-c7de1c7e3724"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50ec4c3e-4016-4072-a69a-73c679b214d0"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bc3d125-8906-44da-9c12-60c448f3b9b4"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GoTo4x4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""In-Game Controls"",
            ""id"": ""2aeecc70-b280-48b2-a5d5-2b2bd996d7bd"",
            ""actions"": [
                {
                    ""name"": ""RotateUp"",
                    ""type"": ""Button"",
                    ""id"": ""5f3a1e82-86e0-48b1-aa59-1324a0aad350"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateDown"",
                    ""type"": ""Button"",
                    ""id"": ""eb72e852-4f78-41e0-97c5-431bb6272384"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateLeft"",
                    ""type"": ""Button"",
                    ""id"": ""ff2dc2c8-bd4f-41e2-b268-2c752dbe2460"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateRight"",
                    ""type"": ""Button"",
                    ""id"": ""4864d917-28f4-46c0-a19e-8935b98a3084"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TiltLeft"",
                    ""type"": ""Button"",
                    ""id"": ""fc99756c-d056-4199-8f31-400ccceed81f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TiltRight"",
                    ""type"": ""Button"",
                    ""id"": ""db5bcde0-c5ab-4109-bfc4-68d8889e73a3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""b21e0d72-10a7-46da-beb3-47a3d2198d74"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""ed60c474-ea8b-4aa1-acfa-477f40ff2467"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""46ce05f5-634d-49c9-9fd9-75d480a0c0db"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""4bead492-0b6f-4e02-8351-c76145b76dd2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CycleLeft"",
                    ""type"": ""Button"",
                    ""id"": ""b45ce98d-e1e5-4b6b-bbce-01c424a1acb0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)""
                },
                {
                    ""name"": ""CycleRight"",
                    ""type"": ""Button"",
                    ""id"": ""0b5a8974-6ebf-4151-b61c-868bf27f56f6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)""
                },
                {
                    ""name"": ""CycleUp"",
                    ""type"": ""Button"",
                    ""id"": ""e98781bb-1511-45d7-a756-0207fe699a5b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)""
                },
                {
                    ""name"": ""CycleDown"",
                    ""type"": ""Button"",
                    ""id"": ""de897d4f-88e7-4a0a-85ef-21fc38fd8fdb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)""
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""adf04510-826d-44d5-a3c9-5f64dc79d004"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)""
                },
                {
                    ""name"": ""ToggleCamProjection"",
                    ""type"": ""Button"",
                    ""id"": ""1d16ccab-db8b-40e1-ac8e-51275ad6a2aa"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)""
                },
                {
                    ""name"": ""FastFall"",
                    ""type"": ""Button"",
                    ""id"": ""bfdb0597-feb6-4ffa-b945-f75c670b9575"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0500c6de-74fe-46c4-b2eb-8bcfb60489e2"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": ""Press(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d043b686-1ccf-4f40-ba7b-f30ac26f3e8f"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": ""Press(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""396c3ab7-3bc9-4b2a-b7df-c251192b0b16"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": ""Press(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93665274-a1d3-4281-af18-43eae35217aa"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": ""Press(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ff2ae3e-3a44-4288-8e2d-56da4a90cea5"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TiltLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3addfa8-3d91-4649-824c-46d6ff2cb6ec"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TiltRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""388a4130-5fa4-495d-ab70-93e59b84756e"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": ""Press(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db346d2d-ec8b-46a7-abf2-db932dac4631"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": ""Press(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67dfd0ab-6df1-4ac6-a37e-a1854c3703b7"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": ""Press(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""597f4fc7-c9e7-4cd8-85fa-57a804ea20ae"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": ""Press(pressPoint=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f082f318-5eb5-4b26-afbe-dc05aebbfdfb"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa80f204-ba1c-45c9-b1c9-1ad9d5e802ad"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1746aac5-8188-4e48-bba6-96a9040a8449"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76ccb8f2-61e1-48ca-bfdb-5a73a0fcc2c3"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d137dda-8c34-4756-9a91-3b4da1f1d8bf"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa63292e-9080-40a9-a765-3072a1a7673f"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleCamProjection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f585b94-2d92-409a-8eaa-12c28f4d4919"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FastFall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Menu Controls
        m_MenuControls = asset.FindActionMap("Menu Controls", throwIfNotFound: true);
        m_MenuControls_NavUp = m_MenuControls.FindAction("NavUp", throwIfNotFound: true);
        m_MenuControls_NavDown = m_MenuControls.FindAction("NavDown", throwIfNotFound: true);
        m_MenuControls_Enter = m_MenuControls.FindAction("Enter", throwIfNotFound: true);
        m_MenuControls_GoTo4x4 = m_MenuControls.FindAction("GoTo4x4", throwIfNotFound: true);
        // In-Game Controls
        m_InGameControls = asset.FindActionMap("In-Game Controls", throwIfNotFound: true);
        m_InGameControls_RotateUp = m_InGameControls.FindAction("RotateUp", throwIfNotFound: true);
        m_InGameControls_RotateDown = m_InGameControls.FindAction("RotateDown", throwIfNotFound: true);
        m_InGameControls_RotateLeft = m_InGameControls.FindAction("RotateLeft", throwIfNotFound: true);
        m_InGameControls_RotateRight = m_InGameControls.FindAction("RotateRight", throwIfNotFound: true);
        m_InGameControls_TiltLeft = m_InGameControls.FindAction("TiltLeft", throwIfNotFound: true);
        m_InGameControls_TiltRight = m_InGameControls.FindAction("TiltRight", throwIfNotFound: true);
        m_InGameControls_MoveUp = m_InGameControls.FindAction("MoveUp", throwIfNotFound: true);
        m_InGameControls_MoveDown = m_InGameControls.FindAction("MoveDown", throwIfNotFound: true);
        m_InGameControls_MoveLeft = m_InGameControls.FindAction("MoveLeft", throwIfNotFound: true);
        m_InGameControls_MoveRight = m_InGameControls.FindAction("MoveRight", throwIfNotFound: true);
        m_InGameControls_CycleLeft = m_InGameControls.FindAction("CycleLeft", throwIfNotFound: true);
        m_InGameControls_CycleRight = m_InGameControls.FindAction("CycleRight", throwIfNotFound: true);
        m_InGameControls_CycleUp = m_InGameControls.FindAction("CycleUp", throwIfNotFound: true);
        m_InGameControls_CycleDown = m_InGameControls.FindAction("CycleDown", throwIfNotFound: true);
        m_InGameControls_Restart = m_InGameControls.FindAction("Restart", throwIfNotFound: true);
        m_InGameControls_ToggleCamProjection = m_InGameControls.FindAction("ToggleCamProjection", throwIfNotFound: true);
        m_InGameControls_FastFall = m_InGameControls.FindAction("FastFall", throwIfNotFound: true);
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

    // Menu Controls
    private readonly InputActionMap m_MenuControls;
    private IMenuControlsActions m_MenuControlsActionsCallbackInterface;
    private readonly InputAction m_MenuControls_NavUp;
    private readonly InputAction m_MenuControls_NavDown;
    private readonly InputAction m_MenuControls_Enter;
    private readonly InputAction m_MenuControls_GoTo4x4;
    public struct MenuControlsActions
    {
        private @PlayerInput m_Wrapper;
        public MenuControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @NavUp => m_Wrapper.m_MenuControls_NavUp;
        public InputAction @NavDown => m_Wrapper.m_MenuControls_NavDown;
        public InputAction @Enter => m_Wrapper.m_MenuControls_Enter;
        public InputAction @GoTo4x4 => m_Wrapper.m_MenuControls_GoTo4x4;
        public InputActionMap Get() { return m_Wrapper.m_MenuControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMenuControlsActions instance)
        {
            if (m_Wrapper.m_MenuControlsActionsCallbackInterface != null)
            {
                @NavUp.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnNavUp;
                @NavUp.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnNavUp;
                @NavUp.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnNavUp;
                @NavDown.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnNavDown;
                @NavDown.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnNavDown;
                @NavDown.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnNavDown;
                @Enter.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnEnter;
                @GoTo4x4.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnGoTo4x4;
                @GoTo4x4.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnGoTo4x4;
                @GoTo4x4.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnGoTo4x4;
            }
            m_Wrapper.m_MenuControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NavUp.started += instance.OnNavUp;
                @NavUp.performed += instance.OnNavUp;
                @NavUp.canceled += instance.OnNavUp;
                @NavDown.started += instance.OnNavDown;
                @NavDown.performed += instance.OnNavDown;
                @NavDown.canceled += instance.OnNavDown;
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
                @GoTo4x4.started += instance.OnGoTo4x4;
                @GoTo4x4.performed += instance.OnGoTo4x4;
                @GoTo4x4.canceled += instance.OnGoTo4x4;
            }
        }
    }
    public MenuControlsActions @MenuControls => new MenuControlsActions(this);

    // In-Game Controls
    private readonly InputActionMap m_InGameControls;
    private IInGameControlsActions m_InGameControlsActionsCallbackInterface;
    private readonly InputAction m_InGameControls_RotateUp;
    private readonly InputAction m_InGameControls_RotateDown;
    private readonly InputAction m_InGameControls_RotateLeft;
    private readonly InputAction m_InGameControls_RotateRight;
    private readonly InputAction m_InGameControls_TiltLeft;
    private readonly InputAction m_InGameControls_TiltRight;
    private readonly InputAction m_InGameControls_MoveUp;
    private readonly InputAction m_InGameControls_MoveDown;
    private readonly InputAction m_InGameControls_MoveLeft;
    private readonly InputAction m_InGameControls_MoveRight;
    private readonly InputAction m_InGameControls_CycleLeft;
    private readonly InputAction m_InGameControls_CycleRight;
    private readonly InputAction m_InGameControls_CycleUp;
    private readonly InputAction m_InGameControls_CycleDown;
    private readonly InputAction m_InGameControls_Restart;
    private readonly InputAction m_InGameControls_ToggleCamProjection;
    private readonly InputAction m_InGameControls_FastFall;
    public struct InGameControlsActions
    {
        private @PlayerInput m_Wrapper;
        public InGameControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @RotateUp => m_Wrapper.m_InGameControls_RotateUp;
        public InputAction @RotateDown => m_Wrapper.m_InGameControls_RotateDown;
        public InputAction @RotateLeft => m_Wrapper.m_InGameControls_RotateLeft;
        public InputAction @RotateRight => m_Wrapper.m_InGameControls_RotateRight;
        public InputAction @TiltLeft => m_Wrapper.m_InGameControls_TiltLeft;
        public InputAction @TiltRight => m_Wrapper.m_InGameControls_TiltRight;
        public InputAction @MoveUp => m_Wrapper.m_InGameControls_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m_InGameControls_MoveDown;
        public InputAction @MoveLeft => m_Wrapper.m_InGameControls_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_InGameControls_MoveRight;
        public InputAction @CycleLeft => m_Wrapper.m_InGameControls_CycleLeft;
        public InputAction @CycleRight => m_Wrapper.m_InGameControls_CycleRight;
        public InputAction @CycleUp => m_Wrapper.m_InGameControls_CycleUp;
        public InputAction @CycleDown => m_Wrapper.m_InGameControls_CycleDown;
        public InputAction @Restart => m_Wrapper.m_InGameControls_Restart;
        public InputAction @ToggleCamProjection => m_Wrapper.m_InGameControls_ToggleCamProjection;
        public InputAction @FastFall => m_Wrapper.m_InGameControls_FastFall;
        public InputActionMap Get() { return m_Wrapper.m_InGameControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameControlsActions set) { return set.Get(); }
        public void SetCallbacks(IInGameControlsActions instance)
        {
            if (m_Wrapper.m_InGameControlsActionsCallbackInterface != null)
            {
                @RotateUp.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRotateUp;
                @RotateUp.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRotateUp;
                @RotateUp.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRotateUp;
                @RotateDown.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRotateDown;
                @RotateDown.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRotateDown;
                @RotateDown.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRotateDown;
                @RotateLeft.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRotateLeft;
                @RotateRight.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRotateRight;
                @RotateRight.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRotateRight;
                @RotateRight.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRotateRight;
                @TiltLeft.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnTiltLeft;
                @TiltLeft.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnTiltLeft;
                @TiltLeft.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnTiltLeft;
                @TiltRight.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnTiltRight;
                @TiltRight.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnTiltRight;
                @TiltRight.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnTiltRight;
                @MoveUp.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnMoveUp;
                @MoveUp.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnMoveUp;
                @MoveUp.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnMoveUp;
                @MoveDown.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnMoveDown;
                @MoveDown.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnMoveDown;
                @MoveDown.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnMoveDown;
                @MoveLeft.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnMoveRight;
                @CycleLeft.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnCycleLeft;
                @CycleLeft.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnCycleLeft;
                @CycleLeft.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnCycleLeft;
                @CycleRight.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnCycleRight;
                @CycleRight.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnCycleRight;
                @CycleRight.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnCycleRight;
                @CycleUp.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnCycleUp;
                @CycleUp.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnCycleUp;
                @CycleUp.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnCycleUp;
                @CycleDown.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnCycleDown;
                @CycleDown.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnCycleDown;
                @CycleDown.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnCycleDown;
                @Restart.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnRestart;
                @ToggleCamProjection.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnToggleCamProjection;
                @ToggleCamProjection.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnToggleCamProjection;
                @ToggleCamProjection.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnToggleCamProjection;
                @FastFall.started -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnFastFall;
                @FastFall.performed -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnFastFall;
                @FastFall.canceled -= m_Wrapper.m_InGameControlsActionsCallbackInterface.OnFastFall;
            }
            m_Wrapper.m_InGameControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RotateUp.started += instance.OnRotateUp;
                @RotateUp.performed += instance.OnRotateUp;
                @RotateUp.canceled += instance.OnRotateUp;
                @RotateDown.started += instance.OnRotateDown;
                @RotateDown.performed += instance.OnRotateDown;
                @RotateDown.canceled += instance.OnRotateDown;
                @RotateLeft.started += instance.OnRotateLeft;
                @RotateLeft.performed += instance.OnRotateLeft;
                @RotateLeft.canceled += instance.OnRotateLeft;
                @RotateRight.started += instance.OnRotateRight;
                @RotateRight.performed += instance.OnRotateRight;
                @RotateRight.canceled += instance.OnRotateRight;
                @TiltLeft.started += instance.OnTiltLeft;
                @TiltLeft.performed += instance.OnTiltLeft;
                @TiltLeft.canceled += instance.OnTiltLeft;
                @TiltRight.started += instance.OnTiltRight;
                @TiltRight.performed += instance.OnTiltRight;
                @TiltRight.canceled += instance.OnTiltRight;
                @MoveUp.started += instance.OnMoveUp;
                @MoveUp.performed += instance.OnMoveUp;
                @MoveUp.canceled += instance.OnMoveUp;
                @MoveDown.started += instance.OnMoveDown;
                @MoveDown.performed += instance.OnMoveDown;
                @MoveDown.canceled += instance.OnMoveDown;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @CycleLeft.started += instance.OnCycleLeft;
                @CycleLeft.performed += instance.OnCycleLeft;
                @CycleLeft.canceled += instance.OnCycleLeft;
                @CycleRight.started += instance.OnCycleRight;
                @CycleRight.performed += instance.OnCycleRight;
                @CycleRight.canceled += instance.OnCycleRight;
                @CycleUp.started += instance.OnCycleUp;
                @CycleUp.performed += instance.OnCycleUp;
                @CycleUp.canceled += instance.OnCycleUp;
                @CycleDown.started += instance.OnCycleDown;
                @CycleDown.performed += instance.OnCycleDown;
                @CycleDown.canceled += instance.OnCycleDown;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @ToggleCamProjection.started += instance.OnToggleCamProjection;
                @ToggleCamProjection.performed += instance.OnToggleCamProjection;
                @ToggleCamProjection.canceled += instance.OnToggleCamProjection;
                @FastFall.started += instance.OnFastFall;
                @FastFall.performed += instance.OnFastFall;
                @FastFall.canceled += instance.OnFastFall;
            }
        }
    }
    public InGameControlsActions @InGameControls => new InGameControlsActions(this);
    public interface IMenuControlsActions
    {
        void OnNavUp(InputAction.CallbackContext context);
        void OnNavDown(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
        void OnGoTo4x4(InputAction.CallbackContext context);
    }
    public interface IInGameControlsActions
    {
        void OnRotateUp(InputAction.CallbackContext context);
        void OnRotateDown(InputAction.CallbackContext context);
        void OnRotateLeft(InputAction.CallbackContext context);
        void OnRotateRight(InputAction.CallbackContext context);
        void OnTiltLeft(InputAction.CallbackContext context);
        void OnTiltRight(InputAction.CallbackContext context);
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnCycleLeft(InputAction.CallbackContext context);
        void OnCycleRight(InputAction.CallbackContext context);
        void OnCycleUp(InputAction.CallbackContext context);
        void OnCycleDown(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnToggleCamProjection(InputAction.CallbackContext context);
        void OnFastFall(InputAction.CallbackContext context);
    }
}
