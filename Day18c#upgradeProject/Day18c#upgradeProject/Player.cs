using Tower.ItemsSystem;
namespace Tower.Player
{
    // 플레이어 데이터 저장용
    class User
    {
        // 플레이어 이름, 레벨, 경험치, 체력, 공격력, 방어력
        public string Name { get; private set; } = "플레이어";
        public int Level { get; private set; } = 1;
        public int BaseExp { get; set; } = 0;
        public int LevelUpCutLine { get; private set; } = 100;
        public int BaseHp { get; set; } = 200;   // 전투 시 HP변동이 필요해서 set
        public int MaxHp { get; private set; } = 200;
        public int BaseAtk { get; private set; } = 20;
        public int BaseDef { get; private set; } = 10;
        public int Gold { get; set; } = 100;
        // 플레이어 인벤토리 리스트
        public List<Item> inventory = new List<Item>();
        
        public int TotalAtk
        {
            get
            {
                int bonusAtk = 0;

                foreach (Item item in inventory)
                {
                    if(item.IsEquipped)
                    {
                        bonusAtk += item.IncreaseAtk();
                    }
                }

                return BaseAtk + bonusAtk;
            }
        }
        public int TotalDef
        {
            get
            {
                int bonusDef = 0;

                foreach (Item item in inventory)
                {
                    if (item.IsEquipped)
                    {
                        bonusDef += item.IncreaseDef();
                    }
                }

                return BaseDef + bonusDef;
            }
        }
        public void LevelUp()
        {
            // 모인 경험치가 많으면 레벨 업 실행 
            while(BaseExp >= LevelUpCutLine)
            {
                BaseExp -= LevelUpCutLine;
                
                Level++;
               
                LevelUpCutLine = LevelUpCutLine * 3 / 2; // 소수점은 필요없어서 그냥 이렇게 작성함

                int BonusHp = 10;
                MaxHp += BonusHp;
                BaseHp = MaxHp;

                int BonusAtk = 3;
                BaseAtk += BonusAtk;

                int BonusDef = 1;
                BaseDef += BonusDef;

                Console.WriteLine("레벨 업 하셨습니다!");
                Console.ReadLine();
                Console.WriteLine($"현재 레벨 : {Level}");
                Console.WriteLine($"최대 체력 {BonusHp} 상승!");
                Console.WriteLine($"공격력 {BonusAtk} 상승!");
                Console.WriteLine($"방어력 {BonusDef} 상승!");
                Console.ReadLine();
            }
        }
    }
}
