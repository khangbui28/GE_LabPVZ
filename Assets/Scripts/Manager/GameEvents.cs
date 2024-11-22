using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
   public static GameEvents instance;
    void Start()
    {
        instance = this;
    }

    public event Action onDeath;

    public void DeathTrigger()
    {
        if(onDeath != null) onDeath();
    }
}
