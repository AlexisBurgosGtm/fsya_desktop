using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketIOClient;


namespace classSocketio
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        static Client socket;
        public static String ip;
        public static String user;
        [STAThread]
        static void Main()
        {
            
            user = "x";
            
            try
            {
                socket = new Client(ip.ToString());
                socket.On("txt", (data) =>
                {
                    //MessageBox.Show(data.RawMessage);
                    String msg = data.Json.Args[0].ToString();
                    Console.Write(msg);
                    
                    //MessageBox.Show(msg, "Received Data");
                });
                socket.Connect();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString(), "Something Went Wrong!!");
                //Application.Exit();
            }
            if (socket.ReadyState.ToString() == "Connecting")
            {
                userset();
                
            }
            else
            {
                //MessageBox.Show("Failed To Connect To Server!", "Error!");
                
            }
        }
        public static void emit(String msg)
        {
            socket.Emit("private message", user + " : " + msg);

        }
        public static void userset()
        {
            if (socket != null)
                socket.Emit("newuser", user);
        }
        public static void disco()
        {
            if (socket != null)
                socket.Emit("exit", user);
            socket.Close();
        }
        public static void send(string emit,string msn)
        {
            socket.Emit(emit, msn);
        }

    }
};