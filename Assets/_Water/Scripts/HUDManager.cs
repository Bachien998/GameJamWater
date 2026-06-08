using TMPro;
using UnityEngine;

namespace com.IsartDigital.Water
{
    public class HUDManager : UIManager
    {
        private GameManager _gameManager;
        [SerializeField] private TextMeshProUGUI _score;

        private void Start()
        {
            _gameManager = GameManager.Instance;
            _gameManager.OnUpdateScore += UpdateScore;
        }

        private void UpdateScore(int pScoreValue)
        {
            _score.text = pScoreValue.ToString();
        }
    }
}
