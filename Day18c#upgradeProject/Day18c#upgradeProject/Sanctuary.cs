using Tower.FloorSystem;
using Tower.InventorySystem;
using Tower.Player;
using Tower.PlayerStatusSystem;
using Tower.ShopSystem;
using Tower.WaitScene;
namespace Tower.SanctuarySystem
{
    internal class Sanctuary
    {
        public void ShowSanctuary(User player, Floor floor)
        {           
            PlayerStatus status = new PlayerStatus();
            Inventory inventory = new Inventory(player);
            Shop shop = new Shop();
            Wait wait = new Wait();

            while (true)
            {

                Console.Clear();
                Console.WriteLine("==========탑 등반 턴제 RPG 게임==========");
                Console.WriteLine("               1 F ~ 10 F                ");
                Console.WriteLine();
                Console.WriteLine($"               {floor.CurrentFloor} F : 쉼터                ");
                Console.WriteLine();
                Console.WriteLine("               1. 휴식");
                Console.WriteLine("               2. 인벤토리");
                Console.WriteLine("               3. 스테이터스             ");
                Console.WriteLine("               4. 상점");
                Console.WriteLine("               5. 떠나기");
                Console.WriteLine("               0. 프로그램 종료          ");
                Console.Write("               입력: ");

                bool isNum = int.TryParse(Console.ReadLine(), out int choiceSanctuary);
                if (!isNum)
                {
                    Console.WriteLine("올바른 숫자를 입력해주세요.");
                    Console.ReadLine();
                    continue;
                }
                if (choiceSanctuary == 0) // 프로그램 종료
                {
                    Environment.Exit(0);
                }
                switch (choiceSanctuary)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("==========탑 등반 턴제 RPG 게임==========");
                        Console.WriteLine("               1 F ~ 10 F                ");
                        Console.WriteLine();
                        Console.WriteLine("            휴식을 취했습니다.           ");
                        player.BaseHp = player.MaxHp;
                        Console.WriteLine();
                        Console.WriteLine("           체력을 회복했습니다.          ");
                        Console.WriteLine();
                        Console.WriteLine("enter키를 누르면 이전 화면으로 돌아갑니다.");
                        Console.ReadLine();
                        break;
                    case 2: // 인벤토리
                        inventory.ShowInventory();
                        break;
                    case 3: // 스테이터스
                        status.ShowStatus(player);
                        break;
                    case 4: // 상점
                        shop.ShowShop(player);
                        break;
                    case 5:
                        // 현재 층 수에서 떠나서 다음 층 수에 가기전 선택지로 가는 ~ 대기화면
                        wait.ShowWaitScene(floor);
                        return;
                }
            }
        }
    }
}
