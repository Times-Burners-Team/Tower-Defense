using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public List<GameObject> WayPoints = new List<GameObject>();

	public GameObject WayPointParent;

	int wayIndex = 0;
	public int speed;

	
	void Start () 
	{
		GetWay();
	}
	
	
	void Update () 
	{
		Move();	
	}

	void GetWay()
	{
		for(int i = 0; i < WayPointParent.transform.childCount; i++)
		{
			WayPoints.Add(WayPointParent.transform.GetChild(i).gameObject);
		}
	}
	public void Move()
	{
		Vector2 dir = WayPoints[wayIndex].transform.position - transform.position;
		transform.Translate(dir.normalized * Time.deltaTime * speed);

		if(Vector3.Distance(transform.position , WayPoints[wayIndex].transform.position) < 0.5f)
		{
			if(wayIndex < WayPoints.Count - 1)
			{
				wayIndex++;
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}
