using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 5;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		Vector2 direction = new Vector2 (x, y).normalized;
		GetComponent<Rigidbody2D> ().velocity = direction * speed;
	}
}
