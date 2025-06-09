using UnityEngine;

public class RotateOnSpawn : MonoBehaviour
{
    private void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);

    }
}