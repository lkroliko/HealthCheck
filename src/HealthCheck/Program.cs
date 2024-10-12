using HealthCheck;

if (args.Length == 0)
{
    Message.ShowInfo();
    Environment.Exit(Consts.ExitStatusCodes.Fail);
}

try
{
    var parser = new ArgsParser(args);
    if (parser.IsAddressValid() == false)
    {
        Message.ShowAddressError();
        Environment.Exit(Consts.ExitStatusCodes.Fail);
    }
    var logger = Factory.GetLogger(parser.GetIsSilent());
    var worker = Factory.GetHttpWorker(logger);
    var result = await worker.GetResultAsync(parser.GetAddress());
    Environment.Exit(result);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Environment.Exit(Consts.ExitStatusCodes.Fail);
}
