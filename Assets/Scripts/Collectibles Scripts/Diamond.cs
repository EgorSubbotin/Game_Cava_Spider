using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void Start()
    {
        if (DoorScript.instance != null)
            DoorScript.instance.collectablesCount++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            if (DoorScript.instance != null)
                DoorScript.instance.DecrementCollectables();
        }
    }
}
