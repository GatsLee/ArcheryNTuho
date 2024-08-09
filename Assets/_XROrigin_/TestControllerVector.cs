using UnityEngine;

public class DrawLineTowardsTarget : MonoBehaviour
{
    public Transform target; // The target object whose forward direction we want to draw the line towards
    public float lineLength = 5.0f; // Length of the line to draw

    void Update()
    {
        if (target != null)
        {
            // Calculate the end point of the line based on the target's forward direction and specified length
            Vector3 endPoint = target.position + target.forward * lineLength;

            // Draw the line from the current object's position to the calculated end point
            Debug.DrawLine(transform.position, endPoint, Color.red);
        }
    }
}