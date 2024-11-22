using System;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Zombie : MonoBehaviour
{
    [SerializeField] EnemySO stats;
    float _health;

   

    private void Awake()
    {
        _health = stats.Health;
    }

    protected void Update()
    {
        transform.Translate(Vector3.left * stats.Speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
          
            Die();
        }
            
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            Manager.Instance.GameOver();
        }
    }

   
}
