using UnityEngine;
using UnityEngine.Events;

public class GoalFlag : MonoBehaviour
{
    public UnityEvent OnWin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            OnWin.Invoke();
        }
    }
}
