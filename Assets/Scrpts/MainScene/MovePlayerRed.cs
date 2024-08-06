using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlayerRed : MonoBehaviour
{
	public float speed;
	public Transform PlayerBoundaryHolder;
	private Boundary playerBoundary;
	private Rigidbody2D rb;
	public Object Aiplayer;
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		playerBoundary = new Boundary(PlayerBoundaryHolder.GetChild(0).position.y,
							  PlayerBoundaryHolder.GetChild(1).position.y,
							  PlayerBoundaryHolder.GetChild(2).position.x,
							  PlayerBoundaryHolder.GetChild(3).position.x);
		if (GameValues.IsMultiplayer)
		{
			Aiplayer.GetComponent<AiScript>().enabled = false;
			Aiplayer.GetComponent<MovePlayerRed>().enabled = true;
		}
		else
		{
			Aiplayer.GetComponent<AiScript>().enabled = true;
			Aiplayer.GetComponent<MovePlayerRed>().enabled = false;
		}
	}
	void Update()
    {

		Vector3 pos = transform.position;

		if (Input.GetKey("w"))
		{
			float newY = pos.y + speed * Time.deltaTime;
			if (newY <= 4)
			{
				pos.y = Mathf.Clamp(newY, 0, 4);
			}
		}

		if (Input.GetKey("s"))
		{
			float newY = pos.y - speed * Time.deltaTime;
			if (newY >= 0.648)
			{
				pos.y = Mathf.Clamp(newY, 0.648f, float.MaxValue);
			}
		}

		if (Input.GetKey("d"))
		{
			float newX = pos.x + speed * Time.deltaTime;
			if (newX <= 2)
			{
				pos.x = Mathf.Clamp(newX, float.MinValue, 2);
			}
		}

		if (Input.GetKey("a"))
		{
			float newX = pos.x - speed * Time.deltaTime;
			if (newX >= -2)
			{
				pos.x = Mathf.Clamp(newX, -2, float.MaxValue);
			}
		}

		
		rb.velocity = (pos - transform.position) / Time.deltaTime;


	}

}
