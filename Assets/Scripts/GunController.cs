using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] GameObject bullet;
    public Transform firePos;
    public float angle;
    [SerializeField] float atkSpeed = 2;
    [SerializeField] float fireCd = 0;
    AudioSource fire;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        fire = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
        fireCd -= Time.deltaTime;
    }

    void Aim(){
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,angle);

        // if(mousePos.x < screenPoint.x)
        //     sprite.flipY = true;
        // else
        //     sprite.flipY = false;

        sprite.flipY = (mousePos.x < screenPoint.x);
    }

    void Shoot(){
        if(fireCd > 0)
            return;
        if(Input.GetMouseButton(0)){
            // Instantiate(bullet, firePos.position, firePos.rotation);
            GameObject b = Pooling.Instant.getBullet();
            b.transform.position = firePos.position;
            b.transform.rotation = Quaternion.Euler(0,0,angle);
            b.SetActive(true);
            fireCd = atkSpeed;
            fire.Play();
        }
    }
}
