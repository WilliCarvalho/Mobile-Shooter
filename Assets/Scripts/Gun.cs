using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;

    public void Shoot(GameObject gun)
    {
        Destroy(Instantiate(bullet, gun.transform.position, gun.transform.rotation), 3f);
    }
}
