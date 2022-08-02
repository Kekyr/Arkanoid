using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance { get; private set; }
    
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
    
    public float ChangePlatformPositionByTouch()
    {
        Touch touch = Input.GetTouch(0);
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        return touchPosition.x;
    }
    
    public float ChangePlatformPositionByMouse()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x,0);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return mousePosition.x;
    }

    public bool CheckTouchCount()
    {
        if (Input.touchCount > 0)
        {
            return true;
        }
        return false;
    }

    public bool CheckMouseButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    }
}
