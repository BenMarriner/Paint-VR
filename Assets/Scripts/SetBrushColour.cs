using UnityEngine;

public class SetBrushColour : MonoBehaviour
{
    PaintBrush brush;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Equals(other.gameObject, GameManager.ObjectInLeftHand)
            || Equals(other.gameObject, GameManager.ObjectInRightHand))
        {

        }    
            
    }
}
