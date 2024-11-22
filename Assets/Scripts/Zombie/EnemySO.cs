
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieSO", menuName = "Scriptable Objects/ZombieSO")]
public class EnemySO : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private int health;
    [SerializeField] private float speed;

    public int Damage => damage;

    public int Health => health;    
    public float Speed => speed ;    
}
