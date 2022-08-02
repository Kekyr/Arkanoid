using UnityEngine;

public class Lose : MonoBehaviour
{
    [SerializeField] private LoseOrWinText _loseOrWinText;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        _loseOrWinText.TurnOnLoseOrWinText(false);
    }
}
