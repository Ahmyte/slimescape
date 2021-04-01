using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    GameController gameController;
    CameraMovement cameraMovement;

    void Start()
    {
        cameraMovement = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameController.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gameController.GameOver();
        }

        if(collision.CompareTag("End"))
        {
            SceneManager.LoadScene(0);
        }

        if (collision.CompareTag("CameraStart"))
        {
            /*cameraMovement.canAscend = true;
            print("a");*/
        }
    }
}
