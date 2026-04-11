using UnityEngine;

public class GameRunner : MonoBehaviour // 定义一个 Unity 脚本类，用来控制游戏开始时的逻辑
{
    void Start()// Start() 在游戏开始时自动执行1次
    {
        Player player = new Player(10, 3);//造人   //初始 HP=10，ATK=3
        Monster slime = new Monster("슬라임", 8, 2);//造怪

        Debug.Log("플레이어 - HP: " + player.hp +  "/" + player.maxhp + ", ATK: " + player.atk);//将内容打印到Unity Console
        Debug.Log(slime.name + "- HP: " + slime.hp + "/" + slime.maxhp + ", ATK: " + slime.atk);

        while(!player.IsDead() && !slime.IsDead())//只要双方都活着就一直打
        {
            slime.TakeDamage(player.atk);//玩家打怪
            Debug.Log("플레이어가  " + slime.name + "을 공격했습니다!!! (" +slime.name + " HP: " + slime.hp +  "/" +  slime.maxhp + ")");

            if (slime.IsDead())//看看怪死没死
            {
                Debug.Log(slime.name + "을 처치했습니다!!!");

                player.UpDateAfterSlime();
                Debug.Log("공격력 +1, 최대 체력 +3");
                Debug.Log("플레이어 - HP: " + player.hp + "/" + player.maxhp + ", ATK: " + player.atk);

                break;//End loop
            }

            player.TakeDamage(slime.atk);//怪打玩家
            Debug.Log(slime.name + "이 플레이어를 공격했습니다. (플레이어 HP: " + player.hp + "/" + player.maxhp + ")");

            if (player.IsDead())//看看人死没死
            {
                Debug.Log("플레이어가 패배했습니다......");
                break;
            }// if 结束

        }// while 循环结束
    }// Start 函数结束
}// GameRunner 类结束
