using UnityEngine;
using System.Collections;

public class Property_Controller : MonoBehaviour
{
    static Property_Controller instance;
    //获取单实例
    public static Property_Controller Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Property_Controller();
            }
            return instance;
        }
    }

    public Character_Property my_Property;
    

    //选择职业
    //type == 1 :选择swordman
    //type == 0 :选择magicman
    public void Property_Controller_Choose_Magician()
    {
        my_Property = new Character_Property();
        GameObject man = GameObject.FindWithTag("Player");
        if (man != null)
        {
            Destroy(man.GetComponent<Character_Controller>());
            Destroy(man);
        }
            my_Property.career = Career.Magician;
            GameObject a = Instantiate(Resources.Load("Feiz/Magician")) as GameObject;
            Character_Controller.Instance.setCharacter(a);
        Property_Controller_Init();
    }

    //获取当前血量
    public int Property_Controller_Get_CurrentMP()
    {
        return my_Property.Character_Current_MP;
    }

    //设置当前蓝量
    public void Property_Controller_Set_CurrentMP(int value)
    {
        if (value < 0)
        {
            my_Property.Character_Current_MP = 0;
        }
        else if (value > my_Property.Character_MAX_MP)
        {
            my_Property.Character_Current_MP = my_Property.Character_MAX_MP;
        }
        else
        {
            my_Property.Character_Current_MP = value;
        }

    }

    //改变蓝量（消耗或恢复）
    public void Property_Controller_Change_CurrentMP(int value)
    {
        my_Property.Character_Current_MP += value;
        if (my_Property.Character_Current_MP < 0)
        {
            my_Property.Character_Current_MP = 0;
        }
        if (my_Property.Character_Current_MP > my_Property.Character_MAX_MP)
        {
            my_Property.Character_Current_MP = my_Property.Character_MAX_MP;
        }

    }

    //获取当前血量
    public int Property_Controller_Get_CurrentHP()
    {
        return my_Property.Character_Current_HP;
    }

    //设置当前血量
    public void Property_Controller_Set_CurrentHP(int value)
    {
        if (value < 0)
        {
            my_Property.Character_Current_HP = 0;
        }
        else if (value > my_Property.Character_MAX_HP)
        {
            my_Property.Character_Current_HP = my_Property.Character_MAX_HP;
        }
        else
        {
            my_Property.Character_Current_HP = value;
        }

    }

    //改变血量（消耗或恢复）
    public void Property_Controller_Change_CurrentHP(int value)
    {
        my_Property.Character_Current_HP += value;
        if (my_Property.Character_Current_HP < 0)
        {
            my_Property.Character_Current_HP = 0;
        }
        if (my_Property.Character_Current_HP > my_Property.Character_MAX_HP)
        {
            my_Property.Character_Current_HP = my_Property.Character_MAX_HP;
        }

    }

    //获取当前AD
    public int Property_Controller_Get_AD()
    {
        return my_Property.AD;
    }
    
    //设置当前AD
    public void Property_Controller_Set_AD(int value)
    {
        my_Property.AD = value;
    }

    //改变当前AD(增加或减少)
    public void Property_Controller_Change_AD(int value)
    {
        my_Property.AD += value;
        if (my_Property.AD < 0)
        {
            my_Property.AD = 0;
        }
    }


    //获取当前AP
    public int Property_Controller_Get_AP()
    {
        return my_Property.AP;
    }

    //设置当前AP
    public void Property_Controller_Set_AP(int value)
    {
        my_Property.AP = value;
    }

    //改变当前AP(增加或减少)
    public void Property_Controller_Change_AP(int value)
    {
        my_Property.AP += value;
        if (my_Property.AP < 0)
        {
            my_Property.AP = 0;
        }
    }



    public void Property_Controller_Choose_Swordman()
    {
        my_Property = new Character_Property();
        GameObject man = GameObject.FindWithTag("Player");
        if (man != null)
        {
            GameObject.Destroy(man);
        }
            my_Property.career = Career.Swordman;
            GameObject a = Instantiate(Resources.Load("Feiz/Swordman")) as GameObject;
            Character_Controller.Instance.setCharacter(a);
        Property_Controller_Init();
    }

    //初始化角色
    //不同职业不同属性
    public void Property_Controller_Init()
    {
        if (my_Property.career == Career.Magician)
        {
            my_Property.Character_MAX_HP = my_Property.Character_Current_HP = 100;
            my_Property.Character_Current_MP = my_Property.Character_Current_MP = 200;
            my_Property.defensive = 2;
            my_Property.AP = 8;
            my_Property.AD = 3;
        }
        else
        {
            my_Property.Character_MAX_HP = my_Property.Character_Current_HP = 200;
            my_Property.Character_Current_MP = my_Property.Character_Current_MP = 100;
            my_Property.defensive = 5;
            my_Property.AD = 8;
            my_Property.AP = 3;
        }
        my_Property.level = 1;
        my_Property.Character_MAX_EXP = 100;
        my_Property.Character_Current_EXP = 0;
        my_Property.money = 1000;
        my_Property.currentTask = 0;
    }

    public void Property_Controller_GetEXP(int exp)
    {
        my_Property.Character_Current_EXP += exp;
        if (my_Property.Character_Current_EXP >= my_Property.Character_MAX_EXP)
        {
            my_Property.Character_Current_EXP -= my_Property.Character_MAX_EXP;
            Property_Controller_Upgrade();
        }
    }

    public void Property_Controller_GetMoney(int money)
    {
        my_Property.money += money;
    }

    //升级角色
    public void Property_Controller_Upgrade()
    {
        
        if (my_Property.career == Career.Magician)
        {
            my_Property.Character_MAX_HP = my_Property.Character_Current_HP = my_Property.Character_MAX_HP+10;
            my_Property.Character_Current_MP = my_Property.Character_Current_MP = my_Property.Character_Current_MP+20;
            my_Property.defensive += 1;
            my_Property.AD += 1;
            my_Property.AP += 3;
        }
        else
        {
            my_Property.Character_MAX_HP = my_Property.Character_Current_HP = my_Property.Character_MAX_HP+20;
            my_Property.Character_Current_MP = my_Property.Character_Current_MP = my_Property.Character_Current_MP + 10;
            my_Property.defensive += 2;
            my_Property.AD += 2;
            my_Property.AP += 1;
        }
        my_Property.level += 1;

    }
}
