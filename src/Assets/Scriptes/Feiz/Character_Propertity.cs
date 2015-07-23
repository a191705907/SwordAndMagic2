using UnityEngine;
using System.Collections;

public enum Career{
    Swordman,
    Magician
}



public class Character_Propertity {
    public int Character_MAX_HP, Character_MAX_MP, Character_MAX_EXP;
    public int Character_Current_HP, Character_Current_MP, Character_Current_EXP;
    public Career career;
    public int level, money;
    public int damage, defensive;
    public int currentTask;
}
