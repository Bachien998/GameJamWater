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

        public void Load(int pIndex)
        {
            SceneManager.LoadScene(pIndex);
        }
    }
}
