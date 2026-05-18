using Tower.Player;
using Tower.ItemsSystem;
namespace Tower.ShopSystem
{
    class Shop
    {
        // 상점 아이템 리스트
        private List<Item> shopItems = new List<Item>();

        public Shop()
        {
            // 아이템 리스트에 담을 품목들
            shopItems.Add(new Weapon("목검", 10, 150));
            shopItems.Add(new Weapon("철 검", 20, 300));
            shopItems.Add(new Armor("가죽 갑옷", 5, 130));           
            shopItems.Add(new Armor("철 갑옷", 10, 260));
            shopItems.Add(new Potion("체력 포션", 100, 50));
        }

        public void ShowShop(User player)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("==========탑 등반 턴제 RPG 게임==========");
                Console.WriteLine("               1 F ~ 10 F                ");
                Console.WriteLine();
                Console.WriteLine("          ┌----------------┐           ");
                Console.WriteLine("          │      상점      │           ");
                Console.WriteLine("          └----------------┘           ");
                Console.WriteLine();
                Console.WriteLine($"           보유 골드: {player.Gold}     ");
                Console.WriteLine("[목록]");
                // 아이템 나열
                for(int i = 0; i < shopItems.Count; i++)
                {
                    Console.Write($"{i + 1}. "); shopItems[i].ShowInfo();
                }
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.Write("입력 : ");

                int.TryParse(Console.ReadLine(), out int choiceShopNum);

                if(choiceShopNum == 0)
                {
                    break;
                }

                int shopIndex = choiceShopNum - 1;
                //    shopItems길이 > shopIndex >= 0 이면 구매
                if(shopIndex >= 0 && shopIndex < shopItems.Count)
                {
                    BuyItem(player, shopItems[shopIndex]);
                }
            }
        }
        public void BuyItem(User player, Item item)
        {
            if(player.Gold < item.Price)
            {
                Console.WriteLine("골드가 부족합니다.");
                Console.ReadLine();
                return;
            }

            player.Gold -= item.Price;
            player.inventory.Add(item);

            Console.WriteLine($"{item.Name}을(를) 구매하셨습니다.");
            Console.ReadLine();
        }
    }
}
