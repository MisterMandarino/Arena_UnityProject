using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score;
    public Text scoreText;

    [SerializeField]
    private float spawnRadius = 7f, time = 1.5f;

    public GameObject[] enemiesPrefab;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        scoreText.text = score.ToString();
        if(time > 2f)
            time -= 0.0001f;
    }

    IEnumerator SpawnEnemy()
    {
        Vector2 spawnPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemiesPrefab[Random.Range(0,enemiesPrefab.Length)],spawnPos,Quaternion.identity);
        WaitForSeconds waitTime = new WaitForSeconds(time);
        yield return waitTime;

        StartCoroutine(SpawnEnemy());
    }

}
