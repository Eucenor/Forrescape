using UnityEngine;
using System.Collections;
 
public class FlyScript : MonoBehaviour
{
    public float speed = 1.5f;
    public float rotateSpeed = 5.0f;
 
    Vector3 newPosition;
 
    void Start ()
    {
        PositionChange();
    }
 
    void PositionChange()
    {
        newPosition = new Vector2(Random.Range(transform.position.x-2.0f, transform.position.x + 2.0f), Random.Range(transform.position.y - 2.0f, transform.position.y + 2.0f));
    }
   
    void Update ()
    {
        if(Vector2.Distance(transform.position, newPosition) < 1)
            PositionChange();
 
        transform.position=Vector3.Lerp(transform.position,newPosition,Time.deltaTime*speed);
 
        LookAt2D(newPosition);
    }
 
    void LookAt2D(Vector3 lookAtPosition)
    {
        
    }
}