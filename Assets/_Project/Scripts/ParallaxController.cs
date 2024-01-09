using UnityEngine;

namespace VGS
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] private Transform[] backgrounds;
        [SerializeField] private float smoothing = 10f;
        [SerializeField] private float multiplier = 15f;

        private Transform cam;
        private Vector3 previousCamPos;

        private void Awake() => cam = Camera.main.transform;

        private void Start() => previousCamPos = cam.position;

        private void Update()
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                float parallax = (previousCamPos.y - cam.position.y) * (i * multiplier);
                float targetY = backgrounds[i].position.y + parallax;

                Vector3 targetPosition = new Vector3(backgrounds[i].position.x, targetY, backgrounds[i].position.z);

                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPosition, smoothing * Time.deltaTime);
            }

            previousCamPos = cam.position;
        }
    }
}
