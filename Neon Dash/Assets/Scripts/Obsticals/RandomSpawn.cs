using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] parts = null;
    [SerializeField] Vector3[] zones = null;
    [SerializeField] Vector3[] offset = null;
    public int maxZoneLength = 8;
    public int maxZoneWidth = 5;

    void Start()
    {
        //Debug.Break();
        //Debug.Log("Starting Script");
        //foreach(GameObject part in parts)

        Vector3 parentPos = gameObject.transform.position;

        for(int i = 0; i < parts.Length; i++)
        {
            Vector3 newPos = new Vector3(Random.Range(-zones[i].x/2, zones[i].x/2), Random.Range(-zones[i].y/2, zones[i].y)/2, 0);

            Vector3 spawnPos = parentPos + newPos + offset[i];
            parts[i].transform.position = spawnPos;
        }
    }

    /* DEV BUILD ONLY */
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, .5f, .5f, .5f);
        Gizmos.DrawCube(gameObject.transform.position, new Vector3(maxZoneWidth * 2, maxZoneLength * 2, 1));

        Gizmos.color = new Color(.7f, 0f, 0f, .7f);
        for (int i = 0; i < zones.Length; i++)
        {
            Gizmos.DrawCube(gameObject.transform.position + offset[i], zones[i]);
        }
    }
}
