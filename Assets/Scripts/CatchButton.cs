using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProgressBar;

public class CatchButton : MonoBehaviour
{
    [SerializeField] ProgressBar catchBar;
    [SerializeField] SpawnObject spawnObject;
    public void CatchAnimal()
    {
        catchBar.Value += 0.2f;
        spawnObject.spawnedObj.GetComponentInChildren<Animator>().SetTrigger("Interaction");

        if(catchBar.Value>=1)
        {
            spawnObject.spawnedObj.GetComponentInChildren<Animator>().SetTrigger("Death");
        }
    }
}
