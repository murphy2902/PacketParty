using System;
using System.Diagnostics;
using System.ComponentModel;

public class NetworkCalls {

   static string getOS( string ipAddr ) {
      Process proc = new System.Diagnostics.Process();
      proc.StartInfo.FileName = "/usr/bin/nmap";
      proc.StartInfo.Arguments = "-O -v " + ipAddr;
      proc.StartInfo.UseShellExecute = false;
      proc.StartInfo.RedirectStandardOutput = true;
      proc.Start();

      string output = proc.StandardOutput.ReadToEnd();
      
      string[] lines = output.Split('\n');

      for( int i = 0; i < lines.Length; i++ ) {
         string[] focus = lines[i].Split(':');

         if( focus[0].Equals("OS details" ) ) {
               return focus[1];
         }
      }

      Console.WriteLine( output );
      return "I don't know";
   }

   static string getHostName( string ipAddr ) {
      Process proc = new System.Diagnostics.Process();
      proc.StartInfo.FileName = "/usr/bin/nmap";
      proc.StartInfo.Arguments = "-sL " + ipAddr;
      proc.StartInfo.UseShellExecute = false;
      proc.StartInfo.RedirectStandardOutput = true;
      proc.Start();

      string output = proc.StandardOutput.ReadToEnd();
      
      string[] lines = output.Split('\n');


      for( int i=0; i<lines.Length; i++ ) {
         string[] focus = lines[i].Split(' ');
         if( focus[0].Equals("Nmap") && focus[1].Equals("scan") && focus[2].Equals("report")) {
            return focus[4];
         }
      }

      Console.WriteLine( output );
      return "I don't know";
   }

   static string getUptime( string ipAddr ) {
      Process proc = new System.Diagnostics.Process();
      proc.StartInfo.FileName = "/usr/bin/nmap";
      proc.StartInfo.Arguments = "-O -v " + ipAddr;
      proc.StartInfo.UseShellExecute = false;
      proc.StartInfo.RedirectStandardOutput = true;
      proc.Start();

      string output = proc.StandardOutput.ReadToEnd();
      
      string[] lines = output.Split('\n');


      for( int i=0; i<lines.Length; i++ ) {
         string[] focus = lines[i].Split(' ');
         if( focus[0].Equals("Uptime") && focus[1].Equals("guess:")) {
            string result = "";
            for(int j = 2; j<focus.Length; j++){
               result += focus[j] + " ";
            }

            return result;
         }
      }

      Console.WriteLine( output );
      return "I don't know";
   }

   static string getTraceRoute( string ipAddr ) {
      Process proc = new System.Diagnostics.Process();
      proc.StartInfo.FileName = "/usr/bin/traceroute";
      proc.StartInfo.Arguments = " " + ipAddr;
      proc.StartInfo.UseShellExecute = false;
      proc.StartInfo.RedirectStandardOutput = true;
      proc.Start();

      string output = proc.StandardOutput.ReadToEnd();

      string[] lines = output.Split("\n");
      string result = "";

      return output;

      Console.WriteLine( output );
   }

   static void blockIP( string ipAddr ) {
      Process proc = new System.Diagnostics.Process();
      proc.StartInfo.FileName = "/usr/bin/iptables";
      proc.StartInfo.Arguments = "-A INPUT -s " + ipAddr + " -j DROP";
      proc.StartInfo.UseShellExecute = false;
      proc.StartInfo.RedirectStandardOutput = true;
      proc.Start();
   }

   static void ping( string ipAddr ) {
      Process proc = new System.Diagnostics.Process();
      proc.StartInfo.FileName = "/usr/bin/ping";
      proc.StartInfo.Arguments = " " + ipAddr + "-c 1";
      proc.StartInfo.UseShellExecute = false;
      proc.StartInfo.RedirectStandardOutput = true;
      proc.Start();
   }

   public static void Main() {
      Console.WriteLine( getTraceRoute( "www.google.com" ) );
   }
}
