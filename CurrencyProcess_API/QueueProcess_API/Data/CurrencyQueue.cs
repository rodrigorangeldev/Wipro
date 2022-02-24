using QueueProcess_API.Models;

namespace QueueProcess_API.Data
{
    public static class CurrencyQueue
    {
       public static Queue<ParamValues> Queue = new Queue<ParamValues>();
    }
}
