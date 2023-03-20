using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform enemy;
    public bool canSeePlayer;
    private bool resetCooldown;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private Transform firePoint;
    private float shootingspeed;
    private MovementController checkForSlowMotion;
    private SceneSelector scene;
    private float reloadtime;

    [SerializeField] private bool hasLMG;
    // Start is called before the first frame update
    void Start()
    {
        
        checkForSlowMotion = GameObject.Find("Player").GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        //only move if distance with player is less than value
        //activate enemy rotation and shoot
        if(Vector2.Distance(player.position, enemy.position) < 10)
        {
            //rotate enemy
            canSeePlayer = true;
            Vector2 distanceVector = (Vector2)player.position - (Vector2)enemy.position;
            float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else if(Vector2.Distance(player.position, enemy.position) > 10)
        {
            canSeePlayer = false;
        }
        
        if(canSeePlayer == true && resetCooldown == false)
        {
            resetCooldown = true;
            StartCoroutine("CreateEnemyBullet");
            
        }
        //reduce this value if there's a wall between player and enemy (shoot raycast)
    }

    private IEnumerator CreateEnemyBullet()
    {
        if(checkForSlowMotion.slowDown == true)
        {
            reloadtime = 6.0f;
            if(hasLMG == true)
            {
                reloadtime = 2.0f;
            }
        }
        else if(checkForSlowMotion.slowDown == false)
        {
            reloadtime = 3.0f;
            if(hasLMG == true)
            {
                reloadtime = 0.5f; 
            }
        }
        Instantiate(enemyBullet, firePoint.position, transform.rotation);
        yield return new WaitForSeconds(reloadtime);
        resetCooldown = false;
    }
}
