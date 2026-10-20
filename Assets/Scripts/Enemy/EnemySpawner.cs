using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float respawnDelay = 2f;

    private void Start()
    {
        SpawnEnemyimmediately();

    }

    private void SpawnEnemyimmediately()
    {
        GameObject enemy = Instantiate(
        enemyPrefab, transform.position, Quaternion.identity
        );

        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        // khai bao trung nen co the xoa
        
        // if (enemy.TryGetComponent<EnemyHealth>(out var enemyHealth))
        // {
        //     enemyHealth.SetSpawner(this);
        // }
    }

    private IEnumerator SpawnEnemyWithDelay()
    {
        yield return new WaitForSeconds(respawnDelay);

        SpawnEnemyimmediately();
    }
    public void SpawnEnemy()
    {
        StartCoroutine(SpawnEnemyWithDelay());
    }
}