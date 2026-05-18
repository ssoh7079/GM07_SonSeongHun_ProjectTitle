using Tower.ItemsSystem;
using Tower.Player;
namespace Tower.InventorySystem
{
    class Inventory
    {
        private User player;

        public Inventory(User player)
        {
            this.player = player;
        }

        public void AddItem(Item item)
        {
            player.inventory.Add(item);
            Console.WriteLine($"{item.Name}이(가) 추가되었습니다.");
        }
        public void RemoveItem(Item item)
        {
            if(player.inventory.Contains(item))
            {
                player.inventory.Remove(item);
                Console.WriteLine($"{item.Name}을(를) 버렸습니다.");
            }
        }
        public void ShowInventory()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("==========탑 등반 턴제 RPG 게임==========");
                Console.WriteLine("               1 F ~ 10 F                ");
                Console.WriteLine();
                Console.WriteLine("          ┌----------------┐           ");
                Console.WriteLine("          │    인벤토리    │           ");
                Console.WriteLine("          └----------------┘           ");
                Console.WriteLine("[목록]");
                // 아이템 나열
                if (player.inventory.Count == 0)
                {
                    Console.WriteLine("인벤토리가 비어있습니다.");
                }
                else
                {
                    for (int i = 0; i < player.inventory.Count; i++)
                    {
                        Item item = player.inventory[i];
                        string equipInfo = item.IsEquipped ? "[E]" : "";
                        Console.WriteLine($"{i + 1}. {equipInfo} {item.Name}");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("1. 장착 / 해제");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.Write("입력 : ");

                // 장착, 해제, 나가기 용
                if (int.TryParse(Console.ReadLine(), out int inputChoiceNum))
                {
                    if (inputChoiceNum == 1)
                    {
                        ShowEquip();
                    }
                    else if (inputChoiceNum == 0)
                    {
                        break;
                    }
                }               
            }           
        }
        public void ShowEquip()
        {
            Console.Write("장착 / 해제할 아이템 번호 입력 : ");

            int.TryParse(Console.ReadLine(), out int inputEquipNum);

            if(inputEquipNum < 1 || inputEquipNum > player.inventory.Count)
            {
                Console.WriteLine("올바른 번호를 입력해주세요.");
                Console.ReadLine();
                return;
            }
            // 장착, 해제할 아이템 번호 용
            Item choice = player.inventory[inputEquipNum - 1];

            if(choice.Type == ItemType.Potion)
            {
                Console.WriteLine("소모품은 장착할 수 없습니다.");
                Console.ReadLine();
                return;
            }

            choice.IsEquipped = !choice.IsEquipped;

            if(choice.IsEquipped)
            {
                Console.WriteLine($"{choice.Name}을(를) 장착했습니다.");
            }
            else
            {
                Console.WriteLine($"{choice.Name}을(를) 장착 해제했습니다.");
            }
            Console.ReadLine();
        }
    }
}
