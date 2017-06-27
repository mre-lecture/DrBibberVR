
public class HighscoreEntry {

	string username;
	string time;

	public HighscoreEntry(string u, string t)
	{
		username = u;
		time = t;
	}

	public string getUsername()
	{
		return username;
	}

	public string getTime()
	{
		return time;
	}

	public string getTimeString()
	{
		return time;
	}

	public bool newHighscore(string newTime)
	{
		if (time.CompareTo (newTime) < 1)
			return false;
		 else
			return true;

	}
}
