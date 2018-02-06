using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MovingObject {

	public int wallDamage = 2;
	public int pointsPerFood = 10;
	public int pointsPerSoda = 20;
	public float restartLevelDelay = 1f;
	public Text foodText;

	private Animator animator;
	private int food;
	private int horizontal = 0;
	private int vertical = 0;
	// Use this for initialization
	protected override void Start () {
		animator = GetComponent<Animator>();
		food = GameManager.instance.playerFoodPoints;
		foodText.text = "Food: " + food;
		base.Start();
	}

	private void OnDisable()
	{
		GameManager.instance.playerFoodPoints = food;
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameManager.instance.playersTurn){
			 return;
		}
		horizontal = (int)(Input.GetAxisRaw("Horizontal"));
		vertical = (int)(Input.GetAxisRaw("Vertical"));

		if(horizontal != 0)
			vertical =0;
		
		if(horizontal != 0 || vertical != 0)
			AttemptMove<Wall>(horizontal, vertical);
	}

	protected override void AttemptMove<T>(int xDir, int yDir)
	{
		food--;
		foodText.text = "Food: " + food;
		base.AttemptMove<T> (xDir, yDir);
		//RaycastHit2D hit;
		CheckIfGameOver();
		GameManager.instance.playersTurn = false;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "food")
		{
			food += pointsPerFood;
			foodText.text = "+" + pointsPerFood + "Food: " + food;
			other.gameObject.SetActive(false);
		}
		else if(other.tag == "Soda")
		{
			food += pointsPerSoda;
			foodText.text = "+" + pointsPerSoda + "Food: " + food;
			other.gameObject.SetActive(false);
		}
	}

	protected override void OnCantMove<T>(T component)
	{
		Wall hitwall = component as Wall;
		hitwall.DamageWall(wallDamage);
		animator.SetTrigger("PlayerChop");
	}
	private void Restart()
	{
		SceneManager.LoadScene(0);
	}

	public void lossFood(int loss)
	{
		animator.SetTrigger("PlayerHit");
		food -= loss;
		foodText.text = "-" + loss + "Food: " + food;
		CheckIfGameOver();
	}

	private void CheckIfGameOver()
	{
		if(food<=0){
			GameManager.instance.GameOver();
		}

	}
}
