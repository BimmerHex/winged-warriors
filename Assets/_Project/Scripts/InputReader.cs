using UnityEngine;
using UnityEngine.InputSystem;

namespace VGS
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour
    {
        // NOTE: Makesure to set the Player Input to C# events
        private PlayerInput playerInput;
        private InputAction moveAction;

        public Vector2 Move => moveAction.ReadValue<Vector2>();

        private void Start()
        {
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions["Move"];
        }
    }
}
