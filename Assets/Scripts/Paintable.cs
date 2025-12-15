using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    public int surfaceMaterialIdx;

    [HideInInspector]
    public Texture2D surfaceTexture;

    // Start is called before the first frame update
    void Start()
    {
        Material surfaceMaterial = GetComponent<MeshRenderer>().materials[surfaceMaterialIdx];
        surfaceTexture = surfaceMaterial.mainTexture as Texture2D;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
