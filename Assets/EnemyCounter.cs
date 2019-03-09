using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnemyCounter : MonoBehaviour {

	public int enemies;
	public Text zombies_text;
	// Use this for initialization
	void Start () {
		enemies = this.gameObject.transform.childCount;
		zombies_text.text = "Zumbis: " + enemies;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemies == 0)
			SceneManager.LoadScene ("scene_survived"); 
	}

	void EnemyDown() {
		enemies--;
		zombies_text.text = "Zumbis: " + enemies;
	}

}
