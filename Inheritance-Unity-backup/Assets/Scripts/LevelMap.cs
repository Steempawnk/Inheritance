using UnityEngine;
using System.Collections;

public class LevelMap : MonoBehaviour
{

    public Transform entryPoint;
    public Transform exitPoint;

    public Transform GetEntry()
    {
        return entryPoint;
    }


    public Transform GetExit()
    {
        return exitPoint;
    }
}
