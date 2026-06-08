using TMPro;
using UnityEngine;

namespace com.IsartDigital.Water
{
    public class HUDManager : UIManager
    {
        private GameManager _gameManager;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private TextMeshProUGUI loseScore;

        [SerializeField] private GameObject loseScreen;

        private void Start()
        {
            _gameManager = GameManager.Instance;
            _gameManager.OnUpdateScore += UpdateScore;
            _gameManager.OnEndGame += OnEndGame;
        }

        private void OnEndGame()
        {
            player.StopEffects();

            loseScreen.gameObject.SetActive(true);
            loseScore.text += _score.text;
        }

        private void UpdateScore(int pScoreValue)
        {
            _score.text = pScoreValue.ToString();
        }
    }
}
