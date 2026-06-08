using UnityEngine;

namespace com.IsartDigital.Water
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private RectTransform _visual;
        [SerializeField] private float _added;
        [SerializeField] private float _duration;
        private float _elapsedtime;
        private GameManager _gameManager;
        private bool _isUpdating;
        private bool _oneWay;

        private Vector3 _baseSize;

        private void Start()
        {
            _gameManager.OnUpdateScore += UpdateScore;
        }


        void Update()
        {
            if (_isUpdating && _elapsedtime < _duration && _oneWay == true)
            {
                _elapsedtime += Time.deltaTime;
                _visual.transform.localScale = Vector3.Lerp(_baseSize, _baseSize * _added, _elapsedtime);
                if (_elapsedtime >= _duration)
                {
                    _oneWay = false;
                }
            }
            else if (_isUpdating && _elapsedtime < _duration && _oneWay == false)
            {
                _elapsedtime += Time.deltaTime;
                _visual.transform.localScale = Vector3.Lerp(_baseSize, _baseSize * _added, _elapsedtime);

            }
            else if (_isUpdating && _elapsedtime < 0)
            {
                _isUpdating = false;

            }

        }

        private void UpdateScore(int pIndex)
        {
            if (_isUpdating) return;
            _isUpdating = true;
            _oneWay = true;
            _elapsedtime = 0;
            _baseSize = _visual.transform.localScale;
        }
    }
}
