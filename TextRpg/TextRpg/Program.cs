using System;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using TextRpg;
namespace TextRpg
{
    internal class Program
    {
        static public Inventory inventory = new Inventory();
        static public Store store = new Store();
        static public MainMenu mainMenu = new MainMenu();
        static public Item item = new Item();
        static public Player player1 = new Player("", 1, 10, 5, 100, 1000, "전사");
        static public Player player2 = new Player("CC", 1, 12, 4, 100, 1200, "도적");
        static public Program printInfo = new Program();
       

        public void Printinfo()
        {
            
            Console.WriteLine("상태보기\n캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("Level: " + player1.Level);
            Console.Write("( " + player1.Name + " )");
            Console.WriteLine("( " + player1.Job + " )");
            Console.WriteLine("Attack: " + player1.Attack);
            Console.WriteLine("Defense: " + player1.Defense);
            Console.WriteLine("체력: " + player1.Hp);
            Console.WriteLine("Gold: " + player1.Gold + "\n");
            Console.WriteLine("0.나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");


            string Choice = Console.ReadLine();
            int choice = int.Parse(Choice);

            if (choice == 0)
            {
                Console.Clear();
                Program.mainMenu.Printmenu();
            }
            else
            {
                Console.WriteLine("잘못 입력하셨습니다.");
            }

        }
    }

    public class Inventory
    {

        public void inventory()
        {
            Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다,\n");
            Console.WriteLine("[아이템 목록]\n");//  아이템 목록 불러오기 아이템 함수를 더해서 만들어야 할듯 싶다.
            Console.WriteLine(Program.item);
            Console.WriteLine("1. 장착 관리\n0. 나가기");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            string Choice = Console.ReadLine();
            int choice = int.Parse(Choice);
            bool ischoice = int.TryParse(Choice, out choice);

            do //0(나가기) or 1(장착관리)를 고르기 전엔 반복
            {
                switch (Choice)
                {
                    case "1":
                        EquipManage();
                        break;
                    case "0":
                        Console.Clear();
                        Program.mainMenu.Printmenu();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                        Console.ReadLine();
                        break;
                }
            } while (!ischoice || choice < 0 || choice > 1);
        }


        public void EquipManage()// 아이템들을 불러오고 앞에 index의 i값을 붙여 표현하여야하는게 아닌가 
        /*- 장착관리가 시작되면 아이템 목록 앞에 숫자가 표시됩니다.
         일치하는 아이템을 선택했다면
         - 장착중이지 않다면 → 장착
          [E] 표시 추가
         - 이미 장착중이라면 → 장착 해제
          [E] 표시 없애기
         - 일치하는 아이템을 선택했지 않았다면(예제에서 1~3이외 선택시)
         - **잘못된 입력입니다** 출력
         - 아이템의 중복 장착을 허용합니다.*/
        {
            bool isEquip;
            if(isEquip = true)
            {

            }
        }
    }
    public class Item
    {
        public string[] ItemName = new string[8];
        public int[] ItemGold = new int[8];        

        public Item()
        {
            ItemName[0] = " ";
            ItemName[1] = "수련자 갑옷  | 방어력 +5 | 수련에 도움을 주는 갑옷입니다. l";
            ItemName[2] = "무쇠갑옷  | 방어력 + 9 | 무쇠로 만들어져 튼튼한 갑옷입니다. l";
            ItemName[3] = "스파르타의 갑옷 | 방어력 + 15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다. |";
            ItemName[4] = "고인물용 흰티 ㅣ 방어력 + 0 ㅣ 수상할 정도로 게임에 진심인 사람들을 위한 갑옷입니다. ㅣ";
            ItemName[5] = "낡은 검 | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다. ㅣ";
            ItemName[6] = "청동 도끼 | 공격력 +5 | 어디선가 사용됐던거 같은 도끼입니다.ㅣ";
            ItemName[7] = "스파르타의 창  | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다. |";
            ItemName[8] = "장미칼 ㅣ 공격력 +9 ㅣ 보랏빛 장미가 보이는 칼입니다. 베이지 않게 조심하세요. ㅣ";

            ItemGold[0] = 0;
            ItemGold[1] = 1000;
            ItemGold[2] = 1500;
            ItemGold[3] = 2500;
            ItemGold[4] = 5000;
            ItemGold[5] = 600;
            ItemGold[6] = 1500;
            ItemGold[7] = 3000;
            ItemGold[8] = 5000;

            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine(ItemName[i]+" " + ItemGold[i]);
            }
        }
        
        
       
    }

