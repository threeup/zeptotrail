using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using zeptolib;

public class Boss : LazySingletonBehaviour<Boss>
{
    // Start is called before the first frame update

    World world;
    Human human;
    Hero hero;
    Prop prop;
    void Start()
    {
        Debug.Log("Hello World!");

        world = new World();
        world.Generate(10, 10);
        human = new Human();
        hero = new Hero();
        human.Possess(hero);
        world.AddPawn(hero);
        prop = new Prop();
        prop.position.Set(3, 3, 0);
        world.AddProp(prop);


        SpriteRenderer.Instance.Setup();


    }

    // Update is called once per frame
    void Update()
    {
        int camX = 0;
        int camY = 0;
        Action.Slot? inputKey = null;
        
        TextRenderer.Instance.Draw(world, human, camX, camY);
        
        inputKey = null;
        Keyboard keyboard = Keyboard.current;
        if(keyboard.upArrowKey.wasPressedThisFrame)
        {
            camY += 1;
        }
        if(keyboard.downArrowKey.wasPressedThisFrame)
        {
            camY -= 1;
        }
        if(keyboard.leftArrowKey.wasPressedThisFrame)
        {
            camX -= 1;
        }
        if(keyboard.rightArrowKey.wasPressedThisFrame)
        {
            camX += 1;
        }
        if(keyboard.digit1Key.wasPressedThisFrame) { inputKey = Action.Slot.One; }
        if(keyboard.digit2Key.wasPressedThisFrame) { inputKey = Action.Slot.Two; }
        if(keyboard.digit3Key.wasPressedThisFrame) { inputKey = Action.Slot.Three; }
        if(keyboard.digit4Key.wasPressedThisFrame) { inputKey = Action.Slot.Four; }
        if(keyboard.digit5Key.wasPressedThisFrame) { inputKey = Action.Slot.Five; }
        if(keyboard.spaceKey.wasPressedThisFrame) { inputKey = Action.Slot.Cycle; }
        if (inputKey.HasValue)
        {
            human.DoAction(inputKey.Value);
            human.Tick();
            camX = human.pawn.position.X;
            camY = human.pawn.position.Y;
        }
        else
        {
            human.Tick();
        }
    }
}
