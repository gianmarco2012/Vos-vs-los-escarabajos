using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    void Start()
    {
        //No hay demora entre disparos
        cooldown = 0;
        //Esta no es un arma automática, lo cual significa que necesitamos hacer click en un botón de disparo cada vez que queramos dispararla
        auto = false;
        ammoCurrent = 10;
        ammoMax = 10;
        ammoBackPack = 30;
    }
    protected override void OnShoot()
    {
        Vector3 rayStartPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(rayStartPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject gameBullet = Instantiate(particle, hit.point, hit.transform.rotation);
            if (hit.collider.CompareTag("enemy"))
            {
                // Puedes cambiar el número 10 por lo que quieras. Esa es la cantidad de daño que causa una bala.
                hit.collider.gameObject.GetComponent<Enemy>().ChangeHealth(10);
            }
            else if (hit.collider.CompareTag("Player"))
            {
                hit.collider.gameObject.GetComponent<PlayerController>().GetDamage(10);
            }
            Destroy(gameBullet, 1);
        }
    }
    public void IncreaseBullets(int count)
    {
        ammoBackPack += count;
    }
}
