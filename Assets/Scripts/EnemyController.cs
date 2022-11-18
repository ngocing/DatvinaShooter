using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject player;
    // Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        // anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null){
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet")){
            // anim.SetTrigger("Dead");
            this.gameObject.SetActive(false);
        }
    }
}
