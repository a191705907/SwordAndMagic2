using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Career{
    Swordman,
    Magician
}

public class Items{
}

public class Character_Propertity {
    public int Character_MAX_HP, Character_MAX_MP, Character_MAX_EXP;
    public int Character_Current_HP, Character_Current_MP, Character_Current_EXP;
    public Career career;
    public float criticalRate;
    public int level, money;
    public int AD,AP, defensive;
    public int currentTask;
    public Items[] equipments = new Items[6];  
}
