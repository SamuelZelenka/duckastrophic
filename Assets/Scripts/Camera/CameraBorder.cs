using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorder : MonoBehaviour
{
    private float height = 0f;
    private float width = 0f;

    private Vector2[] edgePoints = new Vector2[5];

    void Start()
    {
        height = Camera.main.pixelHeight;
        width = Camera.main.pixelWidth;
        
        edgePoints[0] = Camera.main.ScreenToWorldPoint(new Vector3(width, 0, 0)) - transform.position;
        edgePoints[1] = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)) - transform.position;
        edgePoints[2] = Camera.main.ScreenToWorldPoint(new Vector3(0, height, 0)) - transform.position;
        edgePoints[3] = Camera.main.ScreenToWorldPoint(new Vector3(width, height, 0)) - transform.position;
        edgePoints[4] = edgePoints[0];
        

        GetComponent<EdgeCollider2D>().points = edgePoints;
    }
}
