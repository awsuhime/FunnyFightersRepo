using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : MonoBehaviour
{
    //Status
    private bool shootable = true;
    private bool reloaded = true;


    [Header("Characteristics")]
    public float reloadTime;
    public float angleOffset = 15f;


    [Header("Assignables")]
    [SerializeField] SpriteRenderer spriteRenderer;

    [Header("Projectiles")]
    public GameObject projectile;


    //Mouse vars
    private Vector3 rotation;
    private Vector3 mousePos;
    private float rotz;




    public void Shoot()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotation = mousePos - transform.position;
        rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //Shooting
        if (shootable && Input.GetMouseButton(0) && reloaded)
        {

            reloaded = false;
            Invoke(nameof(Reload), reloadTime);


            Instantiate(projectile, transform.position, Quaternion.Euler(0f, 0f, rotz));
            Instantiate(projectile, transform.position, Quaternion.Euler(0f, 0f, rotz + angleOffset));
            Instantiate(projectile, transform.position, Quaternion.Euler(0f, 0f, rotz - angleOffset));


        }
    }

    void Reload()
    {
        reloaded = true;
    }
}
