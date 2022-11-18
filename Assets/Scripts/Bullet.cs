using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed, timeDestroy;
    Rigidbody2D rb;
    Coroutine autoDestroyCor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnEnable(){
        autoDestroyCor =  StartCoroutine(autoDestroy());
    }
    void OnDisable(){
        StopCoroutine(autoDestroyCor);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    IEnumerator autoDestroy(){
        yield return new WaitForSeconds(timeDestroy);
        this.gameObject.SetActive(false);
    }
}
