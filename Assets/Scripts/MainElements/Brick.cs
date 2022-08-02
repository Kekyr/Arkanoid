using UnityEngine;

public class Brick : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.AddBrick(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameManager.instance.RemoveBrick(gameObject);
    }
}
