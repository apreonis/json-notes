using System.Text.Json;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            static int AskNumberInRange(string prompt, int max)
            {
                while (true)
                {
                    Console.Write($"{prompt}: ");
                    string input = Console.ReadLine()!;

                    if (int.TryParse(input, out int number) && number >= 1 && number <= max)
                    {
                        return number;
                    }

                    Console.WriteLine($"Неверно. Введите число от 1 до {max}.");
                }
            }
            INoteRepository localrepository = new JsonNoteRepository();
            while (true)
            {
                Console.WriteLine("\tЗаметки");
                Console.WriteLine("1.Получить информацию из файла");
                Console.WriteLine("2.Добавить информацию в файл");
                Console.WriteLine("3.Удалить информацию из файла");
                Console.Write("Выберите необходимую вам функцию: ");
                var userchoose = Console.ReadLine();

                switch (userchoose)
                {
                    case "Получить информацию из файла":
                    case "1":
                        List<Note> nelist = await localrepository.GetAllAsync();
                        if (nelist.Count == 0)
                        {
                            Console.WriteLine("Никаких заметок нету");
                            break;
                        }
                        
                            Console.WriteLine($"{nelist.Count} количество заметок");
                                int numbernotes = AskNumberInRange("Введите номер заметки", nelist.Count);
                                Note mylist = nelist[numbernotes - 1];
                                Console.WriteLine(mylist.ID);
                                Console.WriteLine(mylist.Title);
                                Console.WriteLine(mylist.Text);
                                Console.WriteLine(mylist.CreatedAt);
                                for (int i = 0; i < mylist.Tags.Length; i++)
                                {
                                    Console.Write(mylist.Tags[i] + ",");
                                }
                                Console.WriteLine("Информация получена");
                                break;
                        
                    case "Добавить информацию в файл":
                    case "2":
                        Note localNote = new Note();
                        Console.Write("Введите название заметки:");
                        localNote.Title = Console.ReadLine()!;
                        Console.Write("Введите описание заметки:");
                        localNote.Text = Console.ReadLine()!;
                        Console.Write("Введите количество тэгов которое вы хотите приписать к заметке:");
                        int timesfor = Convert.ToInt32(Console.ReadLine()!);
                        localNote.Tags = new string [timesfor];
                        for(int i = 0;i < timesfor; i++)
                        {
                            Console.Write($"Введите {i + 1} тэг: ");
                            localNote.Tags[i] = Console.ReadLine()!;
                        }
                        await localrepository.AddAsync(localNote);
                        Console.WriteLine("Информация добавлена");
                        break;
                    case "Удалить информацию из файла":
                    case "3":
                        List<Note> nelist2 = await localrepository.GetAllAsync();
                        if (nelist2.Count == 0)
                        {
                            Console.WriteLine("Никаких заметок нету");
                            break;
                        }
                       
                            Console.WriteLine($"{nelist2.Count} количество заметок");
                                int numbernotes2 = AskNumberInRange("Введите номер заметки, которую хотите удалит: ", nelist2.Count);
                            Guid localid = nelist2[numbernotes2 - 1].ID;
                                await localrepository.DeleteAsync(localid);
                                Console.WriteLine("Информация удалена из файла");
                                break;
                            
                                
                        
                    default:
                        Console.WriteLine("Такого Варианта ответа нет");
                        break ;
                }
            }
        }
    }
}
