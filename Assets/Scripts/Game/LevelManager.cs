// LevelManager
// By: Lex King
// Place onto Primary Level object
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int lives;
    public Transform spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
//        GameManager.instance.lives = lives;
        GameManager.instance.SpawnPlayer(spawnLocation);
        GameManager.instance.currentLevel = GetComponent<LevelManager>();
    }


}
