using System;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Peashooter : Zombie
{
    public GameObject zombieBulletPrefab;
    public float shootInterval = 3f;

    private float _shootTimer;

   

    new private void Update()
    {
        base.Update();

        _shootTimer += Time.deltaTime;

        if (_shootTimer >= shootInterval)
        {
            Shoot();
            _shootTimer = 0;
        }
    }

    private void Shoot()
    {
        // Instantiate a projectile aimed at Dave
        Instantiate(zombieBulletPrefab, transform.position, Quaternion.identity);
    }
}
