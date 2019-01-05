using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateMap()
    {
        System.Random rnd = new System.Random();
        int width = 28;
        int height = 32;
        for (int x = -1 * width / 2; x < width / 2; x++)
        {
            for (int z = -1 * height / 2; z < height / 2; z++)
            {
                bool firstOrLast = x == -1 * width / 2 ||
                    x == width / 2 - 1 ||
                    z == -1 * height / 2 ||
                    z == height / 2 - 1;
                bool everySecond = z % 2 == 0 && x % 2 == 0;
                bool random = rnd.Next(5) == 0;
                if (firstOrLast || random)
                {
                    this.CreateWall(x, z);
                }
            }
        }
    }

    GameObject CreateWall(int x, int z)
    {
        Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Wall.prefab", typeof(GameObject));
        GameObject clone = Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity) as GameObject;
        return clone;
    }
}
