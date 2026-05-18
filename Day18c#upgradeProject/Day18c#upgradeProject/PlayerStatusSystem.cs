using Tower.Player;
namespace Tower.PlayerStatusSystem
{
    // 플레이어 정보 화면 출력용 
    internal class PlayerStatus
    {
        public void ShowStatus(User player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==========탑 등반 턴제 RPG 게임==========");
                Console.WriteLine("               1 F ~ 10 F                ");
                Console.WriteLine();
                Console.WriteLine("          ┌----------------┐           ");
                Console.WriteLine("          │   스테이터스   │           ");
                Console.WriteLine("          └----------------┘           ");
                Console.WriteLine();
                Console.WriteLine($"이름 : {player.Name}");
                Console.WriteLine($"레벨 : {player.Level}");
                Console.WriteLine($"경험치 : {player.BaseExp} / {player.LevelUpCutLine}");
                Console.WriteLine($"체력 : {player.BaseHp} / {player.MaxHp}");
                Console.WriteLine($"공격력 : {player.BaseAtk} -> 장비 착용 후 : {player.TotalAtk}");
                Console.WriteLine($"방어력 : {player.BaseDef} -> 장비 착용 후 : {player.TotalDef}");
                Console.WriteLine($"보유 골드: {player.Gold}");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.Write("입력: ");
                if (int.TryParse(Console.ReadLine(), out int statusNum))
                {
                    if (statusNum == 0)
                    {
                        break;
                    }
                }
                Console.WriteLine("올바른 숫자를 입력해주세요.");
                Console.ReadLine();
            }
            
        }
    }
}
