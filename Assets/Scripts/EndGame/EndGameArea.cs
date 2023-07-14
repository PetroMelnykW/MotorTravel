using UnityEngine;

public class EndGameArea : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Vehicle>() != null) {
            EndGameManager.EndGame();
        }
    }
}
