using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class DestroyBones : MonoBehaviour
{

    float timeLimit = 3f;
    float time = 0f;

    private void Update()
    {
        time += Time.deltaTime;

        if (time > timeLimit)
        {
            Destroy(gameObject);
        }
    }


}
