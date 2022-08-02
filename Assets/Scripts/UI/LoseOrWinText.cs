using TMPro;
using UnityEngine;

public class LoseOrWinText : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    
    public void TurnOnLoseOrWinText(bool isWin)
    {
        if (isWin)
        {
            _textMeshPro.text = "Победа!";
        }
        else
        {
            _textMeshPro.text = "Поражение!";
        }
        _textMeshPro.enabled=true;
    }
}
