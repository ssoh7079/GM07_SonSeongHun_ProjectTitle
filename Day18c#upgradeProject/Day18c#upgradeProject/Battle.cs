using Tower.Player;
using Tower.Monster;
using Tower.ItemsSystem;
using Tower.FloorSystem;
namespace Tower.BattleSystem
{
    // 전투 UI 담당
    internal class Battle
    {
        public void Fight(User player, Monsters monster, Floor floor)
        {
            while(player.BaseHp > 0 && monster.MonHp > 0)
            {
                Console.Clear();
                Console.WriteLine("==========탑 등반 턴제 RPG 게임==========");
                Console.WriteLine("               1 F ~ 10 F                ");
                Console.WriteLine();
                Console.WriteLine($"               {floor.CurrentFloor} F   ");
                Console.WriteLine("          ┌----------------┐           ");
                Console.WriteLine("          │      전투      │           ");
                Console.WriteLine("          └----------------┘           ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{player.Name}");
                Console.ResetColor();
                Console.WriteLine($"  ||  체력 : {player.BaseHp} | 공격력 : {player.TotalAtk} | 방어력 : {player.TotalDef}");
                monster.ShowMonInfo();
                Console.WriteLine();
                Console.WriteLine("       1. 기본공격        2. 방어        ");
                Console.WriteLine();
                Console.WriteLine("       3. 체력 포션       4. 도주        ");
                Console.WriteLine();
                Console.Write("                입력 : ");

                int.TryParse(Console.ReadLine(), out int inputNum);

                switch(inputNum)
                {
                    case 1:
                        BasicAttack(player, monster);
                        MonsterAttack(player, monster);
                        break;
                    case 2:
                        Defence(player, monster); 
                        break;
                    case 3:
                        DrinkPotion(player); 
                        break;
                    case 4:
                        floor.CurrentFloor--;
                        Console.WriteLine("            도주했습니다.");
                        Console.WriteLine();
                        Console.WriteLine("       전투 시작 전으로 되돌아갑니다.");
                        Console.ReadLine();
                        return;
                }

                if(player.BaseHp <= 0)
                {
                    floor.CurrentFloor--;
                    Console.WriteLine("            패배하셨습니다.");
                    Console.ReadLine();
                    Console.WriteLine("       전투 시작 전으로 되돌아갑니다.");
                    Console.ReadLine();
                    return;
                }
                if(monster.MonHp <= 0)
                {
                    Console.WriteLine("                 승리!!!");
                    Console.ReadLine();
                    Console.WriteLine($"      {monster.MonName}을(를) 처치하셨습니다!");
                    Console.ReadLine();
                    player.Gold += monster.DropGold;
                    player.BaseExp += monster.DropExp;
                    player.LevelUp();
                    Console.WriteLine($"           {monster.DropGold} 골드 획득!!");
                    Console.WriteLine($"           {monster.DropExp} 경험치 획득!!");
                    Console.ReadLine();
                    break;
                }
            }
        }
        // 1. 기본공격
        public void BasicAttack(User player, Monsters monster)
        {
            int DealDamage = Math.Max(1, player.TotalAtk - monster.MonDef);
            monster.MonHp -= DealDamage;
            Console.WriteLine("기본공격을 했다!!!");
            Console.ReadLine();
            Console.WriteLine($"{monster.MonName}에게 {DealDamage}의 데미지를 입혔다!");
            Console.ReadLine();
        }
        // 2. 방어
        public void Defence(User player, Monsters monster)
        {
            int DealDamage = Math.Max(1, monster.MonAtk - player.TotalDef);
            player.BaseHp -= DealDamage;
            Console.WriteLine("방어자세를 취했다!");
            Console.ReadLine();
            Console.WriteLine($"적의 공격을 방어했다!!!");
            Console.WriteLine($"{DealDamage}의 데미지만 입었다! ");
            Console.ReadLine();
        }
        // 3. 체력 포션
        public void DrinkPotion(User player)
        {
            // 기본 값 null
            Potion hpPotion = null;
            // 인벤토리 검사해서 있으면 체력포션
            foreach(Item item in player.inventory)
            {
                if(item is Potion potion)
                {
                    hpPotion = potion;
                    break;
                }
            }
            // 없으면 null
            if (hpPotion == null)
            {
                Console.WriteLine("소지하고 있는 포션이 없습니다.");
                Console.ReadLine();
                return; // 전투 선택창으로
            }
            // 있으면 포션 마시기 진행
            player.BaseHp += hpPotion.HeelHp;
            // 플레이어 현재 체력이 최대체력 이상이면 풀피로
            if(player.BaseHp > player.MaxHp)
            {
                player.BaseHp = player.MaxHp;
            }
            player.inventory.Remove(hpPotion);

            Console.WriteLine($"{hpPotion.Name}을 사용하셨습니다.");
            Console.ReadLine();
            Console.WriteLine("체력을 회복했습니다!");
            Console.ReadLine();
        }
        // 몬스터 공격
        public void MonsterAttack(User player, Monsters monster)
        {
            int DealDamage = Math.Max(1, monster.MonAtk - player.TotalDef);
            player.BaseHp -= DealDamage;
            Console.WriteLine($"{monster.MonName}이(가) 공격해왔다!!!");
            Console.ReadLine();
            Console.WriteLine($"{DealDamage}의 데미지를 입었다!");
            Console.ReadLine();
        }
    }
}
