using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBot {
	class Program {
		static void Main(string[] args) {
			//Username is your username.
			//password from www.twitchapps.com/tmi/
			//include the "oauth:" portion
			IrcClient irc = new IrcClient("irc.twitch.tv", 6667, "<USERNAME GOE HERE>", "<OAUTH PASSWORD HERE>");
			irc.joinRoom("trumpsc");//ENTER ROOM NAME HERE
			while (true) {
				string message = irc.readMessage();
				if (message == null) {
					irc.sendChatMessage("NO MESSAGES YET.");
					Console.WriteLine("NO MESSAGES YET.");
				}
				else
					Console.WriteLine(message);
					if (message.Contains("!hello"))
						irc.sendChatMessage("Yo yo");
			}
		}
	}
}
