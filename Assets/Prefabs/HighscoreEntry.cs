
public class HighscoreEntry {

	string username;
	float time;

	public HighscoreEntry(string u, float t)
	{
		username = u;
		time = t;
	}

	public string getUsername()
	{
		return username;
	}

	public float getTime()
	{
		return time;
	}

	public string getTimeString()
	{
		return string.Format("{0,5:0.00} sec.", time);
	}

	public bool newHighscore(float newTime)
	{
		if (time > newTime)
			return true;
		else
			return false;
	}
}
