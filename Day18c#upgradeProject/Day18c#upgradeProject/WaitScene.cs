using Tower.FloorSystem;
namespace Tower.WaitScene
{
    public enum WaitChoice
    {
        NextFloor, ReturnFirstFloor
    }
    class Wait 
    {
        public WaitChoice ShowWaitScene(Floor floor)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==========탑 등반 턴제 RPG 게임==========");
                Console.WriteLine("               1 F ~ 10 F                ");
                Console.WriteLine();
                Console.WriteLine($"                현재 {floor.CurrentFloor}층                  ");
                Console.WriteLine();
                Console.WriteLine("            1. 다음 층 진행              ");
                Console.WriteLine();
                Console.WriteLine("            2. 1F으로 되돌아가기         ");
                Console.WriteLine();
                Console.Write("            입력 : ");

                int.TryParse(Console.ReadLine(), out int inputNum);

                if (inputNum == 1)
                {
                    Console.WriteLine("다음 층으로 진행합니다.");
                    Console.ReadLine();
                    // return 뒤에 개체를 반환하고 싶어서 위에서 void가 아닌 WaitChoice를 넣었음
                    return WaitChoice.NextFloor;
                }
                else if (inputNum == 2)
                {
                    floor.CurrentFloor = 1;
                    Console.WriteLine("1F층으로 되돌아갑니다.");
                    Console.ReadLine();
                    return WaitChoice.ReturnFirstFloor;
                }
                else
                {
                    Console.WriteLine("잘못된 번호를 입력하셨습니다.");
                    Console.ReadLine();
                }
            }
            
        }
    }
}
