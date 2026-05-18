using Tower.Monster;
namespace Tower.MonstersRandomSet
{
    internal class RandomMonster
    {
        // 랜덤 몬스터 출현
        
        private Random random = new Random();

        public Monsters SetRandomMonsters(int floor)
        {
            // 몬스터들을 담을 리스트
            List<Monsters> monsters = new List<Monsters>();

            // 일반 몹 중 하나 출현
            if(floor >= 2 && floor <= 4)
            {
                monsters.Add(new Slime("슬라임", 50, 13, 2, 30, 10));
                monsters.Add(new Wolf("늑대", 80, 15, 4, 50, 13));
                monsters.Add(new Goblin("고블린", 120, 20, 8, 100, 17));
            }
            // 일반 몹 중 강한 두 개체와 엘리트 몹 중 하나 출현
            else if(floor >= 6 && floor <= 8)
            {
                monsters.Add(new Wolf("늑대", 80, 15, 4, 50, 13));
                monsters.Add(new Goblin("고블린", 120, 20, 8, 100, 17));
                monsters.Add(new Orc("오크", 200, 30, 13, 200, 25));
            }
            // 보스 몹은 하나로 고정
            else if(floor == 10)
            {
                monsters.Add(new OrcChief("오크 족장", 400, 40, 18, 500, 50));
            }
            // 몬스터 종류 3개 1~3사이의 랜덤한 숫자
            int randomMonster = random.Next(monsters.Count);
            // 나온 숫자 
            return monsters[randomMonster];  
        }
    }
}
