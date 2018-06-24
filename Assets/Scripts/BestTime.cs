using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class BestTime : MonoBehaviour
{
    public static float pb = 0.0f;
    public bool isdead;
    public Text personalbest;
    public float temp;
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        temp = Timer.finaltime;
        isdead = PlayerManager.dead;
        if (isdead == true && personalbest!= null)
        {


           if (temp > pb)
           {
               string tmp = temp.ToString("f2");
               personalbest.text = "Best Time: " + tmp;
               pb = temp;
           }
           else
           {
               string tmp = pb.ToString("f2");
               personalbest.text = "Best Time: " + tmp;
           }
      

        }

    }
}
