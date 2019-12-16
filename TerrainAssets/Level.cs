using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    [SerializeField]
    Texture2D textures;

    [SerializeField]
    Texture2D heightMap;

    [SerializeField]
    private GameObject[] objs;

    [SerializeField]
    private Color[] colors;

    [SerializeField]
    private Color[] heights;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < textures.width; i++)
        {
            for (int j = 0; j < textures.height; j++)
            {
                int level = 0;
                for (int l = 0; l < heights.Length; l++)
                {
                    if (heightMap.GetPixel(i, j) == heights[l])
                    {
                        level = l;
                    }
                }
                for (int k = 0; k < colors.Length; k++)
                {
                    if (textures.GetPixel(i,j) == colors[k])
                    {
                        Vector3 pos = new Vector3(3 * i, 0, 3 * j);
                        GameObject temp = Instantiate<GameObject>(objs[k], pos, Quaternion.identity);
                        temp.transform.localScale = new Vector3(temp.transform.localScale.x , temp.transform.localScale.y* (level + 1), temp.transform.localScale.z);
                    }
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
