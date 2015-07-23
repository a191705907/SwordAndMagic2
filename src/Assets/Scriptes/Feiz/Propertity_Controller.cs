using UnityEngine;
using System.Collections;

public class Propertity_Controller
{
    static Propertity_Controller instance;
    //获取单实例
    public static Propertity_Controller Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Propertity_Controller();
            }
            return instance;
        }
    }

    public Character_Propertity my_Propertity;

    //选择职业
    //type == 1 :选择swordman
    //type == 0 :选择magicman
    public void Propertity_Controller_Choose_Career(int type)
    {
        my_Propertity = new Character_Propertity();
        if (type == 1)
        {
            my_Propertity.career = Career.Swordman;
        }
        else
        {
            my_Propertity.career = Career.Magician;
        }
        Propertity_Controller_Init();
    }

    //初始化角色
    //不同职业不同属性
    public void Propertity_Controller_Init()
    {
        if (my_Propertity.career == Career.Magician)
        {
            my_Propertity.Character_MAX_HP = my_Propertity.Character_Current_HP = 100;
            my_Propertity.Character_Current_MP = my_Propertity.Character_Current_MP = 200;
            my_Propertity.defensive = 2;
            my_Propertity.damage = 10;
        }
        else
        {
            my_Propertity.Character_MAX_HP = my_Propertity.Character_Current_HP = 200;
            my_Propertity.Character_Current_MP = my_Propertity.Character_Current_MP = 100;
            my_Propertity.defensive = 5;
            my_Propertity.damage = 5;
        }
        my_Propertity.level = 1;
        my_Propertity.Character_MAX_EXP = 100;
        my_Propertity.Character_Current_EXP = 0;
        my_Propertity.money = 1000;
        my_Propertity.currentTask = 0;
    }

    public void Propertity_Controller_GetEXP(int exp)
    {
        my_Propertity.Character_Current_EXP += exp;
    }

    public void Propertity_Controller_GetMoney(int money)
    {
        my_Propertity.money += money;
    }

    //升级角色
    public void Propertity_Controller_Upgrade()
    {
        
        if (my_Propertity.career == Career.Magician)
        {
            my_Propertity.Character_MAX_HP = my_Propertity.Character_Current_HP = my_Propertity.Character_MAX_HP+10;
            my_Propertity.Character_Current_MP = my_Propertity.Character_Current_MP = my_Propertity.Character_Current_MP+20;
            my_Propertity.defensive += 1;
            my_Propertity.damage += 2;
        }
        else
        {
            my_Propertity.Character_MAX_HP = my_Propertity.Character_Current_HP = my_Propertity.Character_MAX_HP+20;
            my_Propertity.Character_Current_MP = my_Propertity.Character_Current_MP = my_Propertity.Character_Current_MP + 20;
            my_Propertity.defensive += 2;
            my_Propertity.damage += 1;
        }
        my_Propertity.level += 1;

    }
}
