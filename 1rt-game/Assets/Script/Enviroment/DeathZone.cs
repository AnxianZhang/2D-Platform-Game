using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathZone : MonoBehaviour
{
    private Transform spawnPoint;

    private void Start()
    {
        this.spawnPoint = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //StartCoroutine(loadingTime(collision));
            collision.transform.position = spawnPoint.position;
            collision.transform.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    //private IEnumerator loadingTime(Collider2D _collision)
    //{
    //    this.loadSys.SetTrigger("FadeIn");
    //    yield return new WaitForSeconds(1f);
    //    _collision.transform.position = spawnPoint.position;
    //    _collision.transform.GetComponent<SpriteRenderer>().flipX = false;
    //}
}
