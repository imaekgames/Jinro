using UnityEngine;
using System.Collections;

public class TitleSetting : MonoBehaviour {

	public string version = "first";

	// Use this for initialization
	void Start()
	{
		PhotonNetwork.ConnectUsingSettings(version);
	}

	void OnConnectionFail()
	{
		Debug.Log("接続が不安定です。");
	}

	void OnFailedToConnectToPhoton()
	{
		Debug.Log("オフラインの為ゲームが開始できません。");
	}
}
