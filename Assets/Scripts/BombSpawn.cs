using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour {
    public GameObject bomb;
    public float timer = 0.5f;
    public float xMin = -9;
    public float xMax = 9;
    public float y = 8;
    public bool isdead;
	// Use this for initialization
	void Start () 
    {
        InvokeRepeating("SpawnBomb", timer, timer);
	}
	
	// Update is called once per frame
	void Update() 
    {
        isdead = PlayerManager.dead; 
        if (isdead == true)
        {
            CancelInvoke();
        }
	}

    void SpawnBomb()
    {
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), y);
        Instantiate(bomb, pos, transform.rotation);
    }


}
