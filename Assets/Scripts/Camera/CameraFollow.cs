using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 playerPosition;
    private Vector3 offset;

    //lerp experiment

    private bool shouldLerp = false;

    public float lerpTime;

    public Vector3 endPosition;
    public Vector3 nextPosition;
    public Vector3 startPosition;

    void Start()
    {
        StartLerping();
    }

    private void LateUpdate()
    {
        if (shouldLerp)
        {
            nextPosition = Lerp(startPosition, endPosition, lerpTime);


            transform.position = nextPosition;
        }
    }

    private void Update()
    {
        playerPosition = PlayerComponentService<Transform>.instance.position;
        offset = new Vector3(0, 3, -10);
        startPosition = transform.position;
        endPosition = playerPosition + offset;
    }

    private void StartLerping()
    {
        lerpTime = Time.time;
        shouldLerp = true;
    }

    public Vector3 Lerp(Vector3 start, Vector3 end, float lerpTime = 1)
    {
        float timeSinceStarted = Time.deltaTime;

        float percentageComplete = timeSinceStarted / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }
}
