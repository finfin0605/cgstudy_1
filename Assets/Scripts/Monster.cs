using UnityEngine;

public class Monster//定义怪物类
{
    public string name;
    public int hp;//当前体力
    public int maxhp;//最大体力
    public int atk;//怪物攻击力

    public Monster(string name,int hp,int atk) // 构造函数：创建怪物时初始化属性
    {
        this.name = name;//名字=传入name
        this.hp = hp;//当前体力=传入
        this.maxhp = hp;//初始最大体力=初始体力
        this.atk = atk;//攻击力=传入atk
    }

    public void TakeDamage(int damage) // 受伤函数：扣除体力
    {
        hp -= damage;//当前体力-伤害值

        if (hp < 0)
        {
            hp = 0;//把体力修正为 0，避免出现负数
        }
    }

    public bool IsDead()//monster是否死亡
    {
        return hp <= 0;//如果体力小于等于 0，返回 true
    }
}
