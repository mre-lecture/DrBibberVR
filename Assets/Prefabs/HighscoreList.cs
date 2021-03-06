﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighscoreList : MonoBehaviour
{
	List<HighscoreEntry> list;

	public Text displayUsername, displayTime, inputTime;
	public TextMesh inputUsername;

	void Start()
	{

		list = new List<HighscoreEntry> ();
		addToList ();
	}

	void addToList()
	{

        for (int i = 0; i < 10; i++)
		{
			if (PlayerPrefs.HasKey ("username" + i)) 
			{

                string user = PlayerPrefs.GetString ("username" + i);
				string time = PlayerPrefs.GetString ("time" + i);
				HighscoreEntry entry = new HighscoreEntry (user, time);
				list.Add (entry);
			}
			else
				break;
		}

		showList ();
	}

	void showList()
	{
		string username = "";
		string t = "";

		for (int i = 0; i < list.Count && i < 10; i++) 
		{
			username += i+1 + ". " + list [i].getUsername () + "\n";
			t += list [i].getTimeString () + "\n";
		}

		displayUsername.text = username;
		displayTime.text = t;
	}

	public void addEntry()
	{

		HighscoreEntry newEntry = new HighscoreEntry(inputUsername.text, inputTime.text);

		bool added = false;
		for (int i = 0; i < list.Count; i++) 
		{
			if (list [i].newHighscore (newEntry.getTime ())) 
			{
				list.Insert (i, newEntry);
				added = true;
				break;
			}
		}

		if (!added)
			list.Add (newEntry);

		showList();
		saveList();
	}

    void OnTriggerEnter() {
        if (!inputTime.text.Equals("00:00")){
            addEntry();
            SetInsertCubeEnabled(false);
        }
    }


	void saveList()
	{
		for (int i = 0; i < list.Count; i++) 
		{
			PlayerPrefs.SetString ("username" + i, list [i].getUsername ());
			PlayerPrefs.SetString ("time" + i, list [i].getTime ());
		}
	}


	void SetInsertCubeEnabled(bool enabled)
	{
	    BoxCollider[] collider = gameObject.GetComponents<BoxCollider> ();
		foreach (BoxCollider boxCollider in collider) {
			boxCollider.enabled = enabled;
		}
	}
}

