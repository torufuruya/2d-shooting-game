using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int hp = 1;

	public int point = 100;

	Spaceship spaceship;

	// Use this for initialization
	IEnumerator Start () {
		spaceship = GetComponent<Spaceship> ();	

		// ローカル座標のY軸のマイナス方向に移動する
		Move (transform.up * -1);

		if (spaceship.canShot == false) {
			yield break;
		}

		while (true) {
			for (int i = 0; i < transform.childCount; i++) {
				Transform shotPosition = transform.GetChild (i);

				spaceship.Shot (shotPosition);
			}
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}

	public void Move (Vector2 direction) {
		GetComponent<Rigidbody2D>().velocity = direction * spaceship.speed;
	}

	void OnTriggerEnter2D (Collider2D c) {
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		// レイヤー名がBullet (Player)以外の時は何も行わない
		if (layerName != "Bullet (Player)") {
			return;
		}

		Transform playerBulletTransform = c.transform.parent;
		Bullet bullet = playerBulletTransform.GetComponent<Bullet> ();

		hp = hp - bullet.power;

		// 弾の削除
		Destroy(c.gameObject);

		if (hp <= 0) {
			// スコアコンポーネントを取得してポイントを追加
			FindObjectOfType<Score>().AddPoint(point);
			// 爆発
			spaceship.Explosion ();
			// エネミーを削除
			Destroy (gameObject);
		} else {
			spaceship.GetAnimator ().SetTrigger ("Damage");
		}
	}
}
