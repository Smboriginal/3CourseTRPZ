using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Автентификация.
            Console.WriteLine("Вас приветствует система регистрации спецификаций товара.");
            Console.Write("Ваше имя в ФАСТ: ");
            var clientName = Console.ReadLine();
            //Console.WriteLine("Данный вид запаса погружается в фуру...");
            Service service = null;

            // Просим пользователя выбрать расцветку. 
            // Повторяем до тех пор, пока пользователь не введет корректное значение.
            do
            {
                service = GetServiceType(clientName);
            }
            while (service == null);

            // Просим клиента выбрать дополнительные принадлежности.
            // Повторяем вопрос до тех пор, пока пользователь не откажется от добавки.
            while(true)
            {
                service = GetServiceAdding(service, out bool finish);
                if(finish)
                {
                    break;
                }
            }

            // Выводим сообщение о комплектации.
            Console.WriteLine($"{service}. Стоимость {service.Price} бачей.");
            Console.ReadLine();
        }

        /// <summary>
        /// Запросить о добавке принадлежностей.
        /// </summary>
        /// <param name="service">Сервиз, в который можно положить дополнительную фурнитуру.</param>
        /// <param name="finish">Добавление принадлежностей не нужно.</param>
        /// <returns>Сервиз с фурнитурой.</returns>
        private static Service GetServiceAdding(Service service, out bool finish)
        {
            // Предоставим выбор в необходимости фурнитуры пользователю.
            finish = false;

            // Все возможные виды добавления фурнитуры
            // сохраняем выбор на каждом шаге.
            Console.WriteLine("Хотите украсить сервиз для подарка?");
            foreach (AddingType t in Enum.GetValues(typeof(AddingType)))
            {
                Console.WriteLine($"{(int)t} - {t.GetDescription()}");
            }
            var adding = Console.ReadLine();

            // Пытаемся парсить ответ пользователя к требуемому типу.
            if (int.TryParse(adding, out int addingType))
            {
                switch ((AddingType)addingType)
                {
                    case AddingType.None:
                        // Достаточно того, что имеем.
                        // Возвращаем просто сервиз.
                        finish = true;
                        return service;
                    case AddingType.Cup:
                        // Добавляем чашку.
                        return new AddCup(service);
                    case AddingType.Saucer:
                        // Добавляем блюдце
                        return new AddSaucer(service);
                    case AddingType.Dish:
                        // Добавляем мыску.
                        return new AddDeepDish(service);
                    case AddingType.CoffeeCup:
                        // Добавляем коф.кружку.
                        return new AddCoffeeCup(service);
                    default:
                        // Не удалось привести ответ пользователя к требуемому виду.
                        // Введено число отсутствующее в перечислении типов.
                        Console.WriteLine("Вы ввели некорректное значение!");
                        return service;
                }
            }
            else
            {
                // Не удалось привести ответ пользователя к требуемому виду.
                // Введено не целое число.
                Console.WriteLine("Вы ввели некорректное значение!");
                return service;
            }
        }

        /// <summary>
        /// Запросить у пользователя тип окраски.
        /// </summary>
        /// <param name="clientName">имя юзера.</param>
        /// <returns>Шаурма.</returns>
        private static Service GetServiceType(string clientName)
        {
            // Выводим пользователю все возможные окраски
            // и сохраняем его ответ.
            Console.WriteLine($"{clientName}, выберите, пожалуйста, цвет из представленных:");
            foreach (Colours t in Enum.GetValues(typeof(Colours)))
            {
                Console.WriteLine($"{(int)t} - {t.GetDescription()}");
            }
            var type = Console.ReadLine();

            // Пытаемся привести ответ пользователя к требуемому типу.
            if (int.TryParse(type, out int shaurmaType))
            {
                switch ((Colours)shaurmaType)
                {
                    case Colours.Standart:
                        // Шаурма в обычном цвете.
                        return new Pink(clientName);
                    case Colours.Cheese:
                        // Шаурма в золотистом цвете.
                        return new Golden(clientName);
                    case Colours.Arabic:
                        // Шаурма в голубом цвете.
                        return new Blue(clientName);
                    default:
                        // Не удалось привести ответ пользователя к требуемому виду.
                        // Введено число отсутствующее в перечислении окрасок.
                        Console.WriteLine("Вы ввели некорректное значение!");
                        return null;
                }
            }
            else
            {
                // Не удалось привести ответ пользователя к требуемому виду.
                // Введено не целое число.
                Console.WriteLine("Вы ввели некорректное значение!");
                return null;
            }
        }
    }
}
