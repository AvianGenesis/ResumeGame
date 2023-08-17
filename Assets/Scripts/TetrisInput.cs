//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/TetrisInput.inputactions
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

public partial class @TetrisInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @TetrisInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TetrisInput"",
    ""maps"": [
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
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateDown"",
                    ""type"": ""Button"",
                    ""id"": ""eb72e852-4f78-41e0-97c5-431bb6272384"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateLeft"",
                    ""type"": ""Button"",
                    ""id"": ""ff2dc2c8-bd4f-41e2-b268-2c752dbe2460"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateRight"",
                    ""type"": ""Button"",
                    ""id"": ""4864d917-28f4-46c0-a19e-8935b98a3084"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TiltLeft"",
                    ""type"": ""Button"",
                    ""id"": ""fc99756c-d056-4199-8f31-400ccceed81f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TiltRight"",
                    ""type"": ""Button"",
                    ""id"": ""db5bcde0-c5ab-4109-bfc4-68d8889e73a3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""b21e0d72-10a7-46da-beb3-47a3d2198d74"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""ed60c474-ea8b-4aa1-acfa-477f40ff2467"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""46ce05f5-634d-49c9-9fd9-75d480a0c0db"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""4bead492-0b6f-4e02-8351-c76145b76dd2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CycleLeft"",
                    ""type"": ""Button"",
                    ""id"": ""b45ce98d-e1e5-4b6b-bbce-01c424a1acb0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CycleRight"",
                    ""type"": ""Button"",
                    ""id"": ""0b5a8974-6ebf-4151-b61c-868bf27f56f6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CycleUp"",
                    ""type"": ""Button"",
                    ""id"": ""e98781bb-1511-45d7-a756-0207fe699a5b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CycleDown"",
                    ""type"": ""Button"",
                    ""id"": ""de897d4f-88e7-4a0a-85ef-21fc38fd8fdb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""adf04510-826d-44d5-a3c9-5f64dc79d004"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleCamProjection"",
                    ""type"": ""Button"",
                    ""id"": ""1d16ccab-db8b-40e1-ac8e-51275ad6a2aa"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FastFall"",
                    ""type"": ""Button"",
                    ""id"": ""bfdb0597-feb6-4ffa-b945-f75c670b9575"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleControl"",
                    ""type"": ""Button"",
                    ""id"": ""5d359ea4-4b43-40d7-b2ac-3e36976a3812"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1,behavior=2)"",
                    ""initialStateCheck"": false
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
                    ""id"": ""9695c3b1-a255-40bc-bb62-bfbc7f10eccd"",
                    ""path"": ""<Keyboard>/w"",
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
                    ""id"": ""18d32ea6-58b1-4ee9-9ed7-8fbbfcaf6bca"",
                    ""path"": ""<Keyboard>/s"",
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
                    ""id"": ""15adec9f-fc88-4d15-b8ad-35e359897b9c"",
                    ""path"": ""<Keyboard>/a"",
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
                    ""id"": ""631143d4-ba3e-4204-b651-6adba308e136"",
                    ""path"": ""<Keyboard>/d"",
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
                    ""id"": ""bdae91ae-3a3d-48ae-98a1-3314f2d004e1"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": ""Press(pressPoint=1)"",
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
                    ""id"": ""eff6a571-b813-4578-982c-1c7135119974"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press(pressPoint=1)"",
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
                    ""id"": ""8fde0cbf-f7c2-4c0e-ad54-bf17cb98beae"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
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
                    ""id"": ""294c101a-7443-4a78-97a5-00d9b65dcaf0"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
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
                    ""id"": ""6908ea29-0abb-467f-b60f-72821cd691cc"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
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
                    ""id"": ""408e3bba-3caa-46e8-b6ea-f2a362f3e28c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
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
                    ""id"": ""9ca8c32a-b166-487f-b334-6502cecf0508"",
                    ""path"": ""<Keyboard>/r"",
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
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleCamProjection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce032f24-7bd7-49e5-9698-61e8e885b234"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
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
                },
                {
                    ""name"": """",
                    ""id"": ""1b752b22-fa3b-476d-b391-d690f26b231d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FastFall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52496178-27d8-4a96-85af-cbc2fb996614"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
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
        m_InGameControls_ToggleControl = m_InGameControls.FindAction("ToggleControl", throwIfNotFound: true);
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

    // In-Game Controls
    private readonly InputActionMap m_InGameControls;
    private List<IInGameControlsActions> m_InGameControlsActionsCallbackInterfaces = new List<IInGameControlsActions>();
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
    private readonly InputAction m_InGameControls_ToggleControl;
    public struct InGameControlsActions
    {
        private @TetrisInput m_Wrapper;
        public InGameControlsActions(@TetrisInput wrapper) { m_Wrapper = wrapper; }
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
        public InputAction @ToggleControl => m_Wrapper.m_InGameControls_ToggleControl;
        public InputActionMap Get() { return m_Wrapper.m_InGameControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameControlsActions set) { return set.Get(); }
        public void AddCallbacks(IInGameControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_InGameControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InGameControlsActionsCallbackInterfaces.Add(instance);
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
            @ToggleControl.started += instance.OnToggleControl;
            @ToggleControl.performed += instance.OnToggleControl;
            @ToggleControl.canceled += instance.OnToggleControl;
        }

        private void UnregisterCallbacks(IInGameControlsActions instance)
        {
            @RotateUp.started -= instance.OnRotateUp;
            @RotateUp.performed -= instance.OnRotateUp;
            @RotateUp.canceled -= instance.OnRotateUp;
            @RotateDown.started -= instance.OnRotateDown;
            @RotateDown.performed -= instance.OnRotateDown;
            @RotateDown.canceled -= instance.OnRotateDown;
            @RotateLeft.started -= instance.OnRotateLeft;
            @RotateLeft.performed -= instance.OnRotateLeft;
            @RotateLeft.canceled -= instance.OnRotateLeft;
            @RotateRight.started -= instance.OnRotateRight;
            @RotateRight.performed -= instance.OnRotateRight;
            @RotateRight.canceled -= instance.OnRotateRight;
            @TiltLeft.started -= instance.OnTiltLeft;
            @TiltLeft.performed -= instance.OnTiltLeft;
            @TiltLeft.canceled -= instance.OnTiltLeft;
            @TiltRight.started -= instance.OnTiltRight;
            @TiltRight.performed -= instance.OnTiltRight;
            @TiltRight.canceled -= instance.OnTiltRight;
            @MoveUp.started -= instance.OnMoveUp;
            @MoveUp.performed -= instance.OnMoveUp;
            @MoveUp.canceled -= instance.OnMoveUp;
            @MoveDown.started -= instance.OnMoveDown;
            @MoveDown.performed -= instance.OnMoveDown;
            @MoveDown.canceled -= instance.OnMoveDown;
            @MoveLeft.started -= instance.OnMoveLeft;
            @MoveLeft.performed -= instance.OnMoveLeft;
            @MoveLeft.canceled -= instance.OnMoveLeft;
            @MoveRight.started -= instance.OnMoveRight;
            @MoveRight.performed -= instance.OnMoveRight;
            @MoveRight.canceled -= instance.OnMoveRight;
            @CycleLeft.started -= instance.OnCycleLeft;
            @CycleLeft.performed -= instance.OnCycleLeft;
            @CycleLeft.canceled -= instance.OnCycleLeft;
            @CycleRight.started -= instance.OnCycleRight;
            @CycleRight.performed -= instance.OnCycleRight;
            @CycleRight.canceled -= instance.OnCycleRight;
            @CycleUp.started -= instance.OnCycleUp;
            @CycleUp.performed -= instance.OnCycleUp;
            @CycleUp.canceled -= instance.OnCycleUp;
            @CycleDown.started -= instance.OnCycleDown;
            @CycleDown.performed -= instance.OnCycleDown;
            @CycleDown.canceled -= instance.OnCycleDown;
            @Restart.started -= instance.OnRestart;
            @Restart.performed -= instance.OnRestart;
            @Restart.canceled -= instance.OnRestart;
            @ToggleCamProjection.started -= instance.OnToggleCamProjection;
            @ToggleCamProjection.performed -= instance.OnToggleCamProjection;
            @ToggleCamProjection.canceled -= instance.OnToggleCamProjection;
            @FastFall.started -= instance.OnFastFall;
            @FastFall.performed -= instance.OnFastFall;
            @FastFall.canceled -= instance.OnFastFall;
            @ToggleControl.started -= instance.OnToggleControl;
            @ToggleControl.performed -= instance.OnToggleControl;
            @ToggleControl.canceled -= instance.OnToggleControl;
        }

        public void RemoveCallbacks(IInGameControlsActions instance)
        {
            if (m_Wrapper.m_InGameControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInGameControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_InGameControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InGameControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InGameControlsActions @InGameControls => new InGameControlsActions(this);
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
        void OnToggleControl(InputAction.CallbackContext context);
    }
}
