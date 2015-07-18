using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GoogleSighIn : MonoBehaviour {

	bool init = false;
	bool login = false;

	//Google初期化
	public void Awake()
	{
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
			// enables saving game progress.
			.EnableSavedGames()
			.Build();
		PlayGamesPlatform.InitializeInstance(config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();
	}

	//Google自動サインイン
	// Use this for initialization
	void Start()
	{
		Social.localUser.Authenticate((bool success) =>
		{
			Debug.Log("login: " + success);
			init = true;
			login = success;
		});

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("OnMouseDown");
		}
	
	}

	void OnGUI()
	{
		GUILayout.Label("Google Get State : " + init.ToString());
		if (login)
			GUILayout.Label("Google Account State : "+login.ToString());
		else
			GUILayout.Label("Google Account State : "+"Null");
	}


}
        