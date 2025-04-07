using UnityEngine;

public class RotatePU : MonoBehaviour
{
    
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 60) * Time.deltaTime); 
    }

}
