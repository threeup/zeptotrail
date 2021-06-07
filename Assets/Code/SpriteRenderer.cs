using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using zeptolib;

public class SpriteRenderer : LazySingletonBehaviour<SpriteRenderer>
{
    public GameObject StretchPanel;
    public int radius = 3;

    public void Setup()
    {
        if(StretchPanel == null)
        {
            StretchPanel = this.gameObject;
        }
        
        int x=0;
        int y=0;
        Transform parent = StretchPanel.transform;
        for(int yy=y+radius; yy>=y-radius; --yy)
        {
            for(int xx=x-radius; xx<=x+radius; ++xx)
            {
                if(yy<-3)
                {
                    Factory.Instance.MakeGround(GroundType.OCEAN, parent, xx, yy);
                }
                else if(yy==-3)
                {
                    Factory.Instance.MakeGround(GroundType.BEACH, parent, xx, yy);
                }
                else if(yy==-2)
                {
                    Factory.Instance.MakeGround(GroundType.BEACHTOSANDY, parent, xx, yy);
                }
                else if(xx==0 && yy==1)
                {
                    Factory.Instance.MakeGround(GroundType.MOUNTAIN, parent, xx, yy);
                }
                else if(UnityEngine.Random.value > 0.5f)
                {
                    Factory.Instance.MakeGround(GroundType.GRASSY, parent, xx, yy);
                }
                else if(UnityEngine.Random.value > 0.5f)
                {
                    Factory.Instance.MakeGround(GroundType.HILLY, parent, xx, yy);
                }
                else
                {
                    Factory.Instance.MakeGround(GroundType.ROCKY, parent, xx, yy);
                }
            }
        }
/*
        for(int xx=-1; xx<=1; ++x)
        {
            Factory.Instance.MakeSquareTest(StretchPanel.transform, xx, 0);
            
        }*/
    }
    public void Draw(World w, Human h, int x, int y)
    {
        
        for(int yy=y+radius; yy>=y-radius; --yy)
        {
            for(int xx=x-radius; xx<=x+radius; ++xx)
            {
                w.GetPawn(xx,yy);
                w.GetProp(xx,yy);
                w.GetTile(xx,yy);
                
            }
            
        }

    }
}