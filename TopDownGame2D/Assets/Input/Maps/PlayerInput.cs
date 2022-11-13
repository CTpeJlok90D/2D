//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Input/Maps/PlayerInput.inputactions
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

namespace Input
{
    public partial class @PlayerInput : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""WorldMovement"",
            ""id"": ""fc12c675-1983-4c2a-929f-611dfa0c3cf1"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""519765a7-b0c2-4d40-8b90-7f597282fa96"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""b1cf5339-e4bc-456c-b280-73934be6601e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""45ccd9ad-4d2e-4d83-85a3-e7c92879ecc4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""fd65a301-b2f9-4ca2-8635-e083ef5cd911"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""8ff4b3ac-9424-4b9c-b56b-72b62185895a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DropWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""765ae9ce-3941-4b49-8cc7-cb0ff4fffa8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""61f11b7b-1b98-442b-af87-0e765d62c15a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector KeyBoard"",
                    ""id"": ""e26b7029-e5a6-409f-b008-3b74a8b15e2f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cab9d8e4-e428-45ae-9d5b-ca3777ed02cf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a82b7df4-258c-4c91-bc1b-1fd7eac06d75"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c6e87c9d-8635-40df-a03c-d05077381946"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7604a68b-1b58-4c1c-ab6a-fab27fe9051d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector Gamepad"",
                    ""id"": ""267305ed-1fd0-452d-b9e0-aa9153b5ba9b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b29fce1e-0c49-41ef-a088-7fa3da3e8177"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5cc1d8f5-a02f-40e6-86c6-2c2b740f2be5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ac993f3a-2b0d-4ba0-9905-1f987fb079a4"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""76bb9941-cd4b-43b1-88f5-6942e7ff0fff"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1802c7a8-bc8a-412f-8c9b-3101d5cfc5c7"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1aa57832-4f5d-47fb-a490-05138de3c8e8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77a13f1d-210a-4e56-8086-85c2e016a1e4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""189031ed-cee3-4a01-ace6-c08cce2b89ac"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a804eee2-2056-4c02-8301-0b8f564034a3"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e6ac765-97ff-4fc1-8855-015212de4547"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dialog"",
            ""id"": ""2ccbf557-50b5-41e5-b30a-6cc35054031c"",
            ""actions"": [
                {
                    ""name"": ""NextStory"",
                    ""type"": ""Button"",
                    ""id"": ""f2509254-cb69-494f-aa5c-9402a09ec627"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""68a7257a-631c-49da-addb-77213e7f2c1a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextStory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // WorldMovement
            m_WorldMovement = asset.FindActionMap("WorldMovement", throwIfNotFound: true);
            m_WorldMovement_Move = m_WorldMovement.FindAction("Move", throwIfNotFound: true);
            m_WorldMovement_Look = m_WorldMovement.FindAction("Look", throwIfNotFound: true);
            m_WorldMovement_Dash = m_WorldMovement.FindAction("Dash", throwIfNotFound: true);
            m_WorldMovement_Shoot = m_WorldMovement.FindAction("Shoot", throwIfNotFound: true);
            m_WorldMovement_Interact = m_WorldMovement.FindAction("Interact", throwIfNotFound: true);
            m_WorldMovement_DropWeapon = m_WorldMovement.FindAction("DropWeapon", throwIfNotFound: true);
            m_WorldMovement_Reload = m_WorldMovement.FindAction("Reload", throwIfNotFound: true);
            // Dialog
            m_Dialog = asset.FindActionMap("Dialog", throwIfNotFound: true);
            m_Dialog_NextStory = m_Dialog.FindAction("NextStory", throwIfNotFound: true);
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

        // WorldMovement
        private readonly InputActionMap m_WorldMovement;
        private IWorldMovementActions m_WorldMovementActionsCallbackInterface;
        private readonly InputAction m_WorldMovement_Move;
        private readonly InputAction m_WorldMovement_Look;
        private readonly InputAction m_WorldMovement_Dash;
        private readonly InputAction m_WorldMovement_Shoot;
        private readonly InputAction m_WorldMovement_Interact;
        private readonly InputAction m_WorldMovement_DropWeapon;
        private readonly InputAction m_WorldMovement_Reload;
        public struct WorldMovementActions
        {
            private @PlayerInput m_Wrapper;
            public WorldMovementActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_WorldMovement_Move;
            public InputAction @Look => m_Wrapper.m_WorldMovement_Look;
            public InputAction @Dash => m_Wrapper.m_WorldMovement_Dash;
            public InputAction @Shoot => m_Wrapper.m_WorldMovement_Shoot;
            public InputAction @Interact => m_Wrapper.m_WorldMovement_Interact;
            public InputAction @DropWeapon => m_Wrapper.m_WorldMovement_DropWeapon;
            public InputAction @Reload => m_Wrapper.m_WorldMovement_Reload;
            public InputActionMap Get() { return m_Wrapper.m_WorldMovement; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(WorldMovementActions set) { return set.Get(); }
            public void SetCallbacks(IWorldMovementActions instance)
            {
                if (m_Wrapper.m_WorldMovementActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnMove;
                    @Look.started -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnLook;
                    @Look.performed -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnLook;
                    @Look.canceled -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnLook;
                    @Dash.started -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnDash;
                    @Shoot.started -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnShoot;
                    @Shoot.performed -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnShoot;
                    @Shoot.canceled -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnShoot;
                    @Interact.started -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnInteract;
                    @DropWeapon.started -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnDropWeapon;
                    @DropWeapon.performed -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnDropWeapon;
                    @DropWeapon.canceled -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnDropWeapon;
                    @Reload.started -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnReload;
                    @Reload.performed -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnReload;
                    @Reload.canceled -= m_Wrapper.m_WorldMovementActionsCallbackInterface.OnReload;
                }
                m_Wrapper.m_WorldMovementActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Look.started += instance.OnLook;
                    @Look.performed += instance.OnLook;
                    @Look.canceled += instance.OnLook;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                    @Shoot.started += instance.OnShoot;
                    @Shoot.performed += instance.OnShoot;
                    @Shoot.canceled += instance.OnShoot;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @DropWeapon.started += instance.OnDropWeapon;
                    @DropWeapon.performed += instance.OnDropWeapon;
                    @DropWeapon.canceled += instance.OnDropWeapon;
                    @Reload.started += instance.OnReload;
                    @Reload.performed += instance.OnReload;
                    @Reload.canceled += instance.OnReload;
                }
            }
        }
        public WorldMovementActions @WorldMovement => new WorldMovementActions(this);

        // Dialog
        private readonly InputActionMap m_Dialog;
        private IDialogActions m_DialogActionsCallbackInterface;
        private readonly InputAction m_Dialog_NextStory;
        public struct DialogActions
        {
            private @PlayerInput m_Wrapper;
            public DialogActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @NextStory => m_Wrapper.m_Dialog_NextStory;
            public InputActionMap Get() { return m_Wrapper.m_Dialog; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DialogActions set) { return set.Get(); }
            public void SetCallbacks(IDialogActions instance)
            {
                if (m_Wrapper.m_DialogActionsCallbackInterface != null)
                {
                    @NextStory.started -= m_Wrapper.m_DialogActionsCallbackInterface.OnNextStory;
                    @NextStory.performed -= m_Wrapper.m_DialogActionsCallbackInterface.OnNextStory;
                    @NextStory.canceled -= m_Wrapper.m_DialogActionsCallbackInterface.OnNextStory;
                }
                m_Wrapper.m_DialogActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @NextStory.started += instance.OnNextStory;
                    @NextStory.performed += instance.OnNextStory;
                    @NextStory.canceled += instance.OnNextStory;
                }
            }
        }
        public DialogActions @Dialog => new DialogActions(this);
        public interface IWorldMovementActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
            void OnShoot(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnDropWeapon(InputAction.CallbackContext context);
            void OnReload(InputAction.CallbackContext context);
        }
        public interface IDialogActions
        {
            void OnNextStory(InputAction.CallbackContext context);
        }
    }
}
