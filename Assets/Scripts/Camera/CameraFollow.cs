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
    public float xMin = -1.0f, xMax = 1.0f;
    public float yMin = 3.0f, yMax = 6.0f;
    public float nextPositionX;
    public float nextPositionY;

    public Vector3 endPosition;
    public Vector3 nextPosition;
    public Vector3 startPosition;

    void Start()
    {
        StartLerping();
    }
    private void Update()
    {
        playerPosition = GameSession.player.transform.position;
        offset = new Vector3(0, 1, -10);
        startPosition = transform.position;
        endPosition = playerPosition + offset;
    }

    private void LateUpdate()
    {
        if (shouldLerp)
        {
            nextPosition = Lerp(startPosition, endPosition, lerpTime);
            nextPositionX = Mathf.Clamp(nextPosition.x, xMin, xMax);
            nextPositionY = Mathf.Clamp(nextPosition.y, yMin, yMax);

            transform.position = new Vector3(nextPositionX, nextPositionY, transform.position.z);
        }
    }


    private void StartLerping()
    {
        lerpTime = 1.5f;
        shouldLerp = true;
    }

    public Vector3 Lerp(Vector3 start, Vector3 end, float lerpTime = 1.5f)
    {
        float timeSinceStarted = Time.deltaTime;

        float percentageComplete = timeSinceStarted / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }
}
