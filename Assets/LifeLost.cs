using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeLost : MonoBehaviour {
    public Healthbar life;
    private string lastHit;
    public Text timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


    }
    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name.Equals("Hand1") || other.gameObject.name.Equals("Hand2"))
        {
            if (!timer.text.Equals(lastHit))
            {
                lastHit = timer.text;
                life.BroadcastMessage("LifeLost");
            }
        }
    }
}
