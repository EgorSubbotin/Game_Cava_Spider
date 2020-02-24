using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public static DoorScript instance;
    [SerializeField]
    public int collectablesCount;
    BoxCollider2D box;
    Animator anim, animExit;
    private void Awake()
    {
        animExit = GameObject.Find("Exit").GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        MakeInstance();
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void DecrementCollectables()
    {
        collectablesCount--;
        if (collectablesCount == 0)
        {
            StartCoroutine(OpenDoor());
        }
    }
    IEnumerator OpenDoor()
    {
        anim.Play("Door Animation");
        animExit.Play("Exit");
        yield return new WaitForSeconds(1f);
        box.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("LevelMenu");
        }
    }
}
