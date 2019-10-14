using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] levelComponents = null;
    [SerializeField] private float spawnRate = .1f;

    [SerializeField] private Color[] colors = null;
    private int currentColor = 0;

    GameManager gm;
    
    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        StartCoroutine(SpawnNewLevelComponent());
        StartCoroutine(GetManagers());
    }

    IEnumerator GetManagers()
    {
        yield return new WaitForSeconds(.1f);
        gm = FindObjectOfType<GameManager>();
    }

    IEnumerator SpawnNewLevelComponent()
    {
        while(true)
        {
            while(true)
            {
                GameObject spawn = levelComponents[Random.Range(0, levelComponents.Length)];

                if (Random.Range(0, 100) <= (spawn.GetComponent<LevelMover>().obstacleDifficulty + (gm.currentScore * 1)))
                {
                    GameObject newSpawn = Instantiate(spawn, transform);
                    LevelMover lm = newSpawn.GetComponent<LevelMover>();

                    if (gm.currentScore >= 10)
                    {
                        if(gm.currentScore > ((colors.Length/3) * 10))
                        {
                            currentColor = (currentColor + 3) % colors.Length;
                        }
                        else if (gm.currentScore % 10 == 0)
                        {
                            currentColor = (currentColor + 3) % colors.Length;
                        }
                    }
                    lm.SetColor(colors, currentColor);
                    break;
                }
            }
            
            yield return new WaitForSeconds(-Mathf.Log(gm.levelSpeed) * spawnRate + 5);
        }
    }
}