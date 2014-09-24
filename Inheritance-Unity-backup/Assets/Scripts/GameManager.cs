using UnityEngine;
using System.Collections;

[System.Serializable]
public class Prefabs
{
    public GameObject player_prefab;
    public GameObject boo_prefab;

    public LevelMap[] levels;
}

public class GameManager : MonoBehaviour
{
    public Prefabs prefab;

    GameObject player;
    Camera mainCam;

    int current_level = 0;

    void Start()
    {
        // create player
        player = Instantiate(prefab.player_prefab, prefab.levels[current_level].GetEntry().transform.position, Quaternion.identity) as GameObject;

        // init camera
        mainCam = Camera.main;

        // set gm for obejcts
        foreach (LevelMap lvl in prefab.levels)
        {
            lvl.GetEntry().gameObject.GetComponent<Door>().SetGM(this);
            lvl.GetExit().gameObject.GetComponent<Door>().SetGM(this);
        }

    }

    public void MovePlayerToNextLevel()
    {
        current_level++;

        if (current_level >= prefab.levels.Length)
        {
            current_level = prefab.levels.Length;
            print("last level");
            return;
        }

        player.transform.position = prefab.levels[current_level].GetEntry().position;
    }

    public void MovePlayerToPreviousLevel()
    {
        current_level--;

        if (current_level < 0)
        {
            current_level = 0;
            print("first level, going home");
            GoHome();
            return;
        }

        player.transform.position = prefab.levels[current_level].GetExit().position;
    }

    void GoHome()
    {

    }

}