    public class Store
    {
            
        public Store()
        {
            Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]\n" + Program.player1.Gold + " G\n");
            Console.WriteLine("[아이템 목록]\n");
            Console.WriteLine(Program.item);
            Console.WriteLine("1. 아이템 구매\n0. 나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");
            if (Console.ReadLine() == "0") //메인화면
            {
                Console.Clear();
                Program.mainMenu.Printmenu();
            }
            else if (Console.ReadLine() == "1") //아이템 구매
            {
                BuyItem();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.ReadLine();
            }

        }


        public void BuyItem()
        {
            
            int i = Console.Read();
            string stri = i.ToString();
            string StrItemGold= Program.item.ItemGold[i].ToString();
            string[] strItemGold = new string[i];
            string AlreadyBuy = "구매 완료";
            Console.WriteLine("구매하실 아이템의 번호를 입력해주세요.");
            Console.WriteLine( stri + Program.item.ItemName[i]);

            if (i > 0 && i < 9)
            {
                if(Program.player1.Gold > Program.item.ItemGold[i])
                {
                    Program.player1.Gold -= Program.item.ItemGold[i];
                    Console.WriteLine(Program.item.ItemName[i]+"를 구매하셨습니다.");
                    strItemGold[i] = strItemGold[i].Replace(strItemGold[i], AlreadyBuy);                    
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다.");
                }
            }
            else if(i == 0)
            {
                Program.mainMenu.Printmenu();
            }
            else
            {
                Console.WriteLine("올바른 번호를 입력해주세요.");
            }
        }      
    }

    public class Player //보유 골드 현재 체력 방어력 공격력 직업 관련 함수 작성
    {
        public string Name;
        public int Level;
        public int Attack;
        public int Defense;
        public int Hp;
        public int Gold;
        public string Job;

        public Player(string name, int level, int attack, int defense, int hp, int gold, string job)
        {
            Name = name;
            Level = level;
            Attack = attack;
            Defense = defense;
            Hp = hp;
            Gold = gold;
            Job = job;

        }
        public void PlayerStat()
        {
            if (Job == "전사")
            {
                Gold = 1000;
                Level = 1;
                Attack = 10;
                Defense = 5;
                Hp = 120;
            }
            else if (Job == "도적")
            {
                Gold = 1300;
                Level = 1;
                Attack = 12;
                Defense = 4;
                Hp = 100;
            }

            if (Hp <= 0)
            {
                Console.WriteLine("당신은 죽었습니다.");              
            }
        }
        
    }


    public class MainMenu
    {
        
        public void Printmenu()
        {

            Console.WriteLine("스파르타 마을에 오신 여러분을 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            string Choice = Console.ReadLine();
            int choice = int.Parse(Choice);
            bool ischoice = int.TryParse(Choice, out choice);

            do // 선택 수에 따른 클래스 및 함수 화면 노출
            {
                switch (Choice)
                {
                    case "1":
                        Console.Clear();
                        Program.printInfo.Printinfo() ;
                        break;
                    case "2":
                        Console.Clear();

                        break;
                    case "3":
                        Console.Clear();

                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            } while (choice > 3 || choice < 0 || !ischoice);
        }

        public void StartMenu(string Name)
        {

            Console.WriteLine("Text Rpg를 실행해주셔서 정말 감사합니다.");
            Console.WriteLine("이름을 입력해주세요.");
            Name = Console.ReadLine();

            Console.WriteLine("직업을 입력해주세요.\n1. 전사 ㅣ 체력과 방어력이 높다. \n2. 도적 ㅣ 체력과 방어력이 낮지만 공격력과 보유 골드가 많다.");
            int isJob;

            do
            {
                isJob = int.Parse(Console.ReadLine());
                if (isJob == 1 || isJob == 2)
                {
                    if (isJob == 1)
                    {
                        Program player1;
                    }
                    else if (isJob == 2)
                    {
                        Program player2;
                    }
                }
                else
                {
                    Console.WriteLine("올바른 숫자를 입력해주세요.");
                }
            } while (isJob != 1 && isJob != 2);

        }
    }
    static public void Main()
    {
        MainMenu.StartMenu();
    }

}