using System;
using UnityEngine;

namespace com.IsartDigital.Water
{
    public class ParticuleScript : MonoBehaviour
    {
        [SerializeField] 
        private float LifeTime = 5;

        private float Compt = 0;

        [SerializeField] 
        private AudioClip sfx;

        [SerializeField] 
        private AudioSource SourceSfx;

        private void Start()
        {
            SourceSfx.resource = sfx;
            SourceSfx.Play();
        }

        private void Update()
        {
            Compt += Time.deltaTime;
            if (Compt > LifeTime)
                Destroy(gameObject);
        }
    }
}
