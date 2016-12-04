using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {

	public float speed;

	public float shotDelay;

	public GameObject bullet;

	public bool canShot;

	public GameObject explosion;

	private Animator animator;

	public void Start () {
		animator = GetComponent<Animator> ();
	}

	public void Shot (Transform origin) {
		Instantiate (bullet, origin.position, origin.rotation);
	}

	public void Explosion () {
		Instantiate (explosion, transform.position, transform.rotation);
	}

	public Animator GetAnimator () {
		return animator;
	}
}
