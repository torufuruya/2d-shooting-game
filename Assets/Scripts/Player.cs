using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	Spaceship spaceship;

	Background background;

	// Use this for initialization
	IEnumerator Start () {
		spaceship = GetComponent<Spaceship> ();

		background = FindObjectOfType<Background> ();

		while (true) {
			spaceship.Shot (transform);
			GetComponent<AudioSource> ().Play ();
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}
	
	// Update is called once per frame
	void Update () {
		float x = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
		float y = CrossPlatformInputManager.GetAxisRaw ("Vertical");

		Vector2 direction = new Vector2 (x, y).normalized;

		Move(direction);
	}

	void Move (Vector2 direction) {
		Vector2 scale = background.transform.localScale;

		Vector2 min = scale * -0.5f;
		Vector2 max = scale * 0.5f;
		Vector2 pos = transform.position;

		// 移動量を加える
		pos += direction * spaceship.speed * Time.deltaTime;

		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		transform.position = pos;
	}

	void OnTriggerEnter2D (Collider2D c) {
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		if (layerName == "Bullet (Enemy)") {
			// 弾の削除
			Destroy (c.gameObject);
		}

		if (layerName == "Bullet (Enemy)" || layerName == "Enemy") {
			FindObjectOfType<Manager> ().GameOver ();
			// 爆発
			spaceship.Explosion ();
			// プレイヤーを削除
			Destroy (gameObject);
		}
	}
}
