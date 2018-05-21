using UnityEngine;

public class DieSpace : MonoBehaviour {

	public GameObject respawn;

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
	//		CharaterMechanics.lives--;
	//		Debug.Log (CharaterMechanics.lives);
	//		ReceiveDamage();
			other.transform.position = respawn.transform.position;
		}
	}
}
