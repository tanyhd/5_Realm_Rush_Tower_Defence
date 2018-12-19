using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] int playerScore = 0;
    [SerializeField] Text playerScoreText;
    [SerializeField] AudioClip spawnEnemySFX;

    // Use this for initialization
    void Start () {
        StartCoroutine(RepeatedlySpawnEnemies());
        playerScoreText.text = playerScore.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)    // forever
        {
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnEnemySFX);
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
    }
}
