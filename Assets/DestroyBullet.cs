using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this.gameObject, 2.0F);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Destroy (this.gameObject);
	}
}
