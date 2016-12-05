using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	public float speed = 0.1f;

	// Use this for initialization
	void Start () {
		// 画面右上のワールド座標をビューポートから取得
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		// スケールを求める。
		Vector2 scale = max * 2;

		// スケールを変更。
		transform.localScale = scale;
	}
	
	// Update is called once per frame
	void Update () {
		float y = Mathf.Repeat (Time.time * speed, 1);

		Vector2 offset = new Vector2 (0, y);

		GetComponent<Renderer> ().sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}
