using UnityEngine;// 引入 Unity 的基础功能库 / Import Unity's basic library

public class Player // 定义一个玩家类 / Define a Player class
{
    public int hp;// 玩家当前体力
    public int maxhp; // 玩家最大体力
    public int atk;// 玩家攻击力 
    public Player(int hp, int atk) // 构造函数：创建玩家时初始化属性 
    {
        this.hp = hp;//Assign the input hp to this player's hp
        this.maxhp = hp;// 初始最大体力等于初始体力 
        this.atk = atk;// Assign the input atk to this player's attack
    }
    public void TakeDamage(int damage)
    {// 受伤函数：扣除体力
        hp -= damage; // 当前体力减去受到的伤害

        if (hp < 0)
        {
            hp = 0;
        }
    }
    public bool IsDead() // 判断玩家是否死亡 
    {
        return hp <= 0;// HP 小于等于 0 返回 true 
    }
    public void UpDateAfterSlime()  //Level-up after defeating slime
    {
        atk += 1;
        maxhp += 3;
        hp = maxhp;//Restore HP to full

    }
}
