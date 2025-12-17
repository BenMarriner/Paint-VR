using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBrush : MonoBehaviour
{
    public Color CurrentPaintColour = Color.green;
    public Color PaintlessColour = Color.orange;
    public int brushSize = 100;
    public Transform paintTracerTransform;

    Material brushHeadMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        Configure();
        Physics.IgnoreCollision(GameManager.Player.GetComponent<Collider>(), GetComponent<Collider>());
    }


    // Update is called once per frame
    void Update()
    {
        EvaluatePaintableSurface();
    }

    private void OnTriggerEnter(Collider other)
    {
        var bucketComponent = other.GetComponent<PaintBucket>();
        if (bucketComponent != null) SetBrushColour(bucketComponent.paintColour);
    }

    private void OnCollisionEnter(Collision other)
    {
        var bucketComponent = other.transform.root.GetComponent<PaintBucket>();
        if (bucketComponent != null)
        {
            Physics.IgnoreCollision(GetComponent<MeshCollider>(), bucketComponent.GetComponentInChildren<MeshCollider>());
        }
    }

    private void Configure()
    {
        brushHeadMaterial = GetComponent<MeshRenderer>().materials[1];
        SetBrushColour(PaintlessColour);
    }

    public void SetBrushColour(Color brushColour)
    {
        brushHeadMaterial.color = brushColour;
        CurrentPaintColour = brushColour;
    }

    private void EvaluatePaintableSurface()
    {
        Vector3 rayStartPos = paintTracerTransform.position;
        Vector3 rayDirection = transform.up;
        RaycastHit hit;


        if (Physics.Raycast(rayStartPos, rayDirection, out hit, 0.125f))
        {
            var paintable = hit.transform.gameObject.GetComponent<Paintable>();

            if (paintable)
            {
                print("Touching paintable surface");
                
                Texture2D tex = paintable.surfaceTexture;
                Vector2 pixelUV = hit.textureCoord;
                pixelUV.x *= tex.width;
                pixelUV.y *= tex.height;

                for (int x = -(brushSize / 2); x < brushSize / 2; x++)
                {
                    for (int y = -(brushSize / 2); y < brushSize / 2; y++)
                    {
                        tex.SetPixel((int)pixelUV.x + x, (int)pixelUV.y + y, CurrentPaintColour);
                    }
                }

                tex.Apply();
            }
        }
    }
}
