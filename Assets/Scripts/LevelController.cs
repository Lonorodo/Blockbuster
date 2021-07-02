using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int totalBlocks;
    SceneLoader sceneLoader;
    

    public void CountBreakableBlock()
    {

        totalBlocks++;

    }

   public void DestroyBlock()
    {
        totalBlocks--;
        if (totalBlocks <= 0)
           {

            sceneLoader.LoadNextScene();

           }

    }
    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

    }

   
}
