using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    // 반지름 길이
    public float radius =0.1f;

    // 기즈모 그리기
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
