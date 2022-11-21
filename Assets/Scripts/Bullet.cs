using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed, timeDestroy;
    Rigidbody2D rb;
    Coroutine autoDestroyCor;
    [SerializeField] ParticleSystem effect;
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
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Wall")){
            gameObject.SetActive(false);
            Instantiate(effect, transform.position, transform.rotation);
        }
        if(other.gameObject.CompareTag("Enemy")){
            gameObject.SetActive(false);
            Instantiate(effect, transform.position, transform.rotation);
        }
    }
    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.gameObject.CompareTag("Enemy")){
    //         gameObject.SetActive(false);
    //     }
    // }
}
