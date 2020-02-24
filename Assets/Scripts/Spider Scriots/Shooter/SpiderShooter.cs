using System.Collections;
using UnityEngine;

public class SpiderShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    void Start()
    {
        StartCoroutine(Attak());
    }
    IEnumerator Attak()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(Attak());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();
            Destroy(collision.gameObject);
        }
    }
}
