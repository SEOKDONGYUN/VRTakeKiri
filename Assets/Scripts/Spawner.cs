using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject fever;
    public GameObject[] cubes;
    public Transform[] points;
    public float beat = (60/130.0f)*2;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover == false)
        {
            if (timer > beat)
            {
                int cubeL = cubes.Length;
                int pointL = points.Length;
                //GameObject cube = Instantiate(cubes[Random.Range(0, 2)], points[Random.Range(0, 4)]);

                GameObject cube = Instantiate(cubes[Random.Range(0, cubeL)], points[Random.Range(0, pointL)]);

                cube.transform.localPosition = Vector3.zero;
                cube.transform.Rotate(transform.up, 180 * Random.Range(0, 3));
                timer -= beat;
            }
            timer += Time.deltaTime;

            if (GameManager.instance.combo == 7)
            {
                GameObject pi = Instantiate(fever, points[0]);
                pi.transform.localPosition = Vector3.zero;
                pi.transform.Rotate(transform.up, 180 * Random.Range(0, 3));
                GameManager.instance.combo = 0;
            }
        }
    }
}
