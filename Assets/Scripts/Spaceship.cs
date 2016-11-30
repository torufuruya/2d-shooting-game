using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {

	public float speed;

	public float shotDelay;

	public GameObject bullet;

	public bool canShot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Shot (Transform origin) {
		Instantiate (bullet, origin.position, origin.rotation);
	}

	public void Move (Vector2 direction) {
		GetComponent<Rigidbody2D> ().velocity = direction * speed;
	}
}
