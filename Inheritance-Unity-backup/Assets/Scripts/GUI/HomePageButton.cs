using UnityEngine;
using System.Collections;

public class HomePageButton : MonoBehaviour
{
    public GameObject familyTree;

    public void FamilyTree()
    {
        familyTree.GetComponent<TweenPosition>().PlayForward();
    }

    public void Armory()
    {
        familyTree.GetComponent<TweenPosition>().PlayReverse();
    }

    public void Practice()
    {
        familyTree.GetComponent<TweenPosition>().PlayReverse();
    }

    public void Adventuring()
    {
        Application.LoadLevel("mainGame");
    }
}
