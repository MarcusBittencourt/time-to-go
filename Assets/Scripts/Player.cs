using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public Text life_text; 
	public Text bullets_text;

	public int health = 99;
	public int speed = 5;
	public int charge = 0;
	public int munition = 200;
	public int capacity = 30;
	public float fire_rate = 0.5F;
	public float cadency = 0.0F;

	public static Weapon pistol = Arsenal.PISTOL();

	public Weapon weapon;
	public Animator animator;
	public AudioSource pistol_fire_audio;
	public AudioSource pistol_reload_audio;
	public bool moving;
	public bool reloading;
	public bool shooting;
	public bool attacking;

	private Rigidbody2D rb2d;

	public Transform shot_spawn;
	public GameObject shot;

	public const string hud_health = "VIDA: ";
	public const string hud_bullets = "PISTOLA: ";

	private int count;
	
	void Start () {
		life_text.text = hud_health + health;
		bullets_text.text = hud_bullets + charge;
		rb2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator> ();
		weapon = Arsenal.KNIFE();
	}

	void Update () {
		Rotate ();
		Reload ();
		Move ();
		Fire ();
		Died ();
	}

	void Died() {
		if(health < 0) SceneManager.LoadScene("scene_died");
	}

	void Move() {
		float moveHorizontal = 0.0f; //Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		if(moveVertical != 0.0f || moveHorizontal != 0.0f) moving = true;
		if(moveVertical == 0.0f && moveHorizontal == 0.0f) moving = false;
		if (!moving) return;
		animator.SetTrigger("is_move_with_pistol");
		Vector2 moviment = new Vector2(moveVertical, moveHorizontal);
		transform.Translate (moviment * speed * Time.deltaTime);
	}

	void Reload() {
		if (!Input.GetKey ("r")) return;
		if (charge == capacity) return;
		reloading = true;
		animator.SetTrigger ("is_reload_with_pistol");
		pistol_reload_audio.Play ();
		charge = capacity;
		bullets_text.text = hud_bullets + charge;
		//capacity -= charge;
		reloading = false;
	}

	void Fire() {
		if (!Input.GetKey("o")) return;
		if (Time.time <= cadency) return; 
		if (reloading) return;
		if (shooting) return;
		if (charge <= 0) return;
		shooting = true;
		animator.SetTrigger("is_shot_with_pistol");
		cadency = Time.time + fire_rate;
		GameObject bullet = Instantiate (shot, shot_spawn.position, shot_spawn.rotation) as GameObject;
		Rigidbody2D bullet_rigidbody = bullet.GetComponent<Rigidbody2D> () as Rigidbody2D;
		bullet_rigidbody.velocity = shot_spawn.TransformDirection(new Vector3(20, 0, 20));
		pistol_fire_audio.Play ();
		this.charge--;
		bullets_text.text = hud_bullets + charge;
		shooting = false;
	}

	void Rotate() {
		if(Input.GetKey("e")) this.transform.Rotate(new Vector3(0, 0, transform.position.z - 5));
		if(Input.GetKey("q")) this.transform.Rotate(new Vector3(0, 0, transform.position.z + 5));
	}

	void Bitten() {
		health -= 5;
		life_text.text = hud_health + health;
	}


}
