using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpHeight;
	public float speed;
	public Text scoreText;
	public Text winText;

	private Rigidbody rb;
	private Renderer rend;
	private int score;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		rend = GetComponent<Renderer> ();
		score = 0;
		winText.text = "";
		SetText ();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		bool isJumping = Input.GetButtonDown ("Jump");

		Vector3 movement = new Vector3 (moveHorizontal, (isJumping ? jumpHeight : 0) / speed, moveVertical);

		if (isJumping)
			print ("Jumped!");

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			rend.material.color = other.gameObject.GetComponent<Renderer> ().material.color;
			other.gameObject.SetActive (false);
			score++;
			SetText ();
		}
	}

	void SetText () {
		scoreText.text = "Score: " + score.ToString ();
		if (score == Spawner.NUM_PICKUPS) {
			winText.text = "You're winner!";
		}
	}
}
