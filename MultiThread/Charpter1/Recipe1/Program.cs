using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Recipe1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            const string MutexName = "Mutex-Test";
            var m = new Mutex(true, MutexName);
            print("执行代码逻辑...");
            m.ReleaseMutex();
            print("释放Mutex锁");
            Thread t1 = new Thread(() =>
            {
                print("执行代码逻辑...");
                m.WaitOne();
                print("获得了Mutex锁，执行其他逻辑...");
                m.ReleaseMutex();
                print("释放Mutex锁");
            });
            t1.Name = "t1";
            t1.Start();
            t1.Join();
            wait();
        }
        static void print(string msg)
        {
            Console.WriteLine("{0} 线程{1} {2}", DateTime.Now.ToString("HH:mm:ss:ms"), Thread.CurrentThread.Name, msg);
        }
        static void wait()
        {
            print("程序运行结束，按任意键退出...");
            Console.ReadLine();
        }
    }
}
