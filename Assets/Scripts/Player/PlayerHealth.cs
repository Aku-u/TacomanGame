using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float health = 100f;
    public float resetAfterDeathTime = 5f;
    
    private PlayerMovement playerMovement;
    private float timerReseatLevel;

    private bool playerDead;

	// Use this for initialization
	void Awake ()
    {
        playerMovement = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
        {
            if (!playerDead)
            {
                PlayerDying();
            }
            else
            {
                PlayerDead();
                LevelReset();
            }
        }
	}

    void PlayerDying()
    {
        playerDead = true;
    }

    void PlayerDead()
    {
        playerMovement.enabled = false;
    }

    void LevelReset()
    {
        timerReseatLevel += timerReseatLevel*Time.deltaTime;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }
}
