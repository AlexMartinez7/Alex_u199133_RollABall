using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObject : MonoBehaviour
{
    public float amplitude = 1f;
    public float speed = 2f;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
  
    }

    // Update is called once per frame
    void Update()
    {
      float offset = Mathf.Sin(Time.time * speed) * amplitude;
      transform.position = startPos + new Vector3(0, offset, 0);  
    }
}
