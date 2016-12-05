using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public GameObject player;

	private GameObject title;

	// Use this for initialization
	void Start () {
		title = GameObject.Find ("Title");
	}
	
	void OnGUI () {
		if (IsPlaying () == false && Event.current.type == EventType.MouseDown) {
			GameStart ();
		}
	}

	void GameStart () {
		title.SetActive (false);
		Instantiate (player, player.transform.position, player.transform.rotation);
	}

	public void GameOver () {
		// ハイスコアの保存
		FindObjectOfType<Score> ().Save ();

		title.SetActive (true);
	}

	public bool IsPlaying () {
		return title.activeSelf == false;
	}
}
