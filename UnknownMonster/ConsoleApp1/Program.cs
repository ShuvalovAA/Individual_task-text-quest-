Console.Write($"{Config.WHITESPACE}Добро пожаловать в игру 'Неизвестное чудовище'!{Config.INTERVAL_LINE}");
Console.Write($"{Config.WHITESPACE}Нажмите 'Ввод' для продолжения.{Config.INTERVAL_LINE}");
Console.ReadLine();
Game.StartGame();
public class Config {

    public static string WHITESPACE = "\t\t\t";
    public static string INTERVAL_LINE = "\n\n\n";

    public static string[] QUESIONS = {
    "Как ты сюда попал?",
    "Как тебя зовут?",
    "У тебя кровь. Ты помнишь, кто это сделал?",
    "У тебя есть вода?",
    "Что у тебя в кармане светится?",
    "Ты хочешь умереть?"

    };
    public static Tuple<int, int , string >[] ANSWER = {
            Tuple.Create(1, 1, "если честно, я не знаю"),
            Tuple.Create(1, 0, "вы кто ?"),
            Tuple.Create(2, 1, "Кто вы?"),
            Tuple.Create(2, 0, "Ви"),
            Tuple.Create(3, 1, "уже бы сказал"),
            Tuple.Create(3, 0, "Не помню"),
            Tuple.Create(4, 1, "нет"),
            Tuple.Create(4, 0, "у меня только фонарь"),
            Tuple.Create(5, 1, "фонарь, кажется"),
            Tuple.Create(5, 0, "*положить руку на карман"),
            Tuple.Create(6, 1, "*Достать фонарь и посветить на девочку"),
            Tuple.Create(6, 0, "*удивлённо посмотреть на девочку")
    };
};
public class Person {
    public string weapon;
    public int healf = 100;
    public int weapon_power;
};

public class Girlie : Person {
    public string weapon = "poisonous tentacles";
    public double weapon_power = 40;
}

public class Magician : Person
{
    public string weapon = "magic";
    public double weapon_power = 30;
    public double count_magic = 90;
}

public class GoodBoy : Person
{
    public string weapon = "lantern";
    public double weapon_power = 10;
}

public class LogicGame {
    private static GoodBoy  goodboy = new GoodBoy();
    private static Girlie girlie = new Girlie();
    private static Magician magician = new Magician();

