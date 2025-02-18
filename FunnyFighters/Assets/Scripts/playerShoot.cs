using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{

    //Status
    private bool shootable = true;
    private bool reloaded = true;
    

    [Header("Characteristics")]
    public float reloadTime;

    [Header("Assignables")]
    public Camera cam;
    [SerializeField] SpriteRenderer spriteRenderer;

    [Header("Projectiles")]
    public GameObject projectile;
    

    //Mouse vars
    private Vector3 rotation;
    private Vector3 mousePos;
    private float rotz;

    
    

    public void Shoot()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        rotation = mousePos - transform.position;
        rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //Shooting
        if (shootable && Input.GetMouseButton(0) && reloaded)
        {

            reloaded = false;
            Invoke(nameof(Reload), reloadTime);


            Instantiate(projectile, transform.position, Quaternion.Euler(0f, 0f, rotz));
        }
    }

    void Reload()
    {
        reloaded = true;
    }
    
   

    
}
