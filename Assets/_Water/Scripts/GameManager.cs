using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private float scrollSpeed = 10f;

    [Header("Props Spawner")]
    [SerializeField] private Transform propsContainer;
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] private float timeBtwRock;
    [SerializeField] private float timeBtwCoin;

    private float elapsedTimeRock = .5f;
    private float elapsedTimeCoin;

    [NonSerialized] public int Score;

    private int PropsMultiplier => Mathf.Clamp(Score / 20, 1, 5);

    private void Awake() => Instance = this;

    private void Start()
    {
        for (int i = 0; i <= 5; i++)
        {
            Instantiate(rockPrefab, new(Random.Range(-4f, 4f), 1, 50 + i * 8f), transform.rotation, propsContainer);
            Instantiate(coinPrefab, new(Random.Range(-4f, 4f), 1, 50 + i * 9f), transform.rotation, propsContainer);
        }
    }

    private void Update()
    {
        transform.position -= Vector3.forward * (scrollSpeed * Time.deltaTime);

        elapsedTimeRock += Time.deltaTime;
        elapsedTimeCoin += Time.deltaTime;

        if (elapsedTimeRock >= timeBtwRock)
        {
            elapsedTimeRock -= timeBtwRock;

            //TODO Spawn rocks
            for (int i = 0; i < PropsMultiplier; i++)
                Instantiate(rockPrefab, new(Random.Range(-4f, 4f), 1, 100), transform.rotation, propsContainer);
        }

        if (elapsedTimeCoin >= timeBtwCoin)
        {
            elapsedTimeCoin -= timeBtwCoin;

            //TODO Spawn coins
            for (int i = 0; i < PropsMultiplier; i++)
                Instantiate(coinPrefab, new(Random.Range(-4f, 4f), 1, 100), transform.rotation, propsContainer);
        }
    }
}
