using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using zeptolib;

public class TextRenderer : LazySingletonBehaviour<TextRenderer>
{
    public Text text;
    public int radius = 4;
    private StringBuilder sb = new StringBuilder();
    public void Draw(World w, Human h, int x, int y)
    {
        sb.Clear();
        
        int row=0;
        sb.AppendLine("Hero, the hero: X" + x + " Y" + y);
        row++;

        for(int yy=y+radius; yy>=y-radius; --yy)
        {
            for(int xx=x-radius; xx<=x+radius; ++xx)
            {
                IRenderable obj = null;
                if(obj == null)
                {
                    obj = w.GetPawn(xx,yy);
                }
                if(obj == null)
                {
                    obj = w.GetProp(xx,yy);
                }
                if(obj == null)
                {
                    obj = w.GetTile(xx,yy);
                }
                if(obj != null) {
                    sb.Append(obj.GetChar());
                }
                else
                {
                    sb.Append('~');
                }
            }
            if(row >=2 && row <= 6)
            {
                int itx = row-2;
                if(h.items.Count > itx)
                {
                    sb.Append("  ["+(itx+1)+"] ");
                    sb.Append(h.items[itx].Name);
                }
            }
            sb.AppendLine("");
            row++;
        }
        text.text = sb.ToString();

    }
}