using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]Transform initialPointGrid;
    [SerializeField] float size = 0.5f;
    [SerializeField] float padding = 0.2f;
    int[,] grid;

    // Start is called before the first frame update
    void Start()
    {
         grid = new int[7,7];

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                int rand = Random.Range(0, 2);
                grid[i,j] = rand;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Gizmos.DrawCube(initialPointGrid.position + new Vector3(i+size*0.5f +padding,-(j+size*0.5f+padding), 0), Vector3.one * size);
            }
        }
    }
}
