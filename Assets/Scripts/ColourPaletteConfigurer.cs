using NUnit.Framework;
using System.Linq;
using UnityEngine;

public class ColourPaletteConfigurer : MonoBehaviour
{
    public int PaletteSlotIdxRangeMin;
    public int PaletteSlotIdxRangeMax;

    [SerializeField]
    public Color[] Colours;

    private int numSlots;
        
    void Start()
    {
        Material[] materials = GetComponent<MeshRenderer>().materials;
        
        numSlots = PaletteSlotIdxRangeMax - PaletteSlotIdxRangeMin;

        int i = PaletteSlotIdxRangeMin;
        int c = 0;
        while (c < Colours.Length && i <= PaletteSlotIdxRangeMax)
        {
            materials[i].color = Colours[c];
            i++; c++;
        }
        
    }
}
