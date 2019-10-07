using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	private Rigidbody2D laser_rigidbody;
	
    // Start is called before the first frame update
    void Start()
    {
		laser_rigidbody = GetComponent<Rigidbody2D>();
        laser_rigidbody.velocity = new Vector2(6,0);
    }

    // Update is called once per frame
    void Update()
    {
		if(transform.position.x >= 17.0f)
			Destroy(gameObject);   
    }
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		/*
		if(collider.gameObject.name == "meteorBrown(Clone)" || collider.gameObject.name == "meteor2(Clone)" || 
		collider.gameObject.name == "meteor3(Clone)")
		{
			GameObject newExplosion = (GameObject) Object.Instantiate(explosionPrefab);
			newExplosion.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
		}*/
	}
	
}
