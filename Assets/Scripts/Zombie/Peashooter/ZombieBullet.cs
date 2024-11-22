using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class ZombieBullet : MonoBehaviour
{
    
    [SerializeField] int bulletSpeed;

    private void Update()
    {
        transform.position += Time.deltaTime * Vector3.left * bulletSpeed;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

            Manager.Instance.GameOver();
        }
    }

}
