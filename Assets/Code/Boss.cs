using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using zeptolib;

public class Boss : LazySingletonBehaviour<Boss>
{
    // Start is called before the first frame update
    CardManager cardManager;
    World world;
    Human human;
    Hero hero;
    Prop prop;
    int camX = 0;
    int camY = 0;
    
    void Start()
    {
        Debug.Log("Hello World!");

        cardManager = new CardManager();
        cardManager.Populate("Assets/zeptolib/actions.csv");
        world = new World();
        world.Generate(10, 10);
        human = new Human();
        human.Setup();
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
        
        TextRenderer.Instance.Draw(world, human, camX, camY);
        
        int moveX = 0;
        int moveY = 0;
        Slot? slotKey = null;
        Keyboard keyboard = Keyboard.current;
        if (keyboard.upArrowKey.wasPressedThisFrame) { moveY = 1; }
        if (keyboard.downArrowKey.wasPressedThisFrame) { moveY = -1; }
        if (keyboard.leftArrowKey.wasPressedThisFrame) { moveX = -1; }
        if (keyboard.rightArrowKey.wasPressedThisFrame) { moveX = 1; }
        if (keyboard.digit1Key.wasPressedThisFrame) { slotKey = Slot.One; }
        if (keyboard.digit2Key.wasPressedThisFrame) { slotKey = Slot.Two; }
        if (keyboard.digit3Key.wasPressedThisFrame) { slotKey = Slot.Three; }
        if (keyboard.digit4Key.wasPressedThisFrame) { slotKey = Slot.Four; }
        if (keyboard.digit5Key.wasPressedThisFrame) { slotKey = Slot.Five; }
        if (keyboard.enterKey.wasPressedThisFrame) { slotKey = Slot.Cycle; }
        if (slotKey.HasValue)
        {
            human.SelectSlot(slotKey.Value);
        }
        else if (moveX != 0 || moveY != 0)
        {
            human.Move(moveX, moveY);
            human.Tick();
            world.MovePawn(human.pawn);
            camX = human.pawn.position.X;
            camY = human.pawn.position.Y;
        }
        else
        {
            human.Tick();
        }
    }
}
