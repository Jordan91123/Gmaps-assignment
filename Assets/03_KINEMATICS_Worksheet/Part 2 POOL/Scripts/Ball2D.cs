 using System;
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

 public class Ball2D : MonoBehaviour
 {
     public HVector2D Position = new HVector2D(0, 0);
     public HVector2D Velocity = new HVector2D(0, 0);
    
     [HideInInspector]
     public float Radius;

     private void Start()
     {
         Position.x = transform.position.x;
         Position.y = transform.position.y;

         Sprite sprite = GetComponent<SpriteRenderer>().sprite;
         Vector2 sprite_size = sprite.rect.size;
         Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
         Radius = local_sprite_size.x / 2f;

        //example 1
        HVector2D a = new HVector2D(8f, 5f);
        HVector2D b = new HVector2D(1f, 3f);
        float distance = Util.FindDistance(a, b);
        Debug.Log("distance betwwen a and b:" + distance);

        //example 2
        /*HVector2D a = new HVector2D(10f, 4f);
        HVector2D b = new HVector2D(5f, 5f);
        float distance = Util.FindDistance(a, b);
        Debug.Log("distance betwwen a and b:" + distance);*/

        //example 3
        /*HVector2D a = new HVector2D(20f, 5f);
        HVector2D b = new HVector2D(4f, 10f);
        float distance = Util.FindDistance(a, b);
        Debug.Log("distance betwwen a and b:" + distance);*/
    }

    public bool IsCollidingWith(float x, float y)
    {
        float distance = Mathf.Sqrt((x - transform.position.x) * (x - transform.position.x) + (y - transform.position.y) * (y - transform.position.y));
        return distance <= Radius;
    }

    /*public bool IsCollidingWith(Ball2D other)
    {
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }*/

    /*public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }*/

    /*private void UpdateBall2DPhysics(float deltaTime)
    {
        float displacementX = *//*your code here*//*;
        float displacementY = *//*your code here*//*;

        Position.x += *//*your code here*//*;
        Position.y += *//*your code here*//*;

        transform.position = new Vector2(*//*your code here*//*);
    }*/
}

