using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    public ScoreScript ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    public float MaxSpeed;

    public AudioManager audioManager;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(GameValues.IsMultiplayer)
        {  rb = GetComponent<Rigidbody2D>();
			rb.drag = 0f;
		}
		switch (GameValues.Difficulty)
		{
			case GameValues.Difficulties.Medium:
				rb.drag = 0f;
				break;
			case GameValues.Difficulties.Hard:
				rb.drag = 0f;
				break;
		}
		WasGoal = false;
    }
    public void setLinearDrag()
    {
        rb.drag = 0f;
    }
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!WasGoal) {
            if (other.tag=="AiGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.PlayterScore);
                WasGoal=true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(false));
            }
            else if (other.tag=="PlayerGoal")
            {
				ScoreScriptInstance.Increment(ScoreScript.Score.AiScore);
                WasGoal=true;
				audioManager.PlayGoal();
				StartCoroutine(ResetPuck(true));
			}
        }
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
        audioManager.playPuckCollision();
	}
	private IEnumerator ResetPuck(bool didAiScore)
    {
		GetComponent<Renderer>().sortingOrder = -10000;
		rb.position = new Vector2(-4, -4);
		yield return new WaitForSecondsRealtime(1);
		GetComponent<Renderer>().sortingOrder = 0;
		WasGoal = false;
		rb.velocity = rb.position = new Vector2(0, 0);

        if(didAiScore)
        {
            rb.position = new Vector2(0, -1);
        }
        else
        {
			rb.position = new Vector2(0, 1);
		}
		
	}

    public void CenterPuck()
    {
        rb.position =new Vector2(0,0);
    }
	private void FixedUpdate()
	{
        rb.velocity = Vector2.ClampMagnitude(rb.velocity,MaxSpeed);
	}
}
