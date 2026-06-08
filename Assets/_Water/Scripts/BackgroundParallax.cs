using UnityEngine;

namespace com.IsartDigital.Water
{
    public class BackgroundParallax : MonoBehaviour
    {
        [SerializeField] private float maxDistance;

        private int backgroundCount;

        private void Start()
        {
            backgroundCount = GameManager.Instance.BackgroundCount;
        }

        private void Update()
        {
            if (transform.position.z <= maxDistance)
            {
                transform.position = new(transform.position.x, transform.position.y, 30 * backgroundCount);
                //transform.rotation = Quaternion.AngleAxis(90f * Random.Range(0, 4), Vector3.up);
            }
        }
    }
}
