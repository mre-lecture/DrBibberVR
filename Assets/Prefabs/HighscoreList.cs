using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighscoreList : MonoBehaviour
{
	List<HighscoreEntry> list;
	public InputField inputUsername;
	public Text displayUsername, displayTime;

	void Start()
	{
		list = new List<HighscoreEntry> ();
		addToList ();
	}

	void addToList()
	{
		// current: highscorelist is top 10 list (can only have 10 entries)
		// maybe  : dynamic list with more than 10 entries
		for(int i = 0; i < 10; i++)
		{
			if (PlayerPrefs.HasKey ("username" + i)) 
			{
				string user = PlayerPrefs.GetString ("username" + i);
				float time = PlayerPrefs.GetFloat ("time" + i);
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
			username += list [i].getUsername () + "\n";
			t += list [i].getTimeString () + "\n";
		}

		displayUsername.text = username;
		displayTime.text = t;
	}

	public void addEntry()
	{
		// current: testEntry but read in typed username
		float testTime = Random.Range(0.0f, 5.0f);
		string testUser = "testUser";
		HighscoreEntry newEntry = new HighscoreEntry(testUser, testTime);

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

	void saveList()
	{
		for (int i = 0; i < list.Count; i++) 
		{
			PlayerPrefs.SetString ("username" + i, list [i].getUsername ());
			PlayerPrefs.SetFloat ("time" + i, list [i].getTime ());
		}
	}

	public void deleteAll()
	{
		displayUsername.text = "";
		displayTime.text = "";
		list.Clear();
		PlayerPrefs.DeleteAll ();
	}

	// maybe delete only one entry

}

