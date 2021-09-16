using UnityEngine;

public class WinPanel : MonoBehaviour
{
    private void Start()
    {
        GoalFlag goalFlag = FindObjectOfType<GoalFlag>();

        if (goalFlag != null)
        {
            goalFlag.OnWin.AddListener(() => gameObject.SetActive(true));
        }

        else
        {
            Debug.LogError("Scene is missing a GoalFlag object. Designer pls fix");
        }

        gameObject.SetActive(false);
    }
}
