using UnityEngine;

public class EndGameHead : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGameManager.EndGame();
    }
}
