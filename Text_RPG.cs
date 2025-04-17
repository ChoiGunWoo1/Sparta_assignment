using System;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Text_RPG
{
    internal class Program
    {
        static Random rand = new Random();
        public static string Showwhatyouwant()
        {
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            string input = Console.ReadLine();
            Console.WriteLine("");
            return input;
        }

        public enum itemtype
        {
            weapon,
            armor
        }
        public struct item
        {
            public itemtype it;
            public string name;
            public int stats;
            public string explanation;
            public bool equiped;
            public bool issold;
            public int price;

        }
        
        public class Character // 캐릭터 정보 클래스
        {
            public string job = "전사";
            public int level = 1;
            public int attack = 10;
            public int guard = 5;
            public int health = 100;
            public int gold = 1500;
            public item[] items = new item[100];
            public int itemnum = 0;
            public void ShowStatus()
            {
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine("");
                Console.WriteLine($"최건우 ( {job} )");
                int plusattack = 0;
                int plusguard = 0;
                for(int i = 0; i < itemnum; i++)
                {
                    if (items[i].equiped && items[i].it == itemtype.weapon)
                    {
                        plusattack += items[i].stats;
                    }
                    else if(items[i].equiped)
                    {
                        plusguard += items[i].stats;
                    }
                }
                if(plusattack > 0)
                {
                    Console.WriteLine($"공격력 : {attack} (+{plusattack})");
                }
                else
                {
                    Console.WriteLine($"공격력 : {attack}");
                }
                if(plusguard > 0)
                {
                    Console.WriteLine($"방어력 : {guard} (+{plusguard})");
                }
                else
                {
                    Console.WriteLine($"방어력 : {guard}");
                }
                Console.WriteLine($"체 력 : {health}");
                Console.WriteLine($"Gold : {gold} G");
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
            }
            public void ShowInventory()
            {
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < itemnum; i++)
                {
                    string its;
                    if (items[i].it == itemtype.weapon)
                    {
                        its = "공격력";
                    }
                    else
                    {
                        its = "방어력";
                    }
                    if (items[i].equiped)
                    {
                        Console.WriteLine($"-{i + 1} [E]{items[i].name,-8} | {its} +{items[i].stats} | {items[i].explanation}");
                    }
                    else
                    {
                        Console.WriteLine($"-{i + 1} {items[i].name,-8} | {its} +{items[i].stats} | {items[i].explanation}");
                    }
                }
            }
            public void Rest()
            {
                if(gold >= 500)
                {
                    health = 100;
                    Console.WriteLine("휴식을 완료했습니다.");
                }
                else
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }
            }
        }
        public class Store // 상점 정보 클래스
        {
            public item[] storeitems = new item[100];
            public int storeitemnum = 0;
            public Store()
            {
                storeitemnum = 6;
                storeitems[0].it = itemtype.armor;
                storeitems[0].stats = 5;
                storeitems[0].name = "수련자 갑옷";
                storeitems[0].explanation = "수련에 도움을 주는 갑옷입니다.";
                storeitems[0].issold = false;
                storeitems[0].price = 1000;
                storeitems[0].equiped = false;

                storeitems[1].it = itemtype.armor;
                storeitems[1].stats = 9;
                storeitems[1].name = "무쇠 갑옷";
                storeitems[1].explanation = "무쇠로 만들어져 튼튼한 갑옷입니다.";
                storeitems[1].issold = false;
                storeitems[1].price = 2000;
                storeitems[1].equiped = false;

                storeitems[2].it = itemtype.armor;
                storeitems[2].stats = 5;
                storeitems[2].name = "스파르타의 갑옷";
                storeitems[2].explanation = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.";
                storeitems[2].issold = false;
                storeitems[2].price = 3500;
                storeitems[2].equiped = false;

                storeitems[3].it = itemtype.weapon;
                storeitems[3].stats = 2;
                storeitems[3].name = "낡은 검";
                storeitems[3].explanation = "쉽게 볼 수 있는 낡은 검입니다.";
                storeitems[3].issold = false;
                storeitems[3].price = 600;
                storeitems[3].equiped = false;

                storeitems[4].it = itemtype.weapon;
                storeitems[4].stats = 5;
                storeitems[4].name = "청동 도끼";
                storeitems[4].explanation = "어디선가 사용됐던것 같은 도끼입니다.";
                storeitems[4].issold = false;
                storeitems[4].price = 1500;
                storeitems[4].equiped = false;

                storeitems[5].it = itemtype.weapon;
                storeitems[5].stats = 7;
                storeitems[5].name = "스파르타의 창";
                storeitems[5].explanation = "스파르타 전사들이 사용했다는 전설의 창입니다.";
                storeitems[5].issold = false;
                storeitems[5].price = 3000;
                storeitems[5].equiped = false;
            }
            public void Showstoreitems()
            {
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine("");
                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < storeitemnum; i++)
                {
                    string its;
                    if (storeitems[i].it == itemtype.weapon)
                    {
                        its = "공격력";
                    }
                    else
                    {
                        its = "방어력";
                    }
                    if (storeitems[i].issold)
                    {
                        Console.WriteLine($"-{i + 1} {storeitems[i].name,-8} | {its} +{storeitems[i].stats} | {storeitems[i].explanation,-20} | 구매완료");
                    }
                    else
                    {
                        Console.WriteLine($"-{i + 1} {storeitems[i].name,-8} | {its} +{storeitems[i].stats} | {storeitems[i].explanation,-20} | {storeitems[i].price} G");
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
            }
        }
        public struct dg
        {
            public string name;
            public int recommend_defense;
            public int clear_reward;
        }
        public class Dungeon //던전 정보 클래스
        {
            public dg[] dgs = new dg[3];
            public Dungeon()
            {
                dgs[0].name = "쉬운 던전";
                dgs[1].name = "일반 던전";
                dgs[2].name = "어려운 던전";
                dgs[0].recommend_defense = 5;
                dgs[1].recommend_defense = 11;
                dgs[2].recommend_defense = 17;
                dgs[0].clear_reward = 1000;
                dgs[1].clear_reward = 1700;
                dgs[2].clear_reward = 2500;
            }
            public void ShowDg()
            {
                for(int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"{i + 1}. {dgs[i].name,-8} | 방어력 {dgs[i].recommend_defense}이상 권장");
                }
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
            }
        }
        public class GameManager // 전체적인 게임 흐름 관리
        {
            public Character character = new Character();
            public Store store = new Store();
            public Dungeon dungeon = new Dungeon();
            public void TryRest()
            {
                int input;
                while(true)
                {
                    Console.WriteLine("휴식하기");
                    Console.WriteLine($"500 G를 내면 체력을 회복할 수 있습니다. (보유 골드 : {character.gold}");
                    Console.WriteLine("");
                    Console.WriteLine("1. 휴식하기");
                    Console.WriteLine("0. 나가기");
                    string userwant = Showwhatyouwant();
                    if (int.TryParse(userwant, out input))
                    {
                        if(input == 0)
                        {
                            return;
                        }
                        if(input == 1)
                        {
                            Console.WriteLine("");
                            character.Rest();
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
            }
            public void equipmanagement()
            {
                int input;
                while (true){
                    character.ShowInventory();
                    Console.WriteLine("");
                    Console.WriteLine("0. 나가기");
                    string userwant = Showwhatyouwant();
                    if (int.TryParse(userwant, out input))
                    {
                        if(input == 0)
                        {
                            return;
                        }
                        if (input < 0 || input > character.itemnum)
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            continue;
                        }
                        if (character.items[input-1].equiped == false)
                        {
                            for(int i = 0; i < character.itemnum; i++)
                            {
                                if (character.items[input-1].it == character.items[i].it && character.items[i].equiped == true)
                                {
                                    character.items[i].equiped = false;
                                    if (character.items[i].it == itemtype.armor)
                                    {
                                        character.guard -= character.items[i].stats;
                                    }
                                    else
                                    {
                                        character.attack -= character.items[i].stats;
                                    }
                                    break;
                                }
                            }
                            character.items[input - 1].equiped = true;
                            if (character.items[input-1].it == itemtype.armor)
                            {
                                character.guard += character.items[input-1].stats;
                            }
                            else
                            {
                                character.attack += character.items[input-1].stats;
                            }
                        }
                        else
                        {
                            character.items[input-1].equiped = false;
                            if (character.items[input - 1].it == itemtype.armor)
                            {
                                character.guard -= character.items[input - 1].stats;
                            }
                            else
                            {
                                character.attack -= character.items[input - 1].stats;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
            }
            public void Trybuyitem(int itnum)
            {
                if (itnum <= 0 || itnum > store.storeitemnum)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return;
                }
                if (store.storeitems[itnum-1].issold)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                    return;
                }
                if(character.gold >= store.storeitems[itnum-1].price)
                {
                    character.gold -= store.storeitems[itnum-1].price;
                    store.storeitems[itnum - 1].issold = true;
                    character.items[character.itemnum] = store.storeitems[itnum - 1];
                    character.itemnum += 1;
                    Console.WriteLine("구매를 완료했습니다.");
                }
                else
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }
            }
            public void Storemanagement()
            {
                while (true)
                {
                    store.Showstoreitems();
                    string userwant = Showwhatyouwant();
                    int input;
                    if (int.TryParse(userwant, out input))
                    {
                        if (input == 0)
                        {
                            break;
                        }
                        Trybuyitem(input);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");

            }
            public void Enterdungeon(int input)
            {
                if(input < 0 || input > 3)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return;
                }
                int beforehealth = character.health;
                int beforegold = character.gold;
                if (character.guard < dungeon.dgs[input - 1].recommend_defense)
                {
                    int failed = rand.Next(1, 101);
                    if (failed <= 40)
                    {
                        Console.WriteLine("던전 클리어 실패...");
                        character.health /= 2;
                        Console.WriteLine("[탐험 결과]");
                        Console.WriteLine($"체력 {beforehealth} -> {character.health}");
                        Console.WriteLine($"Gold {beforegold} -> {character.gold}");
                        Console.WriteLine("");
                        Console.WriteLine("0. 나가기");
                        return;
                    }
                }
                int minushp = rand.Next(20, 36);
                minushp += (dungeon.dgs[input - 1].recommend_defense- character.guard);
                character.health -= minushp;
                if(character.health <= 0)
                {
                    character.health = 0;
                    Console.WriteLine("던전 클리어 실패...");
                    Console.WriteLine("[탐험 결과]");
                    Console.WriteLine($"체력 {beforehealth} -> {character.health}");
                    Console.WriteLine($"Gold {beforegold} -> {character.gold}");
                    Console.WriteLine("");
                    Console.WriteLine("0. 나가기");
                    return;
                }
                int plusreward = rand.Next(character.attack, (character.attack * 2) + 1);
                int reward = (plusreward + 100) * dungeon.dgs[input - 1].clear_reward / 100;
                character.gold += reward;

                Console.WriteLine("던전 클리어!");
                Console.WriteLine("축하합니다!");
                Console.WriteLine("쉬운 던전을 클리어하였습니다.");
                Console.WriteLine("");
                Console.WriteLine("[탐험 결과]");
                Console.WriteLine($"체력 {beforehealth} -> {character.health}");
                Console.WriteLine($"Gold {beforegold} -> {character.gold}");
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");

            }
            public void Dungeonmanagement()
            {
                Console.WriteLine("던전입장");
                Console.WriteLine("이곳에서 던전으로 들어갈 수 있습니다.");
                Console.WriteLine("");
                while (true) {
                    dungeon.ShowDg();
                    string userwant = Showwhatyouwant();
                    int input;
                    if (int.TryParse(userwant, out input))
                    {
                        if(input == 0)
                        {
                            return;
                        }
                        Enterdungeon(input);
                        while(true)
                        {
                            string userwant2 = Showwhatyouwant();
                            int input2;
                            if (int.TryParse(userwant2, out input2))
                            {
                                if (input2 == 0)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("잘못된 입력입니다.");
                                }
                            }
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            GameManager gamemanager = new GameManager();
          
            while(true)
            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 던전입장");
                Console.WriteLine("5. 휴식하기");
                string item = Showwhatyouwant();
                int input = 0;
                if(int.TryParse(item, out input))
                {
                    if (input <= 0 || input > 5)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        continue;
                    }
                    if(input == 1)
                    {
                        gamemanager.character.ShowStatus();
                        while (true)
                        {
                            string i = Showwhatyouwant();
                            int ip;
                            if(int.TryParse(i, out ip))
                            {
                                if(ip == 0)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("잘못된 입력입니다.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                            }
                        }
                        continue;
                    }
                    else if(input == 2)
                    {
                        Console.WriteLine("인벤토리");
                        gamemanager.character.ShowInventory();
                        Console.WriteLine("1. 장착 관리");
                        Console.WriteLine("0. 나가기");
                        string i = Showwhatyouwant();
                        int ip;
                        if(int.TryParse(i, out ip))
                        {
                            if(ip == 0)
                            {
                                continue;
                            }
                            else if(ip == 1)
                            {
                                gamemanager.equipmanagement();
                                continue;
                            }
                        }
                    }
                    else if(input == 3)
                    {
                        gamemanager.Storemanagement();
                    }
                    else if(input == 4)
                    {
                        gamemanager.Dungeonmanagement();
                    }
                    else if(input == 5)
                    {
                        gamemanager.TryRest();
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
            


        }
    }
}
