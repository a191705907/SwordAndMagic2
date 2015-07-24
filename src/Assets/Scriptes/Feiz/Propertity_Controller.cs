using UnityEngine;
using System.Collections;

public class Propertity_Controller : MonoBehaviour
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
    public void Propertity_Controller_Choose_Magician()
    {
        my_Propertity = new Character_Propertity();
        GameObject man = GameObject.FindWithTag("Player");
        if (man != null)
        {
            Destroy(man.GetComponent<Character_Controller>());
            Destroy(man);
        }
            my_Propertity.career = Career.Magician;
            GameObject a = Instantiate(Resources.Load("Feiz/Magician")) as GameObject;
            Character_Controller.Instance.setCharacter(a);
        Propertity_Controller_Init();
    }

    //获取当前血量
    public int Propertity_Controller_Get_CurrentMP()
    {
        return my_Propertity.Character_Current_MP;
    }

    //设置当前蓝量
    public void Propertity_Controller_Set_CurrentMP(int value)
    {
        if (value < 0)
        {
            my_Propertity.Character_Current_MP = 0;
        }
        else if (value > my_Propertity.Character_MAX_MP)
        {
            my_Propertity.Character_Current_MP = my_Propertity.Character_MAX_MP;
        }
        else
        {
            my_Propertity.Character_Current_MP = value;
        }

    }

    //改变蓝量（消耗或恢复）
    public void Propertity_Controller_Change_CurrentMP(int value)
    {
        my_Propertity.Character_Current_MP += value;
        if (my_Propertity.Character_Current_MP < 0)
        {
            my_Propertity.Character_Current_MP = 0;
        }
        if (my_Propertity.Character_Current_MP > my_Propertity.Character_MAX_MP)
        {
            my_Propertity.Character_Current_MP = my_Propertity.Character_MAX_MP;
        }

    }

    //获取当前血量
    public int Propertity_Controller_Get_CurrentHP()
    {
        return my_Propertity.Character_Current_HP;
    }

    //设置当前血量
    public void Propertity_Controller_Set_CurrentHP(int value)
    {
        if (value < 0)
        {
            my_Propertity.Character_Current_HP = 0;
        }
        else if (value > my_Propertity.Character_MAX_HP)
        {
            my_Propertity.Character_Current_HP = my_Propertity.Character_MAX_HP;
        }
        else
        {
            my_Propertity.Character_Current_HP = value;
        }

    }

    //改变血量（消耗或恢复）
    public void Propertity_Controller_Change_CurrentHP(int value)
    {
        my_Propertity.Character_Current_HP += value;
        if (my_Propertity.Character_Current_HP < 0)
        {
            my_Propertity.Character_Current_HP = 0;
        }
        if (my_Propertity.Character_Current_HP > my_Propertity.Character_MAX_HP)
        {
            my_Propertity.Character_Current_HP = my_Propertity.Character_MAX_HP;
        }

    }

    //获取当前AD
    public int Propertity_Controller_Get_AD()
    {
        return my_Propertity.AD;
    }

    //获取当前AP
    public int Propertity_Controller_Get_AP()
    {
        return my_Propertity.AP;
    }


    public void Propertity_Controller_Choose_Swordman()
    {
        my_Propertity = new Character_Propertity();
        GameObject man = GameObject.FindWithTag("Player");
        if (man != null)
        {
            GameObject.Destroy(man);
        }
            my_Propertity.career = Career.Swordman;
            GameObject a = Instantiate(Resources.Load("Feiz/Swordman")) as GameObject;
            Character_Controller.Instance.setCharacter(a);
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
            my_Propertity.AP = 8;
            my_Propertity.AD = 3;
        }
        else
        {
            my_Propertity.Character_MAX_HP = my_Propertity.Character_Current_HP = 200;
            my_Propertity.Character_Current_MP = my_Propertity.Character_Current_MP = 100;
            my_Propertity.defensive = 5;
            my_Propertity.AD = 8;
            my_Propertity.AP = 3;
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
        if (my_Propertity.Character_Current_EXP >= my_Propertity.Character_MAX_EXP)
        {
            my_Propertity.Character_Current_EXP -= my_Propertity.Character_MAX_EXP;
            Propertity_Controller_Upgrade();
        }
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
            my_Propertity.AD += 1;
            my_Propertity.AP += 3;
        }
        else
        {
            my_Propertity.Character_MAX_HP = my_Propertity.Character_Current_HP = my_Propertity.Character_MAX_HP+20;
            my_Propertity.Character_Current_MP = my_Propertity.Character_Current_MP = my_Propertity.Character_Current_MP + 10;
            my_Propertity.defensive += 2;
            my_Propertity.AD += 2;
            my_Propertity.AP += 1;
        }
        my_Propertity.level += 1;

    }
}
