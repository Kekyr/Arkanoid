using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] private  LoseOrWinText _loseOrWinText;
    private List<GameObject> _bricks=new List<GameObject>();
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        CheckAmountOfDestroyedBricks();
    }

    private void CheckAmountOfDestroyedBricks()
    {
        if (_bricks.Count == 0)
        {
            _loseOrWinText.TurnOnLoseOrWinText(true);
        }
    }

    public void AddBrick(GameObject brick)
    {
        if (brick.GetComponent<Brick>())
        {
            _bricks.Add(brick);
        }
        else
        {
            Debug.Log("You try to add another object!");
        }
    }

    public void RemoveBrick(GameObject brick)
    {
        if (brick.GetComponent<Brick>())
        {
            _bricks.Remove(brick);
        }
        else
        {
            Debug.Log("You try to remove another object!");
        }
    }

}