    public static void RebootGame()
    {
        Console.Write($"{Config.INTERVAL_LINE}{Config.WHITESPACE}Повторить игрy(y/n):{Config.INTERVAL_LINE}");
        string reboot = Console.ReadLine();
        bool reboot_bool = String.Equals(reboot, "y") | String.Equals(reboot, "n");
        while (reboot_bool == false)
        {
            Console.Write($"{Config.WHITESPACE}Повторить игрy(y/n):{Config.INTERVAL_LINE}");
            reboot = Console.ReadLine();
            reboot_bool = String.Equals(reboot, "y") | String.Equals(reboot, "n");
        };
        if (reboot == "y")
        {
            goodboy = new GoodBoy();
            girlie = new Girlie();
            magician = new Magician();
            Game.StartGame();
        };
        Environment.Exit(0);
    }
    public static void GameActions(int answer, int num_q)
    {
        
        if (answer == 1)
        {
            magician.weapon_power += 10;           
        }
        else
        {
            magician.count_magic -= 50;
            girlie.weapon_power += girlie.weapon_power;
        }
        bool ready_weapon = magician.weapon_power >= magician.count_magic;
        bool ready_crit = 90 <= 100 * magician.weapon_power / girlie.healf;
        bool game_over = goodboy.healf < girlie.weapon_power;
        Console.Write($"{ready_weapon}");
        if (ready_crit & ready_weapon)
        {
            Console.Write($"{Config.WHITESPACE}{Config.WHITESPACE}WIN!{Config.INTERVAL_LINE}");
            Console.Write($"{Config.WHITESPACE}Вы что-то вспоминаете и интутивно достаёте фонарик.\n"+
                $"{Config.WHITESPACE}Светите на девочку. Девочка преображается в кошмарное чудовище\n" +
                $"{Config.WHITESPACE}Мужчина в мантии разврачиваете к девочке и выстреливает из рук\n" +
                $"{Config.WHITESPACE}большим светящимся синим шаром. Чущовище повержено.");
            RebootGame();
        }

        if (game_over)
        {
            Console.Write($"{Config.WHITESPACE}{Config.WHITESPACE}GAME OVER!{Config.INTERVAL_LINE}");
            Console.Write($"{Config.WHITESPACE}Девочка начитает улыбаться, её начинает трясти.\n"+
                $"{Config.WHITESPACE}Из неё появляются щупальца. Она убивает Вас и мага!");
            RebootGame();
        }

        bool alternative = !(ready_crit & ready_weapon) & !game_over & num_q == Config.QUESIONS.Length;
        if (alternative)
        {
            Console.Write($"{Config.WHITESPACE}{Config.WHITESPACE}DRAW!{Config.INTERVAL_LINE}");
            Console.Write($"{Config.WHITESPACE}Девочка начитает улыбаться, её начинает трясти.\n" +
                $"{Config.WHITESPACE}Вдруг из темноты появляет второй мужчина и вонзает в девочку меч\n"+
                $"{Config.WHITESPACE}Он говорит что необходимо бежать, потому что меч задержет её не надолго\n"+
                $"{Config.WHITESPACE}Вы убегаете в темноту под страшные крики чудовища.\n"
                );
            RebootGame();
        }
    }
};
public class Game
{
    public static void StartGame()
    {
        Console.WriteLine($"{Config.WHITESPACE}Перед вами непонятное тёмное место,\n" +
        $"{Config.WHITESPACE}похожее то ли на яму то ли на пещеру. Всё тело ломит.Вы чувствуете что рядом с вами\n" +
        $"{Config.WHITESPACE}есть кто-то ещё. Вдруг кто-то поджигает, как Вы видите, ветки, и загарается костёр.\n" +
        $"{Config.WHITESPACE}Перед Вами возникают мужчина в маньтии и маленькая девочка.\n" +
        $"{Config.WHITESPACE}Девочка смотрит на огонь, а мужчина поворачивается к Вам лицом.{Config.INTERVAL_LINE}"
    );
            Console.Write($"{Config.WHITESPACE}Нажмите 'Ввод' для продолжения.{Config.INTERVAL_LINE}");
            Console.ReadLine();
            Console.WriteLine($"{Config.WHITESPACE}{Config.WHITESPACE}ИГРА НАЧАЛАСЬ:{Config.INTERVAL_LINE}");
        for (int i = 0; i < Config.QUESIONS.Length; i++)
        {
            int quesion_index = i+1;
            int q_index;
            int bool_answer;
            string[] answers = new string[2];
            int index_custom = 0;
            Console.Write($"{Config.WHITESPACE}{Config.QUESIONS[i]}{Config.INTERVAL_LINE}");
            for (int z = 0; z < Config.ANSWER.Length; z++) {
                q_index = Config.ANSWER[z].Item1;
                
                if (q_index == quesion_index)
                {
                    bool_answer = Config.ANSWER[z].Item2;
                    answers[index_custom] =Config.ANSWER[z].Item3;
                    index_custom +=1;

                }
            };

            Console.Write("Ответы:");
            for (int a_i = 0; a_i < answers.Length; a_i++)
            {
                Console.Write($"\n{a_i} - {answers[a_i]}");
            };
            Console.Write("\nОтветить(1/0):");
            string answer = Console.ReadLine();

            bool need_wait = String.Equals(answer, "1") | String.Equals(answer, "0");
            while(need_wait == false)
            {
                Console.Write("\nОтветить(1/0):");
                answer = Console.ReadLine();
                need_wait = String.Equals(answer, "1") | String.Equals(answer, "0");
            };
            int answer_int = int.Parse(answer);
            LogicGame.GameActions(answer_int, i+1);
        };

    } 
};


