using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithKey : MonoBehaviour
{
	public float speed;
	public Transform PlayerBoundaryHolder;
	private Boundary playerBoundary;
	private Rigidbody2D rb;
	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		playerBoundary = new Boundary(PlayerBoundaryHolder.GetChild(0).position.y,
							  PlayerBoundaryHolder.GetChild(1).position.y,
							  PlayerBoundaryHolder.GetChild(2).position.x,
							  PlayerBoundaryHolder.GetChild(3).position.x);
	}

    // Update is called once per frame
    void Update()
    {
		Vector3 pos = transform.position;

		if (Input.GetKey("i"))
		{
			float newY = pos.y + speed * Time.deltaTime;
			if (newY <= -0.72)
			{
				pos.y = Mathf.Clamp(newY, -4.17f, -0.72f);
			}
		}

		if (Input.GetKey("k"))
		{
			float newY = pos.y - speed * Time.deltaTime;
			if (newY >= -4.17)
			{
				pos.y = Mathf.Clamp(newY, -4.17f, float.MaxValue);
			}
		}

		if (Input.GetKey("l"))
		{
			float newX = pos.x + speed * Time.deltaTime;
			if (newX <= 2)
			{
				pos.x = Mathf.Clamp(newX, float.MinValue, 2);
			}
		}

		if (Input.GetKey("j"))
		{
			float newX = pos.x - speed * Time.deltaTime;
			if (newX >= -1.97)
			{
				pos.x = Mathf.Clamp(newX, -2, float.MaxValue);
			}
		}


		rb.velocity = (pos - transform.position) / Time.deltaTime;
	}
}
