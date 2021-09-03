using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedInteraction : MonoBehaviour
{
    [SerializeField] private static float _horizontalForce = 2;
    [SerializeField] private static float _verticalForce = 4;
    public static void ApplyDropForce(Rigidbody2D rigidbody)
    {
        Vector2 direction = new Vector2(Mathf.Cos(UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad) * _horizontalForce, Mathf.Sin(UnityEngine.Random.Range(0f, 180f) * Mathf.Deg2Rad) * _verticalForce);
        rigidbody.AddForce(direction, ForceMode2D.Impulse);
    }
}
