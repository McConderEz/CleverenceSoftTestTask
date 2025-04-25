using Task2;

var tasks = new Task[10];

for (var i = 0; i < 7; i++)
{
    tasks[i] = Task.Run(() =>
    {
        var random = new Random();
        for (var j = 0; j < 5; j++) 
        {
            var count = Server.GetCount();
            Console.WriteLine($"Читатель {Task.CurrentId} значение: {count}");
            Thread.Sleep(random.Next(100, 500));
        }
    });
}

for (var i = 7; i < 10; i++)
{
    tasks[i] = Task.Run(() =>
    {
        var random = new Random();
        for (var j = 0; j < 3; j++)
        {
            var valueToAdd = random.Next(1, 10);
            Server.AddToCount(valueToAdd);
            Console.WriteLine($"Писатель {Task.CurrentId} добавил {valueToAdd}, новое значение: {Server.GetCount()}");
            Thread.Sleep(random.Next(200, 600)); 
        }
    });
}

await Task.WhenAll(tasks);

Console.WriteLine($"Итоговое значение: {Server.GetCount()}");