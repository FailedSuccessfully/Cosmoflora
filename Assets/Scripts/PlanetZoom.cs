using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetZoom : MonoBehaviour
{
    float zoomIn = 1.0f;
    float zoomTime = 5f;
    float waitTime = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Player>().enabled = false;
        Camera.main.transform.LookAt(gameObject.transform);
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, zoomIn, zoomTime);
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Planet");
    }
}
