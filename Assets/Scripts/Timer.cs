using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text timerText;
    public static float finaltime;
    private float startTime;
    public bool isdead;
	// Use this for initialization
	void Start () {

        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        isdead = PlayerManager.dead;
        if (!isdead)
        { 
            float t = Time.time - startTime;
            string temp = t.ToString("f2");
            finaltime = t;
            timerText.text = temp;

        }

	}


}
