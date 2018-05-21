using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public virtual void ReceiveDamage()
    {
        Die();
    }

    protected virtual void Die()
    {
		CharaterMechanics.lives--;
		Debug.Log (CharaterMechanics.lives);
		if (CharaterMechanics.lives <= 0) {
		//	endText.SetActive (true);
			Destroy (gameObject);
    }
  }
}
