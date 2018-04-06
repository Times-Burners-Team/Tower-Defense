using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

	public float TimeToSpawn = 2;

	int SpawnCount = 0;

	public GameObject EnemyPref , WayPointParent;
	
	void Update ()
	{
		if(TimeToSpawn <= 0)
		{
			StartCoroutine(SpawnEnemy(SpawnCount + 1));
			TimeToSpawn = 2;
		}

		TimeToSpawn -= Time.deltaTime;
		GameObject.Find("SpawnTime").GetComponent<Text>().text = Mathf.Round(TimeToSpawn).ToString();
	}

	IEnumerator SpawnEnemy(int EnemyCount)
	{
		SpawnCount++;
		for(int i = 0; i < EnemyCount; i++)
		{
			GameObject EnemyTmp = Instantiate(EnemyPref);
			EnemyTmp.transform.SetParent(gameObject.transform, false);
			EnemyTmp.GetComponent<Enemy>().WayPointParent = WayPointParent;

			yield return new WaitForSeconds(0.5f);
		}
	}
}
