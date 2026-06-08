using UnityEngine;

namespace com.IsartDigital.Water
{
    public class Props : MonoBehaviour
    {
        [SerializeField] private bool isCoin;

        [SerializeField] private float maxDistance;

        [SerializeField] 
        private GameObject particules;

        private void Update()
        {
            if (transform.position.z <= maxDistance)
                Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            if (isCoin)
            {
                GameObject vfx = Instantiate(particules, transform.parent);
                vfx.transform.position = transform.position - new Vector3(0, 0, -3);
                vfx.GetComponent<ParticleSystem>().Play();
                Destroy(gameObject);
                //TODO Add to score
                GameManager.Instance.UpdateScore();
            }
            else
            {
                Destroy(other.gameObject);
                //TODO Kill player
            }
        }
    }
}
