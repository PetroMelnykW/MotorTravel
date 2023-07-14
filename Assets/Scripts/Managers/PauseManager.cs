using UnityEngine;
using Events;

public class PauseManager : MonoBehaviour
{
    public static void SetPause(bool pause)
    {
        if (pause) {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }

    private void Awake()
    {
        Observer.Subscribe<EndGameEvent>(OnEndGameEvent);
        SetPause(false);
    }

    private void OnDestroy()
    {
        Observer.Unsubscribe<EndGameEvent>(OnEndGameEvent);
    }

    private void OnEndGameEvent(object sender, EndGameEvent eventData)
    {
        SetPause(true);
    }
}
