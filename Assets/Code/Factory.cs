 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using zeptolib;


public enum GroundType
{
    OCEAN,
    BEACH,
    BEACHTOSANDY,
    SANDY,
    GRASSY,
    HILLY,
    ROCKY,
    MOUNTAIN,

}
public class Factory : LazySingletonBehaviour<Factory>
{

    public GameObject SquareTest;
    public GameObject OceanGround;
    public GameObject BeachGround;
    public GameObject BeachToSandyGround;
    public GameObject SandyGround;
    public GameObject GrassyGround;
    public GameObject HillyGround;
    public GameObject RockyGround;
    public GameObject MountainGround;


    public ZeptoSprite MakeGround(GroundType gtype, Transform parent, int x, int y)
    {
        GameObject go = null;
        switch(gtype)
        {
            case GroundType.OCEAN: go = OceanGround; break;
            case GroundType.BEACH: go = BeachGround; break;
            case GroundType.BEACHTOSANDY: go = BeachToSandyGround; break;
            case GroundType.SANDY: go = SandyGround; break;
            case GroundType.GRASSY: go = GrassyGround; break;
            case GroundType.HILLY: go = HillyGround; break;
            case GroundType.ROCKY: go = RockyGround; break;
            case GroundType.MOUNTAIN: go = MountainGround; break;
            default: break;

        }
        return MakeProtoGround(go, parent, x, y);
    }

    public ZeptoSprite MakeProtoGround(GameObject proto, Transform parent, int x, int y)
    {
        GameObject go = Instantiate(proto, parent);
        ZeptoSprite zs = go.AddComponent<ZeptoSprite>();
        zs.rect = go.GetComponent<RectTransform>();
        zs.MoveTo(x,y);
        go.name = "Ground"+x+","+y;
        return zs;
    }
}