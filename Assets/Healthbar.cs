using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
    private int lifeCounter;
    private Image[] lifes;
    private GameObject instrumentTrolley;

    // Use this for initialization
    void Start () {
        lifeCounter = this.gameObject.transform.childCount-1;
        lifes = this.gameObject.transform.GetComponentsInChildren<Image>();
        instrumentTrolley = GameObject.Find("instrument_trolley");


    }

    // Update is called once per frame
    void Update () {
        
		
	}
    void LifeLost()
    {
        if (lifeCounter <= 0)
        {
            Debug.Log("Loser");
            Reset();

        }
        else
        {
            lifes[lifeCounter].enabled = false;
            lifeCounter--;
        }

    }
    private void Reset()
    {
        instrumentTrolley.BroadcastMessage("StoppingTime", false);
        foreach(Image i in lifes)
        {
            i.enabled = true;
        }
        lifeCounter = this.gameObject.transform.childCount - 1;

    }
}
