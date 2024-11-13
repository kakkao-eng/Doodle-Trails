using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    public GameObject defaultSkin1;
    public GameObject defaultSkin2;
    public static GameObject skinToLoad;

    private void Awake()
    {
        if (skinToLoad != null)
        {
            Destroy(defaultSkin1);
            Destroy(defaultSkin2);
            Instantiate(skinToLoad, transform);
        }
    }
}
