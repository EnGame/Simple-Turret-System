using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [Header("Enemy")]
    public List<Enemy> enemyList = new List<Enemy>();
    [SerializeField] private Transform[] spawners = new Transform[0];
    [SerializeField] private GameObject enemyPrefab;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //SPAWNER
    private void FixedUpdate()
    {
        if(enemyList.Count < 8)
        {
            var spawner = spawners[Random.Range(0, spawners.Length)];
            var enemyGo = Instantiate(enemyPrefab, spawner.transform.position, Quaternion.identity);
            enemyList.Add(enemyGo.GetComponent<Enemy>());
        }
    }
}
