using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public LayerMask[] layer;
    public Vector3 prevPos;
    public Vector3 crx;

    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public Material capMaterial;

    public GameObject slash;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(DelayPosition());
    }

    IEnumerator DelayPosition()
    {
        yield return new WaitForSeconds(0.2f);
        crx = transform.position;
        StartCoroutine(DelayPosition());
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 2f, layer[0]))
        {
            if(Vector3.Angle(transform.position-prevPos, hit.transform.right * -1f) > 130)
            {
                m_cut();                
            }            
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f, layer[1]))
        {
            GameManager.instance.AddScore(-1);
            Destroy(hit.transform.gameObject);
            Instantiate(explosion, hit.point, Quaternion.LookRotation(hit.normal));
            audioSource.PlayOneShot(audioClips[1]);
        }
        prevPos = transform.position;        
    }

    void m_cut()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, layer[0]))
        {
            GameObject[] gameObjects = MeshCut.Cut(hit.collider.gameObject, transform.position, Vector3.Cross(transform.forward, prevPos - crx), capMaterial);
            
            if (!gameObjects[1].GetComponent<Rigidbody>())
            {
                gameObjects[1].AddComponent<BoxCollider>();
                gameObjects[1].AddComponent<Rigidbody>().AddForce(60f, 0f, 3f);
                Destroy(gameObjects[1], 1f);
            }

            hit.transform.gameObject.layer = LayerMask.NameToLayer("Default");
            
            hit.collider.isTrigger = false;
            hit.rigidbody.useGravity = true;
            hit.rigidbody.AddForce(-60f, 0f, 3f);

            Destroy(hit.transform.gameObject, 1f);
            Destroy(hit.transform.GetChild(0).transform.gameObject);

            GameManager.instance.AddScore(1);
            Instantiate(slash, hit.point, Quaternion.LookRotation(hit.normal));
            audioSource.PlayOneShot(audioClips[0]);
        }
    }
}
