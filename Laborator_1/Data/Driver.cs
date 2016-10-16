using System;

namespace Data
{
    public class Driver
    {
        public static void Main(string[] args)
        {
            Guid trololol = Guid.NewGuid();
            DateTime value1 = new DateTime(2012, 10, 21);         
            Manager manager = new Manager(trololol, "asdasd", "dsadsaas", value1, 2321.22);
            manager.Salutation();
            Console.ReadLine();
        }
    }
}
