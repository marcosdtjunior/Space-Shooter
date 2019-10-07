using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVelocity : MonoBehaviour
{
	private Rigidbody2D powerUp_rigidbody;
	
	private Player playerOne;
	private Player2 playerTwo;
	
	public bool collisionP1;
	public bool collisionP2;
	
	private float powerUpTimerP1;
	private float powerUpDurationP1;
	
	private float powerUpTimerP2;
	private float powerUpDurationP2;
	
    // Start is called before the first frame update
    void Start()
    {	
		powerUpDurationP1 = 2.0f;
		powerUpDurationP2 = 2.0f;
		
        powerUp_rigidbody = GetComponent<Rigidbody2D>();
        powerUp_rigidbody.velocity = new Vector2(-8.0f,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -20.41f)
			Destroy(gameObject);
		
		if (collisionP1)
		{
			powerUpTimerP1 += Time.deltaTime;
			Debug.Log("entrou no if");
			
			if (powerUpTimerP1 >= powerUpDurationP1)
			{
				Debug.Log("passou o tempo do powerUp");
				playerOne.velocity = 6.0f;
				powerUpTimerP1 = 0;
				collisionP1 = false;
			}
		}
		
		if (collisionP2)
		{
			powerUpTimerP2 += Time.deltaTime;
			
			if (powerUpTimerP2 >= powerUpDurationP2)
			{
				playerTwo.velocity = 6.0f;
				powerUpTimerP2 = 0;
				collisionP2 = false;
			}
		}
    }
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log("There was a collision with: " + collider.gameObject.name);
		
		if(collider.gameObject.name == "player1")
		{
			GameObject obj = GameObject.Find("player1");
			playerOne = obj.GetComponent<Player>();
			playerOne.velocity = 20.0f;
			Destroy(gameObject);
			collisionP1 = true;
		}
		
		if(collider.gameObject.name == "player2")
		{
			GameObject obj = GameObject.Find("player2");
			playerTwo = obj.GetComponent<Player2>();
			playerTwo.velocity = 20.0f;
			Destroy(gameObject);
			collisionP2 = true;
		}
	}
}
