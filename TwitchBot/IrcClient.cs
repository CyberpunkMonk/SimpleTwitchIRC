﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TwitchBot {
	class IrcClient {
		private string userName;
		private string channel;
		private TcpClient tcpClient;
		private StreamReader inputStream;
		private StreamWriter outputStream;
		public IrcClient(string ip, int port, string uName, string pass) {
			this.userName = uName;

			tcpClient = new TcpClient(ip, port);
			inputStream = new StreamReader(tcpClient.GetStream());
			outputStream = new StreamWriter(tcpClient.GetStream());

			outputStream.WriteLine("PASS "+pass);
			outputStream.WriteLine("NICK " + uName);
			outputStream.WriteLine("USER " + uName + " 8 * :" + uName);
			outputStream.Flush();
		}
		public void joinRoom(string channel) {
			this.channel = channel;
			outputStream.WriteLine("JOIN #" + channel);
			outputStream.Flush();
		}
		public void sendIrcMessage(string message) {
			outputStream.WriteLine(message);
			outputStream.Flush();
		}
		public void sendChatMessage(string message) {
			sendIrcMessage(":"+userName+"!"+userName+"@"+userName+"tmi.twitch.tv PRIVMSG #"+channel+" :"+message);
		}
		public string readMessage(){
			string message = inputStream.ReadLine();
			Console.WriteLine(message);
			return message;
		}
	}
}
