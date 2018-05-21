using UnityEngine;
using System.Collections;
using System.Linq;

public class Mon : Monster
{
	[SerializeField]
	private float speed = 2.0F;

	private Vector3 direction;

	public static int lives = 1;

	protected override void Start()
	{
		direction = transform.right;
	}

	protected override void Update()
	{
		Move();
		if (lives == 0) {
			Destroy (gameObject);
		}
	}

	public void DestroyMon() 
	{
		Destroy (gameObject);
	}
		

	private void Move()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * direction.x * 0.5F, 0.1F);

		if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Character>())) direction *= -1.0F;

		transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
	}
}
