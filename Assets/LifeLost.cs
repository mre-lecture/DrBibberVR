using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeLost : MonoBehaviour {
    public Healthbar life;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


    }
    void OnTriggerEnter()
    {
        life.BroadcastMessage("LifeLost");

    }
}
