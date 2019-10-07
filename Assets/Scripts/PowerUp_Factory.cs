using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Factory : MonoBehaviour
{
	public float horizontalSpawn;
	public float verticalSpawnBound;
	public float spawnDuration;
	public float spawnTimer;
	private Object[] powerUpsPrefab;
	
    // Start is called before the first frame update
    void Start()
    {
		horizontalSpawn = 20.41f;
		verticalSpawnBound = 5.18f;
		spawnTimer = 0;
		spawnDuration = Random.Range(5.0f, 8.0f);
		powerUpsPrefab = new Object[2];
		powerUpsPrefab[0] = Resources.Load("powerupBlue_bolt");
		powerUpsPrefab[1] = Resources.Load("powerupYellow_star");   
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
		
		if(spawnTimer >= spawnDuration)
		{
			GameObject newPowerUp = (GameObject) Object.Instantiate(powerUpsPrefab[Random.Range(0,2)]);
			newPowerUp.transform.SetParent(transform);
			newPowerUp.transform.position = new Vector2(horizontalSpawn, Random.Range(-verticalSpawnBound,verticalSpawnBound));
			spawnTimer = 0;
		}
    }
}
