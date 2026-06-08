using System;
using UnityEngine;

namespace com.IsartDigital.Water
{
    public class Props : MonoBehaviour
    {
        [SerializeField] private bool isCoin;

        [SerializeField] private float maxDistance;

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
