using UnityEngine;

public class Monster
{
    public string name;
    public int hp;
    public int maxhp;
    public int atk;

    public Monster(string name,int hp,int atk) // 构造函数：创建怪物时初始化属性
    {
        this.name = name;
        this.hp = hp;
        this.maxhp = hp;
        this.atk = atk;
    }

    public void TakeDamage(int damage) // 受伤函数：扣除体力
    {
        hp -= damage;

        if (hp < 0)
        {
            hp = 0;//把体力修正为 0，避免出现负数
        }
    }

    public bool IsDead()
    {
        return hp <= 0;//如果体力小于等于 0，返回 true
    }
}
