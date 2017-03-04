using System;

using System.Net;
using System.Net.Sockets;  

namespace ServerConsole
{
    public class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Sever is running now :)");
            ///<remarks>
            ///0.0.0.0 ：是一个所有不清楚的主机和目的网络的集合
            ///127.0.0.1 ：本机地址，主要用于地址。同localhost。
            ///255.255.255.255：限制广播地址，不能被路由器转发。
            ///</remarks>
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            ///<remarks>
            ///TCP 80=超文本服务器（Http),Executor,RingZero
            ///8500[UDP/TCP]: Flight Data Exchange.
            /// </remarks>
            TcpListener listener = new TcpListener(ip, 8500);

            listener.Start();//监听开始
            Console.WriteLine("Start Listening :)");
            ///<remarks>
            /// A new way to confirm.
            /// </remarks>
            Console.WriteLine("input “Q” to quit.");
            ConsoleKey key;//mark
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Q);
        }
    }
}
/*
 * using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
namespace ServerManySelf
{
    class Program
    {
        static void Main(string[] args)
        {
            const int BufferSize = 8192;//缓存大小，8192字节，可以保存4096个汉字和英文字符

            Console.WriteLine("Server is running ...");
            IPAddress ip = IPAddress.Parse("127.0.0.1");//获取ip地址
            TcpListener listener = new TcpListener(ip, 8500);

            listener.Start();//开始监听
            Console.WriteLine("Start Listening...");

            //获取一个连接，中断方法
            TcpClient remoteClient = listener.AcceptTcpClient();
            //打印连接到的客户端信息
            Console.WriteLine("Client Connected! {0}<--{1}", remoteClient.Client.LocalEndPoint, remoteClient.Client.RemoteEndPoint);
            //获取流，并写入buffer中
            NetworkStream streamToClient = remoteClient.GetStream();

            do
            {
                byte[] buffer = new byte[BufferSize];
                int bytesRead = streamToClient.Read(buffer, 0, BufferSize);//一直等待客户端传信息
                Console.WriteLine("Reading data,{0} bytes...", bytesRead);

                //获得请求的字符串
                string msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received:{0}", msg);
            } while (true);
            //按Q退出
            Console.WriteLine("\n\n 输入 \"Q\"键退出。");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Q);
        }
    }
}
*/