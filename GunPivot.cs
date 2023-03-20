using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPivot : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Transform gunHolder;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject muzzleFlash;
    private float shakeDuration = 0.15f;
    private float shakeMagnitude = 0.2f;
    private CameraShake camShake;
    private AudioSource myPlayer;
    private SceneSelector scene;

    private float canfire = -1f;
    private float fireRate = 0.5f;

    private void Start()
    {
        myPlayer = GetComponent<AudioSource>();
        camShake = GameObject.Find("CameraShake").GetComponent<CameraShake>();
        if(camShake == null)
        {
            Debug.LogError("Camera shake is null");
        }
        scene = GameObject.Find("Canvas").GetComponent<SceneSelector>();
    }
    private void Update()
    {
        if(scene.isGameOver == false)
        {
            RotateGun();
            if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > canfire)
            {
                PlayerInput();
            }
        }
        
    }
    void RotateGun()
    {
        Vector2 distanceVector = (Vector2)camera.ScreenToWorldPoint(Input.mousePosition) - (Vector2)gunHolder.position;
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void PlayerInput()
    {
        //shoot
        canfire = Time.time + fireRate;
        myPlayer.Play();
        StartCoroutine(MuzzleFlash());
        Instantiate(bullet, firePoint.position, transform.rotation);
        StartCoroutine(camShake.Shake(shakeDuration, shakeMagnitude));      
    }
    IEnumerator MuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.12f);
        muzzleFlash.SetActive(false);
    }
}
