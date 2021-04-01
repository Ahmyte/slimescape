using UnityEngine;

public class GameController : MonoBehaviour
{
    CameraMovement cameraMovement;
    //bool isGameOver;

    void Start()
    {
        cameraMovement = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();
    }


    public void LevelCompleted()
    {

    }

    public void GameOver()
    {
        cameraMovement.canAscend = false;
    }
}
