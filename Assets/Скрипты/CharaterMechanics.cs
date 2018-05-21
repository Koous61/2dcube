using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class CharaterMechanics : MonoBehaviour
{
	// основные параметры
	public float speedMove; // скорость персонажа
	public float jumpPower;// сила прыжка
	// текст
	public Text scoreText;
	public GameObject endText;
	//параметры гуймлея для персонажа
	private float gravityForce; // гравитация
	private Vector3 moveVector; // направление движения
	// жизни static
	public static int lives = 5;
	// очки
	public int score;
	// смерть


	//Ссылки на компаненты
	private CharacterController ch_controller;
	//private Animator ch_animator // анимания

	private void Start()
	{
	ch_controller = GetComponent<CharacterController> ();
	//	ch_animator = GetComponent<Animator> (); тоже анимация
	}
		
	private void Update()
	{
		scoreText.text = score.ToString ();
		CharacterMove ();
		GamingGravity ();
	}

	// метод перемещения персонажа
	private void CharacterMove()
	{
		if (ch_controller.isGrounded) 
			// перемещение 
			moveVector = Vector3.zero;
			moveVector.x = Input.GetAxis ("Horizontal") * speedMove;

			if (Vector3.Angle (Vector3.forward, moveVector) > 1f || Vector3.Angle (Vector3.forward, moveVector) == 0) {
			Vector3 direct = Vector3.RotateTowards (transform.forward, moveVector, speedMove, 0.0f);
			transform.rotation = Quaternion.LookRotation (direct);
			}
			moveVector.y = gravityForce;
			ch_controller.Move (moveVector * Time.deltaTime); // метод перемещение по направлению
		
	}

	// метод гравитации
	private void GamingGravity()
	{
		if (!ch_controller.isGrounded)
			gravityForce -= 20f * Time.deltaTime;
		else
			gravityForce = -1f;
		if (Input.GetKeyDown (KeyCode.Space) && ch_controller.isGrounded)
			gravityForce = jumpPower; 
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.tag == "coin") {
			score++;
			Debug.Log (score);
			Destroy (other.gameObject);
		}

		if (other.tag == "die") {
			ReceiveDamage ();
				
		}
		if (other.tag == "live") {
			if (lives < 5) {
				lives++;
			}
		}
		if (other.tag == "diemon") {
			score++;

		}
	}

	public virtual void ReceiveDamage()
	{
		Die ();
	}

	protected virtual void Die()
	{
		lives--;
		Debug.Log (lives);
		if (lives <= 0) 
		{
			endText.SetActive (true);
			Destroy (gameObject);
			lives = 5;
		}

	}
	}
			

	
			