using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighscoreList : MonoBehaviour
{
	List<HighscoreEntry> list;
	public Text displayUsername, displayTime;
	public InputField inputUsername;

	void Start()
	{
		list = new List<HighscoreEntry> ();
		addToList ();
	}

	void addToList()
	{
		// highscorelist can only have 10 entries -> should be dynamic
		for(int i = 0; i < 10; i++)
		{
			if (PlayerPrefs.HasKey ("username" + i)) 
			{
				string user = PlayerPrefs.GetString ("username" + i);
				string time = PlayerPrefs.GetFloat ("time" + i);
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
		float testTime = 0.00;
		HighscoreEntry newEntry = HighscoreEntry("test", testTime);

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

		showList ();
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
		displayUsername = "";
		displayTime = "";
		list.Clear;
		PlayerPrefs.DeleteAll ();
	}

	// maybe delete only one entry

}

