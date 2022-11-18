using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    private static Pooling _Instant;

    public static Pooling Instant => _Instant;
    List<GameObject> enemy_pool = new List<GameObject>();
    [SerializeField] GameObject enemyPrefab;
    List<GameObject> bullet_pool = new List<GameObject>();
    [SerializeField] GameObject bulletPrefab;
    private void Awake() {
        _Instant = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject getBullet(){
        foreach (GameObject b in bullet_pool){
            if(b.activeSelf)
                continue;
            return b;
        }
        
        GameObject b2 =  Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        bullet_pool.Add(b2);
        
        return b2;
    }
    public GameObject getEnemy()
    {
        foreach (GameObject e in enemy_pool)
        {
            if (e.activeSelf)
                continue;

            return e;
        }

        GameObject e2 = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
        enemy_pool.Add(e2);

        e2.SetActive(false);

        return e2;
    }
}
