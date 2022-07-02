using System;
namespace task10
{
    class WordDoesntFound:Exception
    {
        public WordDoesntFound() : base()
        {
        }

        public WordDoesntFound(string message) : base(message)
        {
        }
    }
}
