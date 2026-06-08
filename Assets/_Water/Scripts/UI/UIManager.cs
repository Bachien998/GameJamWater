using System.Collections;
using com.IsartDigital.Water._Water.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.IsartDigital.Water
{
    public class UIManager : MonoBehaviour
    {
        #region instance
        public static UIManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
        }
        #endregion

        [SerializeField] private float timeToSpawn;
        [SerializeField] protected Player player;

        public void StartGame(GameObject objectToHide)
        {
            objectToHide.gameObject.SetActive(false);
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            float elapsedTime = 0;
            float startYPos = player.transform.position.y;

            while (elapsedTime <= timeToSpawn)
            {
                player.transform.position = new(player.transform.position.x, Mathf.Lerp(startYPos, 0.8f, elapsedTime / timeToSpawn), player.transform.position.z);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            player.transform.position = new(player.transform.position.x, 0.8f, player.transform.position.z);

            GameManager.IsPlaying = true;
            player.SpawnEffects();
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
