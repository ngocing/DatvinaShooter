using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    Vector2 moveInput;
    Animator anim;
    [SerializeField] Text scoreText;
    [SerializeField] Text hiscoreText;
    float score = 0;
    float hiscore;
    bool isAlive = true;
    Rigidbody2D rb;
    public GameObject gun;
    AudioSource deadth;
    Collider2D coli;
    [SerializeField] AudioClip deadthfx;
    public JsMovement jsMovement;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        deadth = GetComponent<AudioSource>();
        coli = GetComponent<Collider2D>();
        hiscore = PlayerPrefs.GetFloat("hiscore");
    }
    private void FixedUpdate() {
        if(jsMovement.joystickVec.y != 0){
            rb.velocity = new Vector2(jsMovement.joystickVec.x * speed, jsMovement.joystickVec.y * speed);
        }else{
            rb.velocity = Vector2.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // moveInput.x = Input.GetAxisRaw("Horizontal");
        // moveInput.y = Input.GetAxisRaw("Vertical");

        // transform.Translate(moveInput * Time.deltaTime * speed);

        anim.SetBool("isMoving", (Mathf.Abs(rb.velocity.x) > 0 || Mathf.Abs(rb.velocity.y) > 0));

        if(isAlive){
            score  += Time.deltaTime;
            scoreText.text = "Score: " + score.ToString();
            hiscoreText.text = "HIScore: " + hiscore.ToString();
        }
        if(score > hiscore){
            PlayerPrefs.SetFloat("hiscore", score);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            // Destroy(gameObject);
            Die();
            isAlive = false;
        }
    }
    private void Die(){
        rb.bodyType = RigidbodyType2D.Static;
        coli.isTrigger = true;
        anim.SetTrigger("deadth");
        deadth.PlayOneShot(deadthfx);
        gun.SetActive(false);
    }
    private void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
