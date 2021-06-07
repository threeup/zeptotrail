using UnityEngine;
public class ZeptoSprite: MonoBehaviour
{
    public RectTransform rect;

    public void MoveTo(int x, int y)
    {
        int padding = 8;
        int rightFromRow = x*85;
        int rightFromColumnShift = y*48;
        int rightFromPadding = x*padding+y*padding;
        int downFromColumn = y*43;
        int downFromRowShift = x*12;
        int downFromPadding = y*padding;
        rect.anchoredPosition = new Vector2(
            rightFromRow + rightFromColumnShift + rightFromPadding,
            downFromColumn - downFromRowShift + downFromPadding);
    }

    public void ExactMoveTo(int x, int y)
    {
        int rightFromRow = x*85;
        int rightFromColumnShift = y*48;
        int downFromColumn = y*43;
        int downFromRowShift = x*12;
        rect.anchoredPosition = new Vector2(
            rightFromRow + rightFromColumnShift,
            downFromColumn - downFromRowShift);
    }

    
}