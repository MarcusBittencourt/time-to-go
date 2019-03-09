using UnityEngine;
using System.Collections;

public class Arsenal : MonoBehaviour {

	public static Weapon KNIFE() {
		Weapon weapon = new Weapon ();
		weapon.weapon_name = "Faca";
		weapon.heavy = false;
		weapon.equipped = false;
		weapon.id = 1;
		weapon.cadency = 4.0f;
		weapon.reloadTime = 0.0f;
		weapon.capacity = -1;
		weapon.charge = -1;
		return weapon;
	}
	
	public static Weapon PISTOL() {
		Weapon weapon = new Weapon ();
		weapon.weapon_name = "Pistola"; 
		weapon.heavy = false;
		weapon.equipped = false;
		weapon.id = 2;
		weapon.cadency = 3.0f; 
		weapon.reloadTime = 0.0f; 
		weapon.capacity = 30;
		weapon.charge = -1;
		return weapon;
	}
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
