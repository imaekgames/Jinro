using UnityEngine;
using System.Collections;
using UnityEditor;

public class ChangeScene : MonoBehaviour {
	[SceneName]public string NextSceneName="";

	public void goNext()
	{
		if(PhotonNetwork.connected) Application.LoadLevel(NextSceneName);
	}
}
