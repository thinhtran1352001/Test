using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string EnemyType = "Goblin";
    public int damage = 25;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Enemy: " + EnemyType);
        Debug.Log("Damage: " + damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
