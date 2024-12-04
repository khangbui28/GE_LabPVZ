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
    //

    public static GameManager Instance { get; private set; }
    public int Score { get; private set; }

    public delegate void ScoreChanged(int newScore);
    public event ScoreChanged OnScoreChanged;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int points)
    {
        Score += points;
        OnScoreChanged?.Invoke(Score);
    }

    // 

    public GameObject enemyPrefab;

    public GameObject CreateEnemy(Vector3 position)
    {
        GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
        return enemy;
    }

    public class EventManager : MonoBehaviour
{
    public static Action<int> OnScoreUpdated;

    public static void ScoreUpdated(int newScore)
    {
        OnScoreUpdated?.Invoke(newScore);
    }
}

public class ScoreDisplay : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnScoreUpdated += UpdateScoreUI;
    }

    private void OnDisable()
    {
        EventManager.OnScoreUpdated -= UpdateScoreUI;
    }

    private void UpdateScoreUI(int score)
    {
        Debug.Log("Score Updated: " + score);
    }
}

public interface ICommand
{
    void Execute();
}

public class JumpCommand : ICommand
{
    private Transform _player;

    public JumpCommand(Transform player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.position += Vector3.up * 2;
        Debug.Log("Player Jumped");
    }
}

public class InputHandler : MonoBehaviour
{
    public Transform player;

    private ICommand jumpCommand;

    private void Start()
    {
        jumpCommand = new JumpCommand(player);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpCommand.Execute();
        }
    }

 public GameObject bulletPrefab;
    public int poolSize = 10;

    private Queue<GameObject> pool;

    private void Start()
    {
        pool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        GameObject bullet = pool.Dequeue();
        bullet.SetActive(true);
        pool.Enqueue(bullet);
        return bullet;
    }
}
