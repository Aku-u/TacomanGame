using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    public int playerHP;

    public int playerDamage;

    //public GameObject player;
    //public GameObject combatController;

    public MeshRenderer circleArea;
    public bool circleVisible = false;
    float areaAttackTimer;

    

    //public Collider attackArea;

	// Use this for initialization
	void Awake () {

        playerHP = 100;
        playerDamage = 10;
        //player = GetComponent<GameObject>();
        //combatController = GetComponent<GameObject>();


        
        circleArea.enabled = false;
        circleVisible = false;
        // DURATION OF THE ATTACK:
        areaAttackTimer = 120f;
        //attackArea = GetComponent<CapsuleCollider>();

    }
	
	// Update is called once per frame
	void Update () {


        // MAKE THE ATTACK AREA VISIBLE WHEN LEFTMOUSE  CLICKING:
        if (Input.GetMouseButtonDown(0) && circleVisible == false)
        {
            circleArea.enabled = true;
            circleVisible = true;
        }

        if (circleVisible == true)
        {
            areaAttackTimer -= 1;

            if (areaAttackTimer <= 0)
            {
                circleVisible = false;
                circleArea.enabled = false;
                areaAttackTimer = 120;
            }
        }
	
	}

    void Attack()
    {

    }
}
