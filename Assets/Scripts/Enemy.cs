using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Animator animator;
	public Rigidbody2D rigidbody;

	public AudioSource zombie_sound;
	public GameObject target;
	public GameObject zombie_group;

	public int speed = 2;
	public int health = 99;
	public bool moving;
	public bool following_presence;
	public bool following_shot;
	public bool listening;
	public bool idle;
	public float move_x = 0.2f;
	public float move_y = 0.3f;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Walk ();
		Idle();
		Die ();
		if(Near()) Follow ();
		if(following_shot) Follow (); 
	}

	void Idle() {
		if (moving) return;
		if (following_shot) return;
		if (following_presence) return;
		this.idle = true;
		animator.SetTrigger ("zombie_idle");
	}

	bool Near() {
		following_presence = Vector3.Distance (this.transform.position, target.transform.position) <= 5f; 
		return following_presence;
	}

	void Follow() {
		animator.SetTrigger ("zombie_move");
		transform.LookAt(target.transform.position);
		transform.Rotate(new Vector3(0,-90,0),Space.Self);
		transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
	}

	void Die() {
		if(health > 0) return;
		zombie_group.SendMessage ("EnemyDown");
		Destroy (this.gameObject);	
	}

	void Walk () {
		if(following_presence) return;
		if(following_shot) return;
		animator.SetTrigger ("zombie_move");
		Vector2 moviment = new Vector2(move_x, move_y);
		transform.Translate (moviment * speed * Time.deltaTime);
	}

	void Bite () {
		zombie_sound.Play ();
		animator.SetTrigger ("zombie_attack");
	}
		
	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.CompareTag("static_object")) {
			this.transform.Rotate (new Vector3(0, 0, transform.position.z - 2));
		}
		if(collision.gameObject.CompareTag("bullet")) {
			Transform blood = this.gameObject.transform.GetChild (Random.Range (1, 4)) as Transform;
			Animator blood_animator = blood.GetComponent<Animator> ();
			blood_animator.SetTrigger ("empty");
			blood_animator.SetTrigger ("blood");
			health -= 5;
			following_shot = true;
			blood_animator.SetTrigger ("empty");
		}
		if(collision.gameObject.CompareTag("Player")) {
			Bite ();
			collision.gameObject.SendMessage ("Bitten");
		}
	}
}
