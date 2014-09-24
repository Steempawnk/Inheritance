using UnityEngine;
using System.Collections;

public class ClassSelectionGUI : MonoBehaviour
{
    // 0 -- fighter
    public GameObject[] classCards;

    int currentSelection = 0;


    void Start()
    {
        ActiveCurrentSelection();
    }

    void ActiveCurrentSelection()
    {
        classCards[currentSelection].SetActive(true);
        //classCards[currentSelection].GetComponent<TweenScale>().PlayForward();
    }


    void DisableOtherCards()
    {
        for (int i = 0; i < classCards.Length; i++)
        {
            if (i != currentSelection)
                classCards[i].SetActive(false);
        }
    }

    void KeepInBounds()
    {
        if (currentSelection >= classCards.Length)
            currentSelection = 0;

        else if (currentSelection < 0)
            currentSelection = classCards.Length - 1;
    }

    public void ChangeClassToNext()
    {
        currentSelection++;
        KeepInBounds();
        ActiveCurrentSelection();
        DisableOtherCards();
    }

    public void ChangeClassToPrevious()
    {
        currentSelection--;
        KeepInBounds();
        ActiveCurrentSelection();
        DisableOtherCards();
    }
}
