// GENERATED AUTOMATICALLY FROM 'Assets/InputSystems/DefaultInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DefaultInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DefaultInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefaultInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""865f8b4b-5415-4d5c-88c0-f9ac9bc183cf"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""14ee2a61-9412-4267-a248-3a9d500e6bbd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Building"",
                    ""type"": ""Button"",
                    ""id"": ""6d53f79f-55ed-4056-9029-b7e64f9b399b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Deleting"",
                    ""type"": ""Button"",
                    ""id"": ""3edc4b62-662c-464f-83ed-c76d2830529b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MetaUpgrade"",
                    ""type"": ""Button"",
                    ""id"": ""a618ff32-7b03-4a87-bb4d-dda942dcb47b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""13b2cd26-ab26-456d-93da-8675fae6c888"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""772729b3-b493-4f4c-97d1-d4a2e8d76d82"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2e09540d-9679-40ca-b90c-eb5e37e22f7c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""56c0ee60-93ac-482a-bd04-08aa9f78324f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0f792de5-ffa1-42e1-bd0c-1b490ed21e0a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9bbd9186-cb88-48e2-aacf-d64989212d39"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Building"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b634de4-5bff-4da1-8cff-8e7eabe292db"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deleting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""941b88a5-44fc-4184-94cf-30e06c1f3128"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MetaUpgrade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Movement = m_PlayerControls.FindAction("Movement", throwIfNotFound: true);
        m_PlayerControls_Building = m_PlayerControls.FindAction("Building", throwIfNotFound: true);
        m_PlayerControls_Deleting = m_PlayerControls.FindAction("Deleting", throwIfNotFound: true);
        m_PlayerControls_MetaUpgrade = m_PlayerControls.FindAction("MetaUpgrade", throwIfNotFound: true);
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

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Movement;
    private readonly InputAction m_PlayerControls_Building;
    private readonly InputAction m_PlayerControls_Deleting;
    private readonly InputAction m_PlayerControls_MetaUpgrade;
    public struct PlayerControlsActions
    {
        private @DefaultInputActions m_Wrapper;
        public PlayerControlsActions(@DefaultInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerControls_Movement;
        public InputAction @Building => m_Wrapper.m_PlayerControls_Building;
        public InputAction @Deleting => m_Wrapper.m_PlayerControls_Deleting;
        public InputAction @MetaUpgrade => m_Wrapper.m_PlayerControls_MetaUpgrade;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Building.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnBuilding;
                @Building.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnBuilding;
                @Building.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnBuilding;
                @Deleting.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDeleting;
                @Deleting.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDeleting;
                @Deleting.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDeleting;
                @MetaUpgrade.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMetaUpgrade;
                @MetaUpgrade.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMetaUpgrade;
                @MetaUpgrade.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMetaUpgrade;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Building.started += instance.OnBuilding;
                @Building.performed += instance.OnBuilding;
                @Building.canceled += instance.OnBuilding;
                @Deleting.started += instance.OnDeleting;
                @Deleting.performed += instance.OnDeleting;
                @Deleting.canceled += instance.OnDeleting;
                @MetaUpgrade.started += instance.OnMetaUpgrade;
                @MetaUpgrade.performed += instance.OnMetaUpgrade;
                @MetaUpgrade.canceled += instance.OnMetaUpgrade;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
    public interface IPlayerControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnBuilding(InputAction.CallbackContext context);
        void OnDeleting(InputAction.CallbackContext context);
        void OnMetaUpgrade(InputAction.CallbackContext context);
    }
}
