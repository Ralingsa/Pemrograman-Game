using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class weaponCtrl : MonoBehaviour
{
    public static int ammo, ammoMag;
    int add;
    bool trigger = true;
    public float demage = 3f, range = 100f, 
                force = 30f, fireRate = 10f;
    private float timeFire = 0f;
    public int health = 100, ammoStock = 30;
    public Slider healthBar;

    public AudioSource ak47Shot;
    public AudioSource shotgunShot;
    public AudioSource weaponReaload;

    [SerializeField] Camera fpsCamera, tpsCamera;

    public void shoot()
    {
        if (ammo != 0)
        {
            ak47Shot.Play();
            shotgunShot.Play();
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if(Physics.Raycast(ray,out hit, range))
            {
                if (hit.transform.CompareTag("enemy"))
                {
                    hit.transform.gameObject.SendMessage("take demage", demage);
                }
                if (hit.rigidbody != null) hit.rigidbody.AddForce(-hit.normal * force);
            }
            ammo -= 1;
        }
    }

    public void restart()
    {
        health = 100;
        healthBar.value = health;
        ammoMag = 90;
        ammo = ammoStock;
    }
    // Start is called before the first frame update
    void Start()
    {
        ammo = ammoStock;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= timeFire && trigger == true)
        {
            timeFire = Time.time + 1f / fireRate;
            shoot();
        }
        if (Input.GetButton("Reload") && ammo < ammoStock)
        {
            weaponReaload.Play();
            if (ammoMag != 0)
            {
                trigger = false;
                StartCoroutine(waitReload());
            }
            else
            {
                Debug.Log("peluru habis");
            }
        }
        if (AIEnemyCtrl.giveDamage == true)
        {
            health -= AIEnemyCtrl.enemyDamage;
            healthBar.value = health;

            if (health <= 0)
            {
                Debug.Log("player mati");
                //SceneManager.LoadScene("game over");
                SceneManager.LoadScene("game over");
                AIEnemyCtrl.giveDamage = false;
                restart();
            }
        }
    }

    IEnumerator waitReload()
    {
        yield return new WaitForSeconds(2.5f);
        if (ammoMag <= ammoStock)
        {
            ammo = (ammo + ammoMag);
            add = ammo - ammoMag;
            if (add < 0)
            {
                ammoMag = 0;
            }
            else
            {
                ammoMag = add;
                ammo = ammoStock;
                Debug.Log("isi peluru");
            }
        }
        else
        {
            add = (ammo - ammoStock) * -1;
            ammo = ammo + add;
            ammoMag = ammoMag - add;
        }
        trigger = true;
    }
}
