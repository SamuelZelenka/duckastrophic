using System.Collections;
using System.Collections.Generic; // unused namespaces
using UnityEngine;

public class GoalFlag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        Debug.Log("You wiiiin weee:)::):):)"); //implement actual win code
    }
}
