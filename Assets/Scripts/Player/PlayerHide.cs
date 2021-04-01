using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHide : MonoBehaviour
{
    [HideInInspector] public bool isHiding;
    [HideInInspector] public bool isCanHide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hideout"))
            isCanHide = true;

        if (collision.CompareTag("Enemy"))
        {
            if (!isHiding)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);                
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hideout"))
            isCanHide = false;
    }

    void Hide()
    {
        
    }
}