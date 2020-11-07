using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColl : MonoBehaviour
{
    int x = 0;
    public void Start()
    {
        StartCoroutine(AA());
        StartCoroutine(BB());
        Debug.LogError(x);
    }
    public IEnumerator AA()
    {

        while (x < 10)
        {
            x++;
            Debug.LogError(x + "--");
            yield return null;
        }
    }
    public IEnumerator BB()
    {

        while (x < 10)
        {
            x++;
            Debug.LogError(x + "===");
            yield return null;
        }
    }
}
