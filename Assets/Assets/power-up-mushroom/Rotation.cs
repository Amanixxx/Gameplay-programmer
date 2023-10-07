
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 200f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0), Space.World);
    }
}
