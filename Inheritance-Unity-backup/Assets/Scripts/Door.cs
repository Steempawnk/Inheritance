using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public enum DoorType
    {
        entry, exit
    }

    public DoorType doortype;

    GameManager gm;
    Camera mainCam;

    // Use this for initialization
    void Start()
    {
        mainCam = Camera.main;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            switch (doortype)
            {
                case DoorType.entry:
                    gm.MovePlayerToPreviousLevel();
                    break;

                case DoorType.exit:
                    gm.MovePlayerToNextLevel();
                    print("hit exit");
                    break;
            }
        }
    }

    public void SetGM(GameManager GM)
    {
        this.gm = GM;
    }

}
