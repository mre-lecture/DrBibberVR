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
        Debug.Log(other.gameObject.name);
      // if(other.transform != null && other.transform.parent != null) {
      //     Debug.Log(other.transform.parent.gameObject);
      // }
       
        if (other.gameObject.name.Equals("Hand1") || other.gameObject.name.Equals("Hand2") ) 
        {
            Debug.Log(other.gameObject.name + "TRIGGERED" );
            if (!timer.text.Equals(lastHit))
            {
                lastHit = timer.text;
                Debug.Log("lasthit + " + lastHit);
                life.BroadcastMessage("LifeLost");
            }
        }/* else if (other.transform  && other.transform.parent != null)
               Debug.Log(other.gameObject.name + " Parent TRIGGERED");
  
                life.BroadcastMessage("LifeLost");
            }
            }*/

    }
}
