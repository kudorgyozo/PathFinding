using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloScript : MonoBehaviour
{
    public int spacing = 1;
    public int maxHeight = 100;
    public float nodeSize = 0.15f;
    private const int levelSize = 15;

    private Vector3[,] nodes;
    private Vector3 startPos;
    private Vector3 nullNode = new Vector3(500, 500, 500);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    public void BuildNodes()
    {
        Debug.Log("BuildNodes");
        //nodes = new Vector3[levelSize, levelSize];
        //startPos = transform.position;

        //Vector3 dir = Vector3.forward;
        //RaycastHit hit; 

        //for (int x = 0; x < levelSize; x++)
        //{
        //    for (int y = 0; y < levelSize; y++)
        //    {
        //        Vector3 rayStart = new Vector3(startPos.x + spacing * x, startPos.y + spacing * y, -maxHeight);

        //        if (Physics.Raycast(new Ray(rayStart, dir), out hit))
        //            nodes[x, y] = hit.point;
        //        else
        //            nodes[x, y] = nullNode;
        //    }
        //}

    }
    

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector3(0.25f, 0.25f, 0.25f));
        if (nodes == null) return;
        for (int x = 0; x < levelSize; x++)
        {
            for (int y = 0; y < levelSize; y++)
            {
                if (nodes[x,y] != nullNode)
                    Gizmos.DrawCube(nodes[x,y], new Vector3(nodeSize, nodeSize, nodeSize));
            }
        }

    }

}
