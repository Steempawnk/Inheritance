using UnityEngine;
using System.Collections;

public class TransitToScene_GUI : MonoBehaviour
{
    public string TransitToScene;

    public void TransitScene()
    {
        Application.LoadLevel(TransitToScene);
    }


    public void TransitToMainGame()
    {
        Application.LoadLevel("mainGame");
    }
}
