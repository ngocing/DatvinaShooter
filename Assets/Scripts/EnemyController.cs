using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject player;
    // Animator anim;
    Rigidbody2D rb;
    Collider2D coli;
    float time = 2;
    // Start is called before the first frame update
    void Start()
    {
        // anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        coli = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null){
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        Vector3 tmp = this.transform.localScale;
        if(rb.transform.position.x > 0){
            tmp.x = 1;
        }else if(rb.transform.position.x < 0){
            tmp.x = -1;
        }
        this.transform.localScale = tmp;
        time -= Time.deltaTime;
        if(time <= 0){
            coli.isTrigger = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet")){
            // anim.SetTrigger("Dead");
            this.gameObject.SetActive(false);
        }
    }
}
