
using Sirenix.OdinInspector;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Test : More
{
    [AssetSelector]
    public string String;
    [Title("Bitmask Enum")]
    [EnumToggleButtons]
    public wepons _wepons;
    [EnumToggleButtons, HideLabel]
    public wepons _weponAs;
    [InspectorRange(0f, 1f)] public float range;
    private JewelrySlot _health { get; set; }
    private int _healthAmound { get; set; }
    private More more;

    [MinMaxSlider(10, 50)]
    public Vector2 DynamicRange = new Vector2(0, 50);
    [Title("DEFALT")]
    public Button BUTTON;
    
    public float BUTTON1;
 
    public Test()
        {
        _health = JewelrySlot.ring;
        
        }
    public Test(JewelrySlot health)
    {
        _health = health;
     
    }


    private void Start()
    {
      
      
      
        player = 20;
    }
    private void Update()
    {
        Guns(_wepons);
    }

    public void Guns(wepons wepons)
    {
        switch (wepons)
        {
            case wepons.gun:
                print("Good");
                break;
            case wepons.sniper:
                break;
            case wepons.scar:
                break;
            case wepons.autoGun:
                break;
            default:
                break;
        }
    }
}
public enum JewelrySlot
{
    ring,
    chain,
}
