using UnityEngine;

namespace VGS
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float speed = 1f;

        private void Start()
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }

        private void LateUpdate()
        {
            transform.position += Vector3.up * (speed * Time.deltaTime);
        }
    }
}
