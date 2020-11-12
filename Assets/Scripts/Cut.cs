using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    public GameObject spawner;
    public Material capMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            spawner.SetActive(true);
            m_Cut();
            Destroy(gameObject, 1f);
        }
    }

    void m_Cut()
    {
        GameObject[] gameObjects = MeshCut.Cut(gameObject, transform.position + Vector3.up * 1.5f, Vector3.down, capMaterial);
        if (!gameObjects[1].GetComponent<Rigidbody>())
        {
            gameObjects[1].AddComponent<BoxCollider>();
            gameObjects[1].AddComponent<Rigidbody>().AddForce(0f, 0f, 3f);
            Destroy(gameObjects[1], 1f);
        }

        gameObject.layer = LayerMask.NameToLayer("Default");


    }
}
