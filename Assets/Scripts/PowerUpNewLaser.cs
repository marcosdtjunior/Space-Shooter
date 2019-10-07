using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpNewLaser : MonoBehaviour
{
    private Rigidbody2D powerUp_rigidbody;
	
	private Player playerOne;
	private Player2 playerTwo;
	
    // Start is called before the first frame update
    void Start()
    {	
        powerUp_rigidbody = GetComponent<Rigidbody2D>();
        powerUp_rigidbody.velocity = new Vector2(-8.0f,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -20.41f)
			Destroy(gameObject);
    }
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log("There was a collision with: " + collider.gameObject.name);
		
		if(collider.gameObject.name == "player1")
		{
			GameObject obj = GameObject.Find("player1");
			playerOne = obj.GetComponent<Player>();
			playerOne.laserPrefab = Resources.Load("Machine Gun");
			Destroy(gameObject);
		}
		
		if(collider.gameObject.name == "player2")
		{
			GameObject obj = GameObject.Find("player2");
			playerTwo = obj.GetComponent<Player2>();
			playerTwo.laserPrefab = Resources.Load("Ball_02");
			Destroy(gameObject);
		}
	}
}
