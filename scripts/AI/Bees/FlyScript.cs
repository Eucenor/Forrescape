using UnityEngine;
using System.Collections;
 // this is a script for the random movement of the bees.
public class FlyScript : MonoBehaviour
{//speed of the bee
    public float speed = 1.5f;
    // how fast the bee changes direction (basically flips from left to right and vice versa)
    public float rotateSpeed = 5.0f;
 // current position of the bee. vector 3 is a struct that has 3 floats like float x,float y and float z. thats it.
    Vector3 newPosition;
 // start function automatically runs when the level loads and script is initialized
    void Start ()
    {
        PositionChange();
    }
 // gets a 
    void PositionChange()
    {
     // updating position of the bee. vector 2 has just x and y. z value of bee is by default 0 and will stay the same as z value denoted depth and ours is a 2d game only in x and y axis
     // original vector 2 is invoked like this for example
     // Vector2 somename = new Vector2(x_value, y_value);
     // similarly we are getting 2 random numbers since we want random movment for the bee. we get a random value for x axis between -2 and +2 units from the current position
     // and same thing for y axis
        newPosition = new Vector2(Random.Range(transform.position.x-2.0f, transform.position.x + 2.0f), Random.Range(transform.position.y - 2.0f, transform.position.y + 2.0f));
    }
   // update is called every frame or for example 30fps or 30 frames per second. so update is called 30 times in one second
    void Update ()
    {// if distance between current position and new position we calculated is less than 1 then get another new position since distance between current and new position is too less
        if(Vector2.Distance(transform.position, newPosition) < 1)
            PositionChange();
      // transform.position is the position of our bee its what we update to change our position. here what we do is use the lerp function, which smoothly changes our current
      // position to the new position by the speed we just provided up there.
      // for this time.delta time * speed, because we want the change/second and not change/frame.
        transform.position=Vector3.Lerp(transform.position,newPosition,Time.deltaTime*speed);
      // lookat changes where the bee is facing based on its current location
        LookAt2D(newPosition);
    }
 // dont mind this :)
    void LookAt2D(Vector3 lookAtPosition)
    {
        
    }
}
