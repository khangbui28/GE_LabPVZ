using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Rigidbody rb;

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform gunPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float input = Input.GetAxis("Vertical");

        // Move the player only along the Y-axis in world space
        Vector3 movement = new Vector3(0f,0f , input) * speed * Time.deltaTime;

        // Apply the movement to the player's position
        rb.MovePosition(transform.position + movement);

        if (Input.GetMouseButtonDown(0)) {

            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, gunPos.position, gunPos.rotation);
        
    }
}
