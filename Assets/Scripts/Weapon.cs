using UnityEngine;
using System.Collections;
/*
* Lanterna
* Faca
* Rifle 
* Pistola
* Shotgun
* 
* capacity -1 = infinity
* charge -1 = infinity
*/
public class Weapon : MonoBehaviour {

	public string weapon_name { get; set; }
	public float cadency { get; set; }
	public float reloadTime { get; set; }
	public int capacity { get; set; }
	public int charge { get; set; }
	public int id { get; set;}
	public bool equipped { get; set; }
	public bool heavy { get; set; }
	public int speed { get; set; }
	private bool shooting;
	private bool reloading;
	public Rigidbody2D bullet;

	// Use this for initialization
	void Start () {

	}
		
}
