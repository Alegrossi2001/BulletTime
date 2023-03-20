using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool slowDown;
    private bool isMoving;
    private float horizontalInput;
    private float verticalInput;
    private SceneSelector scene;
    private float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        scene = GameObject.Find("Canvas").GetComponent<SceneSelector>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        if (scene.isGameOver == false)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
            transform.Translate(direction * Time.deltaTime * speed);
            if (horizontalInput != 0 || verticalInput != 0)
            {
                slowDown = false;
                isMoving = true;
            }
            else
            {
                //since we are standing still, time needs to slow down and simulate slow motion.
                slowDown = true;
                isMoving = false;

            }
        }
    }
}
