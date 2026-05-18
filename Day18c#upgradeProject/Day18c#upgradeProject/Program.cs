using Tower.Player;
using Tower.Monster;
using Tower.BattleSystem;
using Tower.MonstersRandomSet;
using Tower.FloorSystem;
using Tower.SanctuarySystem;
using Tower.WaitScene;
namespace Day18c_upgradeProject
{
    internal class Program
    {    
        static void Main()
        {
            User player = new User();
            Sanctuary sanctuary = new Sanctuary();
            Floor floor = new Floor();
            Battle battle = new Battle();
            RandomMonster randomMonster = new RandomMonster();
            Wait wait = new Wait();

            while(true)
            {
                if(floor.CurrentFloor == 1)
                {
                    sanctuary.ShowSanctuary(player, floor);
                    floor.CurrentFloor++;
                }
                else if(floor.CurrentFloor >= 2 && floor.CurrentFloor <= 4)
                {
                    Monsters normalMonster = randomMonster.SetRandomMonsters(floor.CurrentFloor);
                    battle.Fight(player, normalMonster, floor);
                    wait.ShowWaitScene(floor);
                    // 이걸 안 넣으니 1층 쉼터가 아니라 자꾸 2층으로 바뀌어서 넣었음
                    if(floor.CurrentFloor != 1)
                    {
                        floor.CurrentFloor++;
                    }                  
                }
                else if(floor.CurrentFloor == 5)
                {
                    sanctuary.ShowSanctuary(player, floor);
                    floor.CurrentFloor++;
                }
                else if(floor.CurrentFloor >= 6 && floor.CurrentFloor <= 8)
                {
                    Monsters eliteMonster = randomMonster.SetRandomMonsters(floor.CurrentFloor);
                    battle.Fight(player, eliteMonster, floor);
                    wait.ShowWaitScene(floor);
                    if (floor.CurrentFloor != 1)
                    {
                        floor.CurrentFloor++;
                    }
                }
                else if(floor.CurrentFloor == 9)
                {
                    sanctuary.ShowSanctuary(player, floor);
                    floor.CurrentFloor++;
                }
                else if(floor.CurrentFloor == 10)
                {
                    Monsters bossMonster = randomMonster.SetRandomMonsters(floor.CurrentFloor);
                    battle.Fight(player, bossMonster, floor);
                    // 보스에게 승리 시 축하메시지 출력 후 프로그램 종료
                    if(player.BaseHp > 0 && bossMonster.MonHp <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("☆★☆★☆★慶☆★☆★☆★祝☆★☆★☆★");
                        Console.WriteLine();
                        Console.ReadLine();
                        Console.WriteLine("             축 하 합 니 다!!!          ");
                        Console.ReadLine();
                        Console.WriteLine("         게임을 클리어 하셨습니다!      ");
                        Console.ReadLine();
                        Console.WriteLine("          만든 건 여기까지 입니다.      ");
                        Console.ReadLine();
                        Console.WriteLine("           프로그램을 종료합니다.       ");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    // 보스에게 패배 시 1F으로 귀환
                    else
                    {
                        floor.CurrentFloor = 1;
                    }
                }
            }
        }
    }
}
