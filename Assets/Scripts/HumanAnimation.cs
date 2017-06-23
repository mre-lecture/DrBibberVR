using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimation : MonoBehaviour {
	
	//List<CloseHumanHoles> myList = new List<CloseHumanHoles>();
	GameObject parent,human;
	GameObject parentHole, childHole;
	Animation humanAnimation;
	// Use this for initialization
	void Start () {
		human = GameObject.FindWithTag ("AnimatedHumanTag");
		print (human);
		human.gameObject.GetComponent<SkinnedMeshRenderer>().enabled= false;
		parent = GameObject.FindWithTag ("ManWithoutHoleTag");
		humanAnimation = parent.GetComponent<Animation> ();
		humanAnimation.Stop();
	}

//	public void RegisterHoles(CloseHumanHoles hole){
//		if (hole != null) {
//			myList.Add (hole);
//		}
//	}

	void Update () {
		
		if (Input.GetKeyDown(KeyCode.A)) {
			this.DeactivateBibber ();
			human.gameObject.GetComponent<SkinnedMeshRenderer>().enabled= true;
			humanAnimation.Play ();
		}
	}

	void DeactivateBibber(){
		parentHole = GameObject.FindWithTag ("HumanWithHoles");
		childHole = GameObject.FindWithTag ("HumanWithoutAnimation");

		if (humanAnimation.IsPlaying() == true) {
			childHole.gameObject.GetComponent<SkinnedMeshRenderer> ().enabled = false;
		}
	}
//
//	bool IsAllEmpty(){
//		bool isEmpty = true;
//		CloseHumanHoles[] arr = myList.ToArray ();
//		for (int i = 0; i < arr.Length && isEmpty == true; i++) {
//			isEmpty =  arr[i].IsHoleEmpty ();
//		}
//		return isEmpty;
//	}
}
