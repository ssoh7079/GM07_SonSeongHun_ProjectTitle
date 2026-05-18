namespace Tower.Monster
{
    public enum MonstersType
    {
        Slime, Wolf, Goblin, Orc, OrcChief
    }
    public abstract class Monsters
    {
        public string MonName { get; private set; }
        public int MonHp { get; set; } // 전투 시 HP변동이 필요해서 set
        public int MonAtk { get; private set; }
        public int MonDef { get; private set; }
        public int DropGold { get; private set; }
        public int DropExp { get; private set; }
        public Monsters(string monName, int monHealth, int monAtk, int monDef, int dropGold, int dropExp)
        {
            MonName = monName;
            MonHp = monHealth;
            MonAtk = monAtk;
            MonDef = monDef;
            DropGold = dropGold;
            DropExp = dropExp;
        }
        public abstract void ShowMonInfo();
    }
    // 슬라임
    public class Slime : Monsters
    {
        public Slime(string monName, int monHealth, int monAtk, int monDef, int dropGold, int dropExp)
            : base(monName, monHealth, monAtk, monDef, dropGold, dropExp) { }
        public override void ShowMonInfo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{MonName}  ");
            Console.ResetColor();
            Console.WriteLine($"||  체력 : {MonHp} | 공격력 : {MonAtk} | 방어력 : {MonDef}");
        }
    }
    // 늑대
    public class Wolf : Monsters
    {
        public Wolf(string monName, int monHealth, int monAtk, int monDef, int dropGold, int dropExp) 
            : base(monName, monHealth, monAtk, monDef, dropGold, dropExp) { }
        public override void ShowMonInfo()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"{MonName}  ");
            Console.ResetColor();
            Console.WriteLine($"||  체력 : {MonHp} | 공격력 : {MonAtk} | 방어력 : {MonDef}");
        }
    }
    // 고블린
    public class Goblin : Monsters
    {
        public Goblin(string monName, int monHealth, int monAtk, int monDef, int dropGold, int dropExp) 
            : base(monName, monHealth, monAtk, monDef, dropGold, dropExp) { }
        public override void ShowMonInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{MonName}  ");
            Console.ResetColor();
            Console.WriteLine($"||  체력 : {MonHp} | 공격력 : {MonAtk} | 방어력 : {MonDef}");
        }
    }
    // 오크
    public class Orc : Monsters
    {
        public Orc(string monName, int monHealth, int monAtk, int monDef, int dropGold, int dropExp) 
            : base(monName, monHealth, monAtk, monDef, dropGold, dropExp) { }
        public override void ShowMonInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{MonName}  ");
            Console.ResetColor();
            Console.WriteLine($"||  체력 : {MonHp} | 공격력 : {MonAtk} | 방어력 : {MonDef}");
        }
    }
    // 오크 족장
    public class OrcChief : Monsters
    {
        public OrcChief(string monName, int monHealth, int monAtk, int monDef, int dropGold, int dropExp) 
            : base(monName, monHealth, monAtk, monDef, dropGold, dropExp) { }
        public override void ShowMonInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{MonName}  ");
            Console.ResetColor();
            Console.WriteLine($"||  체력 : {MonHp} | 공격력 : {MonAtk} | 방어력 : {MonDef}");
        }
    }
}
