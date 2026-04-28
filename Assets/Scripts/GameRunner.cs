using UnityEngine;//引入Unity基础库

public class GameRunner : MonoBehaviour // 定义一个 Unity 脚本类，用来控制游戏开始时的逻辑
{
    void Start()// Start() 在游戏开始时自动执行1次
    {
        Player player = new Player(10, 3);//造人   //初始 HP=10，ATK=3
        int attempt = 0;//记录挑战次数
        bool clear = false;//是否通关

        Debug.Log("======게임 시작ㄱㄱㄱ =====");
        Debug.Log("플레이어 정보: HP" + player.hp + "/" + player.maxhp + ",ATK " + player.atk);

        while (!clear)//只要没通关就一直挑战
        {
            attempt++;//挑战次数+1
            player.HpFull();//每次新挑战前回满血

            Debug.Log("====" + attempt + "번째 도전 시작 ====");//输出第几次挑战开始
            Debug.Log("플레이어 정보: HP " + player.hp + "/" + player.maxhp + ", ATK: " + player.atk);//输出当前玩家状态


            Monster slime = new Monster("슬라임", 8, 2);//造怪
            bool slimeWin = Fight(player, slime);//与怪战斗

            if (!slimeWin)//IF 人类败战
            {
                Debug.Log("플레이어가 패배했습니다...");//失败信息
                Debug.Log("슬라임부터 다시 시작합니다! ! !");//从史莱姆重新开始
                continue;//进入下一次挑战
            }

            Debug.Log("슬라임을 처치했습니다!");//输出击败史莱姆
            Debug.Log("공격력 +1, 최대 체력 +3");//输出奖励
            player.LevelUp(1, 3);//玩家升级//战斗力+1，血量+3
            Debug.Log("플레이어 정보: HP " + player.hp + "/" + player.maxhp + ", ATK " + player.atk);//输出升级玩家状态

            Monster ogre = new Monster("오우거", 20, 6);//创建食人魔
            bool ogreWin = Fight(player, ogre);//与魔战斗

            if (!ogreWin)//IF人类战败
            {
                Debug.Log("플레이어가 패배했습니다...");//失败信息
                Debug.Log("슬라임부터 다시 시작합니다.");重新开始
                continue;
            }


            Debug.Log("오우거를 처치했습니다!");//魔战败
            Debug.Log("공격력 +2, 최대 체력 +5");//输出奖励
            player.LevelUp(2, 5);//玩家升级：战斗力+2，血量+5
            Debug.Log("플레이어 정보: HP " + player.hp + "/" + player.maxhp + ",ATK" + player.atk);

            Monster boss = new Monster("마왕", 30, 8);//创建魔王
            bool bossWin = Fight(player, boss);//与王战斗

            if (!bossWin)//人类战败
            {
                Debug.Log("플레이어가 패배했습니다...");//失败信息
                Debug.Log("슬라임부터 다시 시작합니다.");//重新开始
                continue;//直接进入下一次挑战
            }

            Debug.Log("마왕을 처치했습니다!");//击败王
            Debug.Log("게임 클리어!");//输出通关
            Debug.Log(attempt + "번의 도전 만에 클리어했습니다!");//输出第几次挑战通关

            clear = true;//标记为已通关，结束外层循环
        }
    }

    bool Fight(Player player, Monster monster)//战斗函数：负责player& 一只monster打一场
    {
        Debug.Log("[" + monster.name + " 등장]");//怪兽登场
        Debug.Log(monster.name + " - HP: " + monster.hp + "/" + monster.maxhp + ",ATK: " + monster.atk);//怪兽信息
        Debug.Log("플레이어 - HP: " + player.hp + "/" + player.maxhp + ", ATKA: " + player.atk);//玩家信息

        while (!player.IsDead() && !monster.IsDead())//双方都没死，战斗继续
        {
            monster.TakeDamage(player.atk);//人打怪
            Debug.Log("플레이어가 " + monster.name + "을 공격했습니다. (" + monster.name + "HP: "+monster.hp + "/" +monster.maxhp +")");//人攻击怪后血量

            if (monster.IsDead())//怪死
            {
                return true;//返回true,表示玩家胜利
            }
            player.TakeDamage(monster.atk);//怪反击
            Debug.Log(monster.name + "가 플레이어를 공격했습니다. (플레이어 HP: " + player.hp + "/" + player.maxhp + ")");//怪血量

            if (player.IsDead())//人死
            {
                return false;//表示玩家失败
            }
        }
        return false;//理论上的兜底返回
    }


