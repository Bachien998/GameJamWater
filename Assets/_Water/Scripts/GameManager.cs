using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 10f;

    [Header("Props Spawner")]
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] private float timeBtwRock;
    [SerializeField] private float timeBtwCoin;

    private float elapsedTimeRock;
    private float elapsedTimeCoin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.forward * (scrollSpeed * Time.deltaTime);

        elapsedTimeRock += Time.deltaTime;
        elapsedTimeCoin += Time.deltaTime;

        if (elapsedTimeRock >= timeBtwRock)
        {
            elapsedTimeRock -= timeBtwRock;
        }

        if (elapsedTimeCoin >= timeBtwCoin)
        {
            elapsedTimeCoin -= timeBtwCoin;
        }
    }
}
