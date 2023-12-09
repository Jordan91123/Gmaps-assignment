 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class PoolCue : MonoBehaviour
 {
 	public LineFactory lineFactory;
 	public GameObject ballObject;

 	private Line drawnLine;
 	private Ball2D ball;

 	private void Start()
 	{
 		ball = ballObject.GetComponent<Ball2D>();
 	}

 	void Update()
 	{
        if (Input.GetMouseButtonDown(0))
        {
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
            {
                drawnLine = new Line(); 
                drawnLine.EnableDrawing(true);
            }
        }
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            drawnLine.EnableDrawing(false);

            
            HVector2D v = new HVector2D(transform.position.x - ball.transform.position.x, transform.position.y - ball.transform.position.y);
            ball.Velocity = v;

            drawnLine = null;        
        }

        if (drawnLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            drawnLine.end = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

 	/// <summary>
 	/// Get a list of active lines and deactivates them.
 	/// </summary>
 	public void Clear()
 	{
 		var activeLines = lineFactory.GetActive();

 		foreach (var line in activeLines)
 		{
 			line.gameObject.SetActive(false);
 		}
 	}
 }
