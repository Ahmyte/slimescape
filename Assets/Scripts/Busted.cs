using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Busted : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
