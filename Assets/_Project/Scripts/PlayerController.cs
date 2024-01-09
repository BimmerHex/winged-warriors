using UnityEngine;

namespace VGS
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float smoothness = .1f;
        [SerializeField] private float leanAngle = 15f;
        [SerializeField] private float leanSpeed = 5f;

        [SerializeField] private GameObject model;

        [Header("Camera Bounds")]
        [SerializeField] private Transform cameraFollow;
        [SerializeField] private float minX = -8f;
        [SerializeField] private float maxX = 8f;
        [SerializeField] private float minY = -4f;
        [SerializeField] private float maxY = 4f;

        private InputReader inputReader;

        private Vector3 currentVelocity;
        private Vector3 targetPos;

        private void Start()
        {
            inputReader = GetComponent<InputReader>();
        }

        private void Update()
        {
            targetPos += new Vector3(inputReader.Move.x, inputReader.Move.y, 0f) * (speed * Time.deltaTime);

            // Calculate the min and max X and Y positions for the player based on the camera view
            float minPlayerX = cameraFollow.position.x + minX;
            float maxPlayerX = cameraFollow.position.x + maxX;
            float minPlayerY = cameraFollow.position.y + minY;
            float maxPlayerY = cameraFollow.position.y + maxY;

            // Clamp the player's position to the camera view
            targetPos.x = Mathf.Clamp(targetPos.x, minPlayerX, maxPlayerX);
            targetPos.y = Mathf.Clamp(targetPos.y, minPlayerY, maxPlayerY);

            // Lerp the player's position to the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, smoothness);

            // Calculate the rotation effect
            float targetRotationAngle = -inputReader.Move.x * leanAngle;

            float currentYRotation = transform.localEulerAngles.y;
            float newYRotation = Mathf.LerpAngle(currentYRotation, targetRotationAngle, leanSpeed * Time.deltaTime);

            // Apply the rotation effect
            transform.localEulerAngles = new Vector3(0f, newYRotation, 0f);
        }
    }
}
