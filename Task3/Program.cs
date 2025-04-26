using Task3;

#region format1

using var sr1 = new StreamReader(File.OpenRead(@"input_logs1.txt"));
var log1 = await sr1.ReadToEndAsync();

var formatedLog1 = LogParser.ParseLog(log1);

await using var sw1 = new StreamWriter(File.OpenWrite(@"output_logs1.txt"));
await sw1.WriteAsync(formatedLog1);

#endregion



#region format2

using var sr2 = new StreamReader(File.OpenRead(@"input_logs2.txt"));
var log2 = await sr2.ReadToEndAsync();

var formatedLog2 = LogParser.ParseLog(log2);

await using var sw2 = new StreamWriter(File.OpenWrite(@"output_logs2.txt"));
await sw2.WriteAsync(formatedLog2);

#endregion

#region invalid_format

var invalidLog = "This is an invalid log entry.";
LogParser.ParseLog(invalidLog);

Console.WriteLine(File.ReadAllText("problems.txt"));

#endregion