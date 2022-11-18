using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _Instant;

    public static GameManager Instant => _Instant;
    [SerializeField] GameObject _enemyPrefab;
    Vector2 border;
    float timeCd;
    private void Awake() {
        _Instant = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_spawnEnemy());
        border = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        if(timeCd <= 0){
            // spawnEnemy();
            timeCd = Random.Range(2,3f);
        }
    }

    // void spawnEnemy(){
    //     Vector2 pos = new Vector2(
    //         Random.Range(-border.x, border.x),
    //         Random.Range(-border.y, border.y)
    //     );

    //     GameObject enemy = Pooling.Instant.getEnemy();
    //     enemy.transform.position = pos;
    //     enemy.SetActive(true);
    // }

    IEnumerator _spawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f,3f));
            Vector2 pos = new Vector2(
              Random.Range(-border.x, border.x),
              Random.Range(-border.y, border.y)
              );
            GameObject enemy = Pooling.Instant.getEnemy();
            enemy.transform.position = pos;
            enemy.SetActive(true);
        }
    }
}
