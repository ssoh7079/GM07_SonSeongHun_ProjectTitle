namespace Tower.ItemsSystem
{
    public enum ItemType
    {
        Weapon, Armor, Potion
    }
    interface IEquipment
    {
        void Equip();
        void UnEquip();
    }
    public abstract class Item
    {
        public string Name { get; protected set; }
        public int Price { get; protected set; }
        public ItemType Type { get; protected set; }
        public bool IsEquipped { get; set; }
        public Item(string name, int price, ItemType type)
        {
            Name = name;
            Price = price;
            Type = type;
            IsEquipped = false; // 장착 중이면 true
        }
        public abstract void ShowInfo();
        public virtual int IncreaseAtk()
        {
            return 0;
        }
        public virtual int IncreaseDef()
        {
            return 0;
        }
    }
    public class Weapon : Item, IEquipment
    {
        public int Atk { get; private set; }
        public Weapon (string name, int atk, int price) : base(name, price, ItemType.Weapon)
        {
            Atk = atk;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"{Name} | 공격력 : {Atk} | 금액 : {Price} | 종류 : 무기");
        }
        public override int IncreaseAtk()
        {
            return Atk;
        }
        public void Equip()
        {
            Console.WriteLine($"{Name} 장착. 공격력 {Atk} 증가!");
        }
        public void UnEquip()
        {
            Console.WriteLine($"{Name} 장착 해제. 공격력 {Atk} 감소!");
        }
    }
    public class Armor : Item, IEquipment
    {
        public int Def { get; private set; }
        public Armor(string name, int def, int price) : base(name, price, ItemType.Armor)
        {
            Def = def;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"{Name} | 방어력 : {Def} | 금액 : {Price} | 종류 : 방어구");
        }
        public override int IncreaseDef()
        {
            return Def;
        }
        public void Equip()
        {
            Console.WriteLine($"{Name} 장착. 방어력 {Def} 증가!");
        }
        public void UnEquip()
        {
            Console.WriteLine($"{Name} 장착 해제. 방어력 {Def} 감소!");
        }
    }
    public class Potion : Item
    {
        public int HeelHp { get; private set; }
        public Potion(string name, int hp, int price) : base(name, price, ItemType.Potion)
        {
            HeelHp = hp;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"{Name} | 회복량 : {HeelHp} | 금액 : {Price} | 종류 : 소모품");
        }
    }
}
