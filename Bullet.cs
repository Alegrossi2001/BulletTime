using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private MovementController checkForSlowMotion;
    private float bulletSpeed;
    private SceneSelector scene;
    //private float bulletSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        checkForSlowMotion = GameObject.Find("Player").GetComponent<MovementController>();
        rb = GetComponent<Rigidbody2D>();
        scene = GameObject.Find("Canvas").GetComponent<SceneSelector>();

    }

    void Start()
    {

    }

    private void Update()
    {
        if (checkForSlowMotion.slowDown == true)
        {
            bulletSpeed = 3.0f;
        }
        else if (checkForSlowMotion.slowDown == false)
        {
            bulletSpeed = 40.0f;
        }
        rb.MovePosition(transform.position + transform.right * bulletSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            //other.gameObject.SetActive(false);
            scene.IsGameOver();
        }

        else if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Environment")
        {
            Destroy(gameObject);
        }

    }
}
